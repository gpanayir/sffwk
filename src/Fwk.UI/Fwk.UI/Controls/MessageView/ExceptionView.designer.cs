namespace Fwk.UI.Controls
{
    /// <summary>
    /// 
    /// </summary>
    partial class ExceptionView
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
            this.txtSource = new DevExpress.XtraEditors.MemoEdit();
            this.txtMessage = new DevExpress.XtraEditors.MemoEdit();
            this.txtDetail = new DevExpress.XtraEditors.MemoEdit();
            this.imgFormExpansion = new System.Windows.Forms.ImageList(this.components);
            this.imgIcon = new System.Windows.Forms.PictureBox();
            this.ctlBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.ctlExceptionToolbar = new DevExpress.XtraBars.Bar();
            this.btnExpandCollapse = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnMail = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnOk = new DevExpress.XtraBars.BarButtonItem();
            this.btnNo = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.lblSource = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(72, 30);
            this.txtSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSource.Name = "txtSource";
            this.txtSource.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSource.Properties.Appearance.Options.UseBackColor = true;
            this.txtSource.Properties.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(331, 36);
            this.txtSource.TabIndex = 16;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(72, 102);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtMessage.Properties.Appearance.Options.UseBackColor = true;
            this.txtMessage.Properties.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(331, 96);
            this.txtMessage.TabIndex = 17;
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(7, 247);
            this.txtDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDetail.Properties.Appearance.Options.UseBackColor = true;
            this.txtDetail.Size = new System.Drawing.Size(397, 164);
            this.txtDetail.TabIndex = 18;
            // 
            // imgFormExpansion
            // 
            this.imgFormExpansion.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgFormExpansion.ImageSize = new System.Drawing.Size(16, 16);
            this.imgFormExpansion.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgIcon
            // 
            this.imgIcon.BackColor = System.Drawing.Color.Transparent;
            this.imgIcon.Image = global::Fwk.UI.Properties.Resources.error_32;
            this.imgIcon.Location = new System.Drawing.Point(14, 37);
            this.imgIcon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.Size = new System.Drawing.Size(42, 44);
            this.imgIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgIcon.TabIndex = 15;
            this.imgIcon.TabStop = false;
            // 
            // ctlBarManager
            // 
            this.ctlBarManager.AllowMoveBarOnToolbar = false;
            this.ctlBarManager.AllowQuickCustomization = false;
            this.ctlBarManager.AllowShowToolbarsPopup = false;
            this.ctlBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.ctlExceptionToolbar});
            this.ctlBarManager.DockControls.Add(this.barDockControlTop);
            this.ctlBarManager.DockControls.Add(this.barDockControlBottom);
            this.ctlBarManager.DockControls.Add(this.barDockControlLeft);
            this.ctlBarManager.DockControls.Add(this.barDockControlRight);
            this.ctlBarManager.DockControls.Add(this.standaloneBarDockControl1);
            this.ctlBarManager.Form = this;
            this.ctlBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.btnExpandCollapse,
            this.barStaticItem1,
            this.btnSave,
            this.btnMail,
            this.barButtonItem2,
            this.btnOk,
            this.btnNo});
            this.ctlBarManager.MaxItemId = 8;
            this.ctlBarManager.ShowFullMenusAfterDelay = false;
            this.ctlBarManager.ShowScreenTipsInToolbars = false;
            this.ctlBarManager.ShowShortcutInScreenTips = false;
            this.ctlBarManager.UseAltKeyForMenu = false;
            this.ctlBarManager.UseF10KeyForMenu = false;
            this.ctlBarManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ctlBarManager_ItemClick);
            // 
            // ctlExceptionToolbar
            // 
            this.ctlExceptionToolbar.BarName = "ctlExceptionToolbar";
            this.ctlExceptionToolbar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Standalone;
            this.ctlExceptionToolbar.DockCol = 0;
            this.ctlExceptionToolbar.DockRow = 0;
            this.ctlExceptionToolbar.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.ctlExceptionToolbar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExpandCollapse),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMail),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOk),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNo)});
            this.ctlExceptionToolbar.OptionsBar.AllowQuickCustomization = false;
            this.ctlExceptionToolbar.OptionsBar.DrawDragBorder = false;
            this.ctlExceptionToolbar.OptionsBar.RotateWhenVertical = false;
            this.ctlExceptionToolbar.OptionsBar.UseWholeRow = true;
            this.ctlExceptionToolbar.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.ctlExceptionToolbar.Text = "ctlExceptionToolbar";
            // 
            // btnExpandCollapse
            // 
            this.btnExpandCollapse.Glyph = global::Fwk.UI.Properties.Resources.expandVertical_16;
            this.btnExpandCollapse.Id = 1;
            this.btnExpandCollapse.Name = "btnExpandCollapse";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem1.Caption = "Detalle";
            this.barStaticItem1.Id = 2;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnSave
            // 
            this.btnSave.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnSave.Caption = "Guarda el mensaje en un archivo...";
            this.btnSave.Glyph = global::Fwk.UI.Properties.Resources.save_as_16;
            this.btnSave.Id = 3;
            this.btnSave.Name = "btnSave";
            // 
            // btnMail
            // 
            this.btnMail.Caption = "Envia el mensaje por mail...";
            this.btnMail.Glyph = global::Fwk.UI.Properties.Resources.mail_16;
            this.btnMail.Id = 4;
            this.btnMail.Name = "btnMail";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Copia el mensaje al portapapeles...";
            this.barButtonItem2.Glyph = global::Fwk.UI.Properties.Resources.copy_16;
            this.barButtonItem2.Id = 5;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnOk
            // 
            this.btnOk.Caption = "btnOk";
            this.btnOk.Glyph = global::Fwk.UI.Properties.Resources.apply_16;
            this.btnOk.Id = 6;
            this.btnOk.Name = "btnOk";
            this.btnOk.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOk_ItemClick);
            // 
            // btnNo
            // 
            this.btnNo.Caption = "btnNo";
            this.btnNo.Glyph = global::Fwk.UI.Properties.Resources.cancl_16;
            this.btnNo.Id = 7;
            this.btnNo.Name = "btnNo";
            this.btnNo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNo_ItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.standaloneBarDockControl1.Appearance.Options.UseBackColor = true;
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(7, 207);
            this.standaloneBarDockControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(397, 33);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(411, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 241);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(411, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 241);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(411, 0);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 241);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(80, 75);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(49, 17);
            this.lblMessage.TabIndex = 20;
            this.lblMessage.Text = "Mensaje";
            // 
            // lblSource
            // 
            this.lblSource.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblSource.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(79, 6);
            this.lblSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(40, 17);
            this.lblSource.TabIndex = 19;
            this.lblSource.Text = "Origen";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Location = new System.Drawing.Point(72, 4);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(331, 22);
            this.panelControl1.TabIndex = 21;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Location = new System.Drawing.Point(72, 73);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(331, 22);
            this.panelControl2.TabIndex = 22;
            // 
            // ExceptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 241);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.imgIcon);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ExceptionView";
            this.Text = "FrmTechnicalMsg";
            this.Load += new System.EventHandler(this.FrmTechnicalMsg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtDetail;
        private DevExpress.XtraEditors.MemoEdit txtMessage;
        private DevExpress.XtraEditors.MemoEdit txtSource;
        private System.Windows.Forms.PictureBox imgIcon;
        private System.Windows.Forms.ImageList imgFormExpansion;
        private DevExpress.XtraBars.BarManager ctlBarManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar ctlExceptionToolbar;
        private DevExpress.XtraBars.BarButtonItem btnExpandCollapse;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnMail;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.LabelControl lblSource;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.BarButtonItem btnOk;
        private DevExpress.XtraBars.BarButtonItem btnNo;
    }
}