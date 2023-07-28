using System;
using System.Windows.Forms;
using System.IO;
namespace tmp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text.Trim();
            DirectoryInfo dir = new DirectoryInfo(path); 
            foreach (FileInfo f in dir.GetFiles())
                f.Delete();
            label2.Text = "文件删除完成";
        }
    }
}
