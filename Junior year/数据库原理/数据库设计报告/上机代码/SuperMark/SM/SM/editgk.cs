using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class editgk : Form
    {
        CommDB mydb = new CommDB();
        public editgk()
        {
            InitializeComponent();
        }

        private void editgk_Load(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 省份 FROM Area";
            mydataset = mydb.ExecuteQuery(mystr, "Area");
            DataRow nrow = mydataset.Tables["Area"].NewRow();	//插入一个空行
            nrow["省份"] = "";
            mydataset.Tables["Area"].Rows.InsertAt(nrow, 0);
            comboBox1.DataSource = mydataset.Tables["Area"];
            comboBox1.DisplayMember = "省份";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 城市 FROM Area WHERE 省份='"
                + comboBox1.Text.Trim() + "'";
            mydataset = mydb.ExecuteQuery(mystr, "Area");
            DataRow nrow = mydataset.Tables["Area"].NewRow();	//插入一个空行
            nrow["城市"] = "";
            mydataset.Tables["Area"].Rows.InsertAt(nrow, 0);
            comboBox2.DataSource = mydataset.Tables["Area"];
            comboBox2.DisplayMember = "城市";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 县 FROM Area WHERE 城市='"
                + comboBox2.Text.Trim() + "'";
            mydataset = mydb.ExecuteQuery(mystr, "Area");
            DataRow nrow = mydataset.Tables["Area"].NewRow();	//插入一个空行
            nrow["县"] = "";
            mydataset.Tables["Area"].Rows.InsertAt(nrow, 0);
            comboBox3.DataSource = mydataset.Tables["Area"];
            comboBox3.DisplayMember = "县";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string condstr = "";
            if (textBox1.Text != "")
                condstr = "顾客编号 Like '%" + textBox1.Text.Trim() + "%'";
            if (comboBox1.Text != "")
            {
                if (condstr == "")
                    condstr = "姓名 Like'%" + textBox2.Text.Trim() + "%'";
                else
                    condstr += " AND 姓名 Like'%" + textBox2.Text.Trim() + "%'";
            }
            string xb;
            if (radioButton1.Checked)
                xb = "男";
            else if (radioButton2.Checked)
                xb = "女";
            else
                xb = "";
            if (xb != "")
            {
                if (condstr == "")
                    condstr = "性别='" + xb + "'";
                else
                    condstr = " AND 性别='" + xb + "'";
            }
            if (comboBox1.Text != "")
            {
                if (condstr == "")
                    condstr = "省份='" + comboBox1.Text.Trim() + "'";
                else
                    condstr += " AND 省份='" + comboBox1.Text.Trim() + "'";
            }
            if (comboBox2.Text != "")
            {
                if (condstr == "")
                    condstr = "城市='" + comboBox2.Text.Trim() + "'";
                else
                    condstr += " AND 城市='" + comboBox2.Text.Trim() + "'";
            }
            if (comboBox3.Text != "")
            {
                if (condstr == "")
                    condstr = "县='" + comboBox3.Text.Trim() + "'";
                else
                    condstr += " AND 县='" + comboBox3.Text.Trim() + "'";
            }
            if (condstr != "")
                TempData.sql = "SELECT * FROM Customer WHERE " + condstr;
            else
                TempData.sql = "";
            editgk1 myform = new editgk1();
            myform.ShowDialog();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.Text = ""; comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Focus();
        }

        private void cosebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
