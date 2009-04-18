using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;
namespace Fwk.DataBase.CustomControls
{
    /// <summary>
    /// Manejador de eventos que enuncian cambios en la coneccion .-
    /// </summary>
    public delegate void ConnectionSourceChangeHandler();

    /// <summary>
    /// Manejador de eventos Aceptar.-
    /// </summary>
    public delegate void AceptHandler(bool ConnectionOK);
    /// <summary>
    /// Manejador de eventos Cancel.-
    /// </summary>
    public delegate void CancelHandler();

    /// <summary>
    /// 
    /// </summary>
    public partial class CnnDataBaseForm : UserControl
    {
        #region [Eventos]

        /// <summary>
        /// Acept event .-
        /// </summary>
        private event AceptHandler _AceptEvent = null;
        /// <summary>
        /// 
        /// </summary>
        private event ConnectionSourceChangeHandler _ConnectionSourceChangeEvent = null;

        /// <summary>
        /// Cancel vent .-
        /// </summary>
         private event CancelHandler _CancelEvent = null;

        /// <summary>
        /// 
        /// </summary>
        private void OnCancelEvent()
        {

            if (_CancelEvent != null)
                _CancelEvent();
        }

        /// <summary>
        /// Se produce cuando se preciona el boton cancelar
        /// </summary>
        public  event CancelHandler CancelEvent
        {
            add
            {
                _CancelEvent = (CancelHandler)Delegate.Combine(_CancelEvent, value);
            }
            remove
            {
                _CancelEvent = (CancelHandler)Delegate.Remove(_CancelEvent, value);
            }
        }


