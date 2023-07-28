using System;
using System.Windows.Forms;

namespace Proj4
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void fun11_Click(object sender, EventArgs e)
        {
            Form1 child = new Form1();	//定义子窗体对象
            child.MdiParent = this;		//建立父子窗体关系
            child.Show();				//显示子窗体
        }       
    }
}
