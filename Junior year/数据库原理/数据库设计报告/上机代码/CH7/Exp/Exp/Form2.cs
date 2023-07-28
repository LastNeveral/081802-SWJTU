using System;
using System.Windows.Forms;

namespace Exp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("汉族");
            comboBox1.Items.Add("回族");
            comboBox1.Items.Add("满族");
            comboBox1.Items.Add("其他");
            if (StudLib.tag == 1)           //添加记录情况
            {
                textBox1.Text = "";
                textBox2.Text = "";
                radioButton1.Checked = true;
                comboBox1.Text = "";
                textBox3.Text = "";
            }
            else if (StudLib.tag == 0)      //修改记录情况
            {
                textBox1.Text = StudLib.stlist[StudLib.current].xh.ToString();
                textBox1.ReadOnly = true;   //不能修改学号
                textBox2.Focus();
                textBox2.Text = StudLib.stlist[StudLib.current].xm;
                if (StudLib.stlist[StudLib.current].xb == "男")
                    radioButton1.Checked = true;
                else if (StudLib.stlist[StudLib.current].xb == "女")
                    radioButton2.Checked = true;
                comboBox1.Text = StudLib.stlist[StudLib.current].mz;
                textBox3.Text = StudLib.stlist[StudLib.current].bh;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (StudLib.tag ==1)         //添加记录情况
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                    MessageBox.Show("学号和姓名必须输入");
                else
                {
                    int cxh = int.Parse(textBox1.Text);
                    int i = StudLib.Find(cxh);
                    if (i >= 0)
                    {
                        MessageBox.Show("输入的学号重复，不能添加");
                        return;
                    }
                    Student st = new Student();
                    st.xh = cxh;
                    st.xm = textBox2.Text;
                    if (radioButton1.Checked)
                        st.xb = "男";
                    else if (radioButton2.Checked)
                        st.xb = "女";
                    else
                        st.xb = "";
                    if (comboBox1.SelectedItem.ToString() != "")
                        st.mz = comboBox1.SelectedItem.ToString();
                    else
                        st.mz = "";
                    if (textBox3.Text != "")
                        st.bh = textBox3.Text;
                    else
                        st.bh = "";
                    StudLib.stlist.Add(st);
                    StudLib.current = StudLib.stlist.Count - 1;
                    this.Close();
                }
            }
            else if (StudLib.tag == 0)        //修改记录情况
            {
                int cxh = int.Parse(textBox1.Text);
                int i = StudLib.Find(cxh);
                StudLib.stlist[i].xm = textBox2.Text;
                if (radioButton1.Checked)
                    StudLib.stlist[i].xb = "男";
                else if (radioButton2.Checked)
                    StudLib.stlist[i].xb = "女";
                else
                    StudLib.stlist[i].xb = "";
                if (comboBox1.SelectedItem.ToString() != "")
                    StudLib.stlist[i].mz = comboBox1.SelectedItem.ToString();
                else
                    StudLib.stlist[i].mz = "";
                if (textBox3.Text != "")
                    StudLib.stlist[i].bh = textBox3.Text;
                else
                    StudLib.stlist[i].bh = "";
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
