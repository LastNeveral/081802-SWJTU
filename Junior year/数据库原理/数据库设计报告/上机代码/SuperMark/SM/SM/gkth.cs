using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class gkth : Form
    {
        CommDB mydb = new CommDB();
        public gkth()
        {
            InitializeComponent();
        }

        private void gkth_Load(object sender, EventArgs e)
        {                   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                bind();
            else
                MessageBox.Show("请输入正确的顾客编号","操作提示");
        }
        private void bind()
        {
            string mystr;
            mystr = "SELECT * FROM Sale WHERE 顾客编号='"
                + textBox1.Text.Trim()
                + "' AND DATEDIFF(DAY,日期,'" + DateTime.Now + "') <=7";
            DataSet mydataset = mydb.ExecuteQuery(mystr, "Sale");
            dataGridView1.DataSource = mydataset.Tables["Sale"];
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 90;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //单击任何单元时选择该单元所在的行
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 退货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string mystr;
                string xsno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                string spno = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
                string spsl = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
                DialogResult result = MessageBox.Show("真的退货" + spno
                    + "编号的商品" + spsl + "件吗？", "操作提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //(1)将退货的购物记录从Sale表中删除
                    mystr = "DELETE Sale WHERE 销售编号=" + xsno;
                    mydb.ExecuteNonQuery(mystr);
                    //(2)修改Product表中对应商品的库存数量
                    mystr = "UPDATE Product SET 库存数量=库存数量 + "
                        + spsl + " WHERE 商品编号='" + spno + "'";
                    mydb.ExecuteNonQuery(mystr);
                    bind();
                }
            }
            else
                MessageBox.Show("没有选择合适的要退货的销售记录","操作提示");
        }
    }
}
