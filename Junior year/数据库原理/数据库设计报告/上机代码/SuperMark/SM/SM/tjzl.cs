using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class tjzl : Form
    {
        public tjzl()
        {
            InitializeComponent();
        }

        private void tjzl_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString("d");
            textBox2.Text = DateTime.Now.ToString("d");
            sumlabel.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string rq1 = textBox1.Text.ToString();
                string rq2 = textBox2.Text.ToString();
                CommDB mydb = new CommDB();
                string mystr;
                mystr = "SELECT Product.子类,SUM(Sale.数量) AS 数量,"
                    + "SUM(Sale.金额) AS 金额 FROM Sale,Product "
                    + "WHERE Product.商品编号=Sale.商品编号 AND "
                    + " Sale.日期 >='" + rq1 + "' AND Sale.日期<='" + rq2 + "' "
                    + "GROUP BY Product.子类";
                DataSet mydataset = mydb.ExecuteQuery(mystr, "Sale");
                dataGridView1.DataSource = mydataset.Tables["Sale"];
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.MultiSelect = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                string sumsl, sumjr;
                if (dataGridView1.Rows.Count > 0)
                {
                    mystr = "SELECT SUM(数量) FROM Sale WHERE Sale.日期 >='"
                        + rq1 + "' AND Sale.日期<='" + rq2 + "' ";
                    sumsl = mydb.ExecuteAggregateQuery(mystr);
                    mystr = "SELECT SUM(金额) FROM Sale WHERE Sale.日期 >='"
                       + rq1 + "' AND Sale.日期<='" + rq2 + "' ";
                    sumjr = mydb.ExecuteAggregateQuery(mystr);
                }
                else
                {
                    sumsl = "0"; sumjr = "0";
                }
                sumlabel.Text = "总件数:" + sumsl.Trim() + "，总金额:" + sumjr.Trim() + "元";
            }
            else
                MessageBox.Show("请输入正确的日期", "操作提示");
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
