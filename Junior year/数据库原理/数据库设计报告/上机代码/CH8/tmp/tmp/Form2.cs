using System;
using System.Windows.Forms;
using System.IO;

namespace tmp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text.Trim();
            try
            { 
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                StreamWriter sw = File.CreateText(path+@"\myfile.txt");
                sw.WriteLine("This is a String!");
                sw.Close();
                label2.Text= "创建文件完毕";
            }
            catch (Exception ex)
            {
                label2.Text= ex.Message;
            }
        }
    }
}
