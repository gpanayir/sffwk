﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions;
using DevExpress.XtraTreeList.Nodes;
using Fwk.Caching;


namespace Fwk.Tools.SurveyMenu
{

    public partial class FRM_MainDevExpress : Form
    {
        #region Members
        static FwkSimpleStorageBase<ClientUserSettings> storage = new FwkSimpleStorageBase<ClientUserSettings>();
        bool _Saved = false;
        TreeMenu menu;
        //MenuItemList menu.ItemList;
        string _CurrentFullFileName;
        MenuItem _MenuItemSelected;

        #endregion

        #region Properties

        public FRM_MainDevExpress()
        {
            InitializeComponent();
        }

        #endregion

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            menu = new TreeMenu();
            
            
            _CurrentFullFileName = FileFunctions.OpenFileDialog_New(menu.GetXml(), FileFunctions.OpenFilterEnums.OpenXmlFilter, true);

            LoadMenuFile();
        }

        void LoadMenuFile()
        {
            if (String.IsNullOrEmpty(_CurrentFullFileName))
                return;

            try
            {
                
                menu = TreeListEngineDevExpress.LoadMenuFromFile(_CurrentFullFileName);
                RefreshImageList();

                this.menuItemSurveyBindingSource.DataSource = menu.ItemList  ;
                RefreshImageList();
                treeList1.ExpandAll();
                treeList1.RefreshDataSource();
                lblFileLoad.Text = String.Concat("File ", _CurrentFullFileName);
                storage.StorageObject.File = _CurrentFullFileName;
                storage.Save();
            }
            catch (InvalidOperationException)
            {
                fwkMessageView_Error.Show("The file not contain correct Pelsoftat to represent any menu .-");
            }
            catch (Exception ex2)
            {
                fwkMessageView_Error.Show(ex2);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_CurrentFullFileName))
                return;

            TreeListEngineDevExpress.SaveMenuToFile(_CurrentFullFileName, menu);
            _Saved = true;
            fwkMessageView_Warning.Show("Menu sussefully saved");
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            _CurrentFullFileName = FileFunctions.OpenFileDialog_Open(FileFunctions.OpenFilterEnums.OpenXmlFilter);

            if (String.IsNullOrEmpty(_CurrentFullFileName))
                return;

