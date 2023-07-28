using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class editgk1 : Form
    {
        CommDB mydb = new CommDB();
        public editgk1()
        {
            InitializeComponent();
        }

        private void editgk1_Load(object sender, EventArgs e)
        {
            bind();
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 100;
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows[0].Selected = true;  //默认选择第1行
        }
        private void editgk1_Activated(object sender, EventArgs e)
        {
            bind();
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows[0].Selected = true; //默认选择第1行
        }
        private void bind()     //绑定数据
        {
            string mystr;
            if (TempData.sql == "")
                mystr = "SELECT * FROM Customer";
            else
                mystr = TempData.sql;
            DataSet mydataset = mydb.ExecuteQuery(mystr, "Customer");
            dataGridView1.DataSource = mydataset.Tables["Customer"];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //修改记录
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string gkno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                string gkxm = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
                string gkxb = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
                string gksf = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
                string gkcs = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
                string gkxc = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
                Form myform = new editgk2(gkno,gkxm,gkxb,gksf,gkcs,gkxc);	//带传递数据调用editgk2的构造函数
                myform.ShowDialog();
            }
            else
                MessageBox.Show("必须选择要修改的记录", "操作提示");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //删除记录
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string gkno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                DialogResult result = MessageBox.Show("真的要删除" + gkno
                    + "编号的顾客吗？", "操作提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string mystr = "DELETE Customer WHERE 顾客编号='" + gkno + "'";
                    mydb.ExecuteNonQuery(mystr);
                    bind();
                }
            }
            else
                MessageBox.Show("必须选择要删除的记录", "操作提示");
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //单击任何单元时选择该单元所在的行
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //菜单命令：修改
            button1_Click(sender, e);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //菜单命令：删除
            button2_Click(sender, e);
        }
    }
}
