using System;
using System.Data;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            string mystr, mysql;
            SqlConnection myconn = new SqlConnection();
            mystr = System.Configuration.ConfigurationManager.
                ConnectionStrings["myconnstring"].ToString();
            myconn.ConnectionString = mystr;
            myconn.Open();
            mysql = "SELECT * FROM Product";
            SqlDataAdapter myda = new SqlDataAdapter(mysql, myconn);
            DataSet mydataset = new DataSet();
            myda.Fill(mydataset, "Product");
            myconn.Close();
            Binding mybinding = new Binding("Text", mydataset, "Product.商品编号");
            textBox1.DataBindings.Add(mybinding);
            //上两个语句等同：textBox1.DataBindings.Add("Text", mydataset, "Product.商品编号");
            textBox2.DataBindings.Add("Text", mydataset, "Product.商品名称");
            textBox3.DataBindings.Add("Text", mydataset, "Product.分类");
            textBox4.DataBindings.Add("Text", mydataset, "Product.子类");
            textBox5.DataBindings.Add("Text", mydataset, "Product.单价");
            textBox6.DataBindings.Add("Text", mydataset, "Product.库存数量");
        }
    }
}
