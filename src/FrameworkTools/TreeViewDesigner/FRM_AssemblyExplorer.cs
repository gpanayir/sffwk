using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Fwk.AssemblyExplorer;
using Fwk.Bases;
using Fwk.HelperFunctions;



namespace Fwk.Tools
{

    public partial class FRM_AssemblyExplorer : Form
    {
        #region Members

        private String _BaseClassNameFilter;
        private MenuItem _SelectedPelsoft = null;

        #endregion

        #region Properties

        [Browsable(false)]
        public MenuItem SelectedPelsoft
        {
            get { return _SelectedPelsoft; }
            set { _SelectedPelsoft = value; }
        }

        #endregion

        #region Constructor

        public FRM_AssemblyExplorer(String pBaseClassNameFilter)
        {
            InitializeComponent();
            _BaseClassNameFilter = pBaseClassNameFilter;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog wSchemaDialog = new OpenFileDialog();
            wSchemaDialog.DefaultExt = "dll";
            wSchemaDialog.CheckFileExists = true;

            wSchemaDialog.Filter = FileFunctions.OpenFilterEnums.OpenAssembliesFilter;
            wSchemaDialog.ShowReadOnly = true;

            MenuItemList wMenuItemList = new MenuItemList();
     
            if (wSchemaDialog.ShowDialog() == DialogResult.OK)
            {
                MenuItem wMenuItem = new MenuItem();
                Assembly wAssembly = new Assembly(wSchemaDialog.FileName);
                lblFileName.Text = wSchemaDialog.FileName;

                foreach (AssemblyClass wAssemblyClass in wAssembly.ClassCollections)
                {
                    if (wAssemblyClass.BaseType != null)
                    {
                        if (wAssemblyClass.BaseType.Name.Contains(_BaseClassNameFilter))
                        {
                            wMenuItem = new MenuItem();
                            wMenuItem.AssemblyInfo = wAssemblyClass.FullyQualifiedName;
                            
                            wMenuItemList.Add(wMenuItem);
                        }
                    }
                }

                listBox1.DataSource = wMenuItemList;
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.ListBox)(sender)).Text != String.Empty)
                _SelectedPelsoft = (MenuItem)((System.Windows.Forms.ListBox)(sender)).SelectedItem;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_SelectedPelsoft != null)
                this.DialogResult = DialogResult.OK;
        }

    }
   
}
