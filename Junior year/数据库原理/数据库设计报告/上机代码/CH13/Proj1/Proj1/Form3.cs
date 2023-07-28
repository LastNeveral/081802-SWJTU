using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj1
{
    public partial class Form3 : Form
    {
        public Form3()
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
            mysql = "INSERT INTO Product VALUES('3001','中信3001','通信','手机',1800,100)";
            mycmd.CommandText = mysql;
            mycmd.Connection = myconn;
            mycmd.ExecuteNonQuery();
            label1.Text = "(1)插入编号为3001的商品记录";
            mysql = "DELETE Product WHERE 商品编号='3001'";
            mycmd.CommandText = mysql;
            mycmd.Connection = myconn;
            mycmd.ExecuteNonQuery();
            label2.Text = "(2)删除编号为3001的商品记录";
            myconn.Close();
        }
    }
}
