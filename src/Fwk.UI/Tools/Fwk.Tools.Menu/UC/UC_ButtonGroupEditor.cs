using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controls.Menu;
using DevExpress.XtraNavBar;

namespace Fwk.Tools.Menu
{
    [ToolboxItem(false)]
    public partial class UC_ButtonGroupEditor : UC_MenuItemEditor
    {
        private BarGroup _CopyGroup;
        private BarGroup _OriginalGroup;
        Fwk.UI.Controls.Menu.MenuNavBar _MenuNavBar;

        public UC_ButtonGroupEditor()
        {
            InitializeComponent();

        }



        #region [Public Methods]
        public override void LoadControl(MenuItemBase btn, object parent)
        {
            _MenuNavBar = (MenuNavBar)parent;
            _OriginalGroup = (BarGroup)btn;
            _CopyGroup = _OriginalGroup.Clone<BarGroup>();

            txtId.Text = _CopyGroup.Id;
            txtCaption.Text = _CopyGroup.Caption;
            txtToolTip.Text = _CopyGroup.ToolTipText;
            this.radioGroup1.EditValue = !_CopyGroup.ContainTree;

            if (_CopyGroup.ContainTree)
            {
                cmdGroupStyle.Enabled = false;
                _CopyGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            }
            else
            {
                int index = cmdGroupStyle.FindStringExact(Enum.GetName(typeof(NavBarGroupStyle), _CopyGroup.GroupStyle));
                cmdGroupStyle.SelectedIndex = index;

            }

            if (ActionType == Fwk.UI.Common.ActionTypes.Create)
            {
                base.AceptButtonText = "Agregar grupo";
            }
             if (ActionType == Fwk.UI.Common.ActionTypes.Edit)
            {
                base.AceptButtonText = "Aplicar cambio al grupo";
            }
            this.radioGroup1.Enabled = (ActionType == Fwk.UI.Common.ActionTypes.Create);
            //buttonGroupsBindingSource.DataSource = _NavBarGroup;
            //buttonGroupsBindingSource.ResetBindings(false);
        }

        #endregion

        #region [MenuItemEditor Overrides]
        protected override void SaveModifications()
        {
            if (_MenuNavBar.Exist(txtId.Text) && this.ActionType == Fwk.UI.Common.ActionTypes.Create)
            {
                base.MessageViewer.Show(string.Concat("Ya existe un ID = ", txtId.Text));
                txtId.SelectAll();
                txtId.Focus();
                return;
            }

            

            _CopyGroup.Id = txtId.Text;
            _CopyGroup.Caption = txtCaption.Text;
            _CopyGroup.ToolTipText = txtToolTip.Text;

            _CopyGroup.ContainTree = !(bool)this.radioGroup1.EditValue;//radioButton_Tree.Checked;
            _CopyGroup.GroupStyle = (NavBarGroupStyle)Enum.Parse(typeof(NavBarGroupStyle), cmdGroupStyle.Text);
            OnMenuItemSaved(new MenuItemSavedEventArgs(_CopyGroup));

        }

        protected override void CancelModifications()
        {
            OnMenuItemCancel(new MenuItemSavedEventArgs(_OriginalGroup));
        }

        #endregion

        private void buttonGroupsBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            //OnEditorValueChanges();
        }
    }
}
