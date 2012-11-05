namespace WindowsLogViewer
{
    partial class AuditControl
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
            this.EventLogControl = new System.Diagnostics.EventLog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWinLog = new System.Windows.Forms.Label();
            this.lblAuditedMachine = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.pictureStatus = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ImageEvent = new System.Windows.Forms.DataGridViewImageColumn();
            this.entryTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeGeneratedDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instanceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLogEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eventLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EventLogControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // EventLogControl
            // 
            this.EventLogControl.SynchronizingObject = this;
            this.EventLogControl.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.EventLogControl_EntryWritten);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(710, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Log";
            // 
            // lblWinLog
            // 
            this.lblWinLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWinLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWinLog.Location = new System.Drawing.Point(750, 5);
            this.lblWinLog.Name = "lblWinLog";
            this.lblWinLog.Size = new System.Drawing.Size(157, 22);
            this.lblWinLog.TabIndex = 11;
            // 
            // lblAuditedMachine
            // 
            this.lblAuditedMachine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAuditedMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAuditedMachine.Location = new System.Drawing.Point(530, 7);
            this.lblAuditedMachine.Name = "lblAuditedMachine";
            this.lblAuditedMachine.Size = new System.Drawing.Size(157, 22);
            this.lblAuditedMachine.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(474, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Server";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lblStatus.Location = new System.Drawing.Point(89, 752);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(62, 17);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Paused";
            // 
            // pictureStatus
            // 
            this.pictureStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureStatus.Image = global::WindowsLogViewer.Properties.Resources.ball_yellow;
            this.pictureStatus.InitialImage = null;
            this.pictureStatus.Location = new System.Drawing.Point(7, 748);
            this.pictureStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureStatus.Name = "pictureStatus";
            this.pictureStatus.Size = new System.Drawing.Size(23, 21);
            this.pictureStatus.TabIndex = 17;
            this.pictureStatus.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Image = global::WindowsLogViewer.Properties.Resources.close_241;
            this.btnClose.Location = new System.Drawing.Point(931, -1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 42);
            this.btnClose.TabIndex = 15;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.BackColor = System.Drawing.Color.White;
            this.btnClearLogs.Enabled = false;
            this.btnClearLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLogs.Image = global::WindowsLogViewer.Properties.Resources.del_16;
            this.btnClearLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearLogs.Location = new System.Drawing.Point(276, 4);
            this.btnClearLogs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(146, 28);
            this.btnClearLogs.TabIndex = 14;
            this.btnClearLogs.Text = "Clear all logs";
            this.btnClearLogs.UseVisualStyleBackColor = false;
            this.btnClearLogs.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Image = global::WindowsLogViewer.Properties.Resources.play;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(16, 5);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(103, 28);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(30, 751);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Status :";
            // 
            // lblError
            // 
            this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.DimGray;
            this.lblError.Location = new System.Drawing.Point(173, 751);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(125, 17);
            this.lblError.TabIndex = 19;
            this.lblError.Text = " fwk framework 3.1";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.entryTypeDataGridViewTextBoxColumn,
            this.machineNameDataGridViewTextBoxColumn1,
            this.timeGeneratedDataGridViewTextBoxColumn1,
            this.sourceDataGridViewTextBoxColumn1,
            this.userNameDataGridViewTextBoxColumn1,
            this.categoryDataGridViewTextBoxColumn1,
            this.eventIDDataGridViewTextBoxColumn1,
            this.instanceIdDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn1,
            this.ImageEvent});
            this.dataGridView2.DataSource = this.eventLogEntryBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(3, 41);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(964, 650);
            this.dataGridView2.TabIndex = 20;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // ImageEvent
            // 
            this.ImageEvent.HeaderText = "";
            this.ImageEvent.Name = "ImageEvent";
            this.ImageEvent.ReadOnly = true;
            this.ImageEvent.Width = 50;
            // 
            // entryTypeDataGridViewTextBoxColumn
            // 
            this.entryTypeDataGridViewTextBoxColumn.DataPropertyName = "EntryType";
            this.entryTypeDataGridViewTextBoxColumn.HeaderText = "EntryType";
            this.entryTypeDataGridViewTextBoxColumn.Name = "entryTypeDataGridViewTextBoxColumn";
            this.entryTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // machineNameDataGridViewTextBoxColumn1
            // 
            this.machineNameDataGridViewTextBoxColumn1.DataPropertyName = "MachineName";
            this.machineNameDataGridViewTextBoxColumn1.HeaderText = "MachineName";
            this.machineNameDataGridViewTextBoxColumn1.Name = "machineNameDataGridViewTextBoxColumn1";
            this.machineNameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // timeGeneratedDataGridViewTextBoxColumn1
            // 
            this.timeGeneratedDataGridViewTextBoxColumn1.DataPropertyName = "TimeGenerated";
            this.timeGeneratedDataGridViewTextBoxColumn1.HeaderText = "TimeGenerated";
            this.timeGeneratedDataGridViewTextBoxColumn1.Name = "timeGeneratedDataGridViewTextBoxColumn1";
            this.timeGeneratedDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // sourceDataGridViewTextBoxColumn1
            // 
            this.sourceDataGridViewTextBoxColumn1.DataPropertyName = "Source";
            this.sourceDataGridViewTextBoxColumn1.HeaderText = "Source";
            this.sourceDataGridViewTextBoxColumn1.Name = "sourceDataGridViewTextBoxColumn1";
            this.sourceDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // userNameDataGridViewTextBoxColumn1
            // 
            this.userNameDataGridViewTextBoxColumn1.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn1.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn1.Name = "userNameDataGridViewTextBoxColumn1";
            this.userNameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn1
            // 
            this.categoryDataGridViewTextBoxColumn1.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn1.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn1.Name = "categoryDataGridViewTextBoxColumn1";
            this.categoryDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // eventIDDataGridViewTextBoxColumn1
            // 
            this.eventIDDataGridViewTextBoxColumn1.DataPropertyName = "EventID";
            this.eventIDDataGridViewTextBoxColumn1.HeaderText = "EventID";
            this.eventIDDataGridViewTextBoxColumn1.Name = "eventIDDataGridViewTextBoxColumn1";
            this.eventIDDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // instanceIdDataGridViewTextBoxColumn
            // 
            this.instanceIdDataGridViewTextBoxColumn.DataPropertyName = "InstanceId";
            this.instanceIdDataGridViewTextBoxColumn.HeaderText = "InstanceId";
            this.instanceIdDataGridViewTextBoxColumn.Name = "instanceIdDataGridViewTextBoxColumn";
            this.instanceIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.instanceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // messageDataGridViewTextBoxColumn1
            // 
            this.messageDataGridViewTextBoxColumn1.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn1.HeaderText = "Message";
            this.messageDataGridViewTextBoxColumn1.Name = "messageDataGridViewTextBoxColumn1";
            this.messageDataGridViewTextBoxColumn1.ReadOnly = true;
            this.messageDataGridViewTextBoxColumn1.Visible = false;
            // 
            // eventLogEntryBindingSource
            // 
            this.eventLogEntryBindingSource.DataSource = typeof(System.Diagnostics.EventLogEntry);
            // 
            // eventLogBindingSource
            // 
            this.eventLogBindingSource.DataSource = typeof(WindowsLogViewer.EventLog);
            // 
            // AuditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.lblAuditedMachine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblWinLog);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AuditControl";
            this.Size = new System.Drawing.Size(982, 770);
            ((System.ComponentModel.ISupportInitialize)(this.EventLogControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogEntryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource eventLogBindingSource;
        private System.Windows.Forms.Label label1;
        public System.Diagnostics.EventLog EventLogControl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblAuditedMachine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWinLog;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pictureStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource eventLogEntryBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn ImageEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeGeneratedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn instanceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn1;
    }
}
