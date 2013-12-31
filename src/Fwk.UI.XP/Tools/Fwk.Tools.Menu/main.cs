using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controls.Menu;
using Fwk.Security;
using System.Web.Security;
using Fwk.Caching;
using Fwk.UI.Security.Controls;

namespace Fwk.Tools.Menu
{
    public partial class Main : Form
    {
        #region [Private vars]
    
 

        //private Int32 _newMenuBarIndex = 0;
        //private Int32 _newToolBarIndex = 0;

        #endregion
        public Main()
        {
            InitializeComponent();
            //Common.Controls.Menu.ToolBar toolBar = new Pelsoft.FrontEnd.Common.Controls.Menu.ToolBar();
            //toolBar.Add(new ButtonBase());
            //Common.Controls.Menu.Helper.SaveToolBarToFile(toolBar, "prueba.xml");
            Init();
        }
        
        #region [Menu Event Handling]

        private void optNewMenuBar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewMenuBarDesigner(false);

        }

        private void optSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SaveCurrentForm(false);

        }

        private void optSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveCurrentForm(true);
        }

        private void optOpenMenuBar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            NewMenuBarDesigner(true);

        }

        private void optNewToolBar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            NewToolBarDesigner(false);
            
        }

        private void optOpenToolBar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            NewToolBarDesigner(true);

        }

        #endregion

        #region [Private Methods]

        private void SaveCurrentForm(bool showDialog)
        {

            //string fileName = string.Empty;

            //if(xtraTabbedMdiManager1.SelectedPage ==null)
            //{
            //    return;
            //}

            //IControlDesigner designerForm = (IControlDesigner)xtraTabbedMdiManager1.SelectedPage.MdiChild;

            //fileName = designerForm.SavedFileName;
            
            //if(showDialog || designerForm.SavedFileName == string.Empty)
            //{
            //    ///TODO: usar Fwk.HelperFunctions.FileFunctions.OpenFileDialog_New
            //    fileName = Common.Controls.Menu.Helper.SaveFile(designerForm.SavedFileName);
            //}

            //if (fileName == string.Empty)
            //{
            //    return;
            //}

            //designerForm.SaveToFile(fileName);
            Fwk.Security.FwkAuthorizationRule hh = new FwkAuthorizationRule();
        }

        private void NewMenuBarDesigner(bool showOpenFileDialog)
        {
            //MenuBarDesigner newDesigner = new MenuBarDesigner(_MenuFileList_MenuBar, _FwkCache);
            
            //if (showOpenFileDialog)
            //{
            //    string fileName = Common.Controls.Menu.Helper.OpenFile(Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter);
            //    if(fileName == string.Empty)
            //    {
            //        return;
            //    }
            //    newDesigner.Text = fileName;
            //    newDesigner.LoadFromFile(fileName);
            //}
            //else
            //{
            //    newDesigner.Text = "MenuBar" + _newMenuBarIndex;
            //    _newMenuBarIndex++;
            //}

            //newDesigner.MdiParent = this;
            //newDesigner.Show();

        }

        private void NewToolBarDesigner(bool showOpenFileDialog)
        {
            //ToolBarDesigner newDesigner = new ToolBarDesigner(_MenuFileList_ToolBar, _FwkCache);

            //if (showOpenFileDialog)
            //{
            //    string fileName = Common.Controls.Menu.Helper.OpenFile(Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter);
            //    if (fileName == string.Empty)
            //    {
            //        return;
            //    }
            //    newDesigner.Text = fileName;
            //    newDesigner.LoadFromFile(fileName);
            //}
            //else
            //{
            //    newDesigner.Text = "ToolBar" + _newMenuBarIndex;
            //    _newMenuBarIndex++;
            //}

            //newDesigner.MdiParent = this;
            //newDesigner.Show();

        }

        
        MenuFileList _MenuFileList_ToolBar = null;
        MenuFileList _MenuFileList_MenuBar = null;
        public static Fwk.Caching.FwkSimpleStorageBase<MenuFileList> storeToolBar = new FwkSimpleStorageBase<MenuFileList>();
        public static Fwk.Caching.FwkSimpleStorageBase<MenuFileList> storeMenuBar = new FwkSimpleStorageBase<MenuFileList>();
        internal void Init()
        {

            try
            {
                //UC_RuleSelector.Rules = FwkMembership.GetRulesList("secProvider");
            }
            catch
            { }
            storeToolBar.Load();
            storeToolBar.Load();
            _MenuFileList_ToolBar = storeToolBar.StorageObject;

            if (_MenuFileList_ToolBar == null)
            {
                _MenuFileList_ToolBar = new MenuFileList();
            }

            _MenuFileList_MenuBar = storeToolBar.StorageObject;

            if (_MenuFileList_MenuBar == null)
            {
                _MenuFileList_MenuBar = new MenuFileList();
            }
      

        }
        #endregion

       

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FRM_ToolBarDesigner newDesigner = new FRM_ToolBarDesigner(_MenuFileList_ToolBar);

            newDesigner.MdiParent = this;
            newDesigner.Show();
        }

        private void barButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FRM_MenuBarDesigner newDesigner = new FRM_MenuBarDesigner(_MenuFileList_MenuBar);
            newDesigner.MdiParent = this;
            newDesigner.Show();
        }

    }


}
