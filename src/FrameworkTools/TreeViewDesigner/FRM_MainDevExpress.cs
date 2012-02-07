using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions;
using DevExpress.XtraTreeList.Nodes;


namespace Fwk.Tools.SurveyMenu
{

    public partial class FRM_MainDevExpress : Form
    {
        #region Members

        bool _Saved = false;
        MenuItemList _MenuItemSurveyList;
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
            _MenuItemSurveyList = new MenuItemList();
            _CurrentFullFileName = FileFunctions.OpenFileDialog_New(_MenuItemSurveyList.GetXml(), FileFunctions.OpenFilterEnums.OpenXmlFilter, true);

            LoadMenuFile();
        }

        void LoadMenuFile()
        {
            if (String.IsNullOrEmpty(_CurrentFullFileName))
                return;

            try
            {
                this.menuItemSurveyBindingSource.DataSource = _MenuItemSurveyList = TreeListEngineDevExpress.LoadMenuFromFile(_CurrentFullFileName);
                treeList1.ExpandAll();
                treeList1.RefreshDataSource();
                lblFileLoad.Text = String.Concat("File ", _CurrentFullFileName);
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

            TreeListEngineDevExpress.SaveMenuToFile(_CurrentFullFileName, _MenuItemSurveyList);
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
                    _MenuItemSurveyList.Remove(_MenuItemSelected);
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
            MenuItem wMenuItemNew = new MenuItem();

            if (_MenuItemSurveyList == null)
                return;

            if (_MenuItemSelected == null)
            {
                AddCategory();
                return;

            }

            if (!_MenuItemSelected.IsCategory)
            {
                fwkMessageView_Error.Show("The selected menu item is not category menu");
                return;
            }

            wMenuItemNew.ParentID = _MenuItemSelected.ID;
            wMenuItemNew.Category = _MenuItemSelected.Category;

            using (FRM_EditSurvey wFrm = new FRM_EditSurvey(wMenuItemNew, Action.New))
            {
                if (wFrm.ShowDialog() == DialogResult.OK)
                {
                    if (_MenuItemSelected != null)
                        wMenuItemNew.ID = _MenuItemSurveyList.Count + 1;

                    _MenuItemSurveyList.Add(wMenuItemNew);
                    treeList1.RefreshDataSource();
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
            if (_MenuItemSurveyList == null)
                return;

            if (_MenuItemSelected == null)
            {
                fwkMessageView_Warning.Show("Please.. select any menu to execute this option.-");
                return;
            }
            //Load del Pelsoftulario de edicion de menues
            using (FRM_EditSurvey frm = new FRM_EditSurvey(_MenuItemSelected, Action.Edit))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    treeList1.RefreshDataSource();

                    //Si la categoria cambio. hay que cambiar la categoria de los hijos inmediatos que no son categorias .-
                    if (frm.CategoryChange)
                    {
                        foreach (MenuItem menuChild in _MenuItemSurveyList)
                        {
                            if (menuChild.ParentID == _MenuItemSelected.ID && !menuChild.IsCategory)
                                menuChild.Category = _MenuItemSelected.Category;
                        }
                    }
                }
            }

            _Saved = false;
        }

        private void AddCategory()
        {
            if (_MenuItemSurveyList == null)
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

            if (_MenuItemSelected == null)
                wMenuItemNewCategory.ParentID = 0;
            else
                wMenuItemNewCategory.ParentID = _MenuItemSelected.ID;

            wMenuItemNewCategory.ID = _MenuItemSurveyList.Count + 1;
            wMenuItemNewCategory.DisplayName = "Category " + (_MenuItemSurveyList.Count + 1);
            wMenuItemNewCategory.Category = wMenuItemNewCategory.DisplayName;
            wMenuItemNewCategory.IsCategory = true;
            _MenuItemSurveyList.Add(wMenuItemNewCategory);

            treeList1.RefreshDataSource();
            _Saved = false;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            _MenuItemSelected = (MenuItem)treeList1.GetDataRecordByNode(e.Node);

            if (_MenuItemSelected != null)
            {
                menuItemEditorSurvey1.ShowAction = Action.Query;
                menuItemEditorSurvey1.MenuItemSelected = _MenuItemSelected;
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

                    TreeListEngineDevExpress.SaveMenuToFile(_CurrentFullFileName, _MenuItemSurveyList);

                    fwkMessageView_Warning.Show("Menu sussefully saved");
                }
            }
        }


        private void btnAddCategory1_Click(object sender, EventArgs e)
        {
            AddCategory();
        }

        private void btnMenuPreview_Click(object sender, EventArgs e)
        {
            using (FRM_TestMenu frm = new FRM_TestMenu(_CurrentFullFileName))
            {
                frm.ShowDialog();
            }
        }

    }
}
