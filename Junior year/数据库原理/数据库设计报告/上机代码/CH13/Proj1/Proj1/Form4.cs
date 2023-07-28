using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mystr, mysql;
            SqlConnection myconn = new SqlConnection();
            SqlCommand mycmd = new SqlCommand();
            mystr = System.Configuration.ConfigurationManager.
                ConnectionStrings["myconnstring"].ToString();
            myconn.ConnectionString = mystr;
            myconn.Open();
            mysql = "SELECT AVG(单价) FROM Product WHERE 分类=@dj";
            mycmd.CommandText = mysql;
            mycmd.Connection = myconn;
            mycmd.Parameters.Add("@dj", System.Data.SqlDbType.VarChar, 10).Value
                = textBox1.Text;
            try
            {
                float avg = float.Parse(mycmd.ExecuteScalar().ToString());
                label2.Text = textBox1.Text.Trim() + "分类商品的平均单价为" + avg.ToString();
            }
            catch (Exception ex)
            {
                label2.Text = "提示：输入的分类不存在";
            }
            myconn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
