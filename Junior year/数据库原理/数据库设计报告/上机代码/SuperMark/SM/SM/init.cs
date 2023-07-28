using System;
using System.Windows.Forms;

namespace SM
{
    public partial class init : Form
    {
        CommDB mydb = new CommDB();
        public init()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("真的要进行系统初始化吗？", "操作提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                deltable("Area");
                deltable("Prodsort");
                deltable("Customer");
                deltable("Product");
                deltable("Sale");
                deltable("SUser");
                string mystr = "INSERT INTO SUser(用户名,密码,级别)"
                    + " VALUES('system','manager','管理员')";
                mydb.ExecuteNonQuery(mystr);
                MessageBox.Show("系统初始化完毕,下次以system/manager管理员进入本系统", "操作提示");
                this.Close();
            }
            else
                this.Close();
        }
        private void deltable(string tn)
        {            
            string mystr = "DELETE " + tn;
            mydb.ExecuteNonQuery(mystr);
        }
    }
}
