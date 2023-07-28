using System;
using System.Data;
using System.Drawing;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            string mystr, mysql;
            SqlConnection myconn = new SqlConnection();
            mystr = System.Configuration.ConfigurationManager.
                ConnectionStrings["myconnstring"].ToString();
            myconn.ConnectionString = mystr;
            myconn.Open();
            SqlDataAdapter myda;
            DataSet mydataset = new DataSet();
            mysql = "SELECT DISTINCT 省份 FROM Customer";
            myda = new SqlDataAdapter(mysql, myconn);
            myda.Fill(mydataset, "Customer");
            myconn.Close();
            comboBox1.DataSource=mydataset.Tables["Customer"];
            comboBox1.DisplayMember = "省份";
            taglabel.Text = "";
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
            mysql += " AND Customer.省份='" + comboBox1.Text.Trim() + "'";
            mysql += " GROUP  BY Product.分类,Product.子类";
            mysql += " ORDER BY SUM(Sale.数量) DESC";
            SqlDataAdapter myda = new SqlDataAdapter(mysql, myconn);
            myconn.Close();
            DataSet mydataset = new DataSet();
            myda.Fill(mydataset, "mydata");
            dgv1.DataSource = mydataset.Tables["mydata"];
            dgv1.GridColor = Color.RoyalBlue;
            dgv1.ScrollBars = ScrollBars.Vertical;
            dgv1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Blue;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.Tomato;
            dgv1.Columns[0].Width = 100;
            dgv1.Columns[1].Width = 100;
            dgv1.Columns[2].Width = 100;
            dgv1.Columns[3].Width = 100;
            dgv1.ReadOnly = true;
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < dgv1.RowCount - 1)
                {
                    taglabel.Text = "商品分类为" + dgv1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                    taglabel.Text += "，子类为" + dgv1.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    taglabel.Text += "\n总销售数量为" + dgv1.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                    taglabel.Text += "，总销售金额为" + dgv1.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("需选中一个记录", "信息提示");
            }
        }
    }
}
