using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proj1
{
    public partial class Form6 : Form
    {
        public Form6()
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
            mysql = "SELECT Sale.日期,Customer.姓名,Sale.商品编号,Sale.数量,Sale.金额";
            mysql += " FROM Customer,Sale";
            mysql += " WHERE Customer.顾客编号=Sale.顾客编号 ";
            mysql += "AND Customer.顾客编号='" + textBox1.Text.Trim() + "'";
            mycmd.CommandText = mysql;
            mycmd.Connection = myconn;
            SqlDataReader myreader = mycmd.ExecuteReader();
            ListViewItem itemx = new ListViewItem();
            listView1.View = View.Details;
            //添加5个列
            listView1.Columns.Add("日期", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("姓名", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("商品编号", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("数量", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("金额", 50, HorizontalAlignment.Center);
            while (myreader.Read())		//循环读取信息
            {
                itemx = listView1.Items.Add(myreader["日期"].ToString());//添加1个ListItem对象
                itemx.SubItems.Add(myreader[1].ToString());  //添加4个子项
                itemx.SubItems.Add(myreader[2].ToString());
                itemx.SubItems.Add(myreader.GetInt32(3).ToString());
                itemx.SubItems.Add(myreader[4].ToString());
            }
        }
    }
}
