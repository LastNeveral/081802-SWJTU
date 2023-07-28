using System;
using System.Windows.Forms;

namespace Proj3
{
    public partial class SForm1 : Form
    {
        private int mynum;			//类私有字段，接收传递过来的数据
        private string mystr;		//类私有字段，接收传递过来的数据
        public SForm1(int num, string str)
        {
            InitializeComponent();
            mynum = num;
            mystr = str;
        }
        private void SForm1_Load(object sender, EventArgs e)
        {
            textBox1.Text = mynum.ToString();	//显示传递过来的数据
            textBox2.Text = mystr;				//显示传递过来的数据
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
