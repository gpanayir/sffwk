namespace Fwk.ServiceManagement.Tools.Win32
{
    /// <summary>
    /// 
    /// </summary>
    partial class UCBServiceGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCBServiceGrid));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fwkCellStyleGreenFlat1 = new Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkCellStyleGreenFlat(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.txtXmlFilePath = new System.Windows.Forms.ToolStripTextBox();
            this.cmbSearchType = new System.Windows.Forms.ToolStripComboBox();
            this.fwkCellStyleMarronFlat1 = new Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkCellStyleMarronFlat(this.components);
            this.grdServices = new Fwk.Bases.FrontEnd.Controls.FwkGrid.FwkGenericDataGridView(this.components);
            this.serviceConfigurationCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbFilterTransactionalBehaviour = new Fwk.Bases.FrontEnd.Controls.FwkFlatComboBox();
            this.cmbFilterIsolationLevel = new Fwk.Bases.FrontEnd.Controls.FwkFlatComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fwkMessageViewComponent1 = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionalBehaviourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.availableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isolationLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceConfigurationCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFilter,
            this.txtXmlFilePath,
            this.cmbSearchType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(659, 25);
            this.toolStrip1.TabIndex = 38;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Transparent;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Gainsboro;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(51, 22);
            this.btnFilter.Text = "Filter";
            this.btnFilter.ToolTipText = "Filter ";
            this.btnFilter.Click += new System.EventHandler(this.toolStripButtonFilter_Click);
            // 
            // txtXmlFilePath
            // 
            this.txtXmlFilePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtXmlFilePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtXmlFilePath.Name = "txtXmlFilePath";
            this.txtXmlFilePath.Size = new System.Drawing.Size(200, 25);
            this.txtXmlFilePath.ToolTipText = "Name of service";
            this.txtXmlFilePath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtXmlFilePath_KeyDown);
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(121, 25);
            this.cmbSearchType.ToolTipText = "Search type";
            this.cmbSearchType.Click += new System.EventHandler(this.cmbSearchType_Click);
            // 
            // grdServices
            // 
            this.grdServices.AllowUserToDeleteRows = false;
            this.grdServices.AllowUserToOrderColumns = true;
            this.grdServices.AllowUserToResizeColumns = false;
            this.grdServices.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.grdServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdServices.AutoGenerateColumns = false;
            this.grdServices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(249)))), ((int)(((byte)(234)))));
            this.grdServices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Sienna;
            this.grdServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.transactionalBehaviourDataGridViewTextBoxColumn,
            this.auditDataGridViewCheckBoxColumn,
            this.availableDataGridViewCheckBoxColumn,
            this.isolationLevelDataGridViewTextBoxColumn,
            this.CreatedDateTime,
            this.CreatedUserName});
            this.grdServices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grdServices.CustomGridProperties.AllowAddRows = true;
            this.grdServices.CustomGridProperties.AllowDeleteRows = false;
            this.grdServices.CustomGridProperties.AllowOrderColumns = true;
            this.grdServices.CustomGridProperties.AllowResizeColumns = false;
            this.grdServices.CustomGridProperties.AllowResizeRows = false;
            this.grdServices.CustomGridProperties.MarckEditedRow = false;
            this.grdServices.CustomGridProperties.RowEditedColor = System.Drawing.Color.Salmon;
            this.grdServices.CustomGridProperties.RowErrorColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdServices.CustomGridProperties.RowHeaderVisible = false;
            this.grdServices.DataSource = this.serviceConfigurationCollectionBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdServices.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdServices.EnableHeadersVisualStyles = false;
            this.grdServices.GridColor = System.Drawing.Color.White;
            this.grdServices.Location = new System.Drawing.Point(2, 63);
            this.grdServices.MultiSelect = false;
            this.grdServices.Name = "grdServices";
            this.grdServices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdServices.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdServices.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grdServices.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdServices.Size = new System.Drawing.Size(656, 204);
            this.grdServices.TabIndex = 39;
            this.grdServices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdServices_CellClick);
            // 
            // serviceConfigurationCollectionBindingSource
            // 
            this.serviceConfigurationCollectionBindingSource.DataSource = typeof(Fwk.Bases.ServiceConfigurationCollection);
            // 
            // cmbFilterTransactionalBehaviour
            // 
            this.cmbFilterTransactionalBehaviour.ActiveArrowColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbFilterTransactionalBehaviour.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbFilterTransactionalBehaviour.ActiveButtonColor = System.Drawing.SystemColors.ControlDark;
            this.cmbFilterTransactionalBehaviour.AllowEmptyTextValue = false;
            this.cmbFilterTransactionalBehaviour.AutoComplete = false;
            this.cmbFilterTransactionalBehaviour.ErrorIconRightToLeft = false;
            this.cmbFilterTransactionalBehaviour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilterTransactionalBehaviour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterTransactionalBehaviour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.cmbFilterTransactionalBehaviour.FormattingEnabled = true;
            this.cmbFilterTransactionalBehaviour.InactiveArrowColor = System.Drawing.SystemColors.ControlDark;
            this.cmbFilterTransactionalBehaviour.InactiveBorderColor = System.Drawing.SystemColors.ControlDark;
            this.cmbFilterTransactionalBehaviour.InactiveButtonColor = System.Drawing.SystemColors.Control;
            this.cmbFilterTransactionalBehaviour.Location = new System.Drawing.Point(131, 28);
            this.cmbFilterTransactionalBehaviour.Name = "cmbFilterTransactionalBehaviour";
            this.cmbFilterTransactionalBehaviour.NullTextValue = null;
            this.cmbFilterTransactionalBehaviour.ReadOnly = false;
            this.cmbFilterTransactionalBehaviour.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.cmbFilterTransactionalBehaviour.Required = false;
            this.cmbFilterTransactionalBehaviour.RequiredErrorText = null;
            this.cmbFilterTransactionalBehaviour.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterTransactionalBehaviour.TabIndex = 40;
            this.cmbFilterTransactionalBehaviour.SelectedIndexChanged += new System.EventHandler(this.cmbFilterTransactionalBehaviour_SelectedIndexChanged);
            // 
            // cmbFilterIsolationLevel
            // 
            this.cmbFilterIsolationLevel.ActiveArrowColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbFilterIsolationLevel.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbFilterIsolationLevel.ActiveButtonColor = System.Drawing.SystemColors.ControlDark;
            this.cmbFilterIsolationLevel.AllowEmptyTextValue = false;
            this.cmbFilterIsolationLevel.AutoComplete = false;
            this.cmbFilterIsolationLevel.ErrorIconRightToLeft = false;
            this.cmbFilterIsolationLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilterIsolationLevel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterIsolationLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.cmbFilterIsolationLevel.FormattingEnabled = true;
            this.cmbFilterIsolationLevel.InactiveArrowColor = System.Drawing.SystemColors.ControlDark;
            this.cmbFilterIsolationLevel.InactiveBorderColor = System.Drawing.SystemColors.ControlDark;
            this.cmbFilterIsolationLevel.InactiveButtonColor = System.Drawing.SystemColors.Control;
            this.cmbFilterIsolationLevel.Location = new System.Drawing.Point(364, 28);
            this.cmbFilterIsolationLevel.Name = "cmbFilterIsolationLevel";
            this.cmbFilterIsolationLevel.NullTextValue = null;
            this.cmbFilterIsolationLevel.ReadOnly = false;
            this.cmbFilterIsolationLevel.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.cmbFilterIsolationLevel.Required = false;
            this.cmbFilterIsolationLevel.RequiredErrorText = null;
            this.cmbFilterIsolationLevel.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterIsolationLevel.TabIndex = 41;
            this.cmbFilterIsolationLevel.SelectedIndexChanged += new System.EventHandler(this.cmbFilterIsolationLevel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Isolation Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Transactional Behaviour";
            // 
            // fwkMessageViewComponent1
            // 
            this.fwkMessageViewComponent1.BackColor = System.Drawing.Color.White;
            this.fwkMessageViewComponent1.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageViewComponent1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewComponent1.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewComponent1.TextMessageColor = System.Drawing.Color.White;
            this.fwkMessageViewComponent1.TextMessageForeColor = System.Drawing.Color.Black;
            this.fwkMessageViewComponent1.Title = "Message";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 150;
            // 
            // transactionalBehaviourDataGridViewTextBoxColumn
            // 
            this.transactionalBehaviourDataGridViewTextBoxColumn.DataPropertyName = "TransactionalBehaviour";
            this.transactionalBehaviourDataGridViewTextBoxColumn.HeaderText = "TransactionalBehaviour";
            this.transactionalBehaviourDataGridViewTextBoxColumn.Name = "transactionalBehaviourDataGridViewTextBoxColumn";
            this.transactionalBehaviourDataGridViewTextBoxColumn.Width = 70;
            // 
            // auditDataGridViewCheckBoxColumn
            // 
            this.auditDataGridViewCheckBoxColumn.DataPropertyName = "Audit";
            this.auditDataGridViewCheckBoxColumn.HeaderText = "Audit";
            this.auditDataGridViewCheckBoxColumn.Name = "auditDataGridViewCheckBoxColumn";
            this.auditDataGridViewCheckBoxColumn.Width = 70;
            // 
            // availableDataGridViewCheckBoxColumn
            // 
            this.availableDataGridViewCheckBoxColumn.DataPropertyName = "Available";
            this.availableDataGridViewCheckBoxColumn.HeaderText = "Available";
            this.availableDataGridViewCheckBoxColumn.Name = "availableDataGridViewCheckBoxColumn";
            this.availableDataGridViewCheckBoxColumn.Width = 70;
            // 
            // isolationLevelDataGridViewTextBoxColumn
            // 
            this.isolationLevelDataGridViewTextBoxColumn.DataPropertyName = "IsolationLevel";
            this.isolationLevelDataGridViewTextBoxColumn.HeaderText = "IsolationLevel";
            this.isolationLevelDataGridViewTextBoxColumn.Name = "isolationLevelDataGridViewTextBoxColumn";
            this.isolationLevelDataGridViewTextBoxColumn.Width = 70;
            // 
            // CreatedDateTime
            // 
            this.CreatedDateTime.DataPropertyName = "CreatedDateTime";
            this.CreatedDateTime.HeaderText = "Date";
            this.CreatedDateTime.Name = "CreatedDateTime";
            this.CreatedDateTime.Width = 70;
            // 
            // CreatedUserName
            // 
            this.CreatedUserName.DataPropertyName = "CreatedUserName";
            this.CreatedUserName.HeaderText = "User";
            this.CreatedUserName.Name = "CreatedUserName";
            this.CreatedUserName.Width = 70;
            // 
            // UCBServiceGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFilterIsolationLevel);
            this.Controls.Add(this.cmbFilterTransactionalBehaviour);
            this.Controls.Add(this.grdServices);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UCBServiceGrid";
            this.Size = new System.Drawing.Size(659, 272);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceConfigurationCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtXmlFilePath;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkCellStyleGreenFlat fwkCellStyleGreenFlat1;
        private Fwk.Bases.FrontEnd.Controls.FwkGrid.Design.FwkCellStyleMarronFlat fwkCellStyleMarronFlat1;
        private System.Windows.Forms.ToolStripComboBox cmbSearchType;
        private Fwk.Bases.FrontEnd.Controls.FwkGrid.FwkGenericDataGridView grdServices;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatComboBox cmbFilterTransactionalBehaviour;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatComboBox cmbFilterIsolationLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewComponent1;
        private System.Windows.Forms.BindingSource serviceConfigurationCollectionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionalBehaviourDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn auditDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn availableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isolationLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedUserName;
    }
}
