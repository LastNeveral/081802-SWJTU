using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proj1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Font newFont;
                newFont = new Font(textBox1.Font, textBox1.Font.Style | FontStyle.Bold);
                textBox1.Font = newFont;
            }
            else
            {
                Font newFont;
                newFont = new Font(textBox1.Font, textBox1.Font.Style ^ FontStyle.Bold);
                textBox1.Font = newFont;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Font newFont;
                newFont = new Font(textBox1.Font, textBox1.Font.Style | FontStyle.Underline);
                textBox1.Font = newFont;
            }
            else
            {
                Font newFont;
                newFont = new Font(textBox1.Font, textBox1.Font.Style ^ FontStyle.Underline);
                textBox1.Font = newFont;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                Font newFont;
                newFont = new Font(textBox1.Font, textBox1.Font.Style | FontStyle.Italic);
                textBox1.Font = newFont;
            }
            else
            {
                Font newFont;
                newFont = new Font(textBox1.Font, textBox1.Font.Style ^ FontStyle.Italic);
                textBox1.Font = newFont;
            }
        }      
    }
}
