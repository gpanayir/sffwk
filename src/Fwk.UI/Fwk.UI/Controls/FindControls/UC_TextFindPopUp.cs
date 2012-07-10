using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace Fwk.UI.Controls
{
    [ToolboxItem(true)]
    [DefaultEvent("OnFindClick")]
    public partial class UC_TextFindPopUp : DevExpress.XtraEditors.XtraUserControl
    {
        bool _FindExpanded = false;
        [Category("Fwk.Factory")]
        public event EventHandler OnFindClick;
        [Category("Fwk.Factory")]
        public event EventHandler OnFindTextBoxEnter;

        [Category("Fwk.Factory")]
        public RepositoryItemPopupContainerEdit Properties

        {
            get {return  btnExpand.Properties; }
        }
        
        [Category("Fwk.Factory")]
        public PopupContainerControl PopupControl

        {
            get {return  btnExpand.Properties.PopupControl; }
            set { btnExpand.Properties.PopupControl = value; }
        }
         [Category("Fwk.Factory")]
        public bool AllowAdvancedSearch
        {
            get { return btnExpand.Visible ; }
            set {  btnExpand.Visible = value; }
            
        }
         [Category("Fwk.Factory")]
        [Description("Editor de texto del control")]
         public DevExpress.XtraEditors.ButtonEdit TextEditor
         {
             get { return textEditor; }
             set { textEditor = value; }
         }

        public UC_TextFindPopUp()
        {
            InitializeComponent();
        }

        private void popupContainerEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            _FindExpanded = !_FindExpanded;
        }

        

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (OnFindTextBoxEnter == null) return;
            if (e.KeyChar != (char)Keys.Enter) return;
            FindEventArg arg = new FindEventArg();
            arg.Text = btnExpand.Text;
            arg.IsAdvancedFind = _FindExpanded;
            OnFindTextBoxEnter(this, arg);

        }

        private void txtFind_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (OnFindClick == null) return;
            FindEventArg arg = new FindEventArg();
            arg.Text = btnExpand.Text;
            arg.IsAdvancedFind = _FindExpanded;
            if (OnFindClick != null)
                OnFindClick(this, arg);
        }

        private void txtFind_Properties_BeforeShowMenu(object sender, DevExpress.XtraEditors.Controls.BeforeShowMenuEventArgs e)
        {

        }

        private void popupContainerEdit1_Popup(object sender, EventArgs e)
        {

        }

        private void popupContainerEdit1_Properties_BeforeShowMenu(object sender, DevExpress.XtraEditors.Controls.BeforeShowMenuEventArgs e)
        {

        }

        private void popupContainerEdit1_Properties_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

        }

        private void btnExpand_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
