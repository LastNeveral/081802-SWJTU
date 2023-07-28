using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (StudLib.stlist.Count>0)
                Dispst();
        }
        private void Dispst()    //显示索引为StudLib.current的记录
        {
            int i = StudLib.current;
            textBox1.Text = StudLib.stlist[i].xh.ToString();
            textBox2.Text = StudLib.stlist[i].xm;
            textBox3.Text = StudLib.stlist[i].xb;
            textBox4.Text = StudLib.stlist[i].mz;
            textBox5.Text = StudLib.stlist[i].bh;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StudLib.stlist.Count > 0)
            {
                StudLib.current = 0;
                Dispst();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StudLib.stlist.Count > 0)
            {
                if (StudLib.current != 0)
                {
                    StudLib.current--;
                    Dispst();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (StudLib.stlist.Count > 0)
            {
                if (StudLib.current != StudLib.stlist.Count - 1)
                {
                    StudLib.current++;
                    Dispst();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (StudLib.stlist.Count > 0)
            {
                StudLib.current = StudLib.stlist.Count - 1;
                Dispst();
            }

        }
        private void SAdd_Click(object sender, EventArgs e)     //添加记录
        {
            StudLib.tag = 1;
            Form2 myform = new Form2();
            myform.ShowDialog();
        }

        private void SUpdate_Click(object sender, EventArgs e)  //修改记录
        {
            StudLib.tag = 0;
            Form2 myform = new Form2();
            myform.ShowDialog();
        }

        private void SDelete_Click(object sender, EventArgs e)  //删除记录
        {
            DialogResult result = MessageBox.Show("确定要删除学号为"+ textBox1.Text+ "的记录吗？","提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                StudLib.stlist.RemoveAt(StudLib.current);
                if (StudLib.stlist.Count > 0)
                {
                    if (StudLib.current == StudLib.stlist.Count) //删除最后记录
                        StudLib.current = 0;
                    Dispst();
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
            }
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (StudLib.stlist.Count == 0)
            {
                SUpdate.Enabled = false;
                SDelete.Enabled = false;
            }
            else
            {
                SUpdate.Enabled = true;
                SDelete.Enabled = true;
            }
        }      
    }
}
