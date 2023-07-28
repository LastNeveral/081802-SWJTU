using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Proj2
{
    public partial class Form1 : Form
    {
        string path = "D:\\C#和数据库\\CH8\\MyFile.txt";  //文件名
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))  //存在该文件时删除之
                File.Delete(path);
            else
            {
                FileStream myfs = new FileStream(path, FileMode.Create);
                //创建文件流
                StreamWriter mysw = new StreamWriter(myfs, Encoding.Default);
                //创建写入器
                mysw.WriteLine(textBox1.Text);	//写入文件内容
                mysw.Close();					//关闭写入器
                myfs.Close();					//关闭文件流
                button2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string mystr = "";
            FileStream myfs = new FileStream(path, FileMode.Open);
            //创建文件流
            StreamReader mysr = new StreamReader(myfs, Encoding.Default);
            //创建阅读器
            mystr = mysr.ReadToEnd();		//读取文件内容
            mysr.Close();					//关闭阅读器
            myfs.Close();					//关闭文件流
            textBox2.Text = mystr;
        }
    }
}
