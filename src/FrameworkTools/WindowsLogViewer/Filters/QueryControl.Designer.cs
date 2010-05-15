namespace WindowsLogViewer
{
    partial class QueryControl
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRefilter = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.eventLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEventImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeGenerated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWinLog = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClose.Image = global::WindowsLogViewer.Properties.Resources.close_241;
            this.btnClose.Location = new System.Drawing.Point(863, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 34);
            this.btnClose.TabIndex = 16;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::WindowsLogViewer.Properties.Resources.refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(144, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(88, 23);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRefilter
            // 
            this.btnRefilter.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRefilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefilter.Image = global::WindowsLogViewer.Properties.Resources.file_edit_16;
            this.btnRefilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefilter.Location = new System.Drawing.Point(12, 9);
            this.btnRefilter.Name = "btnRefilter";
            this.btnRefilter.Size = new System.Drawing.Size(88, 23);
            this.btnRefilter.TabIndex = 18;
            this.btnRefilter.Text = "Edit";
            this.btnRefilter.UseVisualStyleBackColor = false;
            this.btnRefilter.Click += new System.EventHandler(this.btnRefilter_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.eventLogBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(3, 50);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1});
            this.gridControl1.Size = new System.Drawing.Size(902, 664);
            this.gridControl1.TabIndex = 19;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // eventLogBindingSource
            // 
            this.eventLogBindingSource.DataSource = typeof(WindowsLogViewer.EventLog);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEventImage,
            this.colEventID,
            this.colCategory,
            this.colMachineName,
            this.colSource,
            this.colTimeGenerated,
            this.colUserName,
            this.colWinLog,
            this.colAuditMachineName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colEventImage
            // 
            this.colEventImage.FieldName = "EventImage";
            this.colEventImage.Name = "colEventImage";
            this.colEventImage.OptionsColumn.AllowEdit = false;
            this.colEventImage.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colEventImage.OptionsColumn.ReadOnly = true;
            this.colEventImage.OptionsColumn.ShowCaption = false;
            this.colEventImage.Visible = true;
            this.colEventImage.VisibleIndex = 0;
            this.colEventImage.Width = 87;
            // 
            // colEventID
            // 
            this.colEventID.FieldName = "EventID";
            this.colEventID.Name = "colEventID";
            this.colEventID.OptionsColumn.AllowEdit = false;
            this.colEventID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colEventID.OptionsColumn.ReadOnly = true;
            this.colEventID.Visible = true;
            this.colEventID.VisibleIndex = 8;
            this.colEventID.Width = 50;
            // 
            // colCategory
            // 
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.OptionsColumn.AllowEdit = false;
            this.colCategory.OptionsColumn.ReadOnly = true;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 2;
            this.colCategory.Width = 83;
            // 
            // colMachineName
            // 
            this.colMachineName.FieldName = "MachineName";
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.OptionsColumn.AllowEdit = false;
            this.colMachineName.OptionsColumn.ReadOnly = true;
            this.colMachineName.Visible = true;
            this.colMachineName.VisibleIndex = 3;
            this.colMachineName.Width = 136;
            // 
            // colSource
            // 
            this.colSource.FieldName = "Source";
            this.colSource.Name = "colSource";
            this.colSource.OptionsColumn.AllowEdit = false;
            this.colSource.OptionsColumn.ReadOnly = true;
            this.colSource.Visible = true;
            this.colSource.VisibleIndex = 4;
            this.colSource.Width = 74;
            // 
            // colTimeGenerated
            // 
            this.colTimeGenerated.FieldName = "TimeGenerated";
            this.colTimeGenerated.Name = "colTimeGenerated";
            this.colTimeGenerated.OptionsColumn.AllowEdit = false;
            this.colTimeGenerated.OptionsColumn.ReadOnly = true;
            this.colTimeGenerated.Visible = true;
            this.colTimeGenerated.VisibleIndex = 5;
            this.colTimeGenerated.Width = 116;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.ReadOnly = true;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 6;
            this.colUserName.Width = 95;
            // 
            // colWinLog
            // 
            this.colWinLog.FieldName = "WinLog";
            this.colWinLog.Name = "colWinLog";
            this.colWinLog.OptionsColumn.AllowEdit = false;
            this.colWinLog.OptionsColumn.ReadOnly = true;
            this.colWinLog.Visible = true;
            this.colWinLog.VisibleIndex = 7;
            this.colWinLog.Width = 40;
            // 
            // colAuditMachineName
            // 
            this.colAuditMachineName.FieldName = "AuditMachineName";
            this.colAuditMachineName.Name = "colAuditMachineName";
            this.colAuditMachineName.OptionsColumn.AllowEdit = false;
            this.colAuditMachineName.OptionsColumn.ReadOnly = true;
            this.colAuditMachineName.Visible = true;
            this.colAuditMachineName.VisibleIndex = 1;
            this.colAuditMachineName.Width = 119;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // QueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnRefilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Name = "QueryControl";
            this.Size = new System.Drawing.Size(908, 641);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRefilter;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.BindingSource eventLogBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEventImage;
        private DevExpress.XtraGrid.Columns.GridColumn colEventID;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineName;
        private DevExpress.XtraGrid.Columns.GridColumn colSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeGenerated;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colWinLog;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditMachineName;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
    }
}
