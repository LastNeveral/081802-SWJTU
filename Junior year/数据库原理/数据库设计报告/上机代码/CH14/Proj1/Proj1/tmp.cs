using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj1
{
    public partial class tmp : Form
    {
        public tmp()
        {
            InitializeComponent();
        }

        private void tmp_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“sMKDataSet1.Product”中。您可以根据需要移动或删除它。
            this.productTableAdapter.Fill(this.sMKDataSet1.Product);

        }
    }
}
