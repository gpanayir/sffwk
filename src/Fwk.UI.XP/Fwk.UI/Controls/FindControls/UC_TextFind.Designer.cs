namespace Fwk.UI.Controls
{
    partial class UC_TextFind
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
            this.panelControl_Find = new DevExpress.XtraEditors.PanelControl();
            this.textEditor = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Find)).BeginInit();
            this.panelControl_Find.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl_Find
            // 
            this.panelControl_Find.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl_Find.Controls.Add(this.textEditor);
            this.panelControl_Find.Location = new System.Drawing.Point(0, 0);
            this.panelControl_Find.Name = "panelControl_Find";
            this.panelControl_Find.Size = new System.Drawing.Size(597, 28);
            this.panelControl_Find.TabIndex = 5;
            // 
            // textEditor
            // 
            this.textEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditor.Location = new System.Drawing.Point(5, 3);
            this.textEditor.Name = "textEditor";
            this.textEditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, global::Fwk.UI.Properties.Resources.srch_16, null)});
            this.textEditor.Size = new System.Drawing.Size(587, 22);
            this.textEditor.TabIndex = 0;
            this.textEditor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFind_ButtonClick);
            this.textEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // UC_TextFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl_Find);
            this.Name = "UC_TextFind";
            this.Size = new System.Drawing.Size(600, 30);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Find)).EndInit();
            this.panelControl_Find.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl_Find;
        private DevExpress.XtraEditors.ButtonEdit textEditor;
    }
}
