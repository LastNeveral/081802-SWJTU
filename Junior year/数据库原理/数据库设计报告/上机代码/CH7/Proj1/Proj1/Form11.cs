using System;
using System.Windows.Forms;

namespace Proj1
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "RTF File(*.rtf)|*.RTF|TXT FILE(*.txt)|*.txt";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
                switch (openFileDialog1.FilterIndex)
                {
                    case 1:			//选择的是.rtf类型
                        richTextBox1.LoadFile(openFileDialog1.FileName,
                            RichTextBoxStreamType.RichText);
                        break;
                    case 2:			//选择的是.txt类型
                        richTextBox1.LoadFile(openFileDialog1.FileName,
                            RichTextBoxStreamType.PlainText);
                        break;
                }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "RTF File(*.rtf)|*.RTF|TXT FILE(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() ==
                System.Windows.Forms.DialogResult.OK)
                switch (openFileDialog1.FilterIndex)
                {
                    case 1:			//选择的是.rtf类型
                        richTextBox1.SaveFile(saveFileDialog1.FileName,
                            RichTextBoxStreamType.RichText);
                        break;
                    case 2:		//选择的是.txt类型
                        richTextBox1.SaveFile(saveFileDialog1.FileName,
                            RichTextBoxStreamType.PlainText);
                        break;
                }
        }

    }
}
