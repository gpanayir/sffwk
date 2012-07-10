using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Fwk.UI.Controls
{
    [ToolboxItem(true)]
    [DefaultEvent("OnFindClick")]
    public partial class UC_TextFind : DevExpress.XtraEditors.XtraUserControl
    {
   
        [Category("Fwk.Factory")]
        public event EventHandler OnFindClick;
        [Category("Fwk.Factory")]
        public event EventHandler OnFindTextBoxEnter;

        [Category("Fwk.Factory")]
        [Description("Editor de texto del control")]
        public DevExpress.XtraEditors.ButtonEdit TextEditor
        {
            get { return textEditor; }
            set { textEditor = value; }
        }
        public UC_TextFind()
        {
            InitializeComponent();
        }

       

        private void txtFind_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (OnFindClick == null) return;
            FindEventArg arg = new FindEventArg();
            arg.Text = textEditor.Text;
            arg.IsAdvancedFind = false;
            if (OnFindClick != null)
                OnFindClick(this, arg);
        }
        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (OnFindTextBoxEnter == null) return;
            if (e.KeyChar != (char)Keys.Enter) return;
            FindEventArg arg = new FindEventArg();
            arg.Text = textEditor.Text;
            arg.IsAdvancedFind = false;
            OnFindTextBoxEnter(this, arg);
        }

       
    }
}
