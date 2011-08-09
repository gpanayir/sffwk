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

namespace Fwk.GuidPk
{

    public partial class wizDBSelect : CustomWizardPage
    {
        bool onInitServerCollection = true;
        CnnString _cnn = new CnnString();
        DataTable _AvailableSqlServers;
        Server _Server;






        public wizDBSelect()
        {
            InitializeComponent();
        }

        public wizDBSelect(WizardForm parent)      : base(parent)
        {
            InitializeComponent();
        }

        [RecipeArgument]
        public string ConnectionString
        {
            set
            {
                if (value != null)
                {

                    _cnn = new CnnString("1",value.ToString());
                    SetUI(_cnn);
                }
             
            }
        }

       

        /// <summary>
        /// Carga las bses de datos del server
        /// </summary>
        /// <param name="pCnnString"></param>
        void FillDatabaseCombo(CnnString pCnnString)
        {
            if (onInitServerCollection) return;


            SqlConnection sqlConnection = new SqlConnection(pCnnString.ToString());

            ServerConnection serverConnection = new ServerConnection(sqlConnection);

            try
            {
                _Server = new Server(serverConnection);
                cmbDataBases.Items.Clear();
                foreach (Database db in _Server.Databases)
                {
                    cmbDataBases.Items.Add(db.Name);
                }
                cmbDataBases.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(HelperFunctions.GetAllMessageException(ex));
            }
        }

        public void setIDictionaryService(CnnString cnn)
        {
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;

            if (cnn == null)
                dictionaryService.SetValue("ConnectionString", null);
            else
                dictionaryService.SetValue("ConnectionString", cnn.ToString());
        }
        

      

   
      

        private void WindowsAutentificaction_CheckedChanged(object sender, EventArgs e)
        {
            if (WindowsAutentificaction.Checked)
            {
                txtPassword.Enabled = false;
                txtUserName.Enabled = false;
            }
            else
            {
                txtPassword.Enabled = true;
                txtUserName.Enabled = true;
            }
        }
      

        private CnnString GetAuxiliarCnnString()
        {
            CnnString wCnnString = new CnnString();


            wCnnString.InitialCatalog = cmbDataBases.Text.Trim();
            wCnnString.DataSource = cmbServer.Text.Trim();

            if (WindowsAutentificaction.Checked)
            {
                wCnnString.User = String.Empty;
                wCnnString.Password = String.Empty;

            }
            else
            {
                wCnnString.User = txtUserName.Text.Trim();
                wCnnString.Password = txtPassword.Text.Trim();
            }

            wCnnString.WindowsAutentification = WindowsAutentificaction.Checked;
           
            return wCnnString;
        }

        private void SetUI(CnnString cnn)
        {
            WindowsAutentificaction.Checked = cnn.WindowsAutentification;
            

            cmbDataBases.Text = cnn.InitialCatalog;
            cmbServer.Text = cnn.DataSource;

            if (cnn.WindowsAutentification)
            {
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;

            }
            else
            {
                txtUserName.Text = cnn.User;
                txtPassword.Text = cnn.Password;
            }

            
 
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
           if(Test())
               setIDictionaryService(_cnn);
            else
               setIDictionaryService(null);
        }





        public bool Test()
        {
            _cnn = GetAuxiliarCnnString();

            if (string.IsNullOrEmpty(_cnn.DataSource))
            {
                MessageBox.Show("Ingrese servidor de SQL.-", "Fwk wizard");
                cmbServer.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(_cnn.InitialCatalog))
            {
                MessageBox.Show("Seleccione o ingrese una base de datos.-", "Fwk wizard");
                cmbDataBases.Focus();
                return false;
            }



            if (!_cnn.WindowsAutentification)
            {
                if (string.IsNullOrEmpty(_cnn.User))
                {
                    MessageBox.Show("Ingrese usuario.-", "Fwk wizard");
                    txtUserName.Focus();
                    return false;
                }
            }
            SqlConnection sqlConnection = new SqlConnection(_cnn.ToString());

            Microsoft.SqlServer.Management.Common.ServerConnection serverConnection =
              new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConnection);

            try
            {
                _Server = new Server(serverConnection);


                ////iterate over all Databases
                foreach (Database db in _Server.Databases)
                {
                    MessageBox.Show("Coneccion exitosa.-", "Fwk wizard");
                    
                  
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(HelperFunctions.GetAllMessageException(ex), "Fwk wizard");
                return false;
            }
            return true;
        }

      


        internal void LoadCnn(CnnString cnn)
        {
            cmbDataBases.Text = cnn.InitialCatalog;
            cmbServer.Text = cnn.DataSource ;
            WindowsAutentificaction.Checked = cnn.WindowsAutentification;
        }


        private void cmbServer_Click(object sender, EventArgs e)
        {
            InitServers();
        }

        void InitServers()
        {

            onInitServerCollection = true;

            if (_AvailableSqlServers == null)
            {
                _AvailableSqlServers = SmoApplication.EnumAvailableSqlServers(false);
                cmbServer.DataSource = _AvailableSqlServers;
                cmbServer.DisplayMember = "Name";


            }
            onInitServerCollection = false;
        }
        private void cmbDataBases_Click(object sender, EventArgs e)
        {
           
            _cnn = GetAuxiliarCnnString();
            setIDictionaryService(_cnn);

            if (!_cnn.DataSource.Equals(cmbServer.Text.Trim()) || cmbDataBases.Items.Count == 0)
            {
                _cnn.DataSource = cmbServer.Text.Trim();
                FillDatabaseCombo(_cnn);
            }
        }


        private void cmbDataBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cnn = GetAuxiliarCnnString();
            setIDictionaryService(_cnn);

            if (!_cnn.DataSource.Equals(cmbServer.Text.Trim()) || cmbDataBases.Items.Count == 0)
            {
                _cnn.DataSource = cmbServer.Text.Trim();
                FillDatabaseCombo(_cnn);
            }
        }

        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
