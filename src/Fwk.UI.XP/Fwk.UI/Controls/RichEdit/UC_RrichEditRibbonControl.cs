using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraSpellChecker;
using DevExpress.XtraSpellChecker.Native;
using DevExpress.XtraSpellChecker.Parser;
using DevExpress.XtraRichEdit.SpellChecker;


namespace Fwk.UI.Controls
{
    [ToolboxItem(true)]
    public partial class UC_RrichEditRibbonControl : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_RrichEditRibbonControl()
        {
            InitializeComponent();
            RtfLoadHelper.Load("TextWithImages.rtf", richEditControl);
        }

        //public override RichEditControl PrintingRichEditControl { get { return richEditControl; } }

        //protected override void DoShow() {
        //    base.DoShow();
        //    richEditControl.Focus();
        //}

        private void RibbonModule_Load(object sender, EventArgs e) {
            if (DesignMode)
                return;

            SpellCheckerHelper.AddDictionaries(sharedDictionaryStorage1);
        }
        void checkSpellingItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            spellChecker1.Check(richEditControl);
        }
        void richEditControl_ReadOnlyChanged(object sender, EventArgs e) {
            this.checkSpellingItem.Enabled = !richEditControl.ReadOnly;
        }
        [Category("Fwk.Factory")]
        public override string Text
        {
            get { return richEditControl.Text; }
        }
        [Category("Fwk.Factory")]
        public string RtfText
        {
            get { return richEditControl.RtfText; }
            set
            {
                richEditControl.RtfText = value;
            }
        }
    }
}
