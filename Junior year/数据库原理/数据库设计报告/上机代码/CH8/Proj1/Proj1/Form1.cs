using System;
using System.Windows.Forms;
using System.IO;

namespace Proj1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            listView1.Items.Clear();
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            if (folderBrowserDialog1.SelectedPath == "") return;
            if (!Directory.Exists(folderBrowserDialog1.SelectedPath))
                MessageBox.Show(folderBrowserDialog1.SelectedPath + "文件夹不存在",
                    "信息提示", MessageBoxButtons.OK);
            else
            {
                string[] filen;
                filen = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                if (filen.Length > 0)
                {
                    ListViewItem itemx = new ListViewItem();
                    listView1.View = View.Details;
                    listView1.Columns.Add("文件名", 140, HorizontalAlignment.Center);	//添加第1个列
                    listView1.Columns.Add("创建日期", 140, HorizontalAlignment.Center);	//添加第2个列
                    listView1.Columns.Add("文件属性", 80, HorizontalAlignment.Center);	//添加第3个列
                    for (i = 0; i <= filen.Length - 1; i++)
                    {
                        itemx = listView1.Items.Add(filen[i]);		//添加第1个ListItem对象
                        itemx.SubItems.Add(File.GetCreationTime(filen[i]).ToString());				//添加一个子项目
                        itemx.SubItems.Add(fileatt(filen[i]));			//添加一个子项目
                    }
                }
            }
        }
        private string fileatt(string filename) //获取文件属性
        {
            string fa = "";
            switch (File.GetAttributes(filename))
            {
                case FileAttributes.Archive:
                    fa = "存档";
                    break;
                case FileAttributes.ReadOnly:
                    fa = "只读";
                    break;
                case FileAttributes.Hidden:
                    fa = "隐藏";
                    break;
                case FileAttributes.Archive | FileAttributes.ReadOnly:
                    fa = "存档+只读";
                    break;
                case FileAttributes.Archive | FileAttributes.Hidden:
                    fa = "存档+隐藏";
                    break;
                case FileAttributes.ReadOnly | FileAttributes.Hidden:
                    fa = "只读+隐藏";
                    break;
                case FileAttributes.Archive | FileAttributes.ReadOnly
                    | FileAttributes.Hidden:
                    fa = "存档+只读+隐藏";
                    break;
            }
            return fa;
        }
    }
}
