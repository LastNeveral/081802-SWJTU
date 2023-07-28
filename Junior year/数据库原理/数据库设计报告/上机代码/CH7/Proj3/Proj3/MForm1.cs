using System;
using System.Windows.Forms;

namespace Proj3
{
    public partial class MForm1 : Form
    {
        public MForm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox1.Text);
            string str = textBox2.Text;
            Form myform = new SForm1(num, str);	//带传递数据调用SForm1的构造函数
            myform.ShowDialog();

        }
    }
}
