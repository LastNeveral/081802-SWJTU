using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class editsp : Form
    {
        CommDB mydb = new CommDB();
        public editsp()
        {
            InitializeComponent();
        }

        private void editsp_Load(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 分类 FROM Prodsort";
            mydataset = mydb.ExecuteQuery(mystr, "Prodsort");
            DataRow nrow = mydataset.Tables["Prodsort"].NewRow();	//插入一个空行
            nrow["分类"] = "";
            mydataset.Tables["Prodsort"].Rows.InsertAt(nrow, 0);
            comboBox1.DataSource = mydataset.Tables["Prodsort"];
            comboBox1.DisplayMember = "分类";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            DataSet mydataset;
            string mystr = "SELECT distinct 子类 FROM Prodsort WHERE 分类='"
                + comboBox1.Text.Trim() + "'";
            mydataset = mydb.ExecuteQuery(mystr, "Prodsort");
            DataRow nrow = mydataset.Tables["Prodsort"].NewRow();	//插入一个空行
            nrow["子类"] = "";
            mydataset.Tables["Prodsort"].Rows.InsertAt(nrow, 0);
            comboBox2.DataSource = mydataset.Tables["Prodsort"];
            comboBox2.DisplayMember = "子类";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string condstr = "";
            if (textBox1.Text != "")
                condstr = "商品编号 Like '%" + textBox1.Text.Trim() + "%'";
            if (comboBox1.Text != "")
            {
                if (condstr == "")
                    condstr = "分类='" + comboBox1.Text.Trim() + "'";
                else
                    condstr += " AND 分类='" + comboBox1.Text.Trim() + "'";
            }
            if (comboBox2.Text != "")
            {
                if (condstr == "")
                    condstr = "子类='" + comboBox2.Text.Trim() + "'";
                else
                    condstr += " AND 子类='" + comboBox2.Text.Trim() + "'";
            }
            if (textBox2.Text != "")
            {
                if (textBox2.Text != "")
                    condstr = "商品名称 Like '%" + textBox2.Text.Trim() + "%'";
                else
                    condstr += " AND 商品名称 Like '%" + textBox2.Text.Trim() + "%'";
            }
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                double dj1, dj2;
                try
                {
                    dj1 = double.Parse(textBox3.Text.Trim());
                    dj2 = double.Parse(textBox4.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("单价区间输入有错误：" + ex.Message);
                    return;
                }
                if (dj1 > dj2)
                {
                    MessageBox.Show("单价区间输入有错误", "操作提示");
                    return;
                }
                if (condstr == "")
                    condstr = "单价>=" + dj1.ToString() + " AND 单价<=" + dj2.ToString();
                else
                    condstr += " AND (单价>=" + dj1.ToString() + " AND 单价<=" + dj2.ToString() + ")";
            }
            else if (textBox3.Text != "" || textBox4.Text != "")
            {
                MessageBox.Show("单价区间上下界输入有错误", "操作提示");
                return;
            }
            if (condstr != "")
                TempData.sql = "SELECT * FROM Product WHERE " + condstr;
            else
                TempData.sql = "";
            editsp1 myform = new editsp1();
            myform.ShowDialog();      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = "";
            textBox3.Text = ""; textBox4.Text = "";
            comboBox1.Text = ""; comboBox2.Text = "";
            textBox1.Focus();
        }

        private void cosebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
