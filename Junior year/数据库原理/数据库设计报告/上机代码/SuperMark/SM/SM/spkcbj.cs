using System;
using System.Data;
using System.Windows.Forms;

namespace SM
{
    public partial class spkcbj : Form
    {
        public spkcbj()
        {
            InitializeComponent();
        }

        private void spkcbj_Load(object sender, EventArgs e)
        {
            CommDB mydb = new CommDB();
            string mystr;
            mystr = "SELECT * FROM Product WHERE 库存数量<=40";
            DataSet mydataset = mydb.ExecuteQuery(mystr, "Product");
            dataGridView1.DataSource = mydataset.Tables["Product"];
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
