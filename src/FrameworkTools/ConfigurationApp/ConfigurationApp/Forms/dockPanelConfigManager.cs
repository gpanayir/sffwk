using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ConfigurationApp.Common;
using ConfigurationApp.IsolatedStorage;

namespace ConfigurationApp.Forms
{
    public partial class dockPanelConfigManager :  Fwk.Controls.Win32.DockContent
    {
        private event DoActionEventHandler _DoActionEvent;

        private void OnDoActionEvent(Object sender)
        {
            if (_DoActionEvent != null)
                _DoActionEvent(sender);
        }

        public event DoActionEventHandler DoActionEvent
        {
            add
            {
                _DoActionEvent = (DoActionEventHandler)Delegate.Combine(_DoActionEvent, value);

            }
            remove
            {
                _DoActionEvent = (DoActionEventHandler)Delegate.Remove(_DoActionEvent, value);
            }
        }

        #region Private members
        private CnfgManagerSelectedNodeType _CnfgManagerSelectedNodeType = CnfgManagerSelectedNodeType.Root;
        private Storage _Storage = null;

    
        private PropertyGrid _PropertyGrid = null;
        public String _FileName = String.Empty;
        public String _GroupName = String.Empty;
        public String _KeyName = String.Empty;

        public PropertyGrid Property
        {
            get { return _PropertyGrid; }
            set { _PropertyGrid = value; }

        }
        public TreeNode SelectedNode
        {
            get { return treeView1.SelectedNode; }
        }
        internal Storage Storage
        {
            set { _Storage = value; }
        }
        #endregion

        public dockPanelConfigManager()
        {
            InitializeComponent();
        }

        #region Events --> mnCnfgManFile 

        /// <summary>
        /// Guarda un archivo en disco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemSaveFile_Click(object sender, EventArgs e)
        {
            ConfigManagerControl.SaveFile(treeView1.SelectedNode);
        }

