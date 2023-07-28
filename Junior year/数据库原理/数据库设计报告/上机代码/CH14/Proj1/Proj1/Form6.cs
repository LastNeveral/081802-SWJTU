using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
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
            dgv1.DataSource = mydataset.Tables["Product"];
            dgv1.GridColor = Color.RoyalBlue;
            dgv1.ScrollBars = ScrollBars.Vertical;
            dgv1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv1.ReadOnly = true;		//设置为只读的
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Blue;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.Tomato;
            dgv1.Columns[0].Width = 90;
            dgv1.Columns[1].Width = 100;
            dgv1.Columns[2].Width = 80;
            dgv1.Columns[3].Width = 80;
            dgv1.Columns[4].Width = 70;
            dgv1.Columns[5].Width = 90;
            label1.Text = "";
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < dgv1.RowCount - 1)
                    label1.Text = "选择的商品编号为:" +
                        dgv1.Rows[e.RowIndex].Cells[0].Value;
            }
            catch (Exception ex)
            { 
                MessageBox.Show("需选中一个商品记录", "信息提示");
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
