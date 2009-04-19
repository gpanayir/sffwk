using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConfigurationApp.Common;


namespace ConfigurationApp.Forms
{
    public partial class dockPanelAppConfigClient : Fwk.Controls.Win32.DockContent
    {

        public dockPanelAppConfigClient()
        {
            InitializeComponent();
            
        }
    
        

        #region Wrapper configuration

        private void tsMenuItemWrapperWebService_Click(object sender, EventArgs e)
        {
            AddWebServiceWrapperSeccion();
        }

        private void tsMenuItemWrapperRemoting_Click(object sender, EventArgs e)
        {
            AddRemotingWrapperSeccion();
        }

        private void tsMenuItemWrapperLocal_Click(object sender, EventArgs e)
        {
            AddLocalWrapperSection();
        }

        private void tsMenuItemWrappeRemove_Click(object sender, EventArgs e)
        {
            RemoveWrapperSection();
        }

        #endregion

        #region Data Access

 
        /// <summary>
        /// Se produce cuando cambia un property relacionado a una cnn string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        void PropertyGrid_PropertyValueChangedDataBase(object s, PropertyValueChangedEventArgs e)
        {

            if (e.ChangedItem.Label == "Name")
            {
                
                treeView1.SelectedNode.Text = e.ChangedItem.Value.ToString();
                CnnStringChange(e.OldValue.ToString());
            }
            else
            {
                CnnStringChange(treeView1.SelectedNode.Text);
            }
            
        }

        /// <summary>
        /// Se produce cuando cambia un property relacionado a un Setting
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        void PropertyGrid_PropertyValueChangedSetting(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "Value")
            {
                AppConfigSettingsChange();

            }

        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemAddDataConnection_Click(object sender, EventArgs e)
        {
            AddDataConnection();
        }

        /// <summary>
        /// Elimina una cadena de coneccion determinada del tree view y del xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuQuitCnnString_Click_1(object sender, EventArgs e)
        {
            DataConfigControl.RemoveCnnString(treeView1.SelectedNode);
        }

        /// <summary>
        /// Renombrado de una cnn string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuRenameCnnString_Click(object sender, EventArgs e)
        {
            treeView1.LabelEdit = true;

            treeView1.AfterLabelEdit += new NodeLabelEditEventHandler(treeView1_AfterLabelEdit);

            treeView1.SelectedNode.BeginEdit();
        }

        /// <summary>
        /// Renombrado de una cnn string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            treeView1.LabelEdit = false;

            treeView1.AfterLabelEdit -= new NodeLabelEditEventHandler(treeView1_AfterLabelEdit);
            CnnString wCnnString = (CnnString)treeView1.SelectedNode.Tag;
            wCnnString.Name = e.Label;
            CnnStringChange(treeView1.SelectedNode.Text);
            treeView1.SelectedNode.EndEdit(true);
        }

        /// <summary>
        /// Crea una nueva cadena de conexión; por defecto le determina un nombre que despues el usuario debe 
        /// reemplazar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuNewCnnString_Click(object sender, EventArgs e)
        {
            TreeNode wFile = GetTreeNodeFile();
            try
            {
                DataConfigControl.AddCnnStringDefault(wFile, mnCnnString);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "App config", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// Elimina el nodo Data Access del tree view y todo lo relacionado a cadenas de coneccion 
        /// dentro del el xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuQuitDataAccessCnnString_Click(object sender, EventArgs e)
        {
            DataConfigControl.ClearDataAccess(treeView1.SelectedNode);
        }
       
        #endregion

        #region Tree View Events

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
      
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            

            DetermineAppConfigSelectedNodeType(e.Node);

            DoAppConfig(e);

            //TODO: Lanzar evento AfterSelect
            DetermineContextMenuEnabled();
        }

        #endregion


        #region Events --> Menu mnAppConfigAplications

        /// <summary>
        /// Guarda un archivo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuSaveAppClientConfig_Click(object sender, EventArgs e)
        {
            SaveFile();

        }

        /// <summary>
        /// Quita un archivo App.Config del Tree View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuQuitAppClientConfig_Click(object sender, EventArgs e)
        {
            QuitFile();
        }

        /// <summary>
        /// Crea un settings para Fwk Libraries Configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemAddConfigurationProvider_Click(object sender, EventArgs e)
        {
            if (_AppConfigSelectedNodeType == AppConfigSelectedNodeType.File)
                AppConfigControl.AddConfigurationManagerSeccion(treeView1.SelectedNode,mnSection);
            if (_AppConfigSelectedNodeType == AppConfigSelectedNodeType.ApplicationSettings ||
                _AppConfigSelectedNodeType == AppConfigSelectedNodeType.SectionGroup)
                AppConfigControl.AddConfigurationManagerSeccion(treeView1.SelectedNode.Parent, mnSection);
        }

        /// <summary>
        /// Refresca un archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuRefreshAppClientConfig_Click(object sender, EventArgs e)
        {
            ///TODO: Completar Refresca un archivo
        }
        #endregion


        /// <summary>
        /// Load del formulario .-
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockPanelAppConfigClient_Load(object sender, EventArgs e)
        {
            ///Refresca limpiando todos los nodos del treeview y de AppConfigControl.AppConfigFilesList
            /// 
            RefreshAllFiles(true);
        }

        /// <summary>
        /// Cuando el formulario se sierra se guardan los archivos abiertos por el usuario en el Isolated Storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockPanelAppConfigClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveIsolatedStorage();
            _PropertyGrid.PropertyValueChanged -=
                                new PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChangedSetting);
            _PropertyGrid.PropertyValueChanged -=
                                new PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChangedDataBase);
        }

        /// <summary>
        /// Permite quitar una seccion puede ser de:
        /// wrapper
        /// configuration manager
        /// etc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemQuitSection_Click(object sender, EventArgs e)
        {
            if (_AppConfigSelectedNodeType == AppConfigSelectedNodeType.ApplicationSettings ||
               _AppConfigSelectedNodeType == AppConfigSelectedNodeType.Application)
            {
                TreeNode wTreeNodeFile = GetTreeNodeFile();
                AppConfigControl.Remove(wTreeNodeFile, treeView1.SelectedNode.Text);
            }
        }


        #region Menu mnRoot Events
        private void tsMenuNewFile_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void tsMenuSaveAllFile_Click(object sender, EventArgs e)
        {
            SaveAllFile();
        }

        private void tsMenuQuitAllFile_Click(object sender, EventArgs e)
        {
            QuitAllFiles();
        }

        private void tsMenuRefreshAllFile_Click(object sender, EventArgs e)
        {
            RefreshAllFiles(true);
        }
        #endregion

        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode wTreeNodeFile = GetTreeNodeFile();

            System.Diagnostics.Process.Start("explorer.exe", wTreeNodeFile.ToolTipText);

        }

        /// <summary>
        /// Agrega Fwk.ServiceManagement.Properties.Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setDispatcherSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AddBusinessFacadeSection();
           
        }
        /// <summary>
        /// Agrega el Wrapper Local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLocalWrapperSection();
        }

       

        
       
       











    }
}