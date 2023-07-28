using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class querygkgw : Form
    {
        public querygkgw()
        {
            InitializeComponent();
        }
        private void querygkgw_Load(object sender, EventArgs e)
        {
            sumlabel.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                CommDB mydb = new CommDB();
                string mystr;
                mystr = "SELECT * FROM Sale WHERE 顾客编号='"
                    + textBox1.Text.Trim()
                    + "' AND DATEDIFF(DAY,日期,'" + DateTime.Now + "') <=7";
                DataSet mydataset = mydb.ExecuteQuery(mystr, "Sale");
                dataGridView1.DataSource = mydataset.Tables["Sale"];
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.MultiSelect = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 70;
                dataGridView1.Columns[5].Width = 90;
                string sumsl, sumjr;
                if (dataGridView1.Rows.Count > 0)
                {
                    mystr = "SELECT SUM(数量) FROM Sale WHERE 顾客编号='"
                        + textBox1.Text.Trim() + "'";
                    sumsl = mydb.ExecuteAggregateQuery(mystr);
                    mystr = "SELECT SUM(金额) FROM Sale WHERE 顾客编号='"
                        + textBox1.Text.Trim() + "'";
                    sumjr = mydb.ExecuteAggregateQuery(mystr);
                }
                else
                {
                    sumsl = "0"; sumjr = "0";
                }
                sumlabel.Text = "总件数:" + sumsl.Trim() + "，总金额:" + sumjr.Trim();
            }
            else
                MessageBox.Show("请输入正确的顾客编号", "操作提示");
        }
        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
