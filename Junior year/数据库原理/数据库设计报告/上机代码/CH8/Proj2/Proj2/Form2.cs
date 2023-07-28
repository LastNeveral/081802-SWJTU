using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Proj2
{
    struct Student					        //声明结构类型
    {
        public int sno;
        public string sname;
        public int score;
    }
    public partial class Form2 : Form
    {
        const int NUM = 4;
        string path = "D:\\C#和数据库\\CH8\\MyFile.dat";  //文件名
        Student[] st = new Student[NUM];	//定义结构数组        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            st[0].sno = 1; st[0].sname = "王华"; st[0].score = 92;
            st[1].sno = 3; st[1].sname = "陈红兵"; st[1].score = 87;
            st[2].sno = 4; st[2].sname = "刘英"; st[2].score = 65;
            st[3].sno = 2; st[3].sname = "张晓华"; st[3].score = 88;
            ListViewItem itemx = new ListViewItem();
            listView1.View = View.Details;
            listView1.Columns.Add("学号", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("姓名", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("分数", 80, HorizontalAlignment.Center);
            for (int i = 0; i < NUM; i++)
            {
                itemx = listView1.Items.Add(st[i].sno.ToString());//添加1个ListItem对象
                itemx.SubItems.Add(st[i].sname); 
                itemx.SubItems.Add(st[i].score.ToString());	//添加2个子项目
            }
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
                BinaryWriter mysw = new BinaryWriter(myfs, Encoding.Default);
                //创建写入器
                for (int i = 0; i < NUM; i++)  //写入文件内容
                {
                    mysw.Write(st[i].sno);
                    mysw.Write(st[i].sname);
                    mysw.Write(st[i].score);
                }
                mysw.Close();					//关闭写入器
                myfs.Close();					//关闭文件流
                button2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FileStream myfs = new FileStream(path, FileMode.Open);
            //创建文件流
            BinaryReader mysr = new BinaryReader(myfs, Encoding.Default);
            //创建阅读器
            ListViewItem itemx = new ListViewItem();
            listView2.View = View.Details;
            listView2.Columns.Add("学号", 80, HorizontalAlignment.Center);
            listView2.Columns.Add("姓名", 80, HorizontalAlignment.Center);
            listView2.Columns.Add("分数", 80, HorizontalAlignment.Center);
            myfs.Seek(0, SeekOrigin.Begin);
            while (mysr.PeekChar() > -1)        //读取文件内容
            {
                itemx = listView2.Items.Add(mysr.ReadInt32().ToString());
                itemx.SubItems.Add(mysr.ReadString());
                itemx.SubItems.Add(mysr.ReadInt32().ToString());	//添加2个子项目
            }
            mysr.Close();					//关闭阅读器
            myfs.Close();					//关闭文件流
        }
    }
}
