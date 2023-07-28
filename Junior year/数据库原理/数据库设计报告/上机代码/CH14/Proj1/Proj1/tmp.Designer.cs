namespace Proj1
{
    partial class tmp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sMKDataSet1 = new Proj1.SMKDataSet1();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new Proj1.SMKDataSet1TableAdapters.ProductTableAdapter();
            this.商品编号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名称DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.分类DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.子类DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单价DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.库存数量DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMKDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.商品编号DataGridViewTextBoxColumn,
            this.商品名称DataGridViewTextBoxColumn,
            this.分类DataGridViewTextBoxColumn,
            this.子类DataGridViewTextBoxColumn,
            this.单价DataGridViewTextBoxColumn,
            this.库存数量DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.productBindingSource;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(424, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // sMKDataSet1
            // 
            this.sMKDataSet1.DataSetName = "SMKDataSet1";
            this.sMKDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.sMKDataSet1;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // 商品编号DataGridViewTextBoxColumn
            // 
            this.商品编号DataGridViewTextBoxColumn.DataPropertyName = "商品编号";
            this.商品编号DataGridViewTextBoxColumn.HeaderText = "商品编号";
            this.商品编号DataGridViewTextBoxColumn.Name = "商品编号DataGridViewTextBoxColumn";
            this.商品编号DataGridViewTextBoxColumn.Width = 78;
            // 
            // 商品名称DataGridViewTextBoxColumn
            // 
            this.商品名称DataGridViewTextBoxColumn.DataPropertyName = "商品名称";
            this.商品名称DataGridViewTextBoxColumn.HeaderText = "商品名称";
            this.商品名称DataGridViewTextBoxColumn.Name = "商品名称DataGridViewTextBoxColumn";
            // 
            // 分类DataGridViewTextBoxColumn
            // 
            this.分类DataGridViewTextBoxColumn.DataPropertyName = "分类";
            this.分类DataGridViewTextBoxColumn.HeaderText = "分类";
            this.分类DataGridViewTextBoxColumn.Name = "分类DataGridViewTextBoxColumn";
            // 
            // 子类DataGridViewTextBoxColumn
            // 
            this.子类DataGridViewTextBoxColumn.DataPropertyName = "子类";
            this.子类DataGridViewTextBoxColumn.HeaderText = "子类";
            this.子类DataGridViewTextBoxColumn.Name = "子类DataGridViewTextBoxColumn";
            // 
            // 单价DataGridViewTextBoxColumn
            // 
            this.单价DataGridViewTextBoxColumn.DataPropertyName = "单价";
            this.单价DataGridViewTextBoxColumn.HeaderText = "单价";
            this.单价DataGridViewTextBoxColumn.Name = "单价DataGridViewTextBoxColumn";
            // 
            // 库存数量DataGridViewTextBoxColumn
            // 
            this.库存数量DataGridViewTextBoxColumn.DataPropertyName = "库存数量";
            this.库存数量DataGridViewTextBoxColumn.HeaderText = "库存数量";
            this.库存数量DataGridViewTextBoxColumn.Name = "库存数量DataGridViewTextBoxColumn";
            // 
            // tmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 335);
            this.Controls.Add(this.dataGridView1);
            this.Name = "tmp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tmp";
            this.Load += new System.EventHandler(this.tmp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMKDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private SMKDataSet1 sMKDataSet1;
        private System.Windows.Forms.BindingSource productBindingSource;
        private SMKDataSet1TableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品编号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名称DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 分类DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 子类DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单价DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 库存数量DataGridViewTextBoxColumn;
    }
}