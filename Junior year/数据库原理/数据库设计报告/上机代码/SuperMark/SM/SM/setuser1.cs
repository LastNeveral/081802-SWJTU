using System;
using System.Windows.Forms;

namespace SM
{
    public partial class setuser1 : Form
    {
        string userno,userpass,userlevel;
        public setuser1()
        {
            InitializeComponent();
        }
        public setuser1(string no,string pass,string level)
        {
            InitializeComponent();
            userno = no;
            userpass = pass;
            userlevel = level;
        }

        private void setuser1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("操作员");
            comboBox1.Items.Add("管理员");
            if (TempData.tag == 1)      //添加
            {
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                textBox1.Focus();
            }
            else if (TempData.tag == 2)    //修改
            {
                textBox1.Text = userno;
                textBox1.Enabled = false;
                textBox2.Text = userpass;
                comboBox1.Text = userlevel;
                textBox1.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string mystr;
            CommDB mydb = new CommDB();
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                if (TempData.tag == 1)           //添加
                {
                    mystr = "SELECT * FROM SUser WHERE 用户名='" + textBox1.Text.Trim() + "'";
                    int i = mydb.Rownum(mystr);
                    if (i == 1)
                    {
                        MessageBox.Show("输入的用户名重复，重新输入","操作提示");
                        return;
                    }
                    mystr = "INSERT INTO SUser(用户名,密码,级别) VALUES('"
                        + textBox1.Text.Trim() + "','"
                        + textBox2.Text.Trim() + "','"
                        + comboBox1.Text.Trim() + "')";
                    mydb.ExecuteNonQuery(mystr);
                }
                else if (TempData.tag == 2)     //修改
                {
                    mystr = "UPDATE SUser SET 密码='"
                        + textBox2.Text.Trim() + "',级别='"
                        + comboBox1.Text.Trim() + "' WHERE 用户名='"
                        + textBox1.Text.Trim() + "'";
                    mydb.ExecuteNonQuery(mystr);
                }
               this.Close();
            }
            else
                MessageBox.Show("必须输入所有数据项","操作提示");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
