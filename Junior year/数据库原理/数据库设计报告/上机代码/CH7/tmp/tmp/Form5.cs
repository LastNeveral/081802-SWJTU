using System;
using System.Windows.Forms;

namespace tmp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "你的选择是：" + comboBox1.SelectedItem;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("15001");
            comboBox1.Items.Add("15002");
            comboBox1.Items.Add("15003");
            comboBox1.Items.Add("15004");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form myform = new Form1();
            myform.Show();
        }
    }
}
