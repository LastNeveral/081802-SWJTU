using System;
using System.Windows.Forms;

namespace Proj1
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString("h:mm:ss");
            timer1.Enabled = true;	//启到定时器timer1
            timer1.Interval = 1000;           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString("h:mm:ss");
        }        
    }
}
