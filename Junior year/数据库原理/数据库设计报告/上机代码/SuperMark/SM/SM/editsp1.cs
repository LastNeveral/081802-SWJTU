using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class editsp1 : Form
    {
        CommDB mydb = new CommDB();
        public editsp1()
        {
            InitializeComponent();
        }

        private void editsp1_Load(object sender, EventArgs e)
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
        private void editsp1_Activated(object sender, EventArgs e)
        {
            bind();
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows[0].Selected = true; //默认选择第1行
        }      
        private void bind()     //绑定数据
        {
            string mystr;
            if (TempData.sql == "")
                mystr = "SELECT * FROM Product";
            else
                mystr = TempData.sql;
            DataSet mydataset = mydb.ExecuteQuery(mystr, "Product");
            dataGridView1.DataSource = mydataset.Tables["Product"];
        }

        private void button1_Click(object sender, EventArgs e)
        {   //修改记录
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string spno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                string spmc = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
                string spfl = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
                string spzl = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
                string spdj = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
                string spsl = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
                Form myform = new editsp2(spno,spmc,spfl,spzl,spdj,spsl);	//带传递数据调用editsp2的构造函数
                myform.ShowDialog();
            }
        }      

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {   //删除记录
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string spno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                DialogResult result = MessageBox.Show("真的要删除" + spno 
                    + "编号的商品吗？", "操作提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string mystr = "DELETE Product WHERE 商品编号='" + spno + "'";
                    mydb.ExecuteNonQuery(mystr);
                    bind();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //单击任何单元时选择该单元所在的行
            if (e.RowIndex>=0 && e.RowIndex<dataGridView1.Rows.Count) 
                dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {   //菜单命令：修改
            button1_Click(sender, e);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {   //菜单命令：删除
            button2_Click(sender,e);
        } 
    }
}
