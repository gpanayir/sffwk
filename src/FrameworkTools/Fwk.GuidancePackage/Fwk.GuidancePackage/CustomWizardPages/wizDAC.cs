using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Fwk.DataBase;
using Microsoft.Practices.WizardFramework;
using System.ComponentModel.Design;
using Microsoft.Practices.RecipeFramework.Services;
using Microsoft.Practices.RecipeFramework.Library;
using Microsoft.Practices.RecipeFramework.VisualStudio;
using EnvDTE;
using Fwk.CodeGenerator;
using System.Reflection;

namespace Fwk.GuidPk
{

    public partial class wizDAC : CustomWizardPage
    {

        CnnString _cnn = new CnnString();
        string _Content = "";
        List<GeneratedCode> _GeneratedCodeList;
        [RecipeArgument]
        public string Content
        {
            set
            {
                if (value != null)
                    _Content = value;
                else
                    _Content = string.Empty;

            }
        }

        [RecipeArgument]
        public GeneratedCode[] GeneratedCodeList
        {
            set
            {
                if (value != null)
                    _GeneratedCodeList.AddRange( value);
                else
                    _GeneratedCodeList = null;

            }
        }


        [RecipeArgument]
        public string EntityName
        {
            set
            {
                if (value != null)
                {

                    txtEntityName.Text = value;
                }
                else
                {
                    txtEntityName.Text = string.Empty;
                }
            }
        }

        public wizDAC()
        {
            InitializeComponent();
        }

        public wizDAC(WizardForm parent)
            : base(parent)
        {
            InitializeComponent();

            ctrlTreeViewTables1.SelectElementHandler += new SelectElementHandler(ctrlTreeViewTables1_SelectElementHandler);
        }

        internal void LoadCnn(string cnnString)
        {
            _cnn = new CnnString("c1", cnnString.ToString());
            ctrlTreeViewTables1.Populate(_cnn);
        }


      

   

       

       
      

        void LoadTables()
        {
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;

            string connectionString = dictionaryService.GetValue("ConnectionString").ToString();

            if (!string.IsNullOrEmpty(connectionString))
                LoadCnn(connectionString);
       }


        public void Generate()
        {
            GeneratedCode wGeneratedCode = null;
             _GeneratedCodeList = new List<GeneratedCode>();
            Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting = new TemplateSettingObject();

            TreeNode dacs = Fwk.CodeGenerator.DACGenerator.GenCode(ctrlTreeViewTables1.CheckedTables);
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            foreach (TreeNode nodeDac in dacs.Nodes)
            {
                wGeneratedCode = (GeneratedCode)nodeDac.Tag;
                dictionaryService.SetValue("Content", wGeneratedCode.Code.ToString());
                _GeneratedCodeList.Add(wGeneratedCode);
            }
            dictionaryService.SetValue("GeneratedCodeList", _GeneratedCodeList.ToArray());

        }
    
      
       


        public bool Test()
        {
           
            try
            {

                EnvDTE.DTE dte = (EnvDTE.DTE)GetService(typeof(EnvDTE.DTE));
                IAssetReferenceService referenceService = (IAssetReferenceService)GetService(typeof(IAssetReferenceService));
                object item = DteHelper.GetTarget(dte);
                //MessageBox.Show("Coneccion exitosa.- a " + _Server.Information.Product.ToString(),  Fwk.GuidPk.Properties.Resources.ProductTitle);


                //templateFilename = new Uri(templateFilename).LocalPath;
                StringBuilder items= new StringBuilder ();
                //VsBoundReference vsTarget = null;
                if (item is EnvDTE.Project)
                {
                    foreach (ProjectItem i in ((EnvDTE.Project)item).ProjectItems)
                    {
                        items.AppendLine(i.Name);
                    }
                    //vsTarget = new ProjectReference(templateFilename, (Project)item);
                }

                MessageBox.Show(items.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(Fwk.CodeGenerator.HelperFunctions.GetAllMessageException(ex),  Fwk.GuidPk.Properties.Resources.ProductTitle);
                return false;
            }
            return true;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Generate();
        }











        Table selTable = null;
        void ctrlTreeViewTables1_SelectElementHandler(object e)
        {


            if (e != null)
            {
                 selTable = (Table)e;
                txtEntityName.Text = selTable.Name;
            }



        }

        private void wizDAC_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void wizDAC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadTables();
            }
        }
        private void txtEntityName_TextChanged(object sender, EventArgs e)
        {
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            if (string.IsNullOrEmpty(txtEntityName.Text.ToString()))
                dictionaryService.SetValue("EntityName", null);
            else
                dictionaryService.SetValue("EntityName", txtEntityName.Text);
        }
    }

}