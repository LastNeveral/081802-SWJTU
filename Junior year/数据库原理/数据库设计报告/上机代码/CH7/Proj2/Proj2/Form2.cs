using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void addop_Click(object sender, EventArgs e)
        {
            int n;
            n = Convert.ToInt16(textBox1.Text) + Convert.ToInt16(textBox2.Text);
            textBox3.Text = n.ToString();
        }
        private void subop_Click(object sender, EventArgs e)
        {
            int n;
            n = Convert.ToInt16(textBox1.Text) - Convert.ToInt16(textBox2.Text);
            textBox3.Text = n.ToString();
        }
        private void multop_Click(object sender, EventArgs e)
        {
            int n;
            n = Convert.ToInt16(textBox1.Text) * Convert.ToInt16(textBox2.Text);
            textBox3.Text = n.ToString();
        }
        private void divop_Click(object sender, EventArgs e)
        {
            int n;
            n = Convert.ToInt16(textBox1.Text) / Convert.ToInt16(textBox2.Text);
            textBox3.Text = n.ToString();
        }

        private void op_Opened(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || Convert.ToInt16(textBox2.Text) == 0)
                divop.Enabled = false;
            else
                divop.Enabled = true;
        }
    }
}
