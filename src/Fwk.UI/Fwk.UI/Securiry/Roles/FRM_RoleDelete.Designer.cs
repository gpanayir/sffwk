namespace Fwk.UI.Security
{
    partial class FRM_RoleDelete
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
            this.uC_RoleDelete1 = new Fwk.UI.Security.Controls.UC_RoleDelete();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(9, 110);
            this.aceptCancelButtonBar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(317, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // uC_RoleDelete1
            // 
            this.uC_RoleDelete1.AcceptButton = null;
            this.uC_RoleDelete1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_RoleDelete1.CancelButton = null;
            this.uC_RoleDelete1.Location = new System.Drawing.Point(8, 9);
            this.uC_RoleDelete1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.uC_RoleDelete1.Name = "uC_RoleDelete1";
            this.uC_RoleDelete1.Size = new System.Drawing.Size(315, 91);
            this.uC_RoleDelete1.TabIndex = 1;
            // 
            // FRM_RoleDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 149);
            this.Controls.Add(this.uC_RoleDelete1);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FRM_RoleDelete";
            this.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.Text = "Eliminar rol";
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.uC_RoleDelete1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Security.Controls.UC_RoleDelete uC_RoleDelete1;
    }
}