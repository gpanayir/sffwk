using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Tools.Menu
{
    public partial class UC_PopupButtonEditor
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.ButtonBase3 = new DevExpress.XtraEditors.SimpleButton();
            this.pctImage = new DevExpress.XtraEditors.PictureEdit();
            this.buttonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkBeginGroup = new DevExpress.XtraEditors.CheckEdit();
            this.txtShortCut = new DevExpress.XtraEditors.TextEdit();
            this.txtToolTip = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCaption = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeginGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortCut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToolTip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(3, 265);
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Size = new System.Drawing.Size(445, 33);
            this.panelControl1.Visible = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 134);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(32, 13);
            label2.TabIndex = 33;
            label2.Text = "Icon:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 101);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 13);
            label1.TabIndex = 29;
            label1.Text = "ShortCut:";
            // 
            // ButtonBase3
            // 
            this.ButtonBase3.Location = new System.Drawing.Point(182, 184);
            this.ButtonBase3.Name = "ButtonBase3";
            this.ButtonBase3.Size = new System.Drawing.Size(23, 23);
            this.ButtonBase3.TabIndex = 35;
            this.ButtonBase3.Text = "...";
            this.ButtonBase3.Click += new System.EventHandler(this.ButtonBase3_Click);
            // 
            // pctImage
            // 
            this.pctImage.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.buttonsBindingSource, "LargeImage", true));
            this.pctImage.Location = new System.Drawing.Point(90, 126);
            this.pctImage.Name = "pctImage";
            this.pctImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pctImage.Size = new System.Drawing.Size(86, 81);
            this.pctImage.TabIndex = 34;
            // 
            // buttonsBindingSource
            // 
            this.buttonsBindingSource.DataSource = typeof(Fwk.UI.Controls.Menu.ButtonBase);
            this.buttonsBindingSource.CurrentItemChanged += new System.EventHandler(this.buttonsBindingSource_CurrentItemChanged);
            // 
            // chkBeginGroup
            // 
            this.chkBeginGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBeginGroup.Location = new System.Drawing.Point(361, 21);
            this.chkBeginGroup.Name = "chkBeginGroup";
            this.chkBeginGroup.Properties.Caption = "Begin Group";
            this.chkBeginGroup.Size = new System.Drawing.Size(79, 19);
            this.chkBeginGroup.TabIndex = 31;
            // 
            // txtShortCut
            // 
            this.txtShortCut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortCut.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.buttonsBindingSource, "Shortcut", true));
            this.txtShortCut.Location = new System.Drawing.Point(90, 99);
            this.txtShortCut.Name = "txtShortCut";
            this.txtShortCut.Size = new System.Drawing.Size(350, 20);
            this.txtShortCut.TabIndex = 30;
            // 
            // txtToolTip
            // 
            this.txtToolTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToolTip.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.buttonsBindingSource, "ToolTipText", true));
            this.txtToolTip.Location = new System.Drawing.Point(90, 73);
            this.txtToolTip.Name = "txtToolTip";
            this.txtToolTip.Size = new System.Drawing.Size(350, 20);
            this.txtToolTip.TabIndex = 27;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 76);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 13);
            this.labelControl3.TabIndex = 26;
            this.labelControl3.Text = "ToolTip Text:";
            // 
            // txtCaption
            // 
            this.txtCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaption.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.buttonsBindingSource, "Caption", true));
            this.txtCaption.Location = new System.Drawing.Point(90, 47);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(350, 20);
            this.txtCaption.TabIndex = 25;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 24;
            this.labelControl2.Text = "Caption:";
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.buttonsBindingSource, "Id", true));
            this.txtId.Location = new System.Drawing.Point(90, 21);
            this.txtId.MinimumSize = new System.Drawing.Size(81, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(81, 20);
            this.txtId.TabIndex = 23;
            this.txtId.EditValueChanged += new System.EventHandler(this.txtId_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Button ID:";
            // 
            // UC_PopupButtonEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ButtonBase3);
            this.Controls.Add(this.pctImage);
            this.Controls.Add(label2);
            this.Controls.Add(this.chkBeginGroup);
            this.Controls.Add(this.txtShortCut);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtToolTip);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.labelControl1);
            this.LookAndFeel.SkinName = "Black";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_PopupButtonEditor";
            this.Size = new System.Drawing.Size(451, 301);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.txtCaption, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.txtToolTip, 0);
            this.Controls.SetChildIndex(label1, 0);
            this.Controls.SetChildIndex(this.txtShortCut, 0);
            this.Controls.SetChildIndex(this.chkBeginGroup, 0);
            this.Controls.SetChildIndex(label2, 0);
            this.Controls.SetChildIndex(this.pctImage, 0);
            this.Controls.SetChildIndex(this.ButtonBase3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeginGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortCut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToolTip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton ButtonBase3;
        private DevExpress.XtraEditors.PictureEdit pctImage;
        private DevExpress.XtraEditors.CheckEdit chkBeginGroup;
        private DevExpress.XtraEditors.TextEdit txtShortCut;
        private DevExpress.XtraEditors.TextEdit txtToolTip;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCaption;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.BindingSource buttonsBindingSource;
    }

}
