using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mystr;
            SqlConnection myconn = new SqlConnection();
            //mystr = "Data Source=LCB-PC;Initial Catalog=SMK;Integrated Security=True";
            mystr = System.Configuration.ConfigurationManager.ConnectionStrings["myconnstring"].ToString();
            //mystr = @"Server=localhost\SQLEXPRESS;Database=SMK;Trusted_Connection=True;";
            myconn.ConnectionString = mystr;
            myconn.Open();
            if (myconn.State == System.Data.ConnectionState.Open)
                label1.Text = "成功连接到SQL Server数据库";
            else
                label1.Text = "不能连接到SQL Server数据库";
            myconn.Close();
        }
    }
}
