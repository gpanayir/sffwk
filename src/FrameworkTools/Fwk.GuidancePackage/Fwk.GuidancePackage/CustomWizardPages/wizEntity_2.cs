using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.WizardFramework;
using Fwk.DataBase;
using System.ComponentModel.Design;
using Microsoft.SqlServer.Management.Smo;

namespace Fwk.GuidPk
{
    public partial class wizEntity_2 : CustomWizardPage
    {


        CnnString _cnn = new CnnString();

        public wizEntity_2(WizardForm parent)
            : base(parent)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            ctrlTreeViewTables1.SelectElementHandler += new SelectElementHandler(ctrlTreeViewTables1_SelectElementHandler);

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

        [RecipeArgument]
        public Table Table
        {
            set
            {
                if (value != null)
                {

                    ctrlTreeViewTables1.SelectedTable = value;
                }
                else
                {
                    ctrlTreeViewTables1.SelectedTable = null;
                }
            }
        }

        internal void LoadCnn(string cnnString)
        {
            _cnn = new CnnString("c1", cnnString.ToString());
            ctrlTreeViewTables1.Populate(_cnn);
        }





        void ctrlTreeViewTables1_SelectElementHandler(object e)
        {


            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            if (e == null)
            {

                dictionaryService.SetValue("Table", null);
            }
            else
            {
                Table selTable = (Table)e;

                dictionaryService.SetValue("Table", selTable);
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

        private void wizEntity_2_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void wizEntity_2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadTables();
            }

        }


        void LoadTables()
        {
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;

            string connectionString = dictionaryService.GetValue("ConnectionString").ToString();

            if (!string.IsNullOrEmpty(connectionString))
                LoadCnn(connectionString);
        }


    }
}

