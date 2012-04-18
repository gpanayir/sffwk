using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.UI.Controls.Menu;

namespace Fwk.Tools.Menu
{
    [ToolboxItem(false)]
    public partial class UC_MenuEditor : UC_MenuItemEditor
    {
        private Fwk.UI.Controls.Menu.BarGroup _Menu;
        private Fwk.UI.Controls.Menu.BarGroup _MenuOriginal;
        object  _Parent;
        public UC_MenuEditor()
        {
            InitializeComponent();
        }

        #region [Public Methods]

        public override void LoadControl(MenuItemBase btn, object parent)
        {
            _Parent = parent;
            BarGroup menuToLoad = (BarGroup)btn;
           _Menu = menuToLoad.Clone<Fwk.UI.Controls.Menu.BarGroup>();
            _MenuOriginal = menuToLoad;

            menuBindingSource.DataSource = _Menu;
            menuBindingSource.ResetBindings(false);
        }
      
        #endregion

        #region [Overrided Methods]
        protected override void SaveModifications()
        {
            //_menuOriginal.SetXml(_menu.GetXml());
            _MenuOriginal.Caption = _Menu.Caption;
            _MenuOriginal.Id = _Menu.Id;
            _MenuOriginal.ToolTipText = _Menu.ToolTipText;
            
            OnMenuItemSaved(new MenuItemSavedEventArgs(_MenuOriginal));
        }

        protected override void CancelModifications()
        {
            LoadControl(_MenuOriginal, _Parent);
        }
        #endregion


        private void menuBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            //OnEditorValueChanges();
        }
    }
}
