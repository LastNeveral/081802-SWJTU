using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class addsp : Form
    {
        CommDB mydb = new CommDB();
        public addsp()
        {
            InitializeComponent();
        }
        private void addsp_Load(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 分类 FROM Prodsort";
            mydataset = mydb.ExecuteQuery(mystr, "Prodsort");
            comboBox1.DataSource = mydataset.Tables["Prodsort"];
            comboBox1.DisplayMember = "分类";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet mydataset;
            string mystr = "SELECT distinct 子类 FROM Prodsort WHERE 分类='"
                + comboBox1.Text.Trim() + "'";
            mydataset = mydb.ExecuteQuery(mystr, "Prodsort");
            comboBox2.DataSource = mydataset.Tables["Prodsort"];
            comboBox2.DisplayMember = "子类";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == ""
                || textBox3.Text == "" || textBox4.Text == ""
                || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("所有数据项必须输入", "操作提示");
                return;
            }
            string mystr = "SELECT * FROM Product WHERE 商品编号='" + textBox1.Text.Trim() + "'";
            int i = mydb.Rownum(mystr);
            if (i != 0)
            {
                MessageBox.Show("输入的商品编号已存在", "操作提示");
                return;
            }
            try
            {
                double dj = double.Parse(textBox3.Text.Trim());
                int sl = int.Parse(textBox4.Text.Trim());
                mystr = "INSERT INTO Product(商品编号,分类,子类," +
                    "商品名称,单价,库存数量)  VALUES('"
                    + textBox1.Text.Trim() + "','"
                    + comboBox1.Text.Trim() + "','"
                    + comboBox2.Text.Trim() + "','"
                    + textBox2.Text.Trim() + "',"
                    + dj.ToString() + ","
                    + sl.ToString() + ")";
                mydb.ExecuteNonQuery(mystr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入的商品数据有错误：" + ex.Message);
                return;
            }
            button2_Click(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";  textBox2.Text = "";
            textBox3.Text = "";  textBox4.Text = "";
            comboBox1.Text = ""; comboBox2.Text = "";
            textBox1.Focus();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
