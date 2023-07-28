using System;
using System.Windows.Forms;

namespace SM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CommDB mydb = new CommDB();
            string mystr;
            mystr = "SELECT * FROM SUser WHERE "
                + "用户名='" + textBox1.Text.Trim() 
                + "' AND 密码='" + textBox2.Text.Trim() + "'";
            int i = mydb.Rownum(mystr);
            if (i == 0)
            {
                MessageBox.Show("本次登录失败！", "操作提示");
                return;
            }
            else
            {
                mystr = "SELECT 级别 FROM SUser WHERE "
                    + "用户名='" + textBox1.Text.Trim()
                    + "' AND 密码='" + textBox2.Text.Trim() + "'";
                TempData.userlevel = mydb.Returnafield(mystr);
                Form myform = new Main();
                myform.ShowDialog();
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
