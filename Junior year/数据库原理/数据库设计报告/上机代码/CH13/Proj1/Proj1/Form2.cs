using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mystr, mysql;
            int num;
            SqlConnection myconn = new SqlConnection();
            SqlCommand mycmd = new SqlCommand();
            mystr = System.Configuration.ConfigurationManager.
                    ConnectionStrings["myconnstring"].ToString();
            myconn.ConnectionString = mystr;
            myconn.Open();
            mysql = "SELECT COUNT(*) FROM Product WHERE 分类='" + textBox1.Text.Trim() + "'";
            mycmd.CommandText = mysql;
            mycmd.Connection = myconn;
            num = int.Parse(mycmd.ExecuteScalar().ToString());
            if (num == 0)
                label2.Text = "你输入的分类不存在";
            else
                label2.Text = textBox1.Text.Trim() + "分类的商品数为" + num.ToString();
            myconn.Close();
        }
    }
}
