namespace Exp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.MCut = new System.Windows.Forms.ToolStripMenuItem();
            this.MCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.MDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.MColor = new System.Windows.Forms.ToolStripMenuItem();
            this.MFont = new System.Windows.Forms.ToolStripMenuItem();
            this.MHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(0, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(754, 471);
            this.textBox1.TabIndex = 5;
            // 
            // MFile
            // 
            this.MFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNew,
            this.MOpen,
            this.MSave,
            this.MSaveAs,
            this.toolStripSeparator1,
            this.MExit});
            this.MFile.Name = "MFile";
            this.MFile.Size = new System.Drawing.Size(54, 20);
            this.MFile.Text = "文件";
            // 
            // MNew
            // 
            this.MNew.Name = "MNew";
            this.MNew.Size = new System.Drawing.Size(152, 22);
            this.MNew.Text = "新建";
            this.MNew.Click += new System.EventHandler(this.MNew_Click);
            // 
            // MOpen
            // 
            this.MOpen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MOpen.Name = "MOpen";
            this.MOpen.Size = new System.Drawing.Size(152, 22);
            this.MOpen.Text = "打开";
            this.MOpen.Click += new System.EventHandler(this.MOpen_Click);
            // 
            // MSave
            // 
            this.MSave.Name = "MSave";
            this.MSave.Size = new System.Drawing.Size(152, 22);
            this.MSave.Text = "保存";
            this.MSave.Click += new System.EventHandler(this.MSave_Click);
            // 
            // MSaveAs
            // 
            this.MSaveAs.Name = "MSaveAs";
            this.MSaveAs.Size = new System.Drawing.Size(152, 22);
            this.MSaveAs.Text = "另存为";
            this.MSaveAs.Click += new System.EventHandler(this.MSaveAs_Click);
            // 
            // MExit
            // 
            this.MExit.Name = "MExit";
            this.MExit.Size = new System.Drawing.Size(152, 22);
            this.MExit.Text = "退出";
            this.MExit.Click += new System.EventHandler(this.MExit_Click);
            // 
            // MEdit
            // 
            this.MEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MUndo,
            this.MCut,
            this.MCopy,
            this.MPaste,
            this.MDelete,
            this.MSelectAll});
            this.MEdit.Name = "MEdit";
            this.MEdit.Size = new System.Drawing.Size(54, 20);
            this.MEdit.Text = "编辑";
            // 
            // MUndo
            // 
            this.MUndo.Name = "MUndo";
            this.MUndo.Size = new System.Drawing.Size(152, 22);
            this.MUndo.Text = "撤销";
            this.MUndo.Click += new System.EventHandler(this.MUndo_Click);
            // 
            // MCut
            // 
            this.MCut.Name = "MCut";
            this.MCut.Size = new System.Drawing.Size(152, 22);
            this.MCut.Text = "剪切";
            this.MCut.Click += new System.EventHandler(this.MCut_Click);
            // 
            // MCopy
            // 
            this.MCopy.Name = "MCopy";
            this.MCopy.Size = new System.Drawing.Size(152, 22);
            this.MCopy.Text = "复制";
            this.MCopy.Click += new System.EventHandler(this.MCopy_Click);
            // 
            // MPaste
            // 
            this.MPaste.Name = "MPaste";
            this.MPaste.Size = new System.Drawing.Size(152, 22);
            this.MPaste.Text = "粘贴";
            this.MPaste.Click += new System.EventHandler(this.MPaste_Click);
            // 
            // MDelete
            // 
            this.MDelete.Name = "MDelete";
            this.MDelete.Size = new System.Drawing.Size(152, 22);
            this.MDelete.Text = "删除";
            this.MDelete.Click += new System.EventHandler(this.MDelete_Click);
            // 
            // MSelectAll
            // 
            this.MSelectAll.Name = "MSelectAll";
            this.MSelectAll.Size = new System.Drawing.Size(152, 22);
            this.MSelectAll.Text = "全选";
            this.MSelectAll.Click += new System.EventHandler(this.MSelectAll_Click);
            // 
            // MFormat
            // 
            this.MFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MColor,
            this.toolStripSeparator2,
            this.MFont});
            this.MFormat.Name = "MFormat";
            this.MFormat.Size = new System.Drawing.Size(54, 20);
            this.MFormat.Text = "格式";
            // 
            // MColor
            // 
            this.MColor.Name = "MColor";
            this.MColor.Size = new System.Drawing.Size(152, 22);
            this.MColor.Text = "颜色设置";
            this.MColor.Click += new System.EventHandler(this.MColor_Click);
            // 
            // MFont
            // 
            this.MFont.Name = "MFont";
            this.MFont.Size = new System.Drawing.Size(152, 22);
            this.MFont.Text = "字体设置";
            this.MFont.Click += new System.EventHandler(this.MFont_Click);
            // 
            // MHelp
            // 
            this.MHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.MAbout});
            this.MHelp.Name = "MHelp";
            this.MHelp.Size = new System.Drawing.Size(54, 20);
            this.MHelp.Text = "帮助";
            // 
            // MAbout
            // 
            this.MAbout.Name = "MAbout";
            this.MAbout.Size = new System.Drawing.Size(152, 22);
            this.MAbout.Text = "关于...";
            this.MAbout.Click += new System.EventHandler(this.MAbout_Click);
            // 
            // MMenu
            // 
            this.MMenu.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MFile,
            this.MEdit,
            this.MFormat,
            this.MHelp});
            this.MMenu.Location = new System.Drawing.Point(0, 0);
            this.MMenu.Name = "MMenu";
            this.MMenu.Size = new System.Drawing.Size(754, 24);
            this.MMenu.TabIndex = 3;
            this.MMenu.Text = "menuStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 499);
            this.Controls.Add(this.MMenu);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MMenu.ResumeLayout(false);
            this.MMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem MFile;
        private System.Windows.Forms.ToolStripMenuItem MNew;
        private System.Windows.Forms.ToolStripMenuItem MOpen;
        private System.Windows.Forms.ToolStripMenuItem MSave;
        private System.Windows.Forms.ToolStripMenuItem MSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MExit;
        private System.Windows.Forms.ToolStripMenuItem MEdit;
        private System.Windows.Forms.ToolStripMenuItem MUndo;
        private System.Windows.Forms.ToolStripMenuItem MCut;
        private System.Windows.Forms.ToolStripMenuItem MCopy;
        private System.Windows.Forms.ToolStripMenuItem MPaste;
        private System.Windows.Forms.ToolStripMenuItem MDelete;
        private System.Windows.Forms.ToolStripMenuItem MSelectAll;
        private System.Windows.Forms.ToolStripMenuItem MFormat;
        private System.Windows.Forms.ToolStripMenuItem MColor;
        private System.Windows.Forms.ToolStripMenuItem MFont;
        private System.Windows.Forms.ToolStripMenuItem MHelp;
        private System.Windows.Forms.ToolStripMenuItem MAbout;
        private System.Windows.Forms.MenuStrip MMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

