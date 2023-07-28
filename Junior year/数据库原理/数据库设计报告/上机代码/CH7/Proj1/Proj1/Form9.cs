using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            ListViewItem itemx = new ListViewItem();
            listView1.CheckBoxes =true;
            listView1.View = View.Details;
            listView1.Columns.Add("课程名", 140, HorizontalAlignment.Center); //添加第1个列
            listView1.Columns.Add("学分", 80, HorizontalAlignment.Center); //添加第2个列
            listView1.Columns.Add("上课学期", 80, HorizontalAlignment.Center); //添加第3个列
            itemx = listView1.Items.Add("计算机导论");	//添加第1个ListItem对象
            itemx.SubItems.Add("3");				    //添加一个子项目
            itemx.SubItems.Add("1学期");			    //添加一个子项目
            itemx = listView1.Items.Add("C语言");	    //添加第2个ListItem对象
            itemx.SubItems.Add("3");				    //添加一个子项目
            itemx.SubItems.Add("2学期");			    //添加一个子项目
            itemx = listView1.Items.Add("数据结构");	//添加第3个ListItem对象
            itemx.SubItems.Add("4");				    //添加一个子项目
            itemx.SubItems.Add("3学期");			    //添加一个子项目
            itemx = listView1.Items.Add("数据库");	    //添加第4个ListItem对象
            itemx.SubItems.Add("3");				    //添加一个子项目
            itemx.SubItems.Add("4学期");			    //添加一个子项目
            itemx = listView1.Items.Add("操作系统");	//添加第5个ListItem对象
            itemx.SubItems.Add("3");				    //添加一个子项目
            itemx.SubItems.Add("5学期");			    //添加一个子项目
            itemx = listView1.Items.Add("软件工程");	//添加第6个ListItem对象
            itemx.SubItems.Add("3");				    //添加一个子项目
            itemx.SubItems.Add("5学期");			    //添加一个子项目
            label1.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string mystr = "你的选择：";
            foreach (ListViewItem item in listView1.Items)
                if (item.Checked)
                    mystr += item.Text + " ";
            label1.Text = mystr;
        }      
    }
}
