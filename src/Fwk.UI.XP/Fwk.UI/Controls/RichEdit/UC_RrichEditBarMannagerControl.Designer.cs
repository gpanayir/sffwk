namespace Fwk.UI.Controls
{
   
    partial class UC_RrichEditBarMannagerControl : DevExpress.XtraEditors.XtraUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_RrichEditBarMannagerControl));
            this.richEditControl = new DevExpress.XtraRichEdit.RichEditControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.fontBar1 = new DevExpress.XtraRichEdit.UI.FontBar();
            this.changeFontNameItem1 = new DevExpress.XtraRichEdit.UI.ChangeFontNameItem();
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.changeFontSizeItem1 = new DevExpress.XtraRichEdit.UI.ChangeFontSizeItem();
            this.repositoryItemRichEditFontSizeEdit1 = new DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit();
            this.changeFontColorItem1 = new DevExpress.XtraRichEdit.UI.ChangeFontColorItem();
            this.changeFontBackColorItem1 = new DevExpress.XtraRichEdit.UI.ChangeFontBackColorItem();
            this.toggleFontBoldItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontBoldItem();
            this.toggleFontItalicItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontItalicItem();
            this.toggleFontUnderlineItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontUnderlineItem();
            this.toggleFontDoubleUnderlineItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontDoubleUnderlineItem();
            this.toggleFontStrikeoutItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontStrikeoutItem();
            this.toggleFontDoubleStrikeoutItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontDoubleStrikeoutItem();
            this.toggleFontSuperscriptItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontSuperscriptItem();
            this.toggleFontSubscriptItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontSubscriptItem();
            this.fontSizeIncreaseItem1 = new DevExpress.XtraRichEdit.UI.FontSizeIncreaseItem();
            this.fontSizeDecreaseItem1 = new DevExpress.XtraRichEdit.UI.FontSizeDecreaseItem();
            this.showFontFormItem1 = new DevExpress.XtraRichEdit.UI.ShowFontFormItem();
            this.clipboardBar1 = new DevExpress.XtraRichEdit.UI.ClipboardBar();
            this.cutItem1 = new DevExpress.XtraRichEdit.UI.CutItem();
            this.copyItem1 = new DevExpress.XtraRichEdit.UI.CopyItem();
            this.pasteItem1 = new DevExpress.XtraRichEdit.UI.PasteItem();
            this.editingBar1 = new DevExpress.XtraRichEdit.UI.EditingBar();
            this.findItem1 = new DevExpress.XtraRichEdit.UI.FindItem();
            this.replaceItem1 = new DevExpress.XtraRichEdit.UI.ReplaceItem();
            this.stylesBar1 = new DevExpress.XtraRichEdit.UI.StylesBar();
            this.changeStyleItem1 = new DevExpress.XtraRichEdit.UI.ChangeStyleItem();
            this.repositoryItemRichEditStyleEdit1 = new DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.richEditBarController1 = new DevExpress.XtraRichEdit.UI.RichEditBarController();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditFontSizeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).BeginInit();
            this.SuspendLayout();
            // 
            // richEditControl
            // 
            this.richEditControl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControl.Location = new System.Drawing.Point(0, 53);
            this.richEditControl.MenuManager = this.barManager1;
            this.richEditControl.Name = "richEditControl";
            this.richEditControl.Size = new System.Drawing.Size(721, 554);
            this.richEditControl.TabIndex = 3;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.fontBar1,
            this.clipboardBar1,
            this.editingBar1,
            this.stylesBar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.changeFontNameItem1,
            this.changeFontSizeItem1,
            this.changeFontColorItem1,
            this.changeFontBackColorItem1,
            this.toggleFontBoldItem1,
            this.toggleFontItalicItem1,
            this.toggleFontUnderlineItem1,
            this.toggleFontDoubleUnderlineItem1,
            this.toggleFontStrikeoutItem1,
            this.toggleFontDoubleStrikeoutItem1,
            this.toggleFontSuperscriptItem1,
            this.toggleFontSubscriptItem1,
            this.fontSizeIncreaseItem1,
            this.fontSizeDecreaseItem1,
            this.showFontFormItem1,
            this.cutItem1,
            this.copyItem1,
            this.pasteItem1,
            this.findItem1,
            this.replaceItem1,
            this.changeStyleItem1});
            this.barManager1.MaxItemId = 21;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemFontEdit1,
            this.repositoryItemRichEditFontSizeEdit1,
            this.repositoryItemRichEditStyleEdit1});
            this.barManager1.ShortcutItemClick += new DevExpress.XtraBars.ShortcutItemClickEventHandler(this.barManager1_ShortcutItemClick);
            // 
            // fontBar1
            // 
            this.fontBar1.DockCol = 0;
            this.fontBar1.DockRow = 0;
            this.fontBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.fontBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.changeFontNameItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.changeFontSizeItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.changeFontColorItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.changeFontBackColorItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontBoldItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontItalicItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontUnderlineItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontDoubleUnderlineItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontStrikeoutItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontDoubleStrikeoutItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontSuperscriptItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontSubscriptItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.fontSizeIncreaseItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.fontSizeDecreaseItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.showFontFormItem1)});
            // 
            // changeFontNameItem1
            // 
            this.changeFontNameItem1.Edit = this.repositoryItemFontEdit1;
            this.changeFontNameItem1.Id = 0;
            this.changeFontNameItem1.Name = "changeFontNameItem1";
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // changeFontSizeItem1
            // 
            this.changeFontSizeItem1.Edit = this.repositoryItemRichEditFontSizeEdit1;
            this.changeFontSizeItem1.Id = 1;
            this.changeFontSizeItem1.Name = "changeFontSizeItem1";
            // 
            // repositoryItemRichEditFontSizeEdit1
            // 
            this.repositoryItemRichEditFontSizeEdit1.AutoHeight = false;
            this.repositoryItemRichEditFontSizeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRichEditFontSizeEdit1.Control = this.richEditControl;
            this.repositoryItemRichEditFontSizeEdit1.Name = "repositoryItemRichEditFontSizeEdit1";
            // 
            // changeFontColorItem1
            // 
            this.changeFontColorItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("changeFontColorItem1.Glyph")));
            this.changeFontColorItem1.Id = 2;
            this.changeFontColorItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("changeFontColorItem1.LargeGlyph")));
            this.changeFontColorItem1.Name = "changeFontColorItem1";
            // 
            // changeFontBackColorItem1
            // 
            this.changeFontBackColorItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("changeFontBackColorItem1.Glyph")));
            this.changeFontBackColorItem1.Id = 3;
            this.changeFontBackColorItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("changeFontBackColorItem1.LargeGlyph")));
            this.changeFontBackColorItem1.Name = "changeFontBackColorItem1";
            // 
            // toggleFontBoldItem1
            // 
            this.toggleFontBoldItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontBoldItem1.Glyph")));
            this.toggleFontBoldItem1.Id = 4;
            this.toggleFontBoldItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B));
            this.toggleFontBoldItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontBoldItem1.LargeGlyph")));
            this.toggleFontBoldItem1.Name = "toggleFontBoldItem1";
            // 
            // toggleFontItalicItem1
            // 
            this.toggleFontItalicItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontItalicItem1.Glyph")));
            this.toggleFontItalicItem1.Id = 5;
            this.toggleFontItalicItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
            this.toggleFontItalicItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontItalicItem1.LargeGlyph")));
            this.toggleFontItalicItem1.Name = "toggleFontItalicItem1";
            // 
            // toggleFontUnderlineItem1
            // 
            this.toggleFontUnderlineItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontUnderlineItem1.Glyph")));
            this.toggleFontUnderlineItem1.Id = 6;
            this.toggleFontUnderlineItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U));
            this.toggleFontUnderlineItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontUnderlineItem1.LargeGlyph")));
            this.toggleFontUnderlineItem1.Name = "toggleFontUnderlineItem1";
            // 
            // toggleFontDoubleUnderlineItem1
            // 
            this.toggleFontDoubleUnderlineItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontDoubleUnderlineItem1.Glyph")));
            this.toggleFontDoubleUnderlineItem1.Id = 7;
            this.toggleFontDoubleUnderlineItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                            | System.Windows.Forms.Keys.D));
            this.toggleFontDoubleUnderlineItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontDoubleUnderlineItem1.LargeGlyph")));
            this.toggleFontDoubleUnderlineItem1.Name = "toggleFontDoubleUnderlineItem1";
            // 
            // toggleFontStrikeoutItem1
            // 
            this.toggleFontStrikeoutItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontStrikeoutItem1.Glyph")));
            this.toggleFontStrikeoutItem1.Id = 8;
            this.toggleFontStrikeoutItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontStrikeoutItem1.LargeGlyph")));
            this.toggleFontStrikeoutItem1.Name = "toggleFontStrikeoutItem1";
            // 
            // toggleFontDoubleStrikeoutItem1
            // 
            this.toggleFontDoubleStrikeoutItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontDoubleStrikeoutItem1.Glyph")));
            this.toggleFontDoubleStrikeoutItem1.Id = 9;
            this.toggleFontDoubleStrikeoutItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontDoubleStrikeoutItem1.LargeGlyph")));
            this.toggleFontDoubleStrikeoutItem1.Name = "toggleFontDoubleStrikeoutItem1";
            // 
            // toggleFontSuperscriptItem1
            // 
            this.toggleFontSuperscriptItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontSuperscriptItem1.Glyph")));
            this.toggleFontSuperscriptItem1.Id = 10;
            this.toggleFontSuperscriptItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                            | System.Windows.Forms.Keys.Oemplus));
            this.toggleFontSuperscriptItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontSuperscriptItem1.LargeGlyph")));
            this.toggleFontSuperscriptItem1.Name = "toggleFontSuperscriptItem1";
            // 
            // toggleFontSubscriptItem1
            // 
            this.toggleFontSubscriptItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("toggleFontSubscriptItem1.Glyph")));
            this.toggleFontSubscriptItem1.Id = 11;
            this.toggleFontSubscriptItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus));
            this.toggleFontSubscriptItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("toggleFontSubscriptItem1.LargeGlyph")));
            this.toggleFontSubscriptItem1.Name = "toggleFontSubscriptItem1";
            // 
            // fontSizeIncreaseItem1
            // 
            this.fontSizeIncreaseItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("fontSizeIncreaseItem1.Glyph")));
            this.fontSizeIncreaseItem1.Id = 12;
            this.fontSizeIncreaseItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                            | System.Windows.Forms.Keys.OemPeriod));
            this.fontSizeIncreaseItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("fontSizeIncreaseItem1.LargeGlyph")));
            this.fontSizeIncreaseItem1.Name = "fontSizeIncreaseItem1";
            // 
            // fontSizeDecreaseItem1
            // 
            this.fontSizeDecreaseItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("fontSizeDecreaseItem1.Glyph")));
            this.fontSizeDecreaseItem1.Id = 13;
            this.fontSizeDecreaseItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                            | System.Windows.Forms.Keys.Oemcomma));
            this.fontSizeDecreaseItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("fontSizeDecreaseItem1.LargeGlyph")));
            this.fontSizeDecreaseItem1.Name = "fontSizeDecreaseItem1";
            // 
            // showFontFormItem1
            // 
            this.showFontFormItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("showFontFormItem1.Glyph")));
            this.showFontFormItem1.Id = 14;
            this.showFontFormItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.showFontFormItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("showFontFormItem1.LargeGlyph")));
            this.showFontFormItem1.Name = "showFontFormItem1";
            // 
            // clipboardBar1
            // 
            this.clipboardBar1.DockCol = 0;
            this.clipboardBar1.DockRow = 1;
            this.clipboardBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.clipboardBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cutItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.copyItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pasteItem1)});
            // 
            // cutItem1
            // 
            this.cutItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("cutItem1.Glyph")));
            this.cutItem1.Id = 15;
            this.cutItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X));
            this.cutItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("cutItem1.LargeGlyph")));
            this.cutItem1.Name = "cutItem1";
            // 
            // copyItem1
            // 
            this.copyItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("copyItem1.Glyph")));
            this.copyItem1.Id = 16;
            this.copyItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C));
            this.copyItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("copyItem1.LargeGlyph")));
            this.copyItem1.Name = "copyItem1";
            // 
            // pasteItem1
            // 
            this.pasteItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("pasteItem1.Glyph")));
            this.pasteItem1.Id = 17;
            this.pasteItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V));
            this.pasteItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("pasteItem1.LargeGlyph")));
            this.pasteItem1.Name = "pasteItem1";
            // 
            // editingBar1
            // 
            this.editingBar1.DockCol = 1;
            this.editingBar1.DockRow = 1;
            this.editingBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.editingBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.findItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.replaceItem1)});
            this.editingBar1.Offset = 120;
            // 
            // findItem1
            // 
            this.findItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("findItem1.Glyph")));
            this.findItem1.Id = 18;
            this.findItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.findItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("findItem1.LargeGlyph")));
            this.findItem1.Name = "findItem1";
            // 
            // replaceItem1
            // 
            this.replaceItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("replaceItem1.Glyph")));
            this.replaceItem1.Id = 19;
            this.replaceItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H));
            this.replaceItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("replaceItem1.LargeGlyph")));
            this.replaceItem1.Name = "replaceItem1";
            // 
            // stylesBar1
            // 
            this.stylesBar1.DockCol = 1;
            this.stylesBar1.DockRow = 0;
            this.stylesBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.stylesBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.changeStyleItem1)});
            this.stylesBar1.Offset = 446;
            // 
            // changeStyleItem1
            // 
            this.changeStyleItem1.Edit = this.repositoryItemRichEditStyleEdit1;
            this.changeStyleItem1.Id = 20;
            this.changeStyleItem1.Name = "changeStyleItem1";
            // 
            // repositoryItemRichEditStyleEdit1
            // 
            this.repositoryItemRichEditStyleEdit1.AutoHeight = false;
            this.repositoryItemRichEditStyleEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRichEditStyleEdit1.Control = this.richEditControl;
            this.repositoryItemRichEditStyleEdit1.Name = "repositoryItemRichEditStyleEdit1";
            // 
            // richEditBarController1
            // 
            this.richEditBarController1.BarItems.Add(this.changeFontNameItem1);
            this.richEditBarController1.BarItems.Add(this.changeFontSizeItem1);
            this.richEditBarController1.BarItems.Add(this.changeFontColorItem1);
            this.richEditBarController1.BarItems.Add(this.changeFontBackColorItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontBoldItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontItalicItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontUnderlineItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontDoubleUnderlineItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontStrikeoutItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontDoubleStrikeoutItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontSuperscriptItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontSubscriptItem1);
            this.richEditBarController1.BarItems.Add(this.fontSizeIncreaseItem1);
            this.richEditBarController1.BarItems.Add(this.fontSizeDecreaseItem1);
            this.richEditBarController1.BarItems.Add(this.showFontFormItem1);
            this.richEditBarController1.BarItems.Add(this.cutItem1);
            this.richEditBarController1.BarItems.Add(this.copyItem1);
            this.richEditBarController1.BarItems.Add(this.pasteItem1);
            this.richEditBarController1.BarItems.Add(this.findItem1);
            this.richEditBarController1.BarItems.Add(this.replaceItem1);
            this.richEditBarController1.BarItems.Add(this.changeStyleItem1);
            this.richEditBarController1.RichEditControl = this.richEditControl;
            // 
            // RrichEditBarMannagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richEditControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "RrichEditBarMannagerControl";
            this.Size = new System.Drawing.Size(721, 607);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditFontSizeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControl;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraRichEdit.UI.FontBar fontBar1;
        private DevExpress.XtraRichEdit.UI.ChangeFontNameItem changeFontNameItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraRichEdit.UI.ChangeFontSizeItem changeFontSizeItem1;
        private DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit repositoryItemRichEditFontSizeEdit1;
        private DevExpress.XtraRichEdit.UI.ChangeFontColorItem changeFontColorItem1;
        private DevExpress.XtraRichEdit.UI.ChangeFontBackColorItem changeFontBackColorItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontBoldItem toggleFontBoldItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontItalicItem toggleFontItalicItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontUnderlineItem toggleFontUnderlineItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontDoubleUnderlineItem toggleFontDoubleUnderlineItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontStrikeoutItem toggleFontStrikeoutItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontDoubleStrikeoutItem toggleFontDoubleStrikeoutItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontSuperscriptItem toggleFontSuperscriptItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontSubscriptItem toggleFontSubscriptItem1;
        private DevExpress.XtraRichEdit.UI.FontSizeIncreaseItem fontSizeIncreaseItem1;
        private DevExpress.XtraRichEdit.UI.FontSizeDecreaseItem fontSizeDecreaseItem1;
        private DevExpress.XtraRichEdit.UI.ShowFontFormItem showFontFormItem1;
        private DevExpress.XtraRichEdit.UI.ClipboardBar clipboardBar1;
        private DevExpress.XtraRichEdit.UI.CutItem cutItem1;
        private DevExpress.XtraRichEdit.UI.CopyItem copyItem1;
        private DevExpress.XtraRichEdit.UI.PasteItem pasteItem1;
        private DevExpress.XtraRichEdit.UI.EditingBar editingBar1;
        private DevExpress.XtraRichEdit.UI.FindItem findItem1;
        private DevExpress.XtraRichEdit.UI.ReplaceItem replaceItem1;
        private DevExpress.XtraRichEdit.UI.StylesBar stylesBar1;
        private DevExpress.XtraRichEdit.UI.ChangeStyleItem changeStyleItem1;
        private DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit repositoryItemRichEditStyleEdit1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraRichEdit.UI.RichEditBarController richEditBarController1;
    }
}
