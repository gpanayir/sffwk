namespace Fwk.Logging.Viewer
{
    partial class FRM_Document
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Document));
            this.grdLogs = new System.Windows.Forms.DataGridView();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ctlImages = new System.Windows.Forms.ImageList(this.components);
            this.txtMessage1 = new System.Windows.Forms.TextBox();
            this.txtMessage2 = new System.Windows.Forms.TextBox();
            this.lblMessage1 = new System.Windows.Forms.Label();
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.colImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.machineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserLoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLogs
            // 
            this.grdLogs.AllowUserToAddRows = false;
            this.grdLogs.AllowUserToDeleteRows = false;
            this.grdLogs.AllowUserToOrderColumns = true;
            this.grdLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLogs.AutoGenerateColumns = false;
            this.grdLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdLogs.BackgroundColor = System.Drawing.Color.White;
            this.grdLogs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grdLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImg,
            this.machineDataGridViewTextBoxColumn,
            this.sourceDataGridViewTextBoxColumn,
            this.LogDate,
            this.UserLoginName,
            this.LogType,
            this.Source});
            this.grdLogs.DataSource = this.eventBindingSource;
            this.grdLogs.Location = new System.Drawing.Point(0, -1);
            this.grdLogs.Name = "grdLogs";
            this.grdLogs.ReadOnly = true;
            this.grdLogs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdLogs.RowHeadersVisible = false;
            this.grdLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLogs.Size = new System.Drawing.Size(1095, 375);
            this.grdLogs.TabIndex = 0;
            this.grdLogs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLogs_CellClick);
            this.grdLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLogs_CellContentClick);
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataSource = typeof(Fwk.Logging.Event);
            // 
            // ctlImages
            // 
            this.ctlImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ctlImages.ImageStream")));
            this.ctlImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ctlImages.Images.SetKeyName(0, "folder-closed_16.png");
            this.ctlImages.Images.SetKeyName(1, "search_16.png");
            this.ctlImages.Images.SetKeyName(2, "confirm_16.png");
            this.ctlImages.Images.SetKeyName(3, "info.ico");
            this.ctlImages.Images.SetKeyName(4, "alert.ico");
            this.ctlImages.Images.SetKeyName(5, "delete.ico");
            // 
            // txtMessage1
            // 
            this.txtMessage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage1.Location = new System.Drawing.Point(4, 394);
            this.txtMessage1.Multiline = true;
            this.txtMessage1.Name = "txtMessage1";
            this.txtMessage1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage1.Size = new System.Drawing.Size(453, 259);
            this.txtMessage1.TabIndex = 1;
            // 
            // txtMessage2
            // 
            this.txtMessage2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage2.Location = new System.Drawing.Point(464, 397);
            this.txtMessage2.Multiline = true;
            this.txtMessage2.Name = "txtMessage2";
            this.txtMessage2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage2.Size = new System.Drawing.Size(424, 259);
            this.txtMessage2.TabIndex = 2;
            // 
            // lblMessage1
            // 
            this.lblMessage1.AutoSize = true;
            this.lblMessage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage1.Location = new System.Drawing.Point(6, 381);
            this.lblMessage1.Name = "lblMessage1";
            this.lblMessage1.Size = new System.Drawing.Size(57, 13);
            this.lblMessage1.TabIndex = 4;
            this.lblMessage1.Text = "Message";
            // 
            // lblMessage2
            // 
            this.lblMessage2.AutoSize = true;
            this.lblMessage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage2.Location = new System.Drawing.Point(461, 381);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(63, 13);
            this.lblMessage2.TabIndex = 5;
            this.lblMessage2.Text = "Response";
            // 
            // colImg
            // 
            this.colImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImg.DataPropertyName = "IconImage";
            this.colImg.Description = "IconImage";
            this.colImg.FillWeight = 155.5696F;
            this.colImg.HeaderText = "";
            this.colImg.Name = "colImg";
            this.colImg.ReadOnly = true;
            this.colImg.Width = 5;
            // 
            // machineDataGridViewTextBoxColumn
            // 
            this.machineDataGridViewTextBoxColumn.DataPropertyName = "Machine";
            this.machineDataGridViewTextBoxColumn.HeaderText = "Machine";
            this.machineDataGridViewTextBoxColumn.Name = "machineDataGridViewTextBoxColumn";
            this.machineDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            this.sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
            this.sourceDataGridViewTextBoxColumn.HeaderText = "Source";
            this.sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            this.sourceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // LogDate
            // 
            this.LogDate.DataPropertyName = "LogDate";
            this.LogDate.HeaderText = "LogDate";
            this.LogDate.Name = "LogDate";
            this.LogDate.ReadOnly = true;
            // 
            // UserLoginName
            // 
            this.UserLoginName.DataPropertyName = "UserLoginName";
            this.UserLoginName.HeaderText = "UserLoginName";
            this.UserLoginName.Name = "UserLoginName";
            this.UserLoginName.ReadOnly = true;
            // 
            // LogType
            // 
            this.LogType.DataPropertyName = "LogType";
            this.LogType.HeaderText = "LogType";
            this.LogType.Name = "LogType";
            this.LogType.ReadOnly = true;
            // 
            // Source
            // 
            this.Source.DataPropertyName = "Source";
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            // 
            // FRM_Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1107, 665);
            this.Controls.Add(this.lblMessage2);
            this.Controls.Add(this.lblMessage1);
            this.Controls.Add(this.txtMessage2);
            this.Controls.Add(this.txtMessage1);
            this.Controls.Add(this.grdLogs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_Document";
            this.Text = "[name]";
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdLogs;
        private System.Windows.Forms.ImageList ctlImages;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private System.Windows.Forms.TextBox txtMessage1;
        private System.Windows.Forms.TextBox txtMessage2;
        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAndTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn colImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserLoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;

    }
}