        /// <summary>
        /// Quita un archivo del tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemQuitFile_Click(object sender, EventArgs e)
        {
            ConfigManagerControl.QuitFile(treeView1.SelectedNode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemRefreshFile_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Inserta un nuevo grupo en el archivo y el xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemNewGroup_Click(object sender, EventArgs e)
        {
            if (_CnfgManagerSelectedNodeType == CnfgManagerSelectedNodeType.File)
            {
                frmNewGroup f = new frmNewGroup();
                f.ShowDialog();

                if (f.GroupName.Length != 0)
                {
                    ConfigManagerControl.AddGroup(treeView1.SelectedNode, f.GroupName, mnGroupAndKey);
                }
            }

        }
        #endregion

      
        #region Events --> mnGroupAndKey

        /// <summary>
        /// Inserta una nueva clave de configuracion a algun grupo/archivo determinado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemNewKey_Click(object sender, EventArgs e)
        {
            if (_CnfgManagerSelectedNodeType == CnfgManagerSelectedNodeType.Group)
            {

                frmNewKey f = new frmNewKey();
                f.GroupName = treeView1.SelectedNode.Text;
                f.FileName = treeView1.SelectedNode.Parent.Text;
                f.ShowDialog();

                if (f.KeyName.Length != 0)
                {
                    ConfigManagerControl.AddKey(treeView1.SelectedNode.Parent, f.GroupName, f.KeyName, f.KeyValue, mnGroupAndKey);
                }
            }
        }

        /// <summary>
        /// Elimina una clave o grupo de configuracion dependiendo del nodo seleccionado
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemRemoveGrOrKey_Click(object sender, EventArgs e)
        {
            TreeNode wSel = treeView1.SelectedNode;
            switch (_CnfgManagerSelectedNodeType)
            {
                case CnfgManagerSelectedNodeType.Key:
                    {
                        ConfigManagerControl.RemoveKey(wSel.Parent.Parent, wSel.Parent.Text, wSel.Text);

                        break;
                    }
                case CnfgManagerSelectedNodeType.Group:
                    {
                        ConfigManagerControl.RemoveGroup(wSel.Parent, wSel.Text);
                        break;
                    }

            }
            wSel.Remove();
            treeView1.Refresh();
        }

        #endregion

        #region File Methods

        
        
        /// <summary>
        /// Guarda el archivo
        /// </summary>
        public void SaveFile()
        {
            if (_CnfgManagerSelectedNodeType == CnfgManagerSelectedNodeType.Root)
            {
                MessageBox.Show("Please.. select a file node.","Config manager",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            TreeNode wFileTreeNode = GetTreeNodeFile();
            ConfigManagerControl.SaveFile(wFileTreeNode);
        }
        /// <summary>
        /// Quita o remueve el archivo
        /// </summary>
        public void QuitFile()
        {
            if (_CnfgManagerSelectedNodeType == CnfgManagerSelectedNodeType.Root)
            {
                MessageBox.Show("Please.. select a file node.", "Config manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TreeNode wFileTreeNode = GetTreeNodeFile();
            ConfigManagerControl.QuitFile(wFileTreeNode);
        }
        /// <summary>
        /// Carga un archivo Config Mannager en el tree view
        /// </summary>
        public void LoadFile()
        {
            ConfigManagerControl.LoadFile(treeView1.Nodes[0], mnCnfgManFile, mnGroupAndKey);
        }
        /// <summary>
        /// Crea un nuevo archivo
        /// </summary>
        public void NewFile()
        {
            ConfigManagerControl.NewFile(treeView1.Nodes[0], mnCnfgManFile, mnGroupAndKey);
        }

        /// <summary>
        /// Guarda todos los archivos que estan actualmente en el Tree View
        /// </summary>
        public void SaveAllFiles()
        {
            foreach (TreeNode wFileTreeNode in treeView1.Nodes[0].Nodes)
            {
                ConfigManagerControl.SaveFile(wFileTreeNode);
            }
        }

        /// <summary>
        /// Quita todos los archivos que estan actualmente en el Tree View
        /// </summary>
        public void QuitAllFiles()
        {
            foreach (TreeNode wFileTreeNode in treeView1.Nodes[0].Nodes)
            {
                ConfigManagerControl.QuitFile(wFileTreeNode);
            }
        }
        public void RefreshAllFiles(Boolean pClear)
        {
            if (pClear)
            {
                treeView1.Nodes[0].Nodes.Clear();
            }
            ConfigManagerControl.LoadFilesFromIsolatedStorage(treeView1.Nodes[0], mnCnfgManFile, mnGroupAndKey, _Storage);

            treeView1.Nodes[0].Expand();

        }
        #endregion

        #region [Keys & Settings]
        private void CnfgManagerApplyChanges()
        {
            TreeNode wSel = treeView1.SelectedNode;
            switch (_CnfgManagerSelectedNodeType)
            {
                case CnfgManagerSelectedNodeType.Key:
                    {
                        ChangeKey(wSel);
                        break;
                    }
                case CnfgManagerSelectedNodeType.Group:
                    {
                        ConfigManagerControl.ChangeGroupName(wSel);
                        break;
                    }
            }
        }
        /// <summary>
        /// Realiza un cambio en una clave de configuracion
        /// </summary>
        /// <param name="wTreeNodeKey">Nodo clave (key) del tree view</param>
        /// <returns></returns>
        private XmlNode ChangeKey(TreeNode wTreeNodeKey)
        {

            Key wKey = (Key)wTreeNodeKey.Tag;

            //Cambio el valor 
            XmlNode node = ConfigManagerControl.ChangeKeyValue(wTreeNodeKey);

            //Cambio nombre de key 
            if (wTreeNodeKey.Text.CompareTo(wKey.Name) != 0)
            {
                wTreeNodeKey.Text = wKey.Name;
                ConfigManagerControl.ChangeKeyName(node, wKey.Name);
            }
            return node;
        }


        #endregion

        #region Events --> PropertyGrid 
        /// <summary>
        /// Se ejecuta cuando cambia algun valor de un objeto Group asociado a un Group Key del tree view
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
           string newValue = e.ChangedItem.Value.ToString();
           string oldValue = e.OldValue.ToString();

            CnfgManagerApplyChanges();
            //_PropertyGrid.PropertyValueChanged -=
            //    new PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChanged);
        }

        #endregion

        private void DoConfigManager(TreeViewEventArgs pTreeNodeSelected)
        {
            ///Eklimino cualquir manejador que este abierto 
            _PropertyGrid.PropertyValueChanged -= new PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChanged);
            switch (_CnfgManagerSelectedNodeType)
            {
                case CnfgManagerSelectedNodeType.Key:
                    {
                        Key wKey = (Key)pTreeNodeSelected.Node.Tag;
                        _PropertyGrid.SelectedObject = wKey;
                        _FileName = wKey.FileName;
                        _GroupName = wKey.GroupName;
                        _KeyName = wKey.Name;
                        _PropertyGrid.Show();
                        _PropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChanged);
                        
                        break;
                    }
                case CnfgManagerSelectedNodeType.Group:
                    {
                        Group wGroup = (Group)pTreeNodeSelected.Node.Tag;
                        _PropertyGrid.SelectedObject = wGroup;

                        _FileName = wGroup.FileName;
                        _GroupName = wGroup.Name;
                        _KeyName = String.Empty;
                        _PropertyGrid.Show();
                        _PropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChanged);
                        break;
                    }
                case CnfgManagerSelectedNodeType.File:
                    {
                        if (pTreeNodeSelected.Node.Parent.Index == 1)
                        {
                            _FileName = pTreeNodeSelected.Node.Text;
                            _GroupName = String.Empty;
                            _KeyName = String.Empty;
                        }
                        _PropertyGrid.Hide();
                        break;
                    }
                case CnfgManagerSelectedNodeType.Root:
                    {
                        if (pTreeNodeSelected.Node.Index == 1)
                        {
                            _FileName = String.Empty; ;
                            _GroupName = String.Empty;
                            _KeyName = String.Empty;
                        }
                        _PropertyGrid.Hide();
                        break;
                    }
            }
            OnDoActionEvent(this);
        }

        private TreeNode GetTreeNodeFile()
        {
            TreeNode wTreeNodeFile = null;

            switch (_CnfgManagerSelectedNodeType)
            {
                case CnfgManagerSelectedNodeType.File:
                    {
                        wTreeNodeFile = treeView1.SelectedNode;
                        break;
                    }
                case CnfgManagerSelectedNodeType.Group:
                    {
                        wTreeNodeFile = treeView1.SelectedNode.Parent;
                        break;
                    }
                case CnfgManagerSelectedNodeType.Key:
                    {
                        wTreeNodeFile = treeView1.SelectedNode.Parent.Parent;
                        break;
                    }
            }


            return wTreeNodeFile;
        }


        #region Envents --> treeView
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            //DetermineLabels();

            // Determino que es lo que esta seleccionado 
            _CnfgManagerSelectedNodeType = (CnfgManagerSelectedNodeType) Enum.Parse(typeof (CnfgManagerSelectedNodeType), e.Node.Level.ToString());

            DoConfigManager(e);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;

            if (_CnfgManagerSelectedNodeType == CnfgManagerSelectedNodeType.Key)
            {

                tsMenuItemNewKey.Visible = false;
            }
            else
            {
                tsMenuItemNewKey.Visible = true;
            }
        }
        #endregion

        #region Events --> mnConfigManagerRoot


        private void tsMenuItemSaveAllFiles_Click(object sender, EventArgs e)
        {
            SaveAllFiles();
        }

        private void tsMenuItemNewFile_Click(object sender, EventArgs e)
        {
            NewFile();
        }
        private void tsMenuItemQuitAllFiles_Click(object sender, EventArgs e)
        {
            QuitAllFiles();
        }

        private void tsMenuItemRefreshAllFiles_Click(object sender, EventArgs e)
        {
            RefreshAllFiles(true);
        }
        #endregion


        /// <summary>
        /// Cuando el formulario se sierra se guardan los archivos abiertos por el usuario en el Isolated Storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockPanelConfigManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveIsolatedStorage();
            ConfigManagerControl.Dispose();
        }


        /// <summary>
        /// Almaceno la informacion de las rutas a los archivos cargados en el tree view en un 
        /// isolated storage
        /// </summary>
        internal void SaveIsolatedStorage()
        {
            ConfigManagerControl.SaveIsolatedStorage(treeView1.Nodes[0], _Storage);
        }

        private void dockPanelConfigManager_Load(object sender, EventArgs e)
        {
            RefreshAllFiles(false);
        }

        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode wTreeNodeFile = GetTreeNodeFile();

            System.Diagnostics.Process.Start("explorer.exe", wTreeNodeFile.ToolTipText);
        }
    }
}