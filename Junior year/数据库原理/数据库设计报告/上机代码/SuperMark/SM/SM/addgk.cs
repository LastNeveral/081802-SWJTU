using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class addgk : Form
    {
        CommDB mydb = new CommDB();
        public addgk()
        {
            InitializeComponent();
        }

        private void addgk_Load(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 省份 FROM Area";
            mydataset = mydb.ExecuteQuery(mystr, "Area");
            comboBox1.DataSource = mydataset.Tables["Area"];
            comboBox1.DisplayMember = "省份";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 城市 FROM Area WHERE 省份='"
                + comboBox1.Text.Trim() + "'";
            mydataset = mydb.ExecuteQuery(mystr, "Area");
            comboBox2.DataSource = mydataset.Tables["Area"];
            comboBox2.DisplayMember = "城市";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 县 FROM Area WHERE 城市='"
                + comboBox2.Text.Trim() + "'";
            mydataset = mydb.ExecuteQuery(mystr, "Area");
            comboBox3.DataSource = mydataset.Tables["Area"];
            comboBox3.DisplayMember = "县";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == ""
                || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text=="")
            {
                MessageBox.Show("所有数据项必须输入", "操作提示");
                return;
            }
            string mystr = "SELECT * FROM Customer WHERE 顾客编号='" + textBox1.Text.Trim() + "'";
            int i = mydb.Rownum(mystr);
            if (i != 0)
            {
                MessageBox.Show("输入的顾客编号已存在","操作提示");
                return;
            }
            string xb;
            if (radioButton1.Checked)
                xb="男";
            else if (radioButton2.Checked)
                xb="女";
            else
                xb="";
            mystr = "INSERT INTO Customer(顾客编号,姓名,性别," 
                + "省份,城市,县)  VALUES('"
                + textBox1.Text.Trim() + "','"
                + textBox2.Text.Trim() + "','"
                + xb + "','"
                + comboBox1.Text.Trim() + "','"
                + comboBox2.Text.Trim() + "','"
                + comboBox3.Text.Trim() + "')";
            mydb.ExecuteNonQuery(mystr);
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = "";
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            comboBox1.Text = ""; comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Focus();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
