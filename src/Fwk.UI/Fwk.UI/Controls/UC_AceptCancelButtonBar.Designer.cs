
namespace Fwk.UI.Controls
{
    partial class UC_AceptCancelButtonBar
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
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Acept = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "navBarGroup1";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Cancel.CausesValidation = false;
            this.btn_Cancel.Image = global::Fwk.UI.Properties.Resources.cancl_16;
            this.btn_Cancel.Location = new System.Drawing.Point(346, 4);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(114, 26);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "&Cancelar";
            this.btn_Cancel.Click += new System.EventHandler(this.ButtonBase_Cancel_Click);
            // 
            // btn_Acept
            // 
            this.btn_Acept.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Acept.Image = global::Fwk.UI.Properties.Resources.apply_16;
            this.btn_Acept.Location = new System.Drawing.Point(221, 4);
            this.btn_Acept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Acept.Name = "btn_Acept";
            this.btn_Acept.Size = new System.Drawing.Size(119, 27);
            this.btn_Acept.TabIndex = 0;
            this.btn_Acept.Text = "&Aceptar";
            this.btn_Acept.Click += new System.EventHandler(this.ButtonBase_Acept_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btn_Cancel);
            this.flowLayoutPanel1.Controls.Add(this.btn_Acept);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(463, 34);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // UC_AceptCancelButtonBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UC_AceptCancelButtonBar";
            this.Size = new System.Drawing.Size(463, 34);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Acept;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
