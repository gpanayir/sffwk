namespace Fwk.UI.Security
{
    partial class FRM_UserNew
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.uC_UserNew1 = new Fwk.UI.Security.Controls.UC_UserAdmin();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(7, 578);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(538, 23);
            this.aceptCancelButtonBar1.Enter += new System.EventHandler(this.aceptCancelButtonBar1_Enter);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(7, 7);
            this.xtraTabControl1.MaximumSize = new System.Drawing.Size(550, 570);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(538, 570);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xtraTabPage1.Controls.Add(this.uC_UserNew1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(529, 540);
            this.xtraTabPage1.Text = "Datos Generales";
            // 
            // uC_UserNew1
            // 
            this.uC_UserNew1.AcceptButton = null;
            this.uC_UserNew1.CancelButton = null;
            this.uC_UserNew1.Location = new System.Drawing.Point(0, 3);
            this.uC_UserNew1.Name = "uC_UserNew1";
            this.uC_UserNew1.Size = new System.Drawing.Size(526, 531);
            this.uC_UserNew1.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(529, 540);
            this.xtraTabPage2.Text = "Datos Adicionales";
           
            // FRM_UserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 608);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FRM_UserMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserNew_FormClosing);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;        
        
        private Fwk.UI.Security.Controls.UC_UserAdmin uC_UserNew1;


    }
}