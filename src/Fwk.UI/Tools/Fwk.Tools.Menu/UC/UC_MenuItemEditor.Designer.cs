namespace Fwk.Tools.Menu
{
    partial class UC_MenuItemEditor
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ButtonBase2 = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonBase1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ButtonBase2);
            this.panelControl1.Controls.Add(this.ButtonBase1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(3, 311);
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(553, 41);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Visible = false;
            // 
            // ButtonBase2
            // 
            this.ButtonBase2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBase2.Image = global::Fwk.Tools.Menu.Properties.Resources.close_16;
            this.ButtonBase2.Location = new System.Drawing.Point(459, 6);
            this.ButtonBase2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ButtonBase2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonBase2.Name = "ButtonBase2";
            this.ButtonBase2.Size = new System.Drawing.Size(87, 28);
            this.ButtonBase2.TabIndex = 1;
            this.ButtonBase2.Text = "Cancelar";
            this.ButtonBase2.Click += new System.EventHandler(this.ButtonBase2_Click);
            // 
            // ButtonBase1
            // 
            this.ButtonBase1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBase1.Image = global::Fwk.Tools.Menu.Properties.Resources.save_16;
            this.ButtonBase1.Location = new System.Drawing.Point(207, 6);
            this.ButtonBase1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ButtonBase1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonBase1.Name = "ButtonBase1";
            this.ButtonBase1.Size = new System.Drawing.Size(245, 28);
            this.ButtonBase1.TabIndex = 0;
            this.ButtonBase1.Text = "Guardar";
            this.ButtonBase1.Click += new System.EventHandler(this.ButtonBase1_Click);
            // 
            // UC_MenuItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Black";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UC_MenuItemEditor";
            this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Size = new System.Drawing.Size(559, 356);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton ButtonBase2;
        private DevExpress.XtraEditors.SimpleButton ButtonBase1;
        public DevExpress.XtraEditors.PanelControl panelControl1;

    }
}
