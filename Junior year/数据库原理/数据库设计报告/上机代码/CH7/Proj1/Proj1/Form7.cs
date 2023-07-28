using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 && comboBox2.SelectedIndex >= 0)
            {
                int n = int.Parse(comboBox1.SelectedItem.ToString());
                int m = int.Parse(comboBox2.SelectedItem.ToString());
                label2.Text = "计算结果：" + (n + m).ToString();
            }
            else
                label2.Text = "提示：没有选择合适的数字";
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(5);
            comboBox1.Items.Add(8);
            comboBox1.Items.Add(12);
            comboBox1.Items.Add(21);
            comboBox2.Items.Add(3);
            comboBox2.Items.Add(6);
            comboBox2.Items.Add(9);
            comboBox2.Items.Add(12);
            label2.Text = "";
        }
    }
}
