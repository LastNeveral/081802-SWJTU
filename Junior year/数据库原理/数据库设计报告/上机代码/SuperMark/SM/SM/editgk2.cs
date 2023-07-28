using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class editgk2 : Form
    {
        CommDB mydb = new CommDB();
        string gkno,gkxm,gkxb;
        string gksf,gkcs,gkxc;
        public editgk2(string gkno1,string gkxm1,string gkxb1,string gksf1,string gkcs1,string gkxc1)
        {
            InitializeComponent();
            gkno = gkno1; gkxm = gkxm1;
            gkxb = gkxb1; gksf = gksf1;
            gkcs = gkcs1; gkxc = gkxc1;
        }

        private void editgk2_Load(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 省份 FROM Area";
            mydataset = mydb.ExecuteQuery(mystr, "Area");
            comboBox1.DataSource = mydataset.Tables["Area"];
            comboBox1.DisplayMember = "省份";
            textBox1.Text = gkno;;
            textBox1.Enabled = false;
            textBox2.Text = gkxm;
            if (gkxb == "男")
                radioButton1.Checked = true;
            else if (gkxb == "女")
                radioButton2.Checked = true;
            comboBox1.Text = gksf;
            comboBox2.Text = gkcs;
            comboBox3.Text = gkxc;
            textBox2.Focus();
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
            string mystr;
            if (textBox1.Text == "" || textBox2.Text == "" || 
                comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text=="")
            {
                MessageBox.Show("所有数据项必须输入", "操作提示");
                return;
            }
            string xb;
            if (radioButton1.Checked)
                xb = "男";
            else if (radioButton2.Checked)
                xb = "女";
            else
                xb = "";
            mystr = "UPDATE Customer SET 姓名='"
                + textBox1.Text.Trim() + "',性别='"
                + xb + "',省份='" + comboBox1.Text.Trim()
                + "',城市='" + comboBox2.Text.Trim()
                + "',县='" + comboBox3.Text.Trim()
                + "' WHERE 顾客编号='" + gkno + "'";
            mydb.ExecuteNonQuery(mystr);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
