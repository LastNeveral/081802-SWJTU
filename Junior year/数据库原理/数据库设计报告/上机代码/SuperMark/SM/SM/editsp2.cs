using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class editsp2 : Form
    {
        CommDB mydb = new CommDB();
        string spno, spname;
        string spfl, spzl;
        string spdj, spsl;
        public editsp2(string spno1, string spname1, string spfl1, string spzl1, string spdj1, string spsl1)
        {
            InitializeComponent();
            spno = spno1; spfl = spfl1; spzl = spzl1;
            spname = spname1; spdj = spdj1; spsl = spsl1;
        }

        private void editsp2_Load(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 分类 FROM Prodsort";
            mydataset = mydb.ExecuteQuery(mystr, "Prodsort");
            comboBox1.DataSource = mydataset.Tables["Prodsort"];
            comboBox1.DisplayMember = "分类";
            textBox1.Text = spno;
            textBox1.Enabled = false;
            comboBox1.Text = spfl;
            comboBox2.Text = spzl;
            textBox2.Text = spname;
            textBox3.Text = spdj;
            textBox4.Text = spsl;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 子类 FROM Prodsort WHERE 分类='"
                + comboBox1.Text.Trim() + "'";
            mydataset = mydb.ExecuteQuery(mystr, "Prodsort");
            comboBox2.DataSource = mydataset.Tables["Prodsort"];
            comboBox2.DisplayMember = "子类";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mystr;
            if (textBox1.Text == "" || textBox2.Text == ""
               || textBox3.Text == "" || textBox4.Text == ""
               || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("所有数据项必须输入");
                return;
            }           
            try
            {
                double dj = double.Parse(textBox3.Text.Trim());
                int sl = int.Parse(textBox4.Text.Trim());
                mystr = "UPDATE Product SET 分类='"
                    + comboBox1.Text.Trim() + "',子类='"
                    + comboBox2.Text.Trim() + "',商品名称='"
                    + textBox2.Text.Trim() + "',单价="
                    + dj.ToString() + ",库存数量="
                    + sl.ToString() + " WHERE 商品编号='"
                    + spno + "'";
                    mydb.ExecuteNonQuery(mystr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改的商品数据有错误：" + ex.Message);
                return;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
