using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Exp
{
    public partial class Form1 : Form
    {
        private string savePath = "";//自定义全局变量获取保存文件的路径
        public Form1()
        {
            InitializeComponent();
        }

        private void MNew_Click(object sender, EventArgs e)
        {
            if (textBox1.Modified && textBox1.Text != "")
            {
                DialogResult result = MessageBox.Show("文件" + Text 
                    + "内容已经改变。\n\n你是否要保存文件？",
                    "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (string.Equals(result, DialogResult.Yes))//判断文本单击弹出框单击确认才执行代码
                {
                    SaveFileDialog save = new SaveFileDialog();//创建保存对话框对象
                    save.Filter = "文本文件|*.text;*.txt";//设置保存的格式
                    if (save.ShowDialog() == DialogResult.OK)//打开保存对话框
                    {
                        SaveInfo(save.FileName);//调用自定义的保存方法
                        textBox1.Text = "";      //清空编辑框
                        this.Text = "无标题-记事本";//设定当前记事本的标题栏信息
                    }
                }
                else if (string.Equals(result, DialogResult.No))//判断用户是否按下不保存按钮
                {
                    textBox1.Text = "";
                    this.Text = "无标题-记事本";
                }
            }
        }
        public void SaveInfo(string pat)
        {
            //获取保存文件的路径全称
            string filePath = Path.GetFullPath(pat);
            savePath = filePath;
            //创建写文件流对象
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.Default);
            //设置记事本标题栏信息为当前打开文本文件名
            this.Text = Path.GetFileName(filePath);
            //调用文件流的Write方法，将编辑框中的文本信息写入指定的文件流中
            sw.Write(textBox1.Text);
            sw.Close();
        }

        private void MOpen_Click(object sender, EventArgs e)
        {
            //创建打开文件对话框对象
            OpenFileDialog open = new OpenFileDialog();
            //设置打开文件的格式
            open.Filter = "文本文件|*.text;*.txt";
            //打开文件对话框并判断是否按下确定键
            if (open.ShowDialog() == DialogResult.OK)
                //调用自定义的载人文件方法LoadInfo，打开对话框中选定的文件内容
                LoadInfo(open.FileName);
        }
        public void LoadInfo(string path)//自定义的载入文件的方法
        {
            string filePath = path;
            savePath = filePath;
            StreamReader fm = new StreamReader(filePath,
                System.Text.Encoding.Default);
            this.Text = Path.GetFileName(filePath);
            textBox1.Text = fm.ReadToEnd(); //读取文件流数据到记事本编辑框中。
            fm.Close();                     //释放文件流
        }

        private void MSave_Click(object sender, EventArgs e)
        {
            //创建保存对话框对象
            SaveFileDialog save = new SaveFileDialog();
            //判断是新建记事本还是打开以前的记事本
            if (string.Equals(this.Text, "无标题-记事本"))
            {
                save.Filter = "文本文件|*.text;*.txt";
                //打开保存对话框，并判断是否按下确定保存的按钮
                if (save.ShowDialog() == DialogResult.OK)
                    //调用自定义的保存方法，保存指定文件名和路径的文件
                    SaveInfo(save.FileName);
            }
            else
                Save2Info();
        }
        public void Save2Info()
        {
            StreamWriter sw = new StreamWriter(savePath, false, Encoding.Default);
            sw.Write(textBox1.Text);
            sw.Close();
        }

        private void MSaveAs_Click(object sender, EventArgs e)
        {
            //创建保存对话框对象
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "文本文件|*.text;*.txt";
            if (save.ShowDialog() == DialogResult.OK)
                //调用自定义的保存方法，保存指定文件名和路径的文件
                SaveInfo(save.FileName);
        }

        private void MExit_Click(object sender, EventArgs e)
        {
            if (textBox1.Modified && textBox1.Text != "")
            {
                //如果当前记事本编辑窗口内容有改动并且编辑窗口不为空，则提示用户是否保存
                DialogResult result = MessageBox.Show("文件" + Text 
                    + "内容已经改变。\n\n您是否要保存文件？", "记事本", 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                //单击弹出判断文本框，单击确认后执行代码
                if (string.Equals(result, DialogResult.Yes))
                {
                    //创建保存对话框对象
                    SaveFileDialog save = new SaveFileDialog();
                    //设置保存格式
                    save.Filter = "文本文件|*.text;*.txt";
                    //打开保存对话框，并判断是否按下确定保存的按钮
                    if (save.ShowDialog() == DialogResult.OK)
                        //调用自定义的保存方法，保存指定文件名和路径的文件
                        SaveInfo(save.FileName);
                    this.Close();
                }
                //判断用户是否按下不保存按钮
                else if (string.Equals(result, DialogResult.No))
                    this.Close();   //关闭本窗体
            }
            else
                this.Close();   //关闭本窗体
        }

        private void MUndo_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void MCut_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void MCopy_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void MPaste_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void MDelete_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = "";
        }

        private void MSelectAll_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void MColor_Click(object sender, EventArgs e)
        {
            //创建颜色选择对话框
            ColorDialog ncolor = new ColorDialog();
            if (ncolor.ShowDialog() == DialogResult.OK)
                this.textBox1.ForeColor = ncolor.Color;
        }
        private void MFont_Click(object sender, EventArgs e)
        {
            //创建字体选择对话框
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
                this.textBox1.Font = font.Font; 
        }      

        private void MAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("系统版权所有，不得复制！");
        }
    }
}
