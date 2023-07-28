using System;
using System.Windows.Forms;

namespace Proj1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("");
            comboBox1.Items.Add("计算机");
            comboBox1.Items.Add("通信");
            comboBox1.Items.Add("家电");
            comboBox2.Items.Add("");
            comboBox2.Items.Add("电视机");
            comboBox2.Items.Add("电冰箱");
            comboBox2.Items.Add("手机");
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            string condstr = "";
            if (textBox1.Text != "")
                condstr = "商品编号 Like '%" + textBox1.Text.Trim() + "%'";
            if (comboBox1.Text != "")
            {
                if (condstr == "")
                    condstr = "分类='" + comboBox1.Text.Trim() + "'";
                else
                    condstr += " AND 分类='" + comboBox1.Text.Trim() + "'";
            }
            if (comboBox2.Text != "")
            {
                if (condstr == "")
                    condstr = "子类='" + comboBox2.Text.Trim() + "'";
                else
                    condstr += " AND 子类='" + comboBox2.Text.Trim() + "'";
            }
            if (textBox2.Text != "")
            {
                if (textBox2.Text != "")
                    condstr = "商品名称 Like '%" + textBox2.Text.Trim() + "%'";
                else
                    condstr += " AND 商品名称 Like '%" + textBox2.Text.Trim() + "%'";
            }
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                double dj1, dj2;
                try
                {
                    dj1 = double.Parse(textBox3.Text.Trim());
                    dj2 = double.Parse(textBox4.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("单价区间输入有错误：" + ex.Message);
                    return;
                }
                if (dj1 > dj2)
                {
                    MessageBox.Show("单价区间输入有错误", "操作提示");
                    return;
                }
                if (condstr == "")
                    condstr = "单价>=" + dj1.ToString() + " AND 单价<=" + dj2.ToString();
                else
                    condstr += " AND (单价>=" + dj1.ToString() + " AND 单价<=" + dj2.ToString() + ")";
            }
            else if (textBox3.Text != "" || textBox4.Text != "")
            {
                MessageBox.Show("单价区间上下界输入有错误", "操作提示");
                return;
            }
            TempData.condstr = condstr;
            Form myform = new Form7_1();
            myform.ShowDialog();     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = "";
            textBox3.Text = ""; textBox4.Text = "";
            comboBox1.Text = ""; comboBox2.Text = "";
            textBox1.Focus();
        }

        private void cosebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
