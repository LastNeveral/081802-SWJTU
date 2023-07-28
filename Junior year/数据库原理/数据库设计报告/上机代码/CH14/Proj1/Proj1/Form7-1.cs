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
    public partial class Form7_1 : Form
    {
        DataView mydv = new DataView();
        public Form7_1()
        {
            InitializeComponent();
        }

        private void Form7_1_Load(object sender, EventArgs e)
        {
            bind();
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 100;
        }
        private void bind()     //绑定数据
        {
            string mystr,mysql;
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
            mydv = mydataset.Tables["Product"].DefaultView; //获得DataView对象mydv
            mydv.RowFilter = TempData.condstr;              //过滤DataView中的记录
            dataGridView1.DataSource = mydv;
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