         /// <summary>
         /// 
         /// </summary>
        /// <param name="pConnectionOK"></param>
        private void OnAceptEvent(bool pConnectionOK )
        {

            if (_AceptEvent != null)
                _AceptEvent(pConnectionOK);
        }
        /// <summary>
        /// Se produce cuando se preciona el boton Aceptar
        /// </summary>
        public event AceptHandler AceptEvent
        {
            add
            {
                _AceptEvent = (AceptHandler)Delegate.Combine(_AceptEvent, value);
            }
            remove
            {
                _AceptEvent = (AceptHandler)Delegate.Remove(_AceptEvent, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnConnectionSourceChangeEvent()
        {

            if (_ConnectionSourceChangeEvent != null)
                _ConnectionSourceChangeEvent();
        }
        /// <summary>
        /// Se produce cuando se preciona el boton ConnectionSourceChangear
        /// </summary>
        public event ConnectionSourceChangeHandler ConnectionSourceChangeEvent
        {
            add
            {
                _ConnectionSourceChangeEvent = (ConnectionSourceChangeHandler)Delegate.Combine(_ConnectionSourceChangeEvent, value);
            }
            remove
            {
                _ConnectionSourceChangeEvent = (ConnectionSourceChangeHandler)Delegate.Remove(_ConnectionSourceChangeEvent, value);
            }
        }
        #endregion

        #region [Propieades]
        private CnnString _CurrentConnection = null;

        /// <summary>
        /// Determina si la cadena de coneccion a cambiado.-
        /// </summary>
        public System.Boolean CnnStringChange = false;

        /// <summary>
        /// Indica si la conceccion fue exitosa o no .- 
        /// </summary>
        public System.Boolean ConnectionOK = false;
        /// <summary>
        /// Indica si el combo de BD esta cargado o no.-
        /// </summary>
        private bool ComboDataBasesLoad = false;

        /// <summary>
        /// 
        /// </summary>
        private string ActualTxtBoxServerName = string.Empty;

        

        /// <summary>
        /// Connection String object
        /// </summary>
        [Description("Cadebna de conección")]
        [Browsable(false)]
        public CnnString Connection
        {
            get { return _CurrentConnection; }
            set { _CurrentConnection = value; }
        }

        /// <summary>
        /// Indica si el boton es visible.-
        /// </summary>
        [Description("Indica si el boton es visible.-")]
        public System.Boolean TestBottonVisible
        {
            set { this.btnTestConnection.Visible = value; }
            get { return this.btnTestConnection.Visible; }
        }

        /// <summary>
        /// Indica el color de los botones del formulario de coneccion
        /// </summary>
        [Description("Indica el color de los botones del formulario de coneccion")]
        public Color ButtonsBackColor
        {
            get
            {
                return btnAceptar.BackColor;
            }
            set
            {
                btnAceptar.BackColor = value;
                btnTestConnection.BackColor = value;
                btnCancelar.BackColor = value;
            }
        }

        /// <summary>
        /// Indica la fuente de los botones del formulario de coneccion
        /// </summary>
        [Description("Indica la fuente de los botones del formulario de coneccion")]
        public Font ButtonsFont
        {
            get
            {
                return btnAceptar.Font;
            }
            set
            {
                btnAceptar.Font = value;
                btnTestConnection.Font = value;
                btnCancelar.Font = value;
            }
        }

        /// <summary>
        /// Especifica la apariencia plana de los botones.-
        /// </summary>
        [Description("Especifica la apariencia plana de los botones.-")]
        public FlatStyle ButtonsFlatStyle
        {
            get
            {
                return btnAceptar.FlatStyle;
            }
            set
            {
                btnAceptar.FlatStyle = value;
                btnTestConnection.FlatStyle = value;
                btnCancelar.FlatStyle = value;
            }
        }

        /// <summary>
        /// Especifica el color de las etiquetas (titulos)
        /// </summary>
        [Description("Especifica el color de las etiquetas (titulos)-")]
        public Color LabelsForeColor
        {
            get
            {
                return label1.ForeColor;
            }
            set
            {
                label1.ForeColor = value;
                label4.ForeColor = value;
                label2.ForeColor = value;
                label5.ForeColor = value;
                WindowsAutentificaction.ForeColor = value;

            }
        }


        #endregion

        /// <summary>
        /// 
        /// </summary>
        public CnnDataBaseForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Establece los valores de los controles que muestran la informacion de coneccions .-
        /// </summary>
        public void InitialiceControl()
        {
            DataBaseServer wDataBaseServer = null;
            try
            {
                wDataBaseServer = new DataBaseServer(true);

                txtServer.Text = wDataBaseServer.CnnString.DataSource;
                
                cmbConnections.DataSource = wDataBaseServer.CnnStringList;
                cmbConnections.ValueMember = "Name";
                cmbConnections.DisplayMember = "Name";
                cmbConnections.SelectedIndex = 0;
                WindowsAutentificaction.Checked = wDataBaseServer.CnnString.WindowsAutentification;
                if (!wDataBaseServer.CnnString.WindowsAutentification)
                {
                    txtUserName.Text = wDataBaseServer.CnnString.User;
                    txtPassword.Text = wDataBaseServer.CnnString.Password;
                }
                else
                {
                    txtUserName.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                }

                cmbDataBases.Items.Add(wDataBaseServer.CnnString.InitialCatalog);
                cmbDataBases.Text = wDataBaseServer.CnnString.InitialCatalog;

            }


            catch (DataBaseExeption ex)
            {

                txtServer.Text = ex.CnnString.DataSource;

                txtUserName.Text = ex.CnnString.User;
                txtPassword.Text = ex.CnnString.Password;
                txtPassword.Focus();
                WindowsAutentificaction.Checked = ex.CnnString.WindowsAutentification;
                cmbDataBases.Items.Add(ex.CnnString.InitialCatalog);
                cmbDataBases.Text = ex.CnnString.InitialCatalog;
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de conección");
            }
        }

        private void btnTestConnection_Click(object sender, System.EventArgs e)
        {
            if (WindowsAutentificaction.Checked && txtServer.Text.Trim() == String.Empty)
                return;
            if (txtServer.Text.Trim() == String.Empty)
                return;
            try
            {
                if (DataBaseServer.TestConnection(txtServer.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim(), WindowsAutentificaction.Checked))
                {
                    MessageBox.Show("La conexion se realizo con exito");
                    ConnectionOK = true;
                    OnConnectionSourceChangeEvent();
                }
                else
                {
                    MessageBox.Show("La conexion fallo", "Error de coneccion");
                    ConnectionOK = false;
                }
            }
            catch(Exception ex)
            {
                string wErrMessage = "Error al intentar conetar al servidor de Base de Datos" + Environment.NewLine;
                wErrMessage += ex.Message;
                MessageBox.Show(wErrMessage,"Error de conección");
            }
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            DataBaseServer wDataBaseServer = null;
            if (String.IsNullOrEmpty(txtServer.Text))
            {
                MessageBox.Show("Falta ingresar nombre del servidor");
                txtServer.Focus();
                return;
            }
            if (!WindowsAutentificaction.Checked)
                if (String.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("Falta ingresar nombre de usuario");
                    txtUserName.Focus();
                    return;
                }
            try
            {
                wDataBaseServer = new DataBaseServer(true);
                CnnString wCnnString = GetAuxiliarCnnString();
                //Pregunto si los datos ingresados dan OK a una coneccion antes de
                //guardar la configuracion.-
                if (DataBaseServer.TestConnection(wCnnString))
                {
                    MappingTextBoxToProperties();
                    List<CnnString> listAux = (List < CnnString > )wDataBaseServer.CnnStringList.FindAll(new SearchEntityArg("Name", cmbConnections.Text));

                    if (listAux.Count == 0)
                    {
                        _CurrentConnection.Name = cmbConnections.Text;
                        //Almaceno la configuracion .-
                        wDataBaseServer.SaveSetting(_CurrentConnection, true);
                    }
                    else
                    {
                        //modifico la configuracion .-
                        wDataBaseServer.SaveSetting(_CurrentConnection, false);
                    }
                    ConnectionOK = true;
                }
                else
                {
                    MessageBox.Show("La conexion no se pudo realizar", "Error de conección");
                    ConnectionOK = false;
                }
            }
            catch (DataBaseExeption wDataBaseExeption)
            {
                ConnectionOK = false;
                txtServer.Text = wDataBaseExeption.CnnString.DataSource;

                txtUserName.Text = wDataBaseExeption.CnnString.User;
                txtPassword.Text = wDataBaseExeption.CnnString.Password;

                WindowsAutentificaction.Checked = wDataBaseExeption.CnnString.WindowsAutentification;
                cmbDataBases.Items.Add(wDataBaseExeption.CnnString.InitialCatalog);
                cmbDataBases.Text = wDataBaseExeption.CnnString.InitialCatalog;

                txtPassword.Focus();
                MessageBox.Show(wDataBaseExeption.Message);
            }
            catch (Exception ex)
            {
                ConnectionOK = false;
                MessageBox.Show(ex.Message, "Error de conección");
            }
            finally
            {
                OnAceptEvent(ConnectionOK);
            }
        }

        private void MappingTextBoxToProperties()
        {
            if (_CurrentConnection == null)
                _CurrentConnection = new CnnString();

            if (_CurrentConnection.InitialCatalog != cmbDataBases.Text.Trim() ||
                _CurrentConnection.DataSource != txtServer.Text.Trim())
            {
                CnnStringChange = true;
            }
            else
            {
                CnnStringChange = false;
            }
            _CurrentConnection.InitialCatalog = cmbDataBases.Text.Trim();
            _CurrentConnection.DataSource  = txtServer.Text.Trim();
            _CurrentConnection.User = txtUserName.Text.Trim();
            _CurrentConnection.Password = txtPassword.Text.Trim();
            _CurrentConnection.WindowsAutentification = WindowsAutentificaction.Checked;
        }
        private void MappingPropertiesToTextBox()
        {
       

            //if (_CurrentConnection.InitialCatalog != cmbDataBases.Text.Trim() ||
            //    _CurrentConnection.DataSource != txtServer.Text.Trim())
            //{
            //    CnnStringChange = true;
            //}
            //else
            //{
            //    CnnStringChange = false;
            //}
            CnnStringChange = true;

            cmbDataBases.Text = _CurrentConnection.InitialCatalog;
            txtServer.Text = _CurrentConnection.DataSource;
            txtUserName.Text = _CurrentConnection.User;
            txtPassword.Text = _CurrentConnection.Password;
            WindowsAutentificaction.Checked = _CurrentConnection.WindowsAutentification;
        }
        private CnnString GetAuxiliarCnnString()
        {
            CnnString wCnnString = new CnnString();

            
            wCnnString.InitialCatalog = cmbDataBases.Text.Trim();
            wCnnString.DataSource = txtServer.Text.Trim();

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
       
        private void cmbDataBases_Click(object sender, System.EventArgs e)
        {
            DataBaseServer wDataBaseServer = null;
            try
            {
                 wDataBaseServer = new DataBaseServer(true);
                if (WindowsAutentificaction.Checked)
                {
                    if (txtServer.Text.Trim() == String.Empty) return;
                }
                else
                {
                    if (txtServer.Text.Trim() == String.Empty || txtUserName.Text.Trim() == String.Empty) return;
                }
                if (ComboDataBasesLoad == false)
                {

                    if (DataBaseServer.TestConnection(txtServer.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim(), WindowsAutentificaction.Checked))
                    {
                        cmbDataBases.Items.Clear();
                        

                        wDataBaseServer.CnnString.DataSource = txtServer.Text.Trim();
                        wDataBaseServer.CnnString.User = txtUserName.Text.Trim();
                        wDataBaseServer.CnnString.Password = txtPassword.Text.Trim();
                        wDataBaseServer.CnnString.WindowsAutentification = WindowsAutentificaction.Checked;

                        DataTable dttDataBases = wDataBaseServer.GetDataBases();

                        foreach (DataRow dtr in dttDataBases.Rows)
                        {
                            cmbDataBases.Items.Add(dtr["DATABASE_NAME"].ToString());
                        }
                        ComboDataBasesLoad = true;
                    }

                    else
                    {
                        MessageBox.Show("Los parametros de conexion no son validos.- Verifique nombre de usuario y contraseña", "Error de conección");
                        ConnectionOK = false;
                    }
                }
            }
            catch (DataBaseExeption wDataBaseExeption)
            {
               
                txtServer.Text = wDataBaseExeption.CnnString.DataSource;

                txtUserName.Text = wDataBaseExeption.CnnString.User;
                txtPassword.Text = wDataBaseExeption.CnnString.Password;
                txtPassword.Focus();
                WindowsAutentificaction.Checked = wDataBaseExeption.CnnString.WindowsAutentification;
                cmbDataBases.Items.Add(wDataBaseExeption.CnnString.InitialCatalog);
                cmbDataBases.Text = wDataBaseExeption.CnnString.InitialCatalog;

                MessageBox.Show(wDataBaseExeption.Message, "Error de conección");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error de conección"); }
        }

        private void txtServer_Leave(object sender, System.EventArgs e)
        {
            if (ActualTxtBoxServerName != txtServer.Text.Trim())
            {
                ActualTxtBoxServerName = txtServer.Text.Trim();
                ComboDataBasesLoad = false;
            }

        }

        private void WindowsAutentificaction_CheckedChanged(object sender, System.EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OnCancelEvent();
        }

       

        private void cmbConnections_SelectedValueChanged(object sender, EventArgs e)
        {
            _CurrentConnection  = (CnnString)cmbConnections.SelectedItem;
            MappingPropertiesToTextBox();
        }

       
		
    }
}
