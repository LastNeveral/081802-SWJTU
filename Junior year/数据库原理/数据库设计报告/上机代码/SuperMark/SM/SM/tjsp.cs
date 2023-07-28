using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class tjsp : Form
    {
        public tjsp()
        {
            InitializeComponent();
        }

        private void tjsp_Load(object sender, EventArgs e)
        {
            sptextBox.Text = "";
            textBox1.Text = DateTime.Now.ToString("d");
            textBox2.Text = DateTime.Now.ToString("d");
            sumlabel.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sptextBox.Text!="" && textBox1.Text != "" && textBox2.Text != "")
            {
                string rq1 = textBox1.Text.ToString();
                string rq2 = textBox2.Text.ToString();
                CommDB mydb = new CommDB();
                string mystr;
                mystr = "SELECT 日期,SUM(数量) AS 数量,SUM(金额) AS 金额"
                    + " FROM Sale "
                    + "WHERE 商品编号='" + sptextBox.Text.Trim() + "' AND "
                    + " Sale.日期 >='" + rq1 + "' AND Sale.日期<='" + rq2 + "' "
                    + "GROUP BY 日期 ORDER BY 日期";
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
                    mystr = "SELECT SUM(数量) FROM Sale " 
                        + " WHERE 商品编号='" + sptextBox.Text.Trim() 
                        + "' AND 日期 >='" + rq1 + "' AND 日期<='" + rq2 + "' ";
                    sumsl = mydb.ExecuteAggregateQuery(mystr);
                    mystr = "SELECT SUM(金额) FROM Sale "
                        + " WHERE 商品编号='" + sptextBox.Text.Trim()
                        + "' AND 日期 >='" + rq1 + "' AND 日期<='" + rq2 + "' ";
                    sumjr = mydb.ExecuteAggregateQuery(mystr);
                }
                else
                {
                    sumsl = "0"; sumjr = "0";
                }
                sumlabel.Text = "总件数:" + sumsl.Trim() + "，总金额:" + sumjr.Trim() + "元";
            }
            else
                MessageBox.Show("请输入正确的商品编号和日期", "操作提示");
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
