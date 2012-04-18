using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Fwk.UI.Controls;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Management.Smo.Agent;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using DevExpress.XtraEditors;

namespace Fwk.UI.Controls.Wizard
{
    [ToolboxItem(true)]
    public partial class UC_AuthenticationBD : UC_UserControlBase
    {
        #region Members

        String _NameServer = String.Empty;
        Server _Server;
        ServerConnection _ServerConn;
        List<String> _ServerList;
        List<Database> _DataBaseList;
        Database _DataBase;

        #endregion

        #region Properties

        public Database DataBaseSelected
        {
            get { return _DataBase; }
            set { _DataBase = value; }
        }
        public String NameServer
        {
            get { return _NameServer; }
            set { _NameServer = value; }
        }
        public Server ServerSelected
        {
            get { return _Server; }
            set { _Server = value; }
        }
        public bool IsLoadingServerOrDataBase
        {
            get
            {
                if (pictureBox1.Visible | pictureBox2.Visible)
                    return true;
                else
                    return false;
            }

        }
        public bool HasErrors
        {
            get
            {
                foreach (Control wControl in this.Controls)
                {
                    if (!string.IsNullOrEmpty(errorProvider1.GetError(wControl)))
                        return true;
                }
                return false;
            }
        }

        #endregion

        #region Constructor
        public UC_AuthenticationBD()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        public void Populate()
        {
            pictureBox1.Visible = true; // loading start

            if (!BGWServers.IsBusy)
            {
                BGWServers.RunWorkerAsync();
            }
            else
            {
                errorProvider1.SetError(cmbServers, string.Empty);
            }
        }

        private void ObtenerServers()
        {
            _ServerList = new List<String>();

            DataTable wDt = SmoApplication.EnumAvailableSqlServers(false);

            if (wDt.Rows.Count > 0)
            {
                foreach (DataRow wDr in wDt.Rows)
                {
                    _ServerList.Add(Convert.ToString(wDr["Name"]));
                }
            }
        }

        /// <summary>
        /// Se cargan las databases
        /// </summary>
        private void ObtenerDataBases()
        {
            try
            {
                if (!chkAuthIntegrated.Checked)
                {
                    Login(txtUser.Text, txtPassword.Text);
                }
                else
                    Login();

                // Inicializacion de la lista
                _DataBaseList = new List<Database>();

                foreach (Database item in _Server.Databases)
                {
                    _DataBaseList.Add(item);
                }
            }
            catch (ConnectionFailureException cfex)
            {
                //Fwk.UI.Controls.SimpleMessageView.Show(cfex, "Error de conexión", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Error);
                MessageView wMV = new MessageView();
                wMV.TextMessageColor = Color.Transparent;
                MessageView.Show(cfex, "Error de conexión", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Error);
            }
        }

        private void LoadDataBasesListControl()
        {
            lstDataBases.Items.Clear();
            lstDataBases.DataSource = _DataBaseList;
            lstDataBases.Focus();

            if (_DataBaseList.Count == 0)
                Fwk.UI.Controls.SimpleMessageView.Show("No se encontraron bases de datos a las que el usuario pueda acceder", "", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Information);

        }

        /// <summary>
        /// Carga el combo de servers
        /// </summary>
        private void LoadComboServers()
        {
            cmbServers.Properties.DataSource = _ServerList;
        }

        private void Login()
        {
            try
            {
                // autenticacion integrada
                _Server = new Server(_NameServer);
            }
            catch (Exception ex)
            {
                Fwk.UI.Controls.MessageView.Show(ex, "Error de autenticación", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Error);
            }
        }

        private void Login(string pUser, string pPass)
        {
            try
            {       // Autenticacion de SQL
                SqlConnectionInfo wAA = new SqlConnectionInfo(_NameServer);
                wAA.UserName = pUser;
                wAA.Password = pPass;
                _ServerConn = new ServerConnection(wAA);
                //_ServerConn.LoginSecure = true;                
                _Server = new Server(_ServerConn);

            }
            catch (Exception ex)
            {
                Fwk.UI.Controls.MessageView.Show(ex, "Error de autenticación", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Error);
                pictureBox2.Visible = false; //loading end
            }

        }

        private bool ValidarAutenticacion()
        {
            Boolean wResult = true;

            if (chkAuthIntegrated.Checked)
                return wResult;


            // Password
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Debe ingresar la contraseña");
                wResult = false;
            }
            else
                errorProvider1.SetError(txtPassword, "");

            // Usuario
            if (String.IsNullOrEmpty(txtUser.Text))
            {
                errorProvider1.SetError(txtUser, "Debe ingresar el nombre de usuario");
                wResult = false;
            }
            else
                errorProvider1.SetError(txtUser, "");

            if (!wResult)
                cmbServers.EditValue = null;

            return wResult;
        }

        public void StopBackGround()
        {
            if (BGWServers.IsBusy)
                BGWServers.CancelAsync();

            if (BGWBases.IsBusy)
                BGWBases.CancelAsync();
        }

        #endregion

        #region Events

        private void cmbServers_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbServers.ItemIndex > 0)
            {
                if (!BGWBases.IsBusy)
                {
                    _NameServer = cmbServers.Text;

                    if (ValidarAutenticacion())
                    {
                        pictureBox2.Visible = true; //loading start
                        BGWBases.RunWorkerAsync();
                    }

                    errorProvider1.SetError(cmbServers, string.Empty);
                }
            }
        }

        private void cmbServers_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (BGWBases.IsBusy)
                e.Cancel = true;
        }

        private void lstDataBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataBase = (Database)lstDataBases.SelectedItem;
        }

        private void chkAuthIntegrated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuthIntegrated.Checked)
            {
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void UC_AuthenticationBD_Validating(object sender, CancelEventArgs e)
        {
            if (cmbServers.EditValue == null)
            {
                errorProvider1.SetError(cmbServers, "Valor requerido");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cmbServers, string.Empty);

            if (lstDataBases.ItemCount == 0)
            {
                errorProvider1.SetError(lstDataBases, "Valor requerido");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(lstDataBases, string.Empty);

        }

        #region BackGround Events

        #region Servers

        // Obtiene los servers - Inicio
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // se obtine la lista de servidores         
            ObtenerServers();
        }

        // Obtiene los servers - Fin
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // se carga el combo una vez que se haya terminado con obtencion
            LoadComboServers();
            pictureBox1.Visible = false; //Carga terminada

            if (cmbServers.EditValue == null)
                errorProvider1.SetError(cmbServers, "Valor Requerido");
            else
                errorProvider1.SetError(cmbServers, string.Empty);
        }

        #endregion

        #region Bases de Datos

        // Obtiene las bases - Inicio
        private void BGWBases_DoWork(object sender, DoWorkEventArgs e)
        {
            ObtenerDataBases();
        }

        // Obtiene las bases - Fin
        private void BGWBases_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadDataBasesListControl();
            pictureBox2.Visible = false; //loading end
        }

        #endregion

        #endregion

        #endregion

    }
}
