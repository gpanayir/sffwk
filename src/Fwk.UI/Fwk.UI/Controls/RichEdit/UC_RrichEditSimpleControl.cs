using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.UI.Controls
{
    public partial class UC_RichEditSimpleControl : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_RichEditSimpleControl()
        {
            InitializeComponent();
            RtfLoadHelper.Load("TextWithImages.rtf", richEditControl);
           
        }
        [Category("Fwk.Factory")]
        public override string Text
        {
            get { return richEditControl.Text; }
            set
            {
                richEditControl.Text = value;
            }
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
