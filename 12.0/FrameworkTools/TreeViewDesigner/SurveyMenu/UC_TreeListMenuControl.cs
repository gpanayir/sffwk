using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controls.Menu.Tree;



namespace Fwk.Tools.TreeView
{
    public delegate void MenuItemClickHandler(Fwk.UI.Controls.Menu.Tree.MenuItem pMenuItemSelected, MenuEventArgs Args);

    [DefaultEvent("MenuItemClick")]
    public partial class UC_TreeListMenuControl : UserControl
    {

        #region Declarations
        bool _viewImage = true;
        bool _OnInitLoad = true;
        Fwk.UI.Controls.Menu.Tree.MenuItem _MenuItemSelected = null;
        #endregion

        #region Properties & Events
        [Browsable(false)]
        public Fwk.UI.Controls.Menu.Tree.MenuItem MenuItemSelected
        {
            get { return _MenuItemSelected; }
            set { _MenuItemSelected = value; }
        }
   

        public String DisplayTextCaption
        {
            get { return this.colDisplayName.Caption; }
            set { this.colDisplayName.Caption = value; }
        }
        public String TypeImageCaption
        {
            get { return this.colTypeImage.Caption; }
            set { this.colTypeImage.Caption = value; }
        }

        public bool ViewImages
        {
            get { return _viewImage; }
            set
            {
                _viewImage = value;
                ChangeView(_viewImage);
            }

        }

        public event MenuItemClickHandler MenuItemClick;

        void OnMenuItemClick(MenuEventArgs args)
        {
            if (MenuItemClick != null)
                MenuItemClick(_MenuItemSelected, args);
        }


        #endregion

        #region Constructor
        public UC_TreeListMenuControl()
        {
            InitializeComponent();
        }
        #endregion


        public void Populate(string pFullFileName,ImageList imgList)
        {
            if (string.IsNullOrEmpty(pFullFileName)) return;
            this.imageList1 = imgList;

            TreeMenu menu = TreeListEngineDevExpress.LoadMenuFromFile(pFullFileName);
            this.menuItemSurveyBindingSource.DataSource = menu.ItemList;

            //foreach (MenuImage mi in menu.ImageList.OrderBy<MenuImage, int>(p => p.Index))
            //{
            //    imageList1.Images.Add(mi.Image);
            //}

            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.SelectImageList = this.imageList1;

            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            treeList1.ExpandAll();
            treeList1.RefreshDataSource();
        }

       
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (_OnInitLoad) 
                return;

            if (e.Node == null) 
                return;

            if (e.Node.TreeList.FocusedColumn == null) 
                return;

            if (e.Node.TreeList.FocusedColumn.Name == "colTypeImage" && _viewImage == true) 
                return;

            _MenuItemSelected = (Fwk.UI.Controls.Menu.Tree.MenuItem)treeList1.GetDataRecordByNode(e.Node);

            if (_MenuItemSelected != null)
            {
                MenuEventArgs wMenuEventArgs = new MenuEventArgs(e.Node.TreeList.FocusedColumn.Name, e.Node.TreeList.FocusedColumn.FieldName);
                String s = e.Node.TreeList.FocusedColumn.FieldName;
                OnMenuItemClick(wMenuEventArgs);
            }
        }

        private void TreeListMenuControl_Load(object sender, EventArgs e)
        {
            _OnInitLoad = false;
        
    
        }

        /// <summary>
        /// Cambia la vista de la columna imagen
        /// </summary>
        /// <param name="pViewImage">Si es true la imagen sera siempre visible</param>
        public void ChangeView(Boolean pViewImage)
        {
            _viewImage = pViewImage;
            colTypeImage.Visible = pViewImage;
            colDisplayName.Visible = !colTypeImage.Visible;

            if (_viewImage)
            {
                this.colTypeImage.ColumnEdit = this.repositoryItemPictureEdit1;
                this.btnchangeImageView.Image = global::Fwk.Tools.Properties.Resources.Window_full_screen_16x16;
                this.btnchangeImageView.Text = "Ocultar imagenes";
            }
            
            else
            {
                this.colTypeImage.ColumnEdit = this.repositoryItemImageEdit1;
                this.btnchangeImageView.Image = global::Fwk.Tools.Properties.Resources.Window_nofullscreen;
                this.btnchangeImageView.Text = "Ver imagenes";
            }

            _viewImage = !_viewImage;
        }

        private void btnchangeImageView_Click(object sender, EventArgs e)
        {
            ChangeView(_viewImage);
        }
    }


    public class MenuEventArgs : EventArgs
    {
        #region Members & Properties
        String _ColName;
        String _FieldName;

        public String ColName
        {
            get { return _ColName; }
        }

        public String FieldName
        {
            get { return _FieldName; }
        }
        #endregion

        #region Constructor
        public MenuEventArgs(string pColName, string pFieldName)
        {
            _ColName = pColName;
            _FieldName = pFieldName;
        }
        #endregion
    }

}
