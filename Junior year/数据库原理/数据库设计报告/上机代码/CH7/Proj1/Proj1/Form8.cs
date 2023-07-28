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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            treeView1.Indent = 50;
            treeView1.Nodes.Add("计算机系");
            treeView1.Nodes[0].Nodes.Add("一年级");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("1501班");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("1502班");
            treeView1.Nodes[0].Nodes.Add("二年级");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("1401班");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("1402班");
            treeView1.Nodes.Add("电子工程系");
            treeView1.Nodes[1].Nodes.Add("一年级");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("1503班");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("1504班");
            treeView1.Nodes[1].Nodes.Add("二年级");
            treeView1.Nodes[1].Nodes[1].Nodes.Add("1403班");
            treeView1.Nodes[1].Nodes[1].Nodes.Add("1404班");
            treeView1.ExpandAll();		//展开所有节点
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Level==0)
                label1.Text = "你的选择：" + treeView1.SelectedNode.Text;
            else if (node.Level == 1)
            {
                TreeNode pnode = node.Parent;
                label1.Text = "你的选择：" + pnode.Text + "\\" + node.Text;
            }
            else if (node.Level == 2)
            {
                TreeNode pnode = node.Parent;
                TreeNode ppnode = pnode.Parent;
                label1.Text = "你的选择：" + ppnode.Text + "\\" + pnode.Text + "\\" + node.Text;
            }
        }      
    }
}
