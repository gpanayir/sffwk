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
using System.IO;
using Fwk.Caching;
using Fwk.HelperFunctions;
using Fwk.UI.Forms;
using Fwk.UI.Controls;
using Fwk.UI.Controls.Menu;

namespace Fwk.Tools.Menu
{
    public partial class FRM_ToolBarDesigner : FormBase
    {

        #region [Private Vars]
        MenuFile _SelectedMenuFile;
        FwkCache _FwkCache = null;
        private MenuFileList _MenuFileList = new MenuFileList();
     
        #endregion

        #region [Private Methods]

        /// <summary>
        /// Llena el treeView con el menu.
        /// </summary>
        private void FillTreeView()
        {
            ctlTreeViewMenuBar.ClearNodes();

            if (_SelectedMenuFile == null) return;

            if (!_SelectedMenuFile.FileExist)
            {
                lblFileRemoved.Visible = true;

                return;
            }
            else
            {
                lblFileRemoved.Visible = false;

            }


            foreach (Fwk.UI.Controls.Menu.ButtonBase button in _SelectedMenuFile.Toolbar)
            {
                TreeListNode buttonNode = ctlTreeViewMenuBar.AppendNode(null, -1);
                buttonNode.SetValue("colCaption", button.Caption);
                buttonNode.SetValue("colObjeto", button);

                switch (button.GetType().Name)
                {
                    case "PopupButton":

                        foreach (Fwk.UI.Controls.Menu.ButtonBase ButtonBase in ((PopupButton)button).Buttons)
                        {
                            TreeListNode ButtonBaseNode = ctlTreeViewMenuBar.AppendNode(null, buttonNode);
                            ButtonBaseNode.SetValue("colCaption", ButtonBase.Caption);
                            ButtonBaseNode.SetValue("colObjeto", ButtonBase);
                        }
                        break;
                }
            }


            if (_SelectedMenuFile.Toolbar.Count > 0)
            {
                if (_SelectedMenuFile.Toolbar[0].GetType() == typeof(Fwk.UI.Controls.Menu.ButtonBase))
                {
                    LoadButtonBaseObject((Fwk.UI.Controls.Menu.ButtonBase)_SelectedMenuFile.Toolbar[0]);
                }
                if (_SelectedMenuFile.Toolbar[0].GetType() == typeof(PopupButton))
                {
                    LoadPopupButtonObject((PopupButton)_SelectedMenuFile.Toolbar[0]);
                }
            }
        }

        /// <summary>
        /// Limpia el control grpPanel.
        /// </summary>
        private void ClearControlEditor()
        {
            grpEditionContainer.Controls.Clear();
        }

        /// <summary>
        /// Carga el objeto Menu pasado
        /// en un control MenuEditor y lo muestra
        /// en el grpPanel de edición.
        /// </summary>
        /// <param name="menuObjectToLoad">Objeto Menu a cargar.</param>
        private void LoadPopupButtonObject(Fwk.UI.Controls.Menu.PopupButton popupButtonObjectToLoad)
        {
            UC_PopupButtonEditor popupButtonEditor = null;
            IEnumerable<UC_PopupButtonEditor> editor = grpEditionContainer.Controls.OfType<UC_PopupButtonEditor>();
            
            if (editor.Count() > 0)
            {
                 popupButtonEditor = editor.First();
                popupButtonEditor.OnInit=true;
             
                popupButtonEditor.BringToFront();
                popupButtonEditor.LoadControl(popupButtonObjectToLoad);
                popupButtonEditor.MenuItemSaved += new MenuItemSavedHandler(menuEditor_MenuItemSaved);
                //popupButtonEditor.EditorValueChanges += new EventHandler(editorTemp_EditorValueChanges);
                popupButtonEditor.OnInit = false;
                return;
            }

            popupButtonEditor = new UC_PopupButtonEditor();
            popupButtonEditor.OnInit = true;
            grpEditionContainer.Controls.Add(popupButtonEditor);
            popupButtonEditor.Dock = DockStyle.Fill;
            popupButtonEditor.BringToFront();
            popupButtonEditor.LoadControl(popupButtonObjectToLoad);
            popupButtonEditor.MenuItemSaved += new MenuItemSavedHandler(menuEditor_MenuItemSaved);
            //popupButtonEditor.EditorValueChanges += new EventHandler(editorTemp_EditorValueChanges);
            popupButtonEditor.OnInit = false;
        }
       
