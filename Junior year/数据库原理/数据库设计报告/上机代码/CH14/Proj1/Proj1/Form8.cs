using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj1
{
    public partial class Form8 : Form
    {
        SqlDataAdapter myda;
        DataSet mydataset = new DataSet();
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string mystr, mysql;
            SqlConnection myconn = new SqlConnection();
            mystr = System.Configuration.ConfigurationManager.
                ConnectionStrings["myconnstring"].ToString();
            myconn.ConnectionString = mystr;
            myconn.Open();
            mysql = "SELECT * FROM Product";
            myda = new SqlDataAdapter(mysql, myconn);            
            myda.Fill(mydataset, "Product");
            myconn.Close();
            dgv1.DataSource = mydataset.Tables["Product"];
            dgv1.GridColor = Color.RoyalBlue;
            dgv1.ScrollBars = ScrollBars.Vertical;
            dgv1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Blue;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.Tomato;
            dgv1.Columns[0].Width = 100;
            dgv1.Columns[1].Width = 100;
            dgv1.Columns[2].Width = 80;
            dgv1.Columns[3].Width = 80;
            dgv1.Columns[4].Width = 70;
            dgv1.Columns[5].Width = 100;
            dgv1.AllowUserToAddRows = true;     //允许添加记录
            dgv1.AllowUserToDeleteRows = false; //不允许删除记录
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder mycmdbuilder = new SqlCommandBuilder(myda);
			//获取对应的修改命令
			if (mydataset.HasChanges())					//如果有数据改动
			{
                try
				{
                    myda.Update(mydataset, "Product");	//更新数据源  
                }
				catch(Exception ex)
				{
					MessageBox.Show("数据修改不正确，如商品编号重复等","信息提示");
				}
			}

        }
    }
}
