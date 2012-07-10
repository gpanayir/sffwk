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
using Fwk.UI.Forms;
namespace Fwk.UI.Controls.Menu
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FRM_AssemblyExplorer : FormBase
    {
        private Type[] _BaseTypesFilter;

        private ButtonBase _SelectedForm = null;

        [Browsable(false)]
        public ButtonBase SelectedForm
        {
            get { return _SelectedForm; }
            set { _SelectedForm = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public FRM_AssemblyExplorer(Type[] pBaseTypesFilter)
        {
            InitializeComponent();
            _BaseTypesFilter = pBaseTypesFilter;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog wSchemaDialog = new OpenFileDialog();
            wSchemaDialog.DefaultExt = "dll";
            wSchemaDialog.CheckFileExists = true;

            wSchemaDialog.Filter = FileFunctions.OpenFilterEnums.OpenAssembliesFilter;
            wSchemaDialog.ShowReadOnly = true;

            


            if (wSchemaDialog.ShowDialog() == DialogResult.OK)
            {
                LoadAssembly(wSchemaDialog.FileName);
            }
        }

        void LoadAssembly(string pFileName)
        {
            lblEx.Visible = false;
            ButtonBaseList wButtons = new ButtonBaseList();
            ButtonBase wButton = new ButtonBase();
            try
            {
                Assembly wAssembly = new Assembly(pFileName);
                lblFileName.Text = pFileName;

                foreach (AssemblyClass wAssemblyClass in wAssembly.ClassCollections)
                {
                    string name = wAssemblyClass.Name;


                    if (wAssemblyClass.BaseType != null)
                    {

                        typeof(ButtonBase).IsInstanceOfType(wButton);


                        //if (Fwk.HelperFunctions.TypeFunctions.TypeInheritFrom(wAssemblyClass.Type, _BaseTypesFilter))
                        if (inheritFromAny(wAssemblyClass.Type))
                        {
                            wButton = new ButtonBase();
                            wButton.AssemblyInfo = wAssemblyClass.FullyQualifiedName;

                            wButtons.Add(wButton);
                        }
                    }
                }

                listBox1.DataSource = wButtons;
            }
            catch (Exception ex)
            {
                lblEx.Visible = true;
                lblEx.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

        /// <summary>
        /// Si hereda de alguno de los tipos del vector de tipos retorna verdadero
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool inheritFromAny(Type type)
        {
            foreach (Type t in _BaseTypesFilter)
            {
                if (Fwk.HelperFunctions.TypeFunctions.TypeInheritFrom(type, t)) return true;    
            }
            return false;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.ListBox)(sender)).Text != String.Empty)
            {
                _SelectedForm = (ButtonBase)((System.Windows.Forms.ListBox)(sender)).SelectedItem;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_SelectedForm != null)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void FRM_AssemblyExplorer_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void FRM_AssemblyExplorer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string str = ((string[])e.Data.GetData(DataFormats.FileDrop, true))[0];

                e.Effect = DragDropEffects.Copy;
            }
        }

        private void FRM_AssemblyExplorer_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string str = ((string[])e.Data.GetData(DataFormats.FileDrop, true))[0];
                LoadAssembly(str);


            }
        }

        

    }

   
}
