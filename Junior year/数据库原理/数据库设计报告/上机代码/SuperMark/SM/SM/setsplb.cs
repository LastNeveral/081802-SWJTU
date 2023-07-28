using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class setsplb : Form
    {
        CommDB mydb = new CommDB();
        int tag;            //1:添加，2：修改
        string recno;       //记录编号
        public setsplb()
        {
            InitializeComponent();
        }

        private void setsplb_Load(object sender, EventArgs e)
        {
            bind();
            tag = 1;        //表示添加操作
        }
        private void bind()
        {
            string mystr;
            mystr = "SELECT * FROM Prodsort";
            DataSet mydataset = mydb.ExecuteQuery(mystr, "Prodsort");
            dataGridView1.DataSource = mydataset.Tables["Prodsort"];
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            taglabel.Text = "添加操作";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mystr;
            if (tag == 1)       //当前为添加操作
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    mystr = "SELECT * FROM Prodsort WHERE 分类='"
                        + textBox1.Text.Trim() + "' AND 子类='"
                        + textBox2.Text.Trim() + "'";
                    int i = mydb.Rownum(mystr);
                    if (i == 1)
                    {
                        MessageBox.Show("商品分类重复，重新输入", "操作提示");
                        return;
                    }
                    mystr = "INSERT INTO Prodsort(分类,子类) VALUES('"
                        + textBox1.Text.Trim() + "','"
                        + textBox2.Text.Trim() + "')";
                    mydb.ExecuteNonQuery(mystr);
                    bind();
                    textBox2.Text = "";
                    textBox2.Focus();
                }
                else
                    MessageBox.Show("必须输入所有数据项", "操作提示");
            }
            else if (tag == 2)  //当前为修改操作
            {
                mystr = "UPDATE Prodsort SET 分类='" + textBox1.Text.Trim() + "',"
                    + "子类='" + textBox2.Text.Trim() + 
                    "' WHERE 编号='" + recno + "'";
                mydb.ExecuteNonQuery(mystr);
                bind();
                tag = 1;                    //修改后恢复为添加操作
                taglabel.Text = "添加操作";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //删除记录
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string flno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                DialogResult result = MessageBox.Show("真的要删除" + flno
                    + "编号的分类记录吗？", "操作提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string mystr = "DELETE Prodsort WHERE 编号='" + flno + "'";
                    mydb.ExecuteNonQuery(mystr);
                    bind();
                }
            }
            else
                MessageBox.Show("必须选择要删除的记录","操作提示");
        }
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //修改记录
            if (dataGridView1.SelectedRows.Count > 0)
            {
                tag = 2;        //表示修改操作
                string no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                string fl = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
                string zl = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
                taglabel.Text = "修改编号" + no;
                recno = no;
                textBox1.Text = fl;
                textBox2.Text = zl;
            }
            else
                MessageBox.Show("必须选择要修改的记录", "操作提示");
        }
        private void 复制分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string fl = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
                textBox1.Text = fl;
            }
            else
                MessageBox.Show("必须选择要复制的记录", "操作提示");
        }
    }
}
