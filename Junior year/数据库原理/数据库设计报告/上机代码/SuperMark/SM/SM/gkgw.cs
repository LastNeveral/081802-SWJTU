using System;
using System.Windows.Forms;

namespace SM
{
    public partial class gkgw : Form
    {
        CommDB mydb = new CommDB();
        int sumsl = 0;
        double sumjr = 0;
        public gkgw()
        {
            InitializeComponent();
        }

        private void gkgw_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Columns.Add("spno", "商品编号");      //增加一个列
            dataGridView1.Columns.Add("spdj", "单价");          //增加一个列
            dataGridView1.Columns.Add("spsl", "数量");          //增加一个列
            dataGridView1.Columns.Add("spxj", "小计");          //增加一个列
            //此时dataGridView1中自动添加一个空行
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 100;
            sumlabel.Text = "";
        }  

        private void button1_Click(object sender, EventArgs e)
        {
            string dj;
            double xj;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string mystr = "SELECT * FROM Customer WHERE 顾客编号='" + textBox1.Text.Trim() + "'";
                int i = mydb.Rownum(mystr);
                if (i == 0)
                {
                    MessageBox.Show("输入的顾客不存在，重新输入顾客编号");
                    return;
                }
                try
                {
                    mystr = "SELECT 单价 FROM Product WHERE 商品编号='"
                        + textBox2.Text.Trim() + "'";
                    dj = mydb.Returnafield(mystr);
                    xj = int.Parse(textBox3.Text.Trim()) * Convert.ToDouble(dj);
                    dataGridView1.Rows.Add(textBox2.Text.Trim(), dj.ToString(), textBox3.Text.Trim(), xj.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("输入的商品不存在或数量有错误，重新输入：" + ex.Message);
                    return;
                }
                sumsl += int.Parse(textBox3.Text.Trim());
                sumjr += xj;
                sumlabel.Text = "件数:" + sumsl.ToString().Trim() + "，总金额:" + sumjr.ToString().Trim() + "元";
                textBox2.Text = "";
                textBox3.Text = "1";
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("输入的购物信息有错误，重新输入", "操作提示");
                return;
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>1 && dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int sl = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                    double xj = double.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                    sumsl -= sl;
                    sumjr -= xj;
                    sumlabel.Text = "件数:" + sumsl.ToString().Trim() + "，总金额:" + sumjr.ToString().Trim() + "元";
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("没有选择合适的删除行：" + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {   //单击任何单元时选择该单元所在的行
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            string mystr;
            string gkno = textBox1.Text.Trim();
            string spno, spsl, spxj;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    //(1)将dataGridView1控件中每行插入到Sale表中
                    spno = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    spsl = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    spxj = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    mystr = "INSERT INTO Sale(日期,顾客编号,商品编号,数量,金额) VALUES('"
                        + DateTime.Now + "','"
                        + gkno + "','"
                        + spno + "',"
                        + spsl + ","
                        + spxj + ")";
                    mydb.ExecuteNonQuery(mystr);
                    //(2)修改Product表中对应商品的库存数量
                    mystr = "UPDATE Product SET 库存数量=库存数量 - "
                        + spsl + " WHERE 商品编号='" + spno + "'";
                    mydb.ExecuteNonQuery(mystr);
                }
            }
            this.Close();
        }
        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
