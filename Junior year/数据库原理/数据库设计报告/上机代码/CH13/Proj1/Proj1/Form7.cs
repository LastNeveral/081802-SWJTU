using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Proj1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {         
            string mystr, mysql;
            SqlConnection myconn = new SqlConnection();
            mystr = System.Configuration.ConfigurationManager.
                ConnectionStrings["myconnstring"].ToString();
            myconn.ConnectionString = mystr;
            myconn.Open();
            mysql = "SELECT Sale.日期,Customer.姓名,Sale.商品编号,Sale.数量,Sale.金额";
            mysql += " FROM Customer,Sale";
            mysql += " WHERE Customer.顾客编号=Sale.顾客编号 ";
            mysql += "AND Customer.顾客编号='" + textBox1.Text.Trim() + "'";
            SqlDataAdapter myda = new SqlDataAdapter(mysql, myconn);
            myconn.Close();
            DataSet mydataset = new DataSet();
            myda.Fill(mydataset, "mydata");
            ListViewItem itemx = new ListViewItem();
            listView1.View = View.Details;
            //添加5个列
            listView1.Columns.Add("日期", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("姓名", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("商品编号", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("数量", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("金额", 50, HorizontalAlignment.Center);
            foreach (DataRow dr in mydataset.Tables[0].Rows)
            {
                itemx = listView1.Items.Add(dr[0].ToString());//添加1个ListItem对象
                itemx.SubItems.Add(dr[1].ToString());  //添加4个子项
                itemx.SubItems.Add(dr[2].ToString());
                itemx.SubItems.Add(dr[3].ToString());
                itemx.SubItems.Add(dr[4].ToString());
            }
        }
    }
}
