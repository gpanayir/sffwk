using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Fwk.UI.Controls
{
    [ToolboxItem(true)]
    public partial class UC_RrichEditBarMannagerControl : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_RrichEditBarMannagerControl()
        {
            InitializeComponent();
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

        private void barManager1_ShortcutItemClick(object sender, DevExpress.XtraBars.ShortcutItemClickEventArgs e)
        {



            BarShortcut shortcut = e.Shortcut;
            if (shortcut == pasteItem1.ItemShortcut)
            {
                if (!this.richEditControl.Focused)
                    e.Cancel = true;
            }
            else
                e.Cancel = false;
        }




    }
}
