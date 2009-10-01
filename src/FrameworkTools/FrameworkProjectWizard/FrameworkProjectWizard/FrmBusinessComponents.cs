using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Wizard
{
    /// <summary>
    /// Formulario que permite ingresar parametros basicos para construir 
    /// proyectos de tipo :
    /// 
    /// </summary>
    public partial class FrmBusinessComponents : Form
    {
        private string _LongModuleName = String.Empty;

        public string LongModuleName
        {
            get { return _LongModuleName; }
            set { _LongModuleName = value; }
        }

        private int _CompanyIndex = 0;
        private int _AppIndex = 0;
        private int _ModuleIndex = 0;

        private int _CompanyCommonIndex = 0;
        private int _AppCommonIndex = 0;
        private int _ModuleCommonIndex = 0;

        //"[Company].[App].BackEnd.[Module].BusinessComponents";
        private string[] _BackendNamespaceTemplateArray = null;
        private string[] _CommonNamespaceTemplateArray = null;

        public string BackendNamespaceTemplate
        {
            get 
            {
                
                return string.Join(".", _BackendNamespaceTemplateArray).ToString();
            }

            set
            {
                string auxValue = value ;

                _BackendNamespaceTemplateArray = auxValue.Split('.');
                
             

                for (int i = 0; i <= _BackendNamespaceTemplateArray.Length - 1; i++)
                {
                    if (_BackendNamespaceTemplateArray[i].ToString() == "[Company]")
                        _CompanyIndex = i;
                    if (_BackendNamespaceTemplateArray[i].ToString() == "[App]")
                        _AppIndex = i;
                    if (_BackendNamespaceTemplateArray[i].ToString() == "[Module]")
                        _ModuleIndex = i;
                }

                
            }

        }

        public string CommonNamespaceTemplate
        {
            get
            {

                return string.Join(".", _CommonNamespaceTemplateArray).ToString();
            }

            set
            {
                string auxValue = value;

                _CommonNamespaceTemplateArray = auxValue.Split('.');



                for (int i = 0; i <= _CommonNamespaceTemplateArray.Length - 1; i++)
                {
                    if (_CommonNamespaceTemplateArray[i].ToString() == "[Company]")
                        _CompanyCommonIndex = i;
                    if (_CommonNamespaceTemplateArray[i].ToString() == "[App]")
                        _AppCommonIndex = i;
                    if (_CommonNamespaceTemplateArray[i].ToString() == "[Module]")
                        _ModuleCommonIndex = i;
                }


            }

        }

        public string ProjectName
        {
            get { return txtProjectName.Text; }
            set
            {
                txtProjectName.Text = value;
                txtModule.Text = value;

                if (_BackendNamespaceTemplateArray != null)
                    _BackendNamespaceTemplateArray[_ModuleIndex] = value;
                if (_CommonNamespaceTemplateArray != null)
                    _CommonNamespaceTemplateArray[_ModuleCommonIndex] = value;
            }
           
        }

        public string Company
        {
            get { return txtCompanyName.Text; }
        }
        public string App
        {
            get { return txtApp.Text; }
        }
        public string Module
        {
            get { return txtModule.Text; }
        }
        public FrmBusinessComponents()
        {
            InitializeComponent();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (VAlidateTextBox())
            {
                this.Close();
            }
        }

        private bool VAlidateTextBox()
        {
            if (txtModule.Text.Length == 0)
            {
                MessageBox.Show("El nombre del modulo no puede estar vacio");
                txtModule.Focus();
                return false;
            }
            if (txtApp.Text.Length == 0)
            {
                MessageBox.Show("El nombre de aplicacion no puede estar vacio");
                txtApp.Focus();
                return false;
            }
            if (txtCompanyName.Text.Length == 0)
            {
                MessageBox.Show("El nombre de compania no puede estar vacio");
                txtCompanyName.Focus();
                return false;
            }
            return true;
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            if (_BackendNamespaceTemplateArray != null)
                _BackendNamespaceTemplateArray[_CompanyIndex] = txtCompanyName.Text.ToString();
            if (_CommonNamespaceTemplateArray != null)
                _CommonNamespaceTemplateArray[_CompanyCommonIndex] = txtCompanyName.Text.ToString();

            lblNamesPase.Text = GetNamespace();

        }

        private void txtApp_TextChanged(object sender, EventArgs e)
        {
            if (_BackendNamespaceTemplateArray != null)
                _BackendNamespaceTemplateArray[_AppIndex] = txtApp.Text.ToString();
            if (_CommonNamespaceTemplateArray != null)
                _CommonNamespaceTemplateArray[_AppCommonIndex] = txtApp.Text.ToString();

            lblNamesPase.Text = GetNamespace();
        }

        private string GetNamespace()
        {
            if (_LongModuleName.Contains("Interface"))
            {
                return string.Join(".", _CommonNamespaceTemplateArray) + _LongModuleName;
            }
            else
            {
                return string.Join(".", _BackendNamespaceTemplateArray) + _LongModuleName;
            }
        }

        private void txtModule_TextChanged(object sender, EventArgs e)
        {
            if (_BackendNamespaceTemplateArray != null)
                _BackendNamespaceTemplateArray[_ModuleIndex] = txtModule.Text.ToString();

            if (_CommonNamespaceTemplateArray != null)
                _CommonNamespaceTemplateArray[_ModuleCommonIndex] = txtModule.Text.ToString();

            lblNamesPase.Text = GetNamespace();
        }

       
    }
}