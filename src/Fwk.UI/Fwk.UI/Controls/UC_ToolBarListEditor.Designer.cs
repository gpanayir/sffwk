namespace Fwk.UI.Controls
{
    partial class UC_ToolBarListEditor
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
            this.FwkBarBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.FwkBar = new DevExpress.XtraBars.Bar();
            this.bAddNewQuestion = new DevExpress.XtraBars.BarButtonItem();
            this.bEditQuestion = new DevExpress.XtraBars.BarButtonItem();
            this.bDeleteQuestion = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.FwkBarBarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // FwkBarBarManager
            // 
            this.FwkBarBarManager.AllowCustomization = false;
            this.FwkBarBarManager.AllowMoveBarOnToolbar = false;
            this.FwkBarBarManager.AllowQuickCustomization = false;
            this.FwkBarBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.FwkBar});
            this.FwkBarBarManager.DockControls.Add(this.barDockControlTop);
            this.FwkBarBarManager.DockControls.Add(this.barDockControlBottom);
            this.FwkBarBarManager.DockControls.Add(this.barDockControlLeft);
            this.FwkBarBarManager.DockControls.Add(this.barDockControlRight);
            this.FwkBarBarManager.Form = this;
            this.FwkBarBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bAddNewQuestion,
            this.bDeleteQuestion,
            this.bEditQuestion});
            this.FwkBarBarManager.MaxItemId = 4;
            // 
            // FwkBar
            // 
            this.FwkBar.BarName = "FwkBar";
            this.FwkBar.DockCol = 0;
            this.FwkBar.DockRow = 0;
            this.FwkBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.FwkBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bAddNewQuestion),
            new DevExpress.XtraBars.LinkPersistInfo(this.bEditQuestion),
            new DevExpress.XtraBars.LinkPersistInfo(this.bDeleteQuestion)});
            this.FwkBar.OptionsBar.AllowQuickCustomization = false;
            this.FwkBar.OptionsBar.DrawDragBorder = false;
            this.FwkBar.OptionsBar.DrawSizeGrip = true;
            // 
            // bAddNewQuestion
            // 
            this.bAddNewQuestion.Caption = "&Nuevo";
            this.bAddNewQuestion.Glyph = global::Fwk.UI.Properties.Resources.file_new_16;
            this.bAddNewQuestion.Id = 0;
            this.bAddNewQuestion.Name = "bAddNewQuestion";
            this.bAddNewQuestion.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bAddNewQuestion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bAddNewQuestion_ItemClick);
            // 
            // bEditQuestion
            // 
            this.bEditQuestion.Caption = "&Editar";
            this.bEditQuestion.Glyph = global::Fwk.UI.Properties.Resources.file_edit_16;
            this.bEditQuestion.Id = 1;
            this.bEditQuestion.Name = "bEditQuestion";
            this.bEditQuestion.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bEditQuestion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bEditQuestion_ItemClick);
            // 
            // bDeleteQuestion
            // 
            this.bDeleteQuestion.Caption = "&Eliminar";
            this.bDeleteQuestion.Glyph = global::Fwk.UI.Properties.Resources.file_del_16;
            this.bDeleteQuestion.Id = 2;
            this.bDeleteQuestion.Name = "bDeleteQuestion";
            this.bDeleteQuestion.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bDeleteQuestion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bDeleteQuestion_ItemClick);
            // 
            // UC_ToolBarListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UC_ToolBarListEditor";
            this.Size = new System.Drawing.Size(406, 28);
            ((System.ComponentModel.ISupportInitialize)(this.FwkBarBarManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager FwkBarBarManager;

        private DevExpress.XtraBars.BarButtonItem bAddNewQuestion;
        private DevExpress.XtraBars.BarButtonItem bEditQuestion;
        private DevExpress.XtraBars.BarButtonItem bDeleteQuestion;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar FwkBar;
  
    }
}
