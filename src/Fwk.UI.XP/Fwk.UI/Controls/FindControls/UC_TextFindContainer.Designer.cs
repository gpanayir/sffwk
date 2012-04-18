namespace Fwk.UI.Controls
{
    partial class UC_TextFindContainer
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
            this.textEditor = new DevExpress.XtraEditors.ButtonEdit();
            this.panelControl_Find = new DevExpress.XtraEditors.PanelControl();
            this.btnExpand = new DevExpress.XtraEditors.SimpleButton();
            this.Control_workingArea = new Fwk.UI.Controls.Designers.WorkingAreaControl();
            this.Find_workingArea = new Fwk.UI.Controls.Designers.WorkingAreaControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Find)).BeginInit();
            this.panelControl_Find.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEditor
            // 
            this.textEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditor.Location = new System.Drawing.Point(5, 3);
            this.textEditor.Name = "textEditor";
            this.textEditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, global::Fwk.UI.Properties.Resources.srch_16, null)});
            this.textEditor.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFind_Properties_ButtonClick);
            this.textEditor.Size = new System.Drawing.Size(525, 22);
            this.textEditor.TabIndex = 0;
            this.textEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // panelControl_Find
            // 
            this.panelControl_Find.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl_Find.Controls.Add(this.textEditor);
            this.panelControl_Find.Controls.Add(this.btnExpand);
            this.panelControl_Find.Location = new System.Drawing.Point(3, 2);
            this.panelControl_Find.Name = "panelControl_Find";
            this.panelControl_Find.Size = new System.Drawing.Size(564, 30);
            this.panelControl_Find.TabIndex = 4;
            // 
            // btnExpand
            // 
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnExpand.Image = global::Fwk.UI.Properties.Resources.Expand_16;
            this.btnExpand.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExpand.Location = new System.Drawing.Point(536, 4);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(23, 20);
            this.btnExpand.TabIndex = 2;
            this.btnExpand.ToolTip = "Busqueda avanzada";
            this.btnExpand.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // Control_workingArea
            // 
            this.Control_workingArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Control_workingArea.AutoScroll = true;
            this.Control_workingArea.AutoSize = true;
            this.Control_workingArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Control_workingArea.Location = new System.Drawing.Point(3, 147);
            this.Control_workingArea.Name = "Control_workingArea";
            this.Control_workingArea.Size = new System.Drawing.Size(566, 253);
            this.Control_workingArea.TabIndex = 0;
            // 
            // Find_workingArea
            // 
            this.Find_workingArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Find_workingArea.AutoScroll = true;
            this.Find_workingArea.AutoSize = true;
            this.Find_workingArea.BackColor = System.Drawing.Color.White;
            this.Find_workingArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Find_workingArea.Location = new System.Drawing.Point(3, 36);
            this.Find_workingArea.Name = "Find_workingArea";
            this.Find_workingArea.Size = new System.Drawing.Size(566, 105);
            this.Find_workingArea.TabIndex = 1;
            // 
            // UC_TextFindContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panelControl_Find);
            this.Controls.Add(this.Control_workingArea);
            this.Controls.Add(this.Find_workingArea);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "UC_TextFindContainer";
            this.Size = new System.Drawing.Size(572, 406);
            this.Load += new System.EventHandler(this.TextFindContainer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Find)).EndInit();
            this.panelControl_Find.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit textEditor;
        private Fwk.UI.Controls.Designers.WorkingAreaControl Find_workingArea;
        private Fwk.UI.Controls.Designers.WorkingAreaControl Control_workingArea;
        private DevExpress.XtraEditors.SimpleButton btnExpand;
        private DevExpress.XtraEditors.PanelControl panelControl_Find;
    }
}
