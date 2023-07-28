using System;
using System.Windows.Forms;

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
            textBox1.Text = "C#是一种安全的、稳定的、简单的、优雅的，由C和C++衍生出来的面向对象的编程语言";
            textBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != "")
            {
                textBox2.Text = "选择文字长度:" + textBox1.SelectedText.Length.ToString();
                textBox2.Text += "\r\n" + "选择的文字:" + textBox1.SelectedText;
                
            }
        }
    }
}
