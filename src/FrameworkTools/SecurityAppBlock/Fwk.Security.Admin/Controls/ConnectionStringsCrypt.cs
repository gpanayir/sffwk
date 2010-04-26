using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions;
using System.IO;
using System.Xml;
using System.Configuration;

namespace Fwk.Security.Admin.Controls
{
    public partial class ConnectionStringsCrypt : SecurityControlBase
    {
        bool? currentFileIsEncripted = null;
        string currentFile = string.Empty;
        /// <summary>
        /// Lista de archivos App.Config, en esta lista se almacenan los nombres completo de todos los archivos abiertos 
        /// de modo que quede un registro en memoria de los archivos con los cuales se esta trabajando.-
        /// </summary>
        Fwk.Caching.FwkSimpleStorageBase<Dictionary<String, String>> _Storage = new Fwk.Caching.FwkSimpleStorageBase<Dictionary<string, string>>();
        
        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// </summary>
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(RulesAssingControl).AssemblyQualifiedName;
            }
        }
        public ConnectionStringsCrypt()
        {
            InitializeComponent();

            _Storage.Load();

            if (_Storage.StorageObject == null)
                _Storage.StorageObject = new Dictionary<string, string>();
            else
                Populate();

        }



        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Node.Level != 1 || e.Node.Tag == null)
            {
                lblSelectedFile.Text = string.Empty;
                currentFile = string.Empty;
                currentFileIsEncripted = null;
                return;
            }
            
            treeView1.SelectedNode = e.Node;
            lblSelectedFile.Text = e.Node.Text;
            ShowConnectionData(e.Node.Tag.ToString());
        }


 
        void ShowConnectionData(string fullFileName)
        {
            currentFile = fullFileName;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(fullFileName);
            ConnectionStringsSection sect = config.ConnectionStrings;
            if (sect.SectionInformation.IsProtected)
            {
                btnEncrypt.Text = "Dencrypt";
                currentFileIsEncripted = true;
            }
            else
            {
                btnEncrypt.Text = "Encrypt";
                currentFileIsEncripted = false;
            }

            StringBuilder str;
            XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(fullFileName);
            XmlNode connectionStringsNode = doc.SelectSingleNode("/configuration/connectionStrings");
            if (connectionStringsNode != null)
            {
                str = new StringBuilder("connectionStrings");
                str.AppendLine(Environment.NewLine);

                foreach (XmlNode nodeAdd in connectionStringsNode.ChildNodes)
                {
                    str.AppendLine(".....................................................................");
                    str.AppendLine(Environment.NewLine);
                    str.AppendLine(nodeAdd.OuterXml);
                    str.AppendLine(Environment.NewLine);
                    str.AppendLine(".....................................................................");

                }
                memoEdit1.Text = str.ToString();
                
                str = null;
                doc = null;

            }
        }
        void Populate()
        {

            foreach (System.Collections.Generic.KeyValuePair<string,string> wKeyValuePair in _Storage.StorageObject)
            {
                
                addToTree(wKeyValuePair.Key, wKeyValuePair.Value);
            }
        }

        private void btnFindRoles_Click(object sender, EventArgs e)
        {
            string fullFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open("Xml Files(*.CONFIG;)|*.CONFIG;|All files (*.*)|*.*",string.Empty,txtFileName.Text);
            if (string.IsNullOrEmpty(fullFileName)) return;
            if (_Storage.StorageObject.ContainsKey(fullFileName))
            {
                this.MessageViewInfo.Show("Ya agrego este archivo");
                return;
            }
           
            _Storage.StorageObject.Add(fullFileName, System.IO.Path.GetFileName(fullFileName));
            _Storage.Save();
            addToTree(fullFileName, _Storage.StorageObject[fullFileName]);
        }
        void addToTree(string k, string value)
        {
            TreeNode wFileNode = new TreeNode(k);
            wFileNode.ToolTipText = k;
            wFileNode.ContextMenuStrip = mnGroupAndKey;
            wFileNode.Text = value;

            if (File.Exists(k) == false)
            {
                wFileNode.ImageIndex = imgImages.Images.IndexOfKey("WarningHS.png");
                wFileNode.SelectedImageIndex = imgImages.Images.IndexOfKey("WarningHS.png");
                wFileNode.Tag = null;
            }
            else
            {
                wFileNode.Tag = k;
            }
            treeView1.Nodes[0].Nodes.Add(wFileNode);
        }

        private void tsMenuItemRemoveGrOrKey_Click(object sender, EventArgs e)
        {
          _Storage.StorageObject.Remove(  treeView1.SelectedNode.Tag.ToString());
          treeView1.SelectedNode.Remove();
          _Storage.Save();
        }

        void EncryptCnnStrings(string fileName)
        {

           System.Configuration.Configuration  config = ConfigurationManager.OpenExeConfiguration(fileName);
            ConnectionStringsSection sect = config.ConnectionStrings;
            
            sect.SectionInformation.ForceSave = true;
            sect.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
            config.Save(ConfigurationSaveMode.Minimal,false);

            //XmlDocument doc = new System.Xml.XmlDocument();
            //doc.Load(string.Concat(fileName,".config"));
            //XmlNode connectionStringsNode = doc.SelectSingleNode("/configuration/connectionStrings");

            //string xmlCrypted = connectionStringsNode.InnerXml;
            //doc = null;
            //doc = new System.Xml.XmlDocument();
            //doc.Load(fileName);
            // connectionStringsNode = doc.SelectSingleNode("/configuration/connectionStrings");
            //connectionStringsNode.InnerXml = xmlCrypted;
            //doc.Save(fileName);
            //File.Delete(string.Concat(fileName,".config"));
        }

        void DencryptCnnStrings(string fileName)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
            ConnectionStringsSection sect = config.ConnectionStrings;
            if (sect.SectionInformation.IsProtected)
            {
                sect.SectionInformation.UnprotectSection();
                config.Save(ConfigurationSaveMode.Minimal,true);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (currentFileIsEncripted == null) return;

            if (currentFileIsEncripted.Value)
            
                DencryptCnnStrings(currentFile);
            
            else
                EncryptCnnStrings(currentFile);

            currentFileIsEncripted = !currentFileIsEncripted;

        }
    }
}
