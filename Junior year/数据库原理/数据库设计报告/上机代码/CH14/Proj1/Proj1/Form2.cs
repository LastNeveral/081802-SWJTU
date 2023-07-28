using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj1
{
    public partial class Form2 : Form
    {
        BindingSource mybs;	//类字段
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
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
            mybs = new BindingSource(mydataset, "Product");
            //用数据源mydataset和表Product创建新实例mybs
            textBox1.DataBindings.Add("Text", mybs, "商品编号");
            textBox2.DataBindings.Add("Text", mybs, "商品名称");
            textBox3.DataBindings.Add("Text", mybs, "分类");
            textBox4.DataBindings.Add("Text", mybs, "子类");
            textBox5.DataBindings.Add("Text", mybs, "单价");
            textBox6.DataBindings.Add("Text", mybs, "库存数量");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mybs.Position != 0)
                mybs.MoveFirst();			//移到第一个记录
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mybs.Position != 0)
                mybs.MovePrevious();		//移到上一个记录
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mybs.Position != mybs.Count - 1)
                mybs.MoveNext();			//移到下一个记录
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mybs.Position != mybs.Count - 1)
                mybs.MoveLast();			//移到最后一个记录
        }
    }
}
