namespace Fwk.Security.Admin.Controls
{
    partial class frmRolesFind
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
            this.rolesGrid1 = new Fwk.Security.Admin.Controls.RolesGrid();
            this.brnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAcept = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // rolesGrid1
            // 
            this.rolesGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rolesGrid1.Location = new System.Drawing.Point(3, 1);
            this.rolesGrid1.Name = "rolesGrid1";
            this.rolesGrid1.Size = new System.Drawing.Size(469, 362);
            this.rolesGrid1.TabIndex = 0;
            // 
            // brnCancel
            // 
            this.brnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.brnCancel.Location = new System.Drawing.Point(386, 369);
            this.brnCancel.Name = "brnCancel";
            this.brnCancel.Size = new System.Drawing.Size(75, 23);
            this.brnCancel.TabIndex = 4;
            this.brnCancel.Text = "Cancel";
            this.brnCancel.Click += new System.EventHandler(this.brnCancel_Click);
            // 
            // btnAcept
            // 
            this.btnAcept.Location = new System.Drawing.Point(291, 369);
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.Size = new System.Drawing.Size(75, 23);
            this.btnAcept.TabIndex = 3;
            this.btnAcept.Text = "Acept";
            this.btnAcept.Click += new System.EventHandler(this.btnAcept_Click);
            // 
            // frmRolesFind
            // 
            this.AcceptButton = this.btnAcept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.brnCancel;
            this.ClientSize = new System.Drawing.Size(473, 397);
            this.Controls.Add(this.brnCancel);
            this.Controls.Add(this.btnAcept);
            this.Controls.Add(this.rolesGrid1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRolesFind";
            this.ShowIcon = false;
            this.Text = "Find roles";
            this.ResumeLayout(false);

        }

        #endregion

        private RolesGrid rolesGrid1;
        private DevExpress.XtraEditors.SimpleButton brnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAcept;
    }
}