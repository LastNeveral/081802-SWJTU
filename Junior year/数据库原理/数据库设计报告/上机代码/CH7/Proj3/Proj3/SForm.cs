using System;
using System.Windows.Forms;

namespace Proj3
{
    public partial class SForm : Form
    {
        public SForm()
        {
            InitializeComponent();
        }

        private void SForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = TempData.mynum.ToString();	//读出静态字段mynum中的数据
            textBox2.Text = TempData.mystr;				//读出静态字段mystr中的数据
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();		//关闭本窗体
        }
    }
}
