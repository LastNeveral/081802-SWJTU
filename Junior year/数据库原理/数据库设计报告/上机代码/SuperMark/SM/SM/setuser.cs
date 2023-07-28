using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class setuser : Form
    {
        CommDB mydb = new CommDB();
        public setuser()
        {
            InitializeComponent();
        }

        private void setuser_Load(object sender, EventArgs e)
        {
            bind();
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Width = 130;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 130;
        }
        private void bind()
        {
            string mystr;
            mystr = "SELECT * FROM SUser";
            DataSet mydataset = mydb.ExecuteQuery(mystr, "SUser");
            dataGridView1.DataSource = mydataset.Tables["SUser"];
            
        }
        private void button1_Click(object sender, EventArgs e)  //添加
        {
            TempData.tag = 1;
            Form myform = new setuser1();
            myform.ShowDialog();
            bind();
        }

        private void button2_Click(object sender, EventArgs e)  //修改
        {
            //修改记录
            TempData.tag = 2;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string userno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                string userpass = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
                string userlevel = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
                Form myform = new setuser1(userno, userpass, userlevel);	//带传递数据调用setuser1的构造函数
                myform.ShowDialog();
                bind();
            }
            else
                MessageBox.Show("必须选择一个要修改的记录","操作提示");
        }

        private void button3_Click(object sender, EventArgs e)  //删除
        {
            //删除记录
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string userno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                DialogResult result = MessageBox.Show("真的要删除" + userno
                    + "用户吗？", "操作提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string mystr = "DELETE SUser WHERE 用户名='" + userno + "'";
                    mydb.ExecuteNonQuery(mystr);
                    bind();
                }
            }
            else
                MessageBox.Show("必须选择一个要删除的记录", "操作提示");
        }

        private void cosebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //单击任何单元时选择该单元所在的行
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }
    }
}