        /// <summary>
        /// Carga el objeto ButtonBase pasado
        /// en un control ButtonBaseEditor y lo muestra
        /// en el grpPanel de edición.
        /// </summary>
        /// <param name="ButtonBaseObjectToLoad">Objeto ButtonBase a cargar.</param>
        private void LoadButtonBaseObject(Fwk.UI.Controls.Menu.ButtonBase ButtonBaseObjectToLoad)
        {
            UC_ButtonBaseEditor ButtonBaseEditor = null;
            IEnumerable<UC_ButtonBaseEditor> editor = grpEditionContainer.Controls.OfType<UC_ButtonBaseEditor>();
            if (editor.Count() > 0)
            {
                ButtonBaseEditor = editor.First();
                ButtonBaseEditor.OnInit = true;
                ButtonBaseEditor.BringToFront();
                ButtonBaseEditor.LoadControl(ButtonBaseObjectToLoad, null);
                ButtonBaseEditor.MenuItemSaved += new MenuItemSavedHandler(menuEditor_MenuItemSaved);
                //ButtonBaseEditor.EditorValueChanges += new EventHandler(editorTemp_EditorValueChanges);
                ButtonBaseEditor.OnInit = false;
                return;
            }

            ButtonBaseEditor = new UC_ButtonBaseEditor();
            ButtonBaseEditor.OnInit = true;
            grpEditionContainer.Controls.Add(ButtonBaseEditor);
            ButtonBaseEditor.Dock = DockStyle.Fill;
            ButtonBaseEditor.BringToFront();
            ButtonBaseEditor.LoadControl(ButtonBaseObjectToLoad, null);
            ButtonBaseEditor.MenuItemSaved += new MenuItemSavedHandler(menuEditor_MenuItemSaved);
            //ButtonBaseEditor.EditorValueChanges += new EventHandler(editorTemp_EditorValueChanges);
            ButtonBaseEditor.OnInit = false;
        }

        void editorTemp_EditorValueChanges(object sender, EventArgs e)
        {
            if (_SelectedMenuFile != null)
            {
                _SelectedMenuFile.Saved = false;
                Refresh();
            }
        }
            
        /// <summary>
        /// Agrega un nuevo PopupButton evaluando la posición en la cual
        /// se encuentra el cursor en el tree, lo normal es que desplase el botón
        /// existente hacia abajo.
        /// </summary>
        private void AddNewPopupButton()
        {
            TreeListNode selectedNode;
            int index = -1;

            if (ctlTreeViewMenuBar.FocusedNode == null)
            {
                selectedNode = null;
            }
            else
            {
                selectedNode = ctlTreeViewMenuBar.FocusedNode;

                switch (selectedNode.Level)
                {
                    case 0:
                        selectedNode = ctlTreeViewMenuBar.FocusedNode;
                        break;
                    case 1:
                        selectedNode = ctlTreeViewMenuBar.FocusedNode.ParentNode;
                        break;
                    default:
                        return;
                }

                index = ctlTreeViewMenuBar.GetNodeIndex(selectedNode);
            }

            TreeListNode newNode = AddNewElementToTree<PopupButton>(-1, index);
            ctlTreeViewMenuBar.SetFocusedNode(newNode);

            //Agrego un botón por defecto al popupButton.
            AddNewElementToTree<Fwk.UI.Controls.Menu.ButtonBase>(newNode.Id, -1);

        }

