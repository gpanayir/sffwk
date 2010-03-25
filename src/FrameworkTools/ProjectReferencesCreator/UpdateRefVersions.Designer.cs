namespace ProjectReferencesCreator
{
    partial class UpdateRefVersions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.ReferenceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prjNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrjPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceFileListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.referenceFileListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imageDataGridViewImageColumn,
            this.ReferenceType,
            this.prjNameDataGridViewTextBoxColumn,
            this.PrjPath,
            this.ErrorMessage});
            this.dataGridView1.DataSource = this.referenceFileListBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1018, 631);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // imageDataGridViewImageColumn
            // 
            this.imageDataGridViewImageColumn.DataPropertyName = "Image";
            this.imageDataGridViewImageColumn.HeaderText = "";
            this.imageDataGridViewImageColumn.Name = "imageDataGridViewImageColumn";
            this.imageDataGridViewImageColumn.ReadOnly = true;
            this.imageDataGridViewImageColumn.Width = 50;
            // 
            // ReferenceType
            // 
            this.ReferenceType.DataPropertyName = "ReferenceType";
            this.ReferenceType.HeaderText = "ReferenceType";
            this.ReferenceType.Name = "ReferenceType";
            this.ReferenceType.ReadOnly = true;
            // 
            // prjNameDataGridViewTextBoxColumn
            // 
            this.prjNameDataGridViewTextBoxColumn.DataPropertyName = "PrjName";
            this.prjNameDataGridViewTextBoxColumn.HeaderText = "Project";
            this.prjNameDataGridViewTextBoxColumn.Name = "prjNameDataGridViewTextBoxColumn";
            this.prjNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.prjNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // PrjPath
            // 
            this.PrjPath.DataPropertyName = "PrjPath";
            this.PrjPath.HeaderText = "Path";
            this.PrjPath.Name = "PrjPath";
            this.PrjPath.ReadOnly = true;
            this.PrjPath.Width = 500;
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.DataPropertyName = "ErrorMessage";
            this.ErrorMessage.HeaderText = "ErrorMessage";
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.ReadOnly = true;
            this.ErrorMessage.Width = 500;
            // 
            // referenceFileListBindingSource
            // 
            this.referenceFileListBindingSource.DataSource = typeof(ProjectReferencesCreator.ReferenceFileList);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ReferenceType";
            this.dataGridViewTextBoxColumn1.HeaderText = "ReferenceType";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // UpdateRefVersions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "UpdateRefVersions";
            this.Size = new System.Drawing.Size(1018, 631);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.referenceFileListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource referenceFileListBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn imageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn prjNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrjPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
