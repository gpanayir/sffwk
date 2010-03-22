namespace FwkSqlTrace
{
    partial class frmMain
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.traceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEventClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEventClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTextData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApplicationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNTUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoginName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCPU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReads = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWrites = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientProcessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBinaryData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatabaseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDBUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHostName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjectType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNTDomainName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRowCounts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSessionLoginName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSourceDatabaseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSqlHandle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSuccess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTargetLoginName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTargetUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.connictionFormComponent1 = new Fwk.DataBase.CustomControls.ConnictionFormComponent(this.components);
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnColCheser = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.traceBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1080, 602);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // traceBindingSource
            // 
            this.traceBindingSource.DataSource = typeof(FwkSqlTrace.Trace);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowNumber,
            this.colEventClassName,
            this.colEventClass,
            this.colTextData,
            this.colApplicationName,
            this.colNTUserName,
            this.colLoginName,
            this.colCPU,
            this.colReads,
            this.colWrites,
            this.colDuration,
            this.colClientProcessID,
            this.colSPID,
            this.colStartTime,
            this.colEndTime,
            this.colBinaryData,
            this.colDatabaseName,
            this.colDBUserName,
            this.colError,
            this.colHostName,
            this.colIsSystem,
            this.colObjectID,
            this.colObjectName,
            this.colObjectType,
            this.colNTDomainName,
            this.colRowCounts,
            this.colServerName,
            this.colSessionLoginName,
            this.colSourceDatabaseID,
            this.colSqlHandle,
            this.colState,
            this.colSuccess,
            this.colTargetLoginName,
            this.colTargetUserName,
            this.colTransactionID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Drag & Group there";
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Duration", this.colDuration, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Reads", this.colWrites, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // colRowNumber
            // 
            this.colRowNumber.FieldName = "RowNumber";
            this.colRowNumber.Name = "colRowNumber";
            this.colRowNumber.OptionsColumn.AllowEdit = false;
            // 
            // colEventClassName
            // 
            this.colEventClassName.FieldName = "EventClassName";
            this.colEventClassName.Name = "colEventClassName";
            this.colEventClassName.OptionsColumn.AllowEdit = false;
            this.colEventClassName.OptionsColumn.ReadOnly = true;
            this.colEventClassName.Visible = true;
            this.colEventClassName.VisibleIndex = 0;
            this.colEventClassName.Width = 119;
            // 
            // colEventClass
            // 
            this.colEventClass.FieldName = "EventClass";
            this.colEventClass.Name = "colEventClass";
            this.colEventClass.OptionsColumn.AllowEdit = false;
            this.colEventClass.OptionsColumn.ReadOnly = true;
            // 
            // colTextData
            // 
            this.colTextData.FieldName = "TextData";
            this.colTextData.Name = "colTextData";
            this.colTextData.OptionsColumn.AllowEdit = false;
            this.colTextData.OptionsColumn.ReadOnly = true;
            this.colTextData.Visible = true;
            this.colTextData.VisibleIndex = 1;
            this.colTextData.Width = 77;
            // 
            // colApplicationName
            // 
            this.colApplicationName.FieldName = "ApplicationName";
            this.colApplicationName.Name = "colApplicationName";
            this.colApplicationName.OptionsColumn.AllowEdit = false;
            this.colApplicationName.OptionsColumn.ReadOnly = true;
            this.colApplicationName.Visible = true;
            this.colApplicationName.VisibleIndex = 2;
            this.colApplicationName.Width = 77;
            // 
            // colNTUserName
            // 
            this.colNTUserName.FieldName = "NTUserName";
            this.colNTUserName.Name = "colNTUserName";
            this.colNTUserName.OptionsColumn.AllowEdit = false;
            this.colNTUserName.OptionsColumn.ReadOnly = true;
            this.colNTUserName.Visible = true;
            this.colNTUserName.VisibleIndex = 3;
            this.colNTUserName.Width = 77;
            // 
            // colLoginName
            // 
            this.colLoginName.FieldName = "LoginName";
            this.colLoginName.Name = "colLoginName";
            this.colLoginName.OptionsColumn.AllowEdit = false;
            this.colLoginName.OptionsColumn.ReadOnly = true;
            this.colLoginName.Visible = true;
            this.colLoginName.VisibleIndex = 4;
            this.colLoginName.Width = 77;
            // 
            // colCPU
            // 
            this.colCPU.FieldName = "CPU";
            this.colCPU.Name = "colCPU";
            this.colCPU.OptionsColumn.AllowEdit = false;
            this.colCPU.OptionsColumn.ReadOnly = true;
            this.colCPU.Visible = true;
            this.colCPU.VisibleIndex = 5;
            this.colCPU.Width = 77;
            // 
            // colReads
            // 
            this.colReads.FieldName = "Reads";
            this.colReads.Name = "colReads";
            this.colReads.OptionsColumn.AllowEdit = false;
            this.colReads.OptionsColumn.ReadOnly = true;
            this.colReads.Visible = true;
            this.colReads.VisibleIndex = 6;
            this.colReads.Width = 77;
            // 
            // colWrites
            // 
            this.colWrites.FieldName = "Writes";
            this.colWrites.Name = "colWrites";
            this.colWrites.OptionsColumn.AllowEdit = false;
            this.colWrites.OptionsColumn.ReadOnly = true;
            this.colWrites.Visible = true;
            this.colWrites.VisibleIndex = 7;
            this.colWrites.Width = 77;
            // 
            // colDuration
            // 
            this.colDuration.FieldName = "Duration";
            this.colDuration.Name = "colDuration";
            this.colDuration.OptionsColumn.AllowEdit = false;
            this.colDuration.OptionsColumn.ReadOnly = true;
            this.colDuration.Visible = true;
            this.colDuration.VisibleIndex = 8;
            this.colDuration.Width = 77;
            // 
            // colClientProcessID
            // 
            this.colClientProcessID.FieldName = "ClientProcessID";
            this.colClientProcessID.Name = "colClientProcessID";
            this.colClientProcessID.OptionsColumn.AllowEdit = false;
            this.colClientProcessID.OptionsColumn.ReadOnly = true;
            this.colClientProcessID.Visible = true;
            this.colClientProcessID.VisibleIndex = 9;
            this.colClientProcessID.Width = 77;
            // 
            // colSPID
            // 
            this.colSPID.FieldName = "SPID";
            this.colSPID.Name = "colSPID";
            this.colSPID.OptionsColumn.AllowEdit = false;
            this.colSPID.OptionsColumn.ReadOnly = true;
            this.colSPID.Visible = true;
            this.colSPID.VisibleIndex = 10;
            this.colSPID.Width = 77;
            // 
            // colStartTime
            // 
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.OptionsColumn.AllowEdit = false;
            this.colStartTime.OptionsColumn.ReadOnly = true;
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 11;
            this.colStartTime.Width = 77;
            // 
            // colEndTime
            // 
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.OptionsColumn.AllowEdit = false;
            this.colEndTime.OptionsColumn.ReadOnly = true;
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 12;
            this.colEndTime.Width = 93;
            // 
            // colBinaryData
            // 
            this.colBinaryData.FieldName = "BinaryData";
            this.colBinaryData.Name = "colBinaryData";
            this.colBinaryData.OptionsColumn.AllowEdit = false;
            this.colBinaryData.OptionsColumn.ReadOnly = true;
            // 
            // colDatabaseName
            // 
            this.colDatabaseName.FieldName = "DatabaseName";
            this.colDatabaseName.Name = "colDatabaseName";
            this.colDatabaseName.OptionsColumn.AllowEdit = false;
            this.colDatabaseName.OptionsColumn.ReadOnly = true;
            this.colDatabaseName.Visible = true;
            this.colDatabaseName.VisibleIndex = 13;
            // 
            // colDBUserName
            // 
            this.colDBUserName.FieldName = "DBUserName";
            this.colDBUserName.Name = "colDBUserName";
            this.colDBUserName.OptionsColumn.AllowEdit = false;
            this.colDBUserName.OptionsColumn.ReadOnly = true;
            this.colDBUserName.Visible = true;
            this.colDBUserName.VisibleIndex = 14;
            // 
            // colError
            // 
            this.colError.FieldName = "Error";
            this.colError.Name = "colError";
            this.colError.OptionsColumn.AllowEdit = false;
            this.colError.OptionsColumn.ReadOnly = true;
            this.colError.Visible = true;
            this.colError.VisibleIndex = 15;
            // 
            // colHostName
            // 
            this.colHostName.FieldName = "HostName";
            this.colHostName.Name = "colHostName";
            this.colHostName.OptionsColumn.AllowEdit = false;
            this.colHostName.OptionsColumn.ReadOnly = true;
            this.colHostName.Visible = true;
            this.colHostName.VisibleIndex = 16;
            // 
            // colIsSystem
            // 
            this.colIsSystem.FieldName = "IsSystem";
            this.colIsSystem.Name = "colIsSystem";
            this.colIsSystem.OptionsColumn.AllowEdit = false;
            this.colIsSystem.OptionsColumn.ReadOnly = true;
            this.colIsSystem.Visible = true;
            this.colIsSystem.VisibleIndex = 17;
            // 
            // colObjectID
            // 
            this.colObjectID.FieldName = "ObjectID";
            this.colObjectID.Name = "colObjectID";
            this.colObjectID.OptionsColumn.AllowEdit = false;
            this.colObjectID.OptionsColumn.ReadOnly = true;
            this.colObjectID.Visible = true;
            this.colObjectID.VisibleIndex = 18;
            // 
            // colObjectName
            // 
            this.colObjectName.FieldName = "ObjectName";
            this.colObjectName.Name = "colObjectName";
            this.colObjectName.OptionsColumn.AllowEdit = false;
            this.colObjectName.OptionsColumn.ReadOnly = true;
            this.colObjectName.Visible = true;
            this.colObjectName.VisibleIndex = 19;
            // 
            // colObjectType
            // 
            this.colObjectType.FieldName = "ObjectType";
            this.colObjectType.Name = "colObjectType";
            this.colObjectType.OptionsColumn.AllowEdit = false;
            this.colObjectType.OptionsColumn.ReadOnly = true;
            this.colObjectType.Visible = true;
            this.colObjectType.VisibleIndex = 20;
            // 
            // colNTDomainName
            // 
            this.colNTDomainName.FieldName = "NTDomainName";
            this.colNTDomainName.Name = "colNTDomainName";
            this.colNTDomainName.OptionsColumn.AllowEdit = false;
            this.colNTDomainName.OptionsColumn.ReadOnly = true;
            this.colNTDomainName.Visible = true;
            this.colNTDomainName.VisibleIndex = 21;
            // 
            // colRowCounts
            // 
            this.colRowCounts.FieldName = "RowCounts";
            this.colRowCounts.Name = "colRowCounts";
            this.colRowCounts.OptionsColumn.AllowEdit = false;
            this.colRowCounts.OptionsColumn.ReadOnly = true;
            this.colRowCounts.Visible = true;
            this.colRowCounts.VisibleIndex = 22;
            // 
            // colServerName
            // 
            this.colServerName.FieldName = "ServerName";
            this.colServerName.Name = "colServerName";
            this.colServerName.OptionsColumn.AllowEdit = false;
            this.colServerName.OptionsColumn.ReadOnly = true;
            this.colServerName.Visible = true;
            this.colServerName.VisibleIndex = 23;
            // 
            // colSessionLoginName
            // 
            this.colSessionLoginName.FieldName = "SessionLoginName";
            this.colSessionLoginName.Name = "colSessionLoginName";
            this.colSessionLoginName.OptionsColumn.AllowEdit = false;
            this.colSessionLoginName.OptionsColumn.ReadOnly = true;
            this.colSessionLoginName.Visible = true;
            this.colSessionLoginName.VisibleIndex = 24;
            // 
            // colSourceDatabaseID
            // 
            this.colSourceDatabaseID.FieldName = "SourceDatabaseID";
            this.colSourceDatabaseID.Name = "colSourceDatabaseID";
            this.colSourceDatabaseID.OptionsColumn.AllowEdit = false;
            this.colSourceDatabaseID.OptionsColumn.ReadOnly = true;
            this.colSourceDatabaseID.Visible = true;
            this.colSourceDatabaseID.VisibleIndex = 25;
            // 
            // colSqlHandle
            // 
            this.colSqlHandle.FieldName = "SqlHandle";
            this.colSqlHandle.Name = "colSqlHandle";
            this.colSqlHandle.OptionsColumn.AllowEdit = false;
            this.colSqlHandle.OptionsColumn.ReadOnly = true;
            this.colSqlHandle.Visible = true;
            this.colSqlHandle.VisibleIndex = 26;
            // 
            // colState
            // 
            this.colState.FieldName = "State";
            this.colState.Name = "colState";
            this.colState.OptionsColumn.AllowEdit = false;
            this.colState.OptionsColumn.ReadOnly = true;
            this.colState.Visible = true;
            this.colState.VisibleIndex = 27;
            // 
            // colSuccess
            // 
            this.colSuccess.FieldName = "Success";
            this.colSuccess.Name = "colSuccess";
            this.colSuccess.OptionsColumn.AllowEdit = false;
            this.colSuccess.OptionsColumn.ReadOnly = true;
            this.colSuccess.Visible = true;
            this.colSuccess.VisibleIndex = 28;
            // 
            // colTargetLoginName
            // 
            this.colTargetLoginName.FieldName = "TargetLoginName";
            this.colTargetLoginName.Name = "colTargetLoginName";
            this.colTargetLoginName.OptionsColumn.AllowEdit = false;
            this.colTargetLoginName.OptionsColumn.ReadOnly = true;
            this.colTargetLoginName.Visible = true;
            this.colTargetLoginName.VisibleIndex = 29;
            // 
            // colTargetUserName
            // 
            this.colTargetUserName.FieldName = "TargetUserName";
            this.colTargetUserName.Name = "colTargetUserName";
            this.colTargetUserName.OptionsColumn.AllowEdit = false;
            this.colTargetUserName.OptionsColumn.ReadOnly = true;
            this.colTargetUserName.Visible = true;
            this.colTargetUserName.VisibleIndex = 30;
            // 
            // colTransactionID
            // 
            this.colTransactionID.FieldName = "TransactionID";
            this.colTransactionID.Name = "colTransactionID";
            this.colTransactionID.OptionsColumn.AllowEdit = false;
            this.colTransactionID.OptionsColumn.ReadOnly = true;
            this.colTransactionID.Visible = true;
            this.colTransactionID.VisibleIndex = 31;
            // 
            // btnConnect
            // 
            this.btnConnect.Image = global::FwkSqlTrace.Properties.Resources.web_conect;
            this.btnConnect.Location = new System.Drawing.Point(12, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(89, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::FwkSqlTrace.Properties.Resources.refresh_16;
            this.btnRefresh.Location = new System.Drawing.Point(124, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(139, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh data";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnColCheser
            // 
            this.btnColCheser.Image = global::FwkSqlTrace.Properties.Resources.refresh_16;
            this.btnColCheser.Location = new System.Drawing.Point(618, 9);
            this.btnColCheser.Name = "btnColCheser";
            this.btnColCheser.Size = new System.Drawing.Size(139, 23);
            this.btnColCheser.TabIndex = 3;
            this.btnColCheser.Text = "Chese columns";
            this.btnColCheser.Click += new System.EventHandler(this.btnColCheser_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 652);
            this.Controls.Add(this.btnColCheser);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmMain";
            this.Text = "Trece analizer";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource traceBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colRowNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colEventClass;
        private DevExpress.XtraGrid.Columns.GridColumn colTextData;
        private DevExpress.XtraGrid.Columns.GridColumn colApplicationName;
        private DevExpress.XtraGrid.Columns.GridColumn colNTUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLoginName;
        private DevExpress.XtraGrid.Columns.GridColumn colCPU;
        private DevExpress.XtraGrid.Columns.GridColumn colReads;
        private DevExpress.XtraGrid.Columns.GridColumn colWrites;
        private DevExpress.XtraGrid.Columns.GridColumn colDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colClientProcessID;
        private DevExpress.XtraGrid.Columns.GridColumn colSPID;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colBinaryData;
        private Fwk.DataBase.CustomControls.ConnictionFormComponent connictionFormComponent1;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnColCheser;
        private DevExpress.XtraGrid.Columns.GridColumn colEventClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colDatabaseName;
        private DevExpress.XtraGrid.Columns.GridColumn colDBUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colError;
        private DevExpress.XtraGrid.Columns.GridColumn colHostName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSystem;
        private DevExpress.XtraGrid.Columns.GridColumn colObjectID;
        private DevExpress.XtraGrid.Columns.GridColumn colObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colObjectType;
        private DevExpress.XtraGrid.Columns.GridColumn colNTDomainName;
        private DevExpress.XtraGrid.Columns.GridColumn colRowCounts;
        private DevExpress.XtraGrid.Columns.GridColumn colServerName;
        private DevExpress.XtraGrid.Columns.GridColumn colSessionLoginName;
        private DevExpress.XtraGrid.Columns.GridColumn colSourceDatabaseID;
        private DevExpress.XtraGrid.Columns.GridColumn colSqlHandle;
        private DevExpress.XtraGrid.Columns.GridColumn colState;
        private DevExpress.XtraGrid.Columns.GridColumn colSuccess;
        private DevExpress.XtraGrid.Columns.GridColumn colTargetLoginName;
        private DevExpress.XtraGrid.Columns.GridColumn colTargetUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionID;
    }
}