        /// <summary>
        /// Agrega un nuevo ButtonBase evaluando la posición en la cual
        /// se encuentra el cursor en el tree, lo normal es que desplase el botón
        /// existente hacia abajo.
        /// </summary>
        private void AddNewButtonBase()
        {

            TreeListNode selectedNode;
            int index;
            int parentId;


            if (ctlTreeViewMenuBar.FocusedNode == null)
            {
                selectedNode = null;
                index = -1;
                parentId = -1;
            }
            else
            {
                selectedNode = ctlTreeViewMenuBar.FocusedNode;

                switch (selectedNode.Level)
                {
                    case 0:
                        index = ctlTreeViewMenuBar.GetNodeIndex(selectedNode);
                        parentId = -1;
                        break;
                    case 1:
                        index = ctlTreeViewMenuBar.GetNodeIndex(selectedNode);
                        parentId = selectedNode.ParentNode.Id;
                        break;
                    default:
                        return;
                }
            }

            TreeListNode newNode = AddNewElementToTree<Fwk.UI.Controls.Menu.ButtonBase>(parentId, index);
//            ctlTreeViewMenuBar.Nodes.Add(newNode);
            ctlTreeViewMenuBar.SetFocusedNode(newNode);

        }

        /// <summary>
        /// Agrega un nuevo elemento del tipo T al treeView
        /// </summary>
        /// <typeparam name="T">Tipo del elemento a agregar.</typeparam>
        /// <param name="parentId">Identificador del nodo padre para el nuevo nodo, -1 sino tiene padre.</param>
        /// <param name="newNodeIndex">Indice (Posición) del nuevo nodo, -1 al final.</param>
        /// <returns>El TreeListNode creado.</returns>
        private TreeListNode AddNewElementToTree<T>(int parentId, int newNodeIndex) where T : MenuItemBase, new()
        {
            T newElement = new T();
     
            newElement.Caption = "NewElement" + (_SelectedMenuFile.Toolbar.Count + 1);
            newElement.Id = "ELM" + (_SelectedMenuFile.Toolbar.Count + 1); 
            TreeListNode newNode = ctlTreeViewMenuBar.AppendNode(new object[] { newElement.Caption, newElement }, parentId);

            if (newNodeIndex > 0)
            {

                ctlTreeViewMenuBar.SetNodeIndex(newNode, newNodeIndex);

            }

            return newNode;

        }


        /// <summary>
        /// Obtiene el objeto ToolBar creado
        /// desde los nodos del Tree,
        /// esto se realiza para poder mantener
        /// el orden con el cual se han ido acomodando
        /// los nodos del tree.
        /// </summary>
        /// <returns>ToolBar obtenido</returns>
        private Fwk.UI.Controls.Menu.ToolBar GenerateToolBarFromTree()
        {
            Fwk.UI.Controls.Menu.ToolBar newToolBar = new Fwk.UI.Controls.Menu.ToolBar();

            foreach (TreeListNode node in ctlTreeViewMenuBar.Nodes)
            {
                Fwk.UI.Controls.Menu.ButtonBase newButton = (Fwk.UI.Controls.Menu.ButtonBase)node.GetValue("colObjeto");

                if (newButton.GetType() == typeof(PopupButton))
                {
                    PopupButton popupButton = (PopupButton)newButton;
                    popupButton.Buttons.Clear();

                    foreach (TreeListNode buttonNode in node.Nodes)
                    {
                        Fwk.UI.Controls.Menu.ButtonBase ButtonBase = (Fwk.UI.Controls.Menu.ButtonBase)buttonNode.GetValue("colObjeto");
                        popupButton.Buttons.Add(ButtonBase);
                    }

                    newToolBar.Add(popupButton);
                }

                // Para boton común
                if (newButton.GetType() == typeof(Fwk.UI.Controls.Menu.ButtonBase))
                {
                    newToolBar.Add(newButton);                   
                }
                
                
            }

            return newToolBar;
        }

        #endregion

        #region [Form Event Handling]
        
        public FRM_ToolBarDesigner(MenuFileList pFilesDict, FwkCache cache)
        {
            InitializeComponent();
            _MenuFileList = pFilesDict;
            _FwkCache = cache;
            RefreshMenuFileListFromFiles();
            menuFileBindingSource.DataSource = _MenuFileList;
            lstFiles.Refresh();
           
        }
        
        private void MenuDesigner_Load(object sender, EventArgs e)
        {
            lstFiles.SelectedIndex = 0;
            _SelectedMenuFile = (MenuFile)lstFiles.SelectedItem;
            //this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
           
            FillTreeView();
            RefreshView();
            
        }
        
