namespace Proj2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.op = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addop = new System.Windows.Forms.ToolStripMenuItem();
            this.subop = new System.Windows.Forms.ToolStripMenuItem();
            this.multop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.divop = new System.Windows.Forms.ToolStripMenuItem();
            this.op.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(141, 89);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(60, 21);
            this.textBox3.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(65, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "运算结果";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(205, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(60, 21);
            this.textBox2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(152, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "整数2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 21);
            this.textBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "整数1";
            // 
            // op
            // 
            this.op.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addop,
            this.subop,
            this.multop,
            this.toolStripSeparator1,
            this.divop});
            this.op.Name = "contextMenuStrip1";
            this.op.Size = new System.Drawing.Size(101, 98);
            this.op.Opened += new System.EventHandler(this.op_Opened);
            // 
            // addop
            // 
            this.addop.Name = "addop";
            this.addop.Size = new System.Drawing.Size(152, 22);
            this.addop.Text = "加法";
            this.addop.Click += new System.EventHandler(this.addop_Click);
            // 
            // subop
            // 
            this.subop.Name = "subop";
            this.subop.Size = new System.Drawing.Size(152, 22);
            this.subop.Text = "减法";
            this.subop.Click += new System.EventHandler(this.subop_Click);
            // 
            // multop
            // 
            this.multop.Name = "multop";
            this.multop.Size = new System.Drawing.Size(152, 22);
            this.multop.Text = "乘法";
            this.multop.Click += new System.EventHandler(this.multop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // divop
            // 
            this.divop.Name = "divop";
            this.divop.Size = new System.Drawing.Size(152, 22);
            this.divop.Text = "除法";
            this.divop.Click += new System.EventHandler(this.divop_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 173);
            this.ContextMenuStrip = this.op;
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.op.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip op;
        private System.Windows.Forms.ToolStripMenuItem addop;
        private System.Windows.Forms.ToolStripMenuItem subop;
        private System.Windows.Forms.ToolStripMenuItem multop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem divop;
    }
}