using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj1
{
    public partial class Form4 : Form
    {
        SqlDataAdapter myda;                    //5个窗体级字段
        DataSet mydataset = new DataSet();
        BindingSource mybs;
        SqlConnection myconn = new SqlConnection();
        string spno;        //商品编号
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {           
            string mystr, mysql;           
            mystr = System.Configuration.ConfigurationManager.
                ConnectionStrings["myconnstring"].ToString();
            myconn.ConnectionString = mystr;
            myconn.Open();
            mysql = "SELECT * FROM Product";
            myda = new SqlDataAdapter(mysql, myconn);
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
            bindingNavigator1.Dock = DockStyle.Bottom;
            bindingNavigator1.BindingSource = mybs;
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //保存
        {
            mybs.EndEdit();
            if (this.mydataset.HasChanges() == false)   //数据无变化，返回
                return;
            //添加记录用的SQL语句
            string insertsql = String.Format("INSERT INTO Product(商品编号,"
                + "商品名称,分类,子类,单价,库存数量) VALUES('{0}','{1}','{2}','{3}',{4},{5})",
                textBox1.Text.Trim(), textBox2.Text.Trim(), 
                textBox3.Text.Trim(), textBox4.Text.Trim(), 
                textBox5.Text.Trim(), textBox6.Text.Trim());
            SqlCommand insertcmd = new SqlCommand(insertsql, myconn);
            myda.InsertCommand = insertcmd;
            string deletesql = String.Format("DELETE Product WHERE 商品编号='{0}'",spno);
            SqlCommand deletecmd = new SqlCommand(deletesql, myconn);
            myda.DeleteCommand = deletecmd;
            myda.Update(mydataset,"Product");
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //取消
        {
            mybs.CancelEdit();
        }
        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            //删除之前，先获取当前商品编号
            spno = textBox1.Text.Trim();
        }       
    }
}
