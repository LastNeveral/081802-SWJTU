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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
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
            DataView mydv = new DataView(mydataset.Tables["Product"]);
            mydv.Sort = "单价 ASC,库存数量 DESC";
            listBox1.Items.Add("商品名称\t\t分类\t单价\t库存数量");
            listBox1.Items.Add("=======================================");
            for (int i = 0; i < mydv.Count; i++)
            {
                listBox1.Items.Add(String.Format("{0}\t{1}\t{2}\t{3}",
                    mydv[i]["商品名称"], mydv[i]["分类"], mydv[i]["单价"], mydv[i]["库存数量"]));
            }

        }
    }
}
