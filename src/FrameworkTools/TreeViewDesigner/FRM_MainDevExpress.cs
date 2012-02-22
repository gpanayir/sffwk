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
using Fwk.Caching;
using Fwk.UI.Controls.Menu.Tree;


namespace Fwk.Tools.TreeView
{

    public partial class FRM_MainDevExpress : Form
    {
        #region Members
        static FwkSimpleStorageBase<ClientUserSettings> storage = new FwkSimpleStorageBase<ClientUserSettings>();
        bool _Saved = false;
        internal static TreeMenu Menu;
        //MenuItemList menu.ItemList;
        string _CurrentFullFileName;
        Fwk.UI.Controls.Menu.Tree.MenuItem _MenuItemSelected;

        #endregion

        #region Properties

        public FRM_MainDevExpress()
        {
            InitializeComponent();
        }

        #endregion

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Menu = new TreeMenu();
            
            
            _CurrentFullFileName = FileFunctions.OpenFileDialog_New(Menu.GetXml(), FileFunctions.OpenFilterEnums.OpenXmlFilter, true);

            LoadMenuFile();
        }

        void LoadMenuFile()
        {
            if (String.IsNullOrEmpty(_CurrentFullFileName))
                return;
            menuItemEditorSurvey1.imgList = this.imageList2;
            menuItemEditorSurvey1.PopulateImage();
            try
            {

                Menu = TreeListEngineDevExpress.LoadMenuFromFile(_CurrentFullFileName);
                this.menuItemSurveyBindingSource.DataSource = Menu.ItemList;



            }
            catch (InvalidOperationException)
            {
                fwkMessageView_Error.Show("The file not contain correct Pelsoftat to represent any menu .-");
            }
            catch (Exception ex2)
            {
                fwkMessageView_Error.Show(ex2);
            }
            treeList1.ExpandAll();
            treeList1.RefreshDataSource();
            lblFileLoad.Text = String.Concat("File ", _CurrentFullFileName);
            storage.StorageObject.File = _CurrentFullFileName;
            storage.Save();
         
        }

        public override void Refresh()
        {
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.treeList1.StateImageList = this.imageList2;
            this.treeList1.SelectImageList = this.imageList2;

            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
    
            //treeList1.Refresh();
            base.Refresh();
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_CurrentFullFileName))
                return;

            TreeListEngineDevExpress.SaveMenuToFile(_CurrentFullFileName, Menu);
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
                    Menu.ItemList.Remove(_MenuItemSelected);
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


            if (Menu.ItemList == null)
                return;

            //if (_MenuItemSelected == null)
            //{
            //    AddCategory();
            //    return;
            //}
            if (_MenuItemSelected.ParentID!=0)
            {
                fwkMessageView_Error.Show("The selected menu item is not root menu");
                return;
            }

            Fwk.UI.Controls.Menu.Tree.MenuItem wMenuItemNew = new Fwk.UI.Controls.Menu.Tree.MenuItem();
            wMenuItemNew.ParentID = _MenuItemSelected.ID;
            //wMenuItemNew.Category = _MenuItemSelected.Category;


            using (FRM_EditMenu wFrm = new FRM_EditMenu(Menu, wMenuItemNew, Action.New))
            {
                wFrm.ImageList = this.imageList2;
                if (wFrm.ShowDialog() == DialogResult.OK)
                {
                    if (_MenuItemSelected != null)
                        wMenuItemNew.ID = Menu.GetNewID();

                    Menu.ItemList.Add(wMenuItemNew);
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
            if (Menu.ItemList == null)
                return;

            if (_MenuItemSelected == null)
            {
                fwkMessageView_Warning.Show("Please.. select any menu to execute this option.-");
                return;
            }
            //Load del Pelsoftulario de edicion de menues
            using (FRM_EditMenu frm = new FRM_EditMenu(Menu, _MenuItemSelected, Action.Edit))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    treeList1.RefreshDataSource();
                    treeList1.ExpandAll();
                    //Si la categoria cambio. hay que cambiar la categoria de los hijos inmediatos que no son categorias .-
                    //if (frm.CategoryChange)
                    //{
                    //    foreach (Fwk.UI.Controls.Menu.Tree.MenuItem menuChild in menu.ItemList)
                    //    {
                    //        if (menuChild.ParentID == _MenuItemSelected.ID && !menuChild.IsCategory)
                    //            menuChild.Category = _MenuItemSelected.Category;
                    //    }
                    //}
                }
            }

            _Saved = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuItem"></param>
        private void AddCategory(Fwk.UI.Controls.Menu.Tree.MenuItem menuItem)
        {
            if (Menu.ItemList == null)
                return;

            Fwk.UI.Controls.Menu.Tree.MenuItem wMenuItemNewCategory = new Fwk.UI.Controls.Menu.Tree.MenuItem();
            wMenuItemNewCategory.ParentID = 0;
            wMenuItemNewCategory.ID = Menu.GetNewID();
            wMenuItemNewCategory.DisplayName = "Root node " + (wMenuItemNewCategory.ID);
            //wMenuItemNewCategory.Category = wMenuItemNewCategory.DisplayName;
            //wMenuItemNewCategory.IsCategory = true;
            wMenuItemNewCategory.ImageIndex = 0;
            wMenuItemNewCategory.SelectedImageIndex = 0;
            Menu.ItemList.Add(wMenuItemNewCategory);

            treeList1.RefreshDataSource();
            treeList1.ExpandAll();
            _Saved = false;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            _MenuItemSelected = (Fwk.UI.Controls.Menu.Tree.MenuItem)treeList1.GetDataRecordByNode(e.Node);

            if (_MenuItemSelected != null)
            {
              
                
                menuItemEditorSurvey1.ShowAction = Action.Query;
                menuItemEditorSurvey1.MenuItem = _MenuItemSelected;
                menuItemEditorSurvey1.TreeMenu = Menu;
                menuItemEditorSurvey1.Populate();
                
            }
        }

        //string GetParentCategory(TreeListNode pNode)
        //{
        //    if (pNode.ParentNode != null)
        //    {
        //        Fwk.UI.Controls.Menu.Tree.MenuItem wMenuItemSurvey = (Fwk.UI.Controls.Menu.Tree.MenuItem)treeList1.GetDataRecordByNode(pNode.ParentNode);
        //        if (wMenuItemSurvey != null)
        //        {
        //            if (!string.IsNullOrEmpty(wMenuItemSurvey.Category))
        //            {
        //                return wMenuItemSurvey.Category;
        //            }
        //        }
        //    }

        //    return string.Empty;
        //}

        private void frmMainDevExpress_Leave(object sender, EventArgs e)
        {
            if (!_Saved)
            {
                if (fwkMessageView_Warning.Show("Save file " + _CurrentFullFileName) == DialogResult.OK)
                {
                    if (String.IsNullOrEmpty(_CurrentFullFileName))
                        return;

                    TreeListEngineDevExpress.SaveMenuToFile(_CurrentFullFileName, Menu.ItemList);

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
            using (FRM_TestMenu frm = new FRM_TestMenu(_CurrentFullFileName,this.imageList2))
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
            Refresh();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
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
