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
            this.connictionFormComponent1 = new Fwk.DataBase.CustomControls.ConnictionFormComponent(this.components);
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.traceBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(841, 423);
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
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowNumber,
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
            this.colBinaryData});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colRowNumber
            // 
            this.colRowNumber.FieldName = "RowNumber";
            this.colRowNumber.Name = "colRowNumber";
            this.colRowNumber.Visible = true;
            this.colRowNumber.VisibleIndex = 0;
            // 
            // colEventClass
            // 
            this.colEventClass.FieldName = "EventClass";
            this.colEventClass.Name = "colEventClass";
            this.colEventClass.Visible = true;
            this.colEventClass.VisibleIndex = 1;
            // 
            // colTextData
            // 
            this.colTextData.FieldName = "TextData";
            this.colTextData.Name = "colTextData";
            this.colTextData.Visible = true;
            this.colTextData.VisibleIndex = 2;
            // 
            // colApplicationName
            // 
            this.colApplicationName.FieldName = "ApplicationName";
            this.colApplicationName.Name = "colApplicationName";
            this.colApplicationName.Visible = true;
            this.colApplicationName.VisibleIndex = 3;
            // 
            // colNTUserName
            // 
            this.colNTUserName.FieldName = "NTUserName";
            this.colNTUserName.Name = "colNTUserName";
            this.colNTUserName.Visible = true;
            this.colNTUserName.VisibleIndex = 4;
            // 
            // colLoginName
            // 
            this.colLoginName.FieldName = "LoginName";
            this.colLoginName.Name = "colLoginName";
            this.colLoginName.Visible = true;
            this.colLoginName.VisibleIndex = 5;
            // 
            // colCPU
            // 
            this.colCPU.FieldName = "CPU";
            this.colCPU.Name = "colCPU";
            this.colCPU.Visible = true;
            this.colCPU.VisibleIndex = 6;
            // 
            // colReads
            // 
            this.colReads.FieldName = "Reads";
            this.colReads.Name = "colReads";
            this.colReads.Visible = true;
            this.colReads.VisibleIndex = 7;
            // 
            // colWrites
            // 
            this.colWrites.FieldName = "Writes";
            this.colWrites.Name = "colWrites";
            this.colWrites.Visible = true;
            this.colWrites.VisibleIndex = 8;
            // 
            // colDuration
            // 
            this.colDuration.FieldName = "Duration";
            this.colDuration.Name = "colDuration";
            this.colDuration.Visible = true;
            this.colDuration.VisibleIndex = 9;
            // 
            // colClientProcessID
            // 
            this.colClientProcessID.FieldName = "ClientProcessID";
            this.colClientProcessID.Name = "colClientProcessID";
            this.colClientProcessID.Visible = true;
            this.colClientProcessID.VisibleIndex = 10;
            // 
            // colSPID
            // 
            this.colSPID.FieldName = "SPID";
            this.colSPID.Name = "colSPID";
            this.colSPID.Visible = true;
            this.colSPID.VisibleIndex = 11;
            // 
            // colStartTime
            // 
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 12;
            // 
            // colEndTime
            // 
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 13;
            // 
            // colBinaryData
            // 
            this.colBinaryData.FieldName = "BinaryData";
            this.colBinaryData.Name = "colBinaryData";
            this.colBinaryData.Visible = true;
            this.colBinaryData.VisibleIndex = 14;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 483);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmMain";
            this.Text = "Form1";
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
    }
}

