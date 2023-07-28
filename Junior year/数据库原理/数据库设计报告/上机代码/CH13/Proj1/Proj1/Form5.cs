using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mystr;
            SqlConnection myconn = new SqlConnection();
            SqlCommand mycmd = new SqlCommand();
            mystr = System.Configuration.ConfigurationManager.
                ConnectionStrings["myconnstring"].ToString();
            myconn.ConnectionString = mystr;
            myconn.Open();
            mycmd.CommandType = System.Data.CommandType.StoredProcedure;
            mycmd.CommandText = "spavgfl";
            mycmd.Connection = myconn;
            SqlParameter myparm1 = new SqlParameter();
            myparm1.Direction = ParameterDirection.Input;
            myparm1.ParameterName = "@fl"; 
            myparm1.SqlDbType = SqlDbType.Char;
            myparm1.Size = 10; 
            myparm1.Value = textBox1.Text;
            mycmd.Parameters.Add(myparm1);
            SqlParameter myparm2 = new SqlParameter();
            myparm2.Direction = ParameterDirection.Output;
            myparm2.ParameterName = "@avg"; 
            myparm2.SqlDbType = SqlDbType.Float;
            myparm2.Size = 5; mycmd.Parameters.Add(myparm2);
            mycmd.ExecuteScalar();
            if (myparm2.Value.ToString() == "")
                label2.Text = "提示：输入的分类不存在";
            else
            {
                label2.Text = textBox1.Text.Trim() + "分类商品的平均单价为";
                label2.Text += myparm2.Value.ToString();
            }
            myconn.Close();
        }
    }
}
