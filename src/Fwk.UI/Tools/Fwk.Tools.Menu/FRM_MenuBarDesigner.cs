using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Fwk.Caching;
using Fwk.HelperFunctions;
using System.IO;
using Fwk.UI.Forms;
using Fwk.UI.Controls;
using Fwk.UI.Controls.Menu;
using Fwk.UI.Common;


namespace Fwk.Tools.Menu
{
    public partial class FRM_MenuBarDesigner : FormBase, IControlDesigner
    {
        #region [Private Vars]
        FwkCache _FwkCache = null;
        MenuFileList _MenuFileList = null;
        MenuFile _SelectedMenuFile;
    

        BarGroup _CurrentBarGroup;
        Fwk.UI.Controls.Menu.ButtonBase _CurrentButtonBase;
        #endregion

        #region [Form Event Handling]
        public FRM_MenuBarDesigner(MenuFileList pMenuFilelist, FwkCache cache)
        {
            InitializeComponent();
            _MenuFileList = pMenuFilelist;
            _FwkCache = cache;
            RefreshMenuFileListFromFiles();
            menuFileBindingSource.DataSource = _MenuFileList;
            lstFiles.Refresh();

        }
        private void MenuDesigner_Load(object sender, EventArgs e)
        {

            if (lstFiles.SelectedItem !=null)
            {
                lstFiles.SelectedIndex = 0;
                _SelectedMenuFile = (MenuFile)lstFiles.SelectedItem;
                lblSelectedFileName.Text = _SelectedMenuFile.FullName;
                Load_UC_NavMenu();
            }


        }
        private void MenuBarDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_FwkCache != null)
            {
                _FwkCache.RemoveItem("MenuFileList_MenuBar");
                _FwkCache.SaveItemInCache("MenuFileList_MenuBar", _MenuFileList);
            }
        }
        #endregion

        #region [Private Methods]



        /// <summary>
        /// Limpia el control grpPanel.
        /// </summary>
        private void ClearControlEditor()
        {
            grpEditionContainer.Controls.Clear();
            uC_NavMenu1.Clear();
        }

        void LoadControl<T>(Fwk.UI.Controls.Menu.MenuItemBase pButton, ActionTypes action,object parent) where T : UC_MenuItemEditor
        {
            grpEditionContainer.Controls.Clear();
            T wEditor = (T)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(typeof(T).AssemblyQualifiedName);

            grpEditionContainer.Controls.Add(wEditor);
            wEditor.Dock = DockStyle.Fill;
            wEditor.ActionType = action;
            wEditor.BringToFront();
            wEditor.LoadControl(pButton, parent);
            wEditor.MenuItemSaved += new MenuItemSavedHandler(menuEditor_MenuItemSaved);
            wEditor.MenuItemCancel += new MenuItemSavedHandler(groupEditor_MenuItemCancel);
        }


        private void menuEditor_MenuItemSaved(object sender, MenuItemSavedEventArgs e)
        {
            uC_NavMenu1.ActiveGroupChanged -= new DevExpress.XtraNavBar.NavBarGroupEventHandler(uC_NavMenu1_ActiveGroupChanged);

            #region Group
            if (grpEditionContainer.Controls[0].GetType() == typeof(UC_ButtonGroupEditor))
            {
                if (((UC_ButtonGroupEditor)grpEditionContainer.Controls[0]).ActionType == ActionTypes.Create)
                 
                    uC_NavMenu1.Add_BarGroup((BarGroup)e.MenuItem,true);
                else
                {
                    uC_NavMenu1.Update_BarGroup((BarGroup)e.MenuItem);
                }
                
            }
            #endregion

            #region  Simple button
            if (grpEditionContainer.Controls[0].GetType() == typeof(UC_ButtonBaseEditor))
            {
                if (((UC_ButtonBaseEditor)grpEditionContainer.Controls[0]).ActionType == ActionTypes.Create)
                    uC_NavMenu1.Add_ItemToGroup(uC_NavMenu1.ActiveGroup, (Fwk.UI.Controls.Menu.ButtonBase)e.MenuItem);
                else
                    uC_NavMenu1.Update_ItemFromGroup((Fwk.UI.Controls.Menu.ButtonBase)e.MenuItem);
            }
      
            SaveToFile(_SelectedMenuFile);
            #endregion

            grpEditionContainer.Controls.Clear();
            uC_NavMenu1.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(uC_NavMenu1_ActiveGroupChanged);
        }

        void groupEditor_MenuItemCancel(object sender, MenuItemSavedEventArgs e)
        {
            grpEditionContainer.Controls.Clear();
        }


        #endregion


        /// <summary>
        /// Agrega un grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNavBar_Click(object sender, EventArgs e)
        {
            if (_SelectedMenuFile == null) return;
            _CurrentBarGroup = new BarGroup();
            _CurrentBarGroup.EntityState = Fwk.Bases.EntityState.Added;
            if (uC_NavMenu1.MenuBar == null) uC_NavMenu1.MenuBar = new MenuNavBar();
            LoadControl<UC_ButtonGroupEditor>(_CurrentBarGroup, ActionTypes.Create, uC_NavMenu1.MenuBar);
        }


        private void uC_NavMenu1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            //uC_NavMenu1.ActiveGroup = e.Group;
            LoadControl<UC_ButtonGroupEditor>(((BarGroup)uC_NavMenu1.ActiveGroup.Tag), ActionTypes.Edit, uC_NavMenu1.MenuBar);
        }

        /// <summary>
        /// Agregar Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNavItem_Click(object sender, EventArgs e)
        {
            if (uC_NavMenu1.ActiveGroup == null) return;
            //Si se agrega a un arbol es un TreeNodeButton
            if (((BarGroup)uC_NavMenu1.ActiveGroup.Tag).ContainTree)
            {
                TreeNodeButton newTreeNodeButton = new TreeNodeButton();

                //Asigno el padre del nodo
                if (_CurrentButtonBase != null)
                {
                    newTreeNodeButton.ParentID = _CurrentButtonBase.Id;
                }

                //determino que el actual nodo es el q acabo de crear
                _CurrentButtonBase = (Fwk.UI.Controls.Menu.ButtonBase)newTreeNodeButton;
            }
            //Si se agrega a una simple navbar es un ButtonBase (como simple link)
            else
                _CurrentButtonBase = new Fwk.UI.Controls.Menu.ButtonBase();



            LoadControl<UC_ButtonBaseEditor>(_CurrentButtonBase, ActionTypes.Create, uC_NavMenu1.ActiveGroup.Tag);
        }


        #region [Menu de archivos]
        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((MenuFile)lstFiles.SelectedItem).FileExist == false)
            {
                lblFileRemoved.Visible = true;
            }
            else
                lblFileRemoved.Visible = false;
        }

        private void lstFiles_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null) return;
            
            if (_SelectedMenuFile != null)
                if (_SelectedMenuFile.FullName.Equals(((MenuFile)lstFiles.SelectedItem).FullName))
                    return;
                
            try
            {
                if (_SelectedMenuFile != null && _SelectedMenuFile.Saved == false)
                {
                    _SelectedMenuFile.MenuBar = uC_NavMenu1.MenuBar;
                    SaveToFile(_SelectedMenuFile);
                }
                /// Establezco el actual menu file .-
                _SelectedMenuFile = (MenuFile)lstFiles.SelectedItem;

                lblSelectedFileName.Text = _SelectedMenuFile.FullName;
                ClearControlEditor();
                Load_UC_NavMenu();
            }
            catch (System.IndexOutOfRangeException)
            { }
        }
      

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (_SelectedMenuFile == null) return;
            _SelectedMenuFile.MenuBar =  uC_NavMenu1.MenuBar;//GenerateMenuBarFromTree();
            SaveToFile(_SelectedMenuFile);
        }

        private void saveAllToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (MenuFile f in _MenuFileList)
            {
                if (f.Saved == false)
                    SaveToFile(f);
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Add_MenuFile(true);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Add_MenuFile(false);
        }

        private void removeFiletoolStripBtn_Click(object sender, EventArgs e)
        {
            if (_SelectedMenuFile == null) return;
            base.MessageViewer.MessageBoxButtons = MessageBoxButtons.YesNo;
            base.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Question;
            bool remove = true;

            if (_SelectedMenuFile.FileExist)
            {
                if (base.MessageViewer.Show(string.Concat("Quitar ", _SelectedMenuFile.FullName, " de la lista ?")) == DialogResult.No)
                {
                    remove = false;
                }
                base.SetMessageViewInfoDefault();
            }


            if (remove)
            {
                _MenuFileList.Remove(_SelectedMenuFile);
                _SelectedMenuFile = null;
                lblSelectedFileName.Text = "[...]";
            }
            if (lstFiles.Items.Count > 0) lstFiles.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            //MenuNavBar MenuBar = GenerateMenuBarFromTree();

            //menuControl2.LoadFromXml(MenuBar.GetXml());
        }

        /// <summary>
        /// Agrega un nuevo menu file a la lista de archivos 
        /// </summary>
        /// <param name="isNew"></param>
        void Add_MenuFile(bool isNew)
        {
            uC_NavMenu1.ActiveGroupChanged -= new DevExpress.XtraNavBar.NavBarGroupEventHandler(uC_NavMenu1_ActiveGroupChanged);
            MenuNavBar menuBar = null;
            string wFileName;
            if (isNew)
            {
                menuBar = new MenuNavBar();
                wFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_New(menuBar.GetXml(),
                     Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter, true);
            }
            else
            {
                wFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open(Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter);
            }

            if (string.IsNullOrEmpty(wFileName))
                return;
            try
            {
                FileInfo f = new FileInfo(wFileName);
                if (_MenuFileList.Any<MenuFile>(p => p.Name.CompareTo(f.Name) == 0))
                {
                    base.MessageViewer.Show("Este menu ya esta cargado");
                    return;
                }
                _SelectedMenuFile = new MenuFile(f);
                _SelectedMenuFile.MenuBar = menuBar;
                _MenuFileList.Add(_SelectedMenuFile);

               
                ClearControlEditor();
                LoadFromFile();
                lblSelectedFileName.Text = _SelectedMenuFile.FullName;
                lstFiles.SelectedItem = _SelectedMenuFile;
            }
            catch
            {
                _MenuFileList.Remove(_SelectedMenuFile);

                base.MessageViewer.Show("El archivo seleccionado no es compatible o tiene un formato incorecto");
            }

            uC_NavMenu1.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(uC_NavMenu1_ActiveGroupChanged);
        }

        /// <summary>
        /// Carga en el archivo seleccionado "_SelectedMenuFile" el objeto MenuBar desde el xml del archivo
        /// </summary>
        void LoadFromFile()
        {
            _SelectedMenuFile.MenuBar = MenuNavBar.GetFromXml<MenuNavBar>(FileFunctions.OpenTextFile(_SelectedMenuFile.FullName));
            uC_NavMenu1.IsOnDesignMode = true;
            uC_NavMenu1.Load(_SelectedMenuFile.MenuBar);

        }

        void Load_UC_NavMenu()
        {
            if (_SelectedMenuFile.MenuBar != null)
            {
                uC_NavMenu1.ActiveGroupChanged -= new DevExpress.XtraNavBar.NavBarGroupEventHandler(uC_NavMenu1_ActiveGroupChanged);
                uC_NavMenu1.Load(_SelectedMenuFile.MenuBar);
                groupBox1.Enabled = true;
                uC_NavMenu1.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(uC_NavMenu1_ActiveGroupChanged);
            }
        }

        /// <summary>
        /// Detecta los archivos que ya no existen
        /// </summary>
        void RefreshMenuFileListFromFiles()
        {
            foreach (MenuFile f in _MenuFileList)
            {
                if (System.IO.File.Exists(f.FullName))
                    try
                    {
                        f.MenuBar = MenuNavBar.GetFromXml<MenuNavBar>(FileFunctions.OpenTextFile(f.FullName));
                    }
                    catch
                    {
                        f.FileExist = false;
                    }
                else
                {
                    f.MenuBar.Clear();
                    f.FileExist = false;
                }
            }
          
        }
       
        void SaveToFile(MenuFile pMenuFile)
        {
            Fwk.UI.Controls.Menu.Helper.SaveMenuToFile(pMenuFile.MenuBar, pMenuFile.FullName);
            pMenuFile.Saved = true;
        }
        #endregion


        void uC_NavMenu1_MenuButtonClick(object sender, ButtonClickArgs<Fwk.UI.Controls.Menu.ButtonBase> e)
        {
            _CurrentButtonBase = e.ButtonClicked;
            textBox1.Text = _CurrentButtonBase.Guid.ToString();
            LoadControl<UC_ButtonBaseEditor>(_CurrentButtonBase, ActionTypes.Edit,uC_NavMenu1.ActiveGroup.Tag);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (uC_NavMenu1.ActiveGroup == null) return;
            //Tomar el grupo activo
            BarGroup barToMove = (BarGroup)uC_NavMenu1.ActiveGroup.Tag;

            if (barToMove.Index == 0) return;
            BarGroup barUp = uC_NavMenu1.MenuBar.GetBy_Index(barToMove.Index - 1);
            barToMove.Index = barToMove.Index -1;

            barUp.Index = barUp.Index + 1;
            ClearControlEditor();
            ReordenarMenu();

        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (uC_NavMenu1.ActiveGroup == null) return;
            //Tomar el grupo activo
            BarGroup barToMove = (BarGroup)uC_NavMenu1.ActiveGroup.Tag;
            //Si es sobre si mismo retornar
            if (barToMove.Index == uC_NavMenu1.MenuBar.Count - 1) return;

            //Tomo el grupo que esta arriba para bajarlo
            BarGroup barDown = uC_NavMenu1.MenuBar.GetBy_Index(barToMove.Index + 1);
            barToMove.Index = barToMove.Index + 1;

            barDown.Index = barDown.Index - 1;
            ClearControlEditor();
            ReordenarMenu();
        }

        void ReordenarMenu()
        { 
            IEnumerable <BarGroup> sortedList= from b in uC_NavMenu1.MenuBar orderby (b.Index) select b ;
            MenuNavBar sortedMenuNavBar = new MenuNavBar();
            sortedMenuNavBar.AddRange(sortedList);
            _SelectedMenuFile.MenuBar = null;
            _SelectedMenuFile.MenuBar = sortedMenuNavBar;
            Load_UC_NavMenu();
        }

        private void uC_NavMenu1_MenuButtonClick(object sender)
        {

        }

        private void navBarGroup1_ItemChanged(object sender, EventArgs e)
        {

        }
        
       

       

      



    }
}
