namespace Fwk.UI.Controls
{
    partial class UC_TextFindPopUp
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
            this.btnExpand = new DevExpress.XtraEditors.PopupContainerEdit();
            this.textEditor = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExpand
            // 
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand.Location = new System.Drawing.Point(3, 3);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, global::Fwk.UI.Properties.Resources.Expand_16, null)});
            this.btnExpand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.btnExpand.Properties.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.popupContainerEdit1_Properties_CloseUp);
            this.btnExpand.Properties.BeforeShowMenu += new DevExpress.XtraEditors.Controls.BeforeShowMenuEventHandler(this.popupContainerEdit1_Properties_BeforeShowMenu);
            this.btnExpand.Size = new System.Drawing.Size(437, 22);
            this.btnExpand.TabIndex = 0;
            this.btnExpand.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.popupContainerEdit1_ButtonClick);
            this.btnExpand.EditValueChanged += new System.EventHandler(this.btnExpand_EditValueChanged);
            this.btnExpand.Popup += new System.EventHandler(this.popupContainerEdit1_Popup);
            // 
            // textEditor
            // 
            this.textEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditor.Location = new System.Drawing.Point(3, 3);
            this.textEditor.Name = "textEditor";
            this.textEditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, global::Fwk.UI.Properties.Resources.srch_16, null)});
            this.textEditor.Properties.BeforeShowMenu += new DevExpress.XtraEditors.Controls.BeforeShowMenuEventHandler(this.txtFind_Properties_BeforeShowMenu);
            this.textEditor.Size = new System.Drawing.Size(412, 22);
            this.textEditor.TabIndex = 1;
            this.textEditor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFind_ButtonClick);
            this.textEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // TextFindPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditor);
            this.Controls.Add(this.btnExpand);
            this.Name = "TextFindPopUp";
            this.Size = new System.Drawing.Size(443, 30);
            ((System.ComponentModel.ISupportInitialize)(this.btnExpand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerEdit btnExpand;
        private DevExpress.XtraEditors.ButtonEdit textEditor;
    }
}
