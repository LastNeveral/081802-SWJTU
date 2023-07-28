using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mystr, mysql;
            SqlConnection myconn = new SqlConnection();
            mystr = System.Configuration.ConfigurationManager.
                ConnectionStrings["myconnstring"].ToString();
            myconn.ConnectionString = mystr;
            myconn.Open();
            mysql = "SELECT Product.分类,Product.子类,";
            mysql += " SUM(Sale.数量) AS 总数量,SUM(Sale.金额) AS 总金额";
            mysql += " FROM Product,Customer,Sale";
            mysql += " WHERE Product.商品编号=Sale.商品编号 ";
            mysql += " AND Customer.顾客编号=Sale.顾客编号";
            mysql += " AND Customer.省份='" + textBox1.Text.Trim() + "'";
            mysql += " GROUP  BY Product.分类,Product.子类";
            mysql += " ORDER BY SUM(Sale.数量) DESC";

            SqlDataAdapter myda = new SqlDataAdapter(mysql, myconn);
            myconn.Close();
            DataSet mydataset = new DataSet();
            myda.Fill(mydataset, "mydata");
            ListViewItem itemx = new ListViewItem();
            listView1.View = View.Details;
            listView1.Columns.Add("分类", 80, HorizontalAlignment.Center); //添加4个列
            listView1.Columns.Add("子类", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("总数量", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("总金额", 80, HorizontalAlignment.Center);
            foreach (DataRow dr in mydataset.Tables[0].Rows)
            {
                itemx = listView1.Items.Add(dr[0].ToString());	//添加1个ListItem对象
                itemx.SubItems.Add(dr[1].ToString());			//添加3个子项
                itemx.SubItems.Add(dr[2].ToString());
                itemx.SubItems.Add(dr[3].ToString());
            }

        }
    }
}
