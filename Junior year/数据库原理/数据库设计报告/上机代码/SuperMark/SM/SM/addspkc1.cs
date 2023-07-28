using System;
using System.Data;
using System.Windows.Forms;


namespace SM
{
    public partial class addspkc1 : Form
    {
        CommDB mydb = new CommDB();
        public addspkc1()
        {
            InitializeComponent();
        }

        private void addspkc1_Load(object sender, EventArgs e)
        {
            string mystr;
            if (TempData.sql == "")
                mystr = "SELECT * FROM Product";
            else
                mystr = TempData.sql;
            DataSet mydataset = mydb.ExecuteQuery(mystr, "Product");
            dataGridView1.DataSource=mydataset.Tables["Product"];
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Columns.Add("tjsl", "增加数量");  //增加一个列
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if (dataGridView1.Rows[i].Cells[6].Value != null)
                    Updateks(dataGridView1.Rows[i].Cells[0].Value.ToString().Trim(), 
                        dataGridView1.Rows[i].Cells[6].Value.ToString().Trim());
            this.Close();
        }
        protected void Updateks(string spno, string addks)
        {
            string mystr = "UPDATE Product SET 库存数量=库存数量+" 
                + addks + " WHERE 商品编号='" + spno + "'";
            mydb.ExecuteNonQuery(mystr);
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
