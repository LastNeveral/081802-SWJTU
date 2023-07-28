using System;
using System.Data;
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

        private void Form3_Load(object sender, EventArgs e)
        {
            string mystr, mysql;
            SqlConnection myconn = new SqlConnection();
            mystr = System.Configuration.ConfigurationManager.
                ConnectionStrings["myconnstring"].ToString();
            myconn.ConnectionString = mystr;
            myconn.Open();
            mysql = "SELECT DISTINCT 分类 FROM Product";
            SqlDataAdapter myda = new SqlDataAdapter(mysql, myconn);
            DataSet mydataset = new DataSet();
            myda.Fill(mydataset, "Product");
            myconn.Close();
            comboBox1.DataSource = mydataset;
            comboBox1.DisplayMember = "Product.分类";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                string mystr, mysql;
                SqlConnection myconn = new SqlConnection();
                mystr = System.Configuration.ConfigurationManager.
                    ConnectionStrings["myconnstring"].ToString();
                myconn.ConnectionString = mystr;
                myconn.Open();
                mysql = "SELECT SUM(Sale.数量) AS 数量,SUM(Sale.金额) AS 金额";
                mysql += " FROM Product,Sale";
                mysql += " WHERE Product.商品编号=Sale.商品编号";
                mysql += " AND 分类='" + comboBox1.Text + "'";
                SqlDataAdapter myda = new SqlDataAdapter(mysql, myconn);
                DataSet mydataset = new DataSet();
                myda.Fill(mydataset, "Product");
                myconn.Close();
                label2.Text = comboBox1.Text.Trim()  + "分类商品\n  销售总数量为" + 
                    mydataset.Tables[0].Rows[0][0].ToString();
                label2.Text += "\n  销售总金额为" + mydataset.Tables[0].Rows[0][1].ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