        private void ToolBarDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.MessageViewer.MessageBoxButtons = MessageBoxButtons.YesNo;
            foreach (MenuFile f in _MenuFileList)
            {
                if (f.Saved == false)
                {

                    if (base.MessageViewer.Show("Desea gurdar el archivo" + _SelectedMenuFile.Name) == DialogResult.Yes)
                    {
                        SaveToFile(f);
                    }


                }
                f.Saved = true;
                f.Toolbar = null;
            }
            base.SetMessageViewInfoDefault();
            if (_FwkCache != null)
            {
                _FwkCache.RemoveItem("MenuFileList_ToolBar");
                _FwkCache.SaveItemInCache("MenuFileList_ToolBar", _MenuFileList);

               
            }
        }

        #region Diseño de tool bar

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Caption)
            {
                case "Popup Button":
                    AddNewPopupButton();
                    break;
                case "Simple Button":
                    AddNewButtonBase();
                    break;
                default:
                    break;
            }
            if (_SelectedMenuFile != null)
            {
                _SelectedMenuFile.Saved = false;
                _SelectedMenuFile.Toolbar = GenerateToolBarFromTree();
                RefreshView();
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {

            if (ctlTreeViewMenuBar.FocusedNode == null)
            {
                return;
            }

            if (ctlTreeViewMenuBar.FocusedNode.PrevNode != null)
            {
                int index = ctlTreeViewMenuBar.GetNodeIndex(ctlTreeViewMenuBar.FocusedNode.PrevNode);

                ctlTreeViewMenuBar.SetNodeIndex(ctlTreeViewMenuBar.FocusedNode, index);
            }
            RefreshView();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {

            if (ctlTreeViewMenuBar.FocusedNode == null)
            {
                return;
            }

            if (ctlTreeViewMenuBar.FocusedNode.NextNode != null)
            {
                int index = ctlTreeViewMenuBar.GetNodeIndex(ctlTreeViewMenuBar.FocusedNode.NextNode);

                ctlTreeViewMenuBar.SetNodeIndex(ctlTreeViewMenuBar.FocusedNode, index);
            }
            RefreshView();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ctlTreeViewMenuBar.FocusedNode != null)
            {
                ctlTreeViewMenuBar.DeleteNode(ctlTreeViewMenuBar.FocusedNode);
                RefreshView();
            }

        }

        private void menuEditor_MenuItemSaved(object sender, MenuItemSavedEventArgs e)
        {
            if (ctlTreeViewMenuBar.FocusedNode != null)
            {
                ctlTreeViewMenuBar.FocusedNode.SetValue("colCaption", e.MenuItem.Caption);
                ctlTreeViewMenuBar.FocusedNode.SetValue("colObjeto", e.MenuItem);
            }
        }
              
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        void RefreshView()
        {
            Fwk.UI.Controls.Menu.ToolBar toolBar = GenerateToolBarFromTree();

            toolBarControl1.LoadToolBarFromXml(toolBar.GetXml());
        }

        #endregion

        private void ctlTreeViewMenuBar_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

            if (e.Node == null)
            {
                return;
            }

            object item = e.Node.GetValue("colObjeto");

            if (item == null)
            {
                return;
            }

            switch (item.GetType().Name)
            {
                case "PopupButton":
                    LoadPopupButtonObject((PopupButton)item);
                    break;
                case "ButtonBase":
                    LoadButtonBaseObject((Fwk.UI.Controls.Menu.ButtonBase)item);
                    break;
                default:
                    ClearControlEditor();
                    break;
            }

        }
     
        #endregion

        #region [Menu de archivos]
        
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
            }
            if (lstFiles.Items.Count > 0) lstFiles.SelectedIndex = 0;
        }
        
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            _SelectedMenuFile.Toolbar = GenerateToolBarFromTree();
            SaveToFile(_SelectedMenuFile);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {

            Add_MenuFile(true);
        

           
        }
        
        private void saveAllToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (MenuFile f in _MenuFileList)
            {
                if (f.Saved == false)
                    SaveToFile(f);
            }

        }
        
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Add_MenuFile(false);

        }

        #endregion


        /// <summary>
        /// Agrega un nuevo menu file a la lista de archivos 
        /// </summary>
        /// <param name="isNew"></param>
        void Add_MenuFile(bool isNew)
        {
            Fwk.UI.Controls.Menu.ToolBar toolBar=null;
            string wFileName;
            if (isNew)
            {
                toolBar = new Fwk.UI.Controls.Menu.ToolBar();
                wFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_New(toolBar.GetXml(),
                     Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter, true);
            }
            else
            {
                wFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open(Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter);
            }

            if (string.IsNullOrEmpty(wFileName))
                return;

            FileInfo f = new FileInfo(wFileName);
            if (_MenuFileList.Any<MenuFile>(p => p.Name.CompareTo(f.Name) == 0))
            {
                base.MessageViewer.Show("Este menu ya esta cargado");
                return;
            }
            _SelectedMenuFile = new MenuFile(f);
            _SelectedMenuFile.Toolbar = toolBar;
            _MenuFileList.Add(_SelectedMenuFile);

            lblSelectedFileName.Text = _SelectedMenuFile.FullName;
            ClearControlEditor();
            this.LoadFromFile();
            lstFiles.SelectedItem = _SelectedMenuFile;
        }

        /// <summary>
        /// Carga _SelectedMenuFile.ToolBar de un archivo [_SelectedMenuFile.FullName]
        /// Carga el control visual [toolBarControl1] con el xml de la Toolbar
        /// </summary>
        void LoadFromFile()
        {
            try
            {
                _SelectedMenuFile.Toolbar = Fwk.UI.Controls.Menu.ToolBar.GetFromXml<Fwk.UI.Controls.Menu.ToolBar>(FileFunctions.OpenTextFile(_SelectedMenuFile.FullName));
                FillTreeView();
                toolBarControl1.LoadToolBarFromXml(_SelectedMenuFile.Toolbar.GetXml());
            }
            catch
            {
                base.MessageViewer.Show("El archivo no tiene el formato correcto");
            }
        
        }

        void RefreshMenuFileListFromFiles()
        {
            foreach (MenuFile f in _MenuFileList)
            {
                if (System.IO.File.Exists(f.FullName))
                    f.Toolbar = Fwk.UI.Controls.Menu.ToolBar.GetFromXml<Fwk.UI.Controls.Menu.ToolBar>(FileFunctions.OpenTextFile(f.FullName));
                else
                    f.FileExist = false;
            }
            ///TODO: eliminar  f.FileExist
        }

        /// <summary>
        /// Carga el tree view para 
        /// Carga el item seleccionado al la toolbar
        /// </summary>
        void LoadFromMenufile()
        {

            FillTreeView();
            if (_SelectedMenuFile.Toolbar != null)
                toolBarControl1.LoadToolBarFromXml(_SelectedMenuFile.Toolbar.GetXml());

        }

        void SaveToFile(MenuFile pMenuFile)
        {

            Fwk.UI.Controls.Menu.Helper.SaveToolBarToFile(pMenuFile.Toolbar, pMenuFile.FullName);

            pMenuFile.Saved = true;
        }

     

        /// <summary>
        /// Click en la lista de archivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFiles_Click(object sender, EventArgs e)
        {
            if(_SelectedMenuFile!=null)
                if (_SelectedMenuFile.FullName.Equals(((MenuFile)lstFiles.SelectedItem).FullName))
                {
                    return;
                }
            try
            {
                //if (_SelectedMenuFile != null && _SelectedMenuFile.Saved == false)
                //    _SelectedMenuFile.Toolbar = GenerateToolBarFromTree();
                /// Establezco el actual menu file .-
                _SelectedMenuFile = (MenuFile)lstFiles.SelectedItem;

                lblSelectedFileName.Text = _SelectedMenuFile.FullName;
                ClearControlEditor();
                this.LoadFromMenufile();
            }
            catch (System.IndexOutOfRangeException)
            { }
        }

       
    }
}
