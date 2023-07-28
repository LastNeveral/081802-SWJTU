using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SM
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            this.Text += "-" + TempData.userlevel;
            if (TempData.userlevel == "管理员")  //管理员限制
            {
                toolStrip1.Items["toolStripButton1"].Enabled = false;
                toolStrip1.Items["toolStripButton2"].Enabled = false;
                menuStrip1.Items["gwgl"].Enabled = false;
            }
            else            //操作员功能限制
            {
                menuStrip1.Items["spxxgl"].Enabled = false;
                menuStrip1.Items["gkxxgl"].Enabled = false;
                menuStrip1.Items["cxgl"].Enabled = false;
                menuStrip1.Items["xtgl"].Enabled = false;
            }
        }       
       
        private void 添加新商品menu_Click(object sender, EventArgs e)
        {
            Form myform = new addsp();
            myform.MdiParent = this;		//建立父子窗体关系
            myform.Show();
        }

        private void 编辑商品信息menu_Click(object sender, EventArgs e)
        {
            Form myform = new editsp();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 增加老商品库存menu_Click(object sender, EventArgs e)
        {
            Form myform = new addspkc();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 商品库存报警menu_Click(object sender, EventArgs e)
        {
            Form myform = new spkcbj();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 添加新顾客menu_Click(object sender, EventArgs e)
        {
            Form myform = new addgk();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 编辑顾客信息menu_Click(object sender, EventArgs e)
        {
            Form myform = new editgk();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 查看顾客购物信息menu_Click(object sender, EventArgs e)
        {
            Form myform = new querygkgw();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 顾客购物menu_Click(object sender, EventArgs e)
        {
            Form myform = new gkgw();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 顾客退货menu_Click(object sender, EventArgs e)
        {
            Form myform = new gkth();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 按分类统计销售情况menu_Click(object sender, EventArgs e)
        {
            Form myform = new tjfl();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 按子类统计销售情况menu_Click(object sender, EventArgs e)
        {
            Form myform = new tjzl();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 按商品统计销售情况menu_Click(object sender, EventArgs e)
        {
            Form myform = new tjsp();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 用户管理menu_Click(object sender, EventArgs e)
        {
            Form myform = new setuser();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 设置商品类别menu_Click(object sender, EventArgs e)
        {
            Form myform = new setsplb();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 设置地区信息menu_Click(object sender, EventArgs e)
        {
            Form myform = new setarea();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 系统初始化menu_Click(object sender, EventArgs e)
        {
            Form myform = new init();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 关于menu_Click(object sender, EventArgs e)
        {
            Form myform = new about();
            myform.MdiParent = this;
            myform.Show();
        }

        private void 联系信息menu_Click(object sender, EventArgs e)
        {
            Form myform = new corporation();
            myform.MdiParent = this;
            myform.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form myform = new gkgw();
            myform.MdiParent = this;
            myform.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form myform = new gkth();
            myform.MdiParent = this;
            myform.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