            LoadMenuFile();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMenuItem();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditMenuItem();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletteMenuItem();
        }

        private void DeletteMenuItem()
        {
            if (_MenuItemSelected != null)
                if (fwkMessageView_Warning.Show("Are you sure you want to delette the item menu " + _MenuItemSelected.DisplayName) == DialogResult.OK)
                {
                    menu.ItemList.Remove(_MenuItemSelected);
                    treeList1.RefreshDataSource();
                }
        }


        /// <summary>
        /// Agrega un  MenuItem de negocio.
        /// </summary>
        /// <date>2008-07-13T00:00:00</date>
        /// <author>moviedo</author>
        private void AddMenuItem()
        {
     

            if (menu.ItemList == null)
                return;

            //if (_MenuItemSelected == null)
            //{
            //    AddCategory();
            //    return;
            //}
            if (!_MenuItemSelected.IsCategory)
            {
                fwkMessageView_Error.Show("The selected menu item is not category menu");
                return;
            }

            MenuItem wMenuItemNew = new MenuItem();
            wMenuItemNew.ParentID = _MenuItemSelected.ID;
            wMenuItemNew.Category = _MenuItemSelected.Category;

            using (FRM_EditSurvey wFrm = new FRM_EditSurvey(menu, wMenuItemNew, Action.New))
            {
                if (wFrm.ShowDialog() == DialogResult.OK)
                {
                    if (_MenuItemSelected != null)
                        wMenuItemNew.ID = menu.ItemList.Count + 1;

                    menu.ItemList.Add(wMenuItemNew);
                    treeList1.RefreshDataSource();
                    treeList1.ExpandAll();
                }
            }

            _Saved = false;
        }

        /// <summary>
        /// Edita un  MenuItem de negocio.
        /// </summary>
        /// <date>2008-07-13T00:00:00</date>
        /// <author>moviedo</author>
        private void EditMenuItem()
        {
            if (menu.ItemList == null)
                return;

            if (_MenuItemSelected == null)
            {
                fwkMessageView_Warning.Show("Please.. select any menu to execute this option.-");
                return;
            }
            //Load del Pelsoftulario de edicion de menues
            using (FRM_EditSurvey frm = new FRM_EditSurvey(menu, _MenuItemSelected, Action.Edit))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    treeList1.RefreshDataSource();
                    treeList1.ExpandAll();
                    //Si la categoria cambio. hay que cambiar la categoria de los hijos inmediatos que no son categorias .-
                    if (frm.CategoryChange)
                    {
                        foreach (MenuItem menuChild in menu.ItemList)
                        {
                            if (menuChild.ParentID == _MenuItemSelected.ID && !menuChild.IsCategory)
                                menuChild.Category = _MenuItemSelected.Category;
                        }
                    }
                }
            }

            _Saved = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuItem"></param>
        private void AddCategory(MenuItem menuItem)
        {
            if (menu.ItemList == null)
                return;

            if (_MenuItemSelected != null)
            {
                if (!_MenuItemSelected.IsCategory)
                {
                    fwkMessageView_Warning.Show("Select any category menu to execute this action.-");
                    return;
                }
            }

            MenuItem wMenuItemNewCategory = new MenuItem();

            if (menuItem == null)
                wMenuItemNewCategory.ParentID = 0;
            else
                wMenuItemNewCategory.ParentID = menuItem.ID;

            wMenuItemNewCategory.ID = menu.ItemList.Count + 1;
            wMenuItemNewCategory.DisplayName = "Category " + (menu.ItemList.Count + 1);
            wMenuItemNewCategory.Category = wMenuItemNewCategory.DisplayName;
            wMenuItemNewCategory.IsCategory = true;
            menu.ItemList.Add(wMenuItemNewCategory);

            treeList1.RefreshDataSource();
            treeList1.ExpandAll();
            _Saved = false;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            _MenuItemSelected = (MenuItem)treeList1.GetDataRecordByNode(e.Node);

            if (_MenuItemSelected != null)
            {
                menuItemEditorSurvey1.ShowAction = Action.Query;
                menuItemEditorSurvey1.MenuItem = _MenuItemSelected;
                menuItemEditorSurvey1.TreeMenu = menu;
                menuItemEditorSurvey1.Populate();
            }
        }

        string GetParentCategory(TreeListNode pNode)
        {
            if (pNode.ParentNode != null)
            {
                MenuItem wMenuItemSurvey = (MenuItem)treeList1.GetDataRecordByNode(pNode.ParentNode);
                if (wMenuItemSurvey != null)
                {
                    if (!string.IsNullOrEmpty(wMenuItemSurvey.Category))
                    {
                        return wMenuItemSurvey.Category;
                    }
                }
            }

            return string.Empty;
        }

        private void frmMainDevExpress_Leave(object sender, EventArgs e)
        {
            if (!_Saved)
            {
                if (fwkMessageView_Warning.Show("Save file " + _CurrentFullFileName) == DialogResult.OK)
                {
                    if (String.IsNullOrEmpty(_CurrentFullFileName))
                        return;

                    TreeListEngineDevExpress.SaveMenuToFile(_CurrentFullFileName, menu.ItemList);

                    fwkMessageView_Warning.Show("Menu sussefully saved");
                }
            }

            storage.StorageObject.File = _CurrentFullFileName;
            storage.Save();
        }


        private void btnAddCategory1_Click(object sender, EventArgs e)
        {
            AddCategory(null);
        }

        private void btnMenuPreview_Click(object sender, EventArgs e)
        {
            using (FRM_TestMenu frm = new FRM_TestMenu(_CurrentFullFileName))
            {
                frm.ShowDialog();
            }
        }

        private void FRM_MainDevExpress_Load(object sender, EventArgs e)
        {
            storage.Load();

            if (storage.StorageObject == null)
                storage.InitObject();
            else
            {
                if (System.IO.File.Exists(storage.StorageObject.File))
                {
                    _CurrentFullFileName = storage.StorageObject.File;
                    LoadMenuFile();
                }
            }
        }

        void AddImageToImageList()
        {
            //imageList1.Images.Add();
        }

        void RefreshImageList()
        {
            imageList1.Images.Clear();
            
            foreach (MenuImage mi in menu.ImageList.OrderBy<MenuImage, int>(p => p.Index))
            {
                imageList1.Images.Add(mi.Image);
            }

          
        }
    }

    [Serializable]
    public class ClientUserSettings
    {
        string file;

        public string File
        {
            get { return file; }
            set { file = value; }
        }

    }
}
