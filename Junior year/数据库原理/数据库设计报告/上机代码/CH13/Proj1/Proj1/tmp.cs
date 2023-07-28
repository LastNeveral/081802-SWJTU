using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj1
{
    public partial class tmp : Form
    {
        public tmp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void tmp_Load(object sender, EventArgs e)
        {
            DataSet myds = new DataSet();
            DataTable mydt = new DataTable("Dep");
            myds.Tables.Add(mydt);
            mydt.Columns.Add("dID", Type.GetType("System.String"));
            mydt.Columns.Add("dName", Type.GetType("System.String"));
            DataRow myrow1 = mydt.NewRow();
            myrow1["dID"] = "101";
            myrow1["dName"] = "财务处";
            myds.Tables[0].Rows.Add(myrow1);
            DataRow myrow2 = mydt.NewRow();
            myrow2["dID"] = "120";
            myrow2["dName"] = "人事处";
            myds.Tables["Dep"].Rows.Add(myrow2);
            dataGridView1.DataSource = myds.Tables[0];
            textBox1.Text = myds.Tables[0].Columns[0].Caption.ToString();
            textBox1.Text += " " + myds.Tables[0].Columns[1].Caption.ToString();
            textBox1.Text += "\n";
            textBox1.Text += myds.Tables[0].Rows[0][0].ToString();
            textBox1.Text += myds.Tables[0].Rows[0][1].ToString();
            textBox1.Text += myds.Tables[0].Rows[1][0].ToString();
            textBox1.Text += myds.Tables[0].Rows[1][1].ToString();
            textBox1.Text += myds.Tables[0].Columns.Count.ToString();
        }
    }
}
