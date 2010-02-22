namespace Fwk.Security.ActiveDirectory.Test
{
    partial class DomainGoups
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
            this.grdDomainGroups = new System.Windows.Forms.DataGridView();
            this.cNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectDomainGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtDomainGroupName = new System.Windows.Forms.TextBox();
            this.btnFilterGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDomainGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDomainGroupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDomainGroups
            // 
            this.grdDomainGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDomainGroups.AutoGenerateColumns = false;
            this.grdDomainGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDomainGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.grdDomainGroups.DataSource = this.objectDomainGroupBindingSource;
            this.grdDomainGroups.Location = new System.Drawing.Point(3, 26);
            this.grdDomainGroups.Name = "grdDomainGroups";
            this.grdDomainGroups.Size = new System.Drawing.Size(320, 432);
            this.grdDomainGroups.TabIndex = 23;
            this.grdDomainGroups.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDomainGroups_CellClick);
            // 
            // cNDataGridViewTextBoxColumn
            // 
            this.cNDataGridViewTextBoxColumn.DataPropertyName = "CN";
            this.cNDataGridViewTextBoxColumn.HeaderText = "CN";
            this.cNDataGridViewTextBoxColumn.Name = "cNDataGridViewTextBoxColumn";
            this.cNDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 300;
            // 
            // objectDomainGroupBindingSource
            // 
            this.objectDomainGroupBindingSource.DataSource = typeof(Fwk.Security.ActiveDirectory.ADGroup);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Groups";
            // 
            // txtDomainGroupName
            // 
            this.txtDomainGroupName.Location = new System.Drawing.Point(60, 3);
            this.txtDomainGroupName.Name = "txtDomainGroupName";
            this.txtDomainGroupName.Size = new System.Drawing.Size(178, 20);
            this.txtDomainGroupName.TabIndex = 43;
            this.txtDomainGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDomainGroupName_KeyDown);
            // 
            // btnFilterGroup
            // 
            this.btnFilterGroup.BackColor = System.Drawing.Color.White;
            this.btnFilterGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterGroup.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.fwk_find;
            this.btnFilterGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilterGroup.Location = new System.Drawing.Point(260, 2);
            this.btnFilterGroup.Name = "btnFilterGroup";
            this.btnFilterGroup.Size = new System.Drawing.Size(59, 22);
            this.btnFilterGroup.TabIndex = 44;
            this.btnFilterGroup.Text = "Filter";
            this.btnFilterGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilterGroup.UseVisualStyleBackColor = false;
            this.btnFilterGroup.Click += new System.EventHandler(this.btnFilterGroup_Click);
            // 
            // DomainGoups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDomainGroupName);
            this.Controls.Add(this.btnFilterGroup);
            this.Controls.Add(this.grdDomainGroups);
            this.Name = "DomainGoups";
            this.Size = new System.Drawing.Size(326, 461);
            ((System.ComponentModel.ISupportInitialize)(this.grdDomainGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDomainGroupBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDomainGroups;
        private System.Windows.Forms.BindingSource objectDomainGroupBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn oUDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDomainGroupName;
        private System.Windows.Forms.Button btnFilterGroup;
    }
}
