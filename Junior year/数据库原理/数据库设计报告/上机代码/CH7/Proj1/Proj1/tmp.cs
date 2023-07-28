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
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            label1.Text = "单击了工具栏控件的第1个按钮";
        }
    }
}
