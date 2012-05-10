using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraEditors.Controls;
using Fwk.UI.Forms;
using Fwk.UI.Common;
using Fwk.UI.Security.Controls;
using Fwk.Bases;
using Fwk.UI.Controller;

namespace Fwk.UI.Security.Controls
{

    /// <summary>
    /// Formulario de autenticacion: 
    /// Este formulario es el encargado de registrar las credenciales del usuario tanto en modo integrado con la seguridad de 
    /// windows como mixta.-
    /// Tambien tiene como proposito inicializar los valores estaticos del FormBase <see cref="FormBase"/>
    /// Pasos:
    /// llama a  FormBase.AuthenticateUser(...)
    ///     Dentro de este metodo se inicializa:
    ///      1) FormBase.IndentityUserInfo 
    ///      2) FormBase.IdentityName
    /// Si no se producen exepciones llama a FormBase.InitAuthorizationFactory
    ///     Dentro de este metodo se inicializa:
    ///      1) FormBase.Principal 
    ///      2) FormBase.RuleProvider
    /// </summary>
    public partial class FRM_AuthenticationForm : FormBase
    {
        #region Members
        //static SingletonFactory<SecurityController> _Controllerfactory = new SingletonFactory<SecurityController>();
        private AuthenticationModeEnum _AuthenticationMode = AuthenticationModeEnum.WindowsIntegrated;

        public string Password
        {
            get { return txtPassword.Text; }
            
        }
        public AuthenticationModeEnum Auth_AuthenticationMode
        {
            get { return _AuthenticationMode; }
            set { _AuthenticationMode = value; }
        }
        private bool _HasWindowsAuthenticationMode = false;
        private bool _IsEnvironmentUser;

        public bool Auth_IsEnvironmentUser
        {
            get { return _IsEnvironmentUser; }
            set { _IsEnvironmentUser = value; }
        }


        public string Auth_Title_Text
        {
            get { return this.lbllTitle.Text; }
            set { this.lbllTitle.Text = value; }
        }

        public Image Auth_Title_Image
        {
            get { return this.imgTitle.Image; }
            set
            {
                if (value != null) 
                    this.imgTitle.Image = value;
                else
                    this.imgTitle.Visible =false;
            }
        }
        public Boolean Auth_Enable_AuthenticationModes
        {
            get { return cmdAuthMode.Enabled; }
            set { cmdAuthMode.Enabled = value; }
        }

        public Boolean Auth_Enable_Domains
        {
            get { return cmbDominios.Enabled; }
            set { cmbDominios.Enabled = value; }
        }
        #endregion

        #region Constructor

        public FRM_AuthenticationForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Solo establece clave y nombre de usuario . Los demas valores se establecen por propiedad : Ej AuthenticationMode, IsEnvironmentUser, Titulo etc etc.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void InitCredentials(string userName, string password)
        {
            if (!string.IsNullOrEmpty(password))
                txtPassword.Text = password;
            if (!string.IsNullOrEmpty(userName))
                txtUserName.Text = userName;
        }

        public bool LoadAuthenticationModes()
        {
            Boolean wOutBool = false;
            ImageComboBoxItem wImageComboBoxItem;
            string wDescription;
            //Obtenemos una lista de las Keys en el grupo "AuthenticationMode" del Configuration Manager
            Fwk.Configuration.Common.Group wGroup = Fwk.Configuration.ConfigurationManager.GetGroup("AuthenticationMode");

            List<Fwk.Configuration.Common.Key> wKeyList = null;
            if (wGroup != null)
            {
                wKeyList = wGroup.Keys.Where(p => (!String.IsNullOrEmpty(p.Value.Text) && Boolean.TryParse(p.Value.Text, out wOutBool) && wOutBool == true)).ToList();
            }

            if (wKeyList.Count <= 0)
            {
                MessageViewer.Show("No se encuentran modos de autenticación configurados con Value = true en el archivo de configuración. Por favor verifique.");
                return false;
            }

            cmdAuthMode.Properties.Items.Clear();

            //Por cada Key obtenida la agregamos al Combo de modos de autenticación
            foreach (Fwk.Configuration.Common.Key wItem in wKeyList)
            {
                wDescription = Fwk.UI.Common.HelperFunctions.Enumerations.GetDescription(Enum.Parse(typeof(AuthenticationModeEnum), wItem.Name));
                wImageComboBoxItem = new ImageComboBoxItem(wDescription, wItem.Name);
                cmdAuthMode.Properties.Items.Add(wImageComboBoxItem);

                if (Enum.Parse(typeof(AuthenticationModeEnum), wItem.Name).Equals(AuthenticationModeEnum.WindowsIntegrated))
                    _HasWindowsAuthenticationMode = true;
            }

            //Validamos si el combo tiene Modo de autenticación de Windows y cargamos los Dominios
            if (_HasWindowsAuthenticationMode)
            {
                cmdAuthMode.EditValue = Convert.ToInt32(AuthenticationModeEnum.WindowsIntegrated).ToString();
                LoadDomains();
            }
            else
            {
                cmdAuthMode.SelectedIndex = 0;
                cmbDominios.ItemIndex = 0;
            }

            return true;
        }
    
        private void LoadDomains()
        {
            //SecurityController wControllerfactory = _Controllerfactory.GetObject();
                

            //Obtenemos los dominios y cargamos el combo de dominios
            List<String> wDominiosList = SecurityController.SearchDomainsUrl();
            cmbDominios.Properties.DataSource = wDominiosList;
            cmbDominios.Refresh();

            //Validamos si la lista de dominios contiene el Dominio en el que está logueado el usuario de Windows. De ser así, elegimos ese valor.
            if (wDominiosList.Contains(Environment.UserDomainName))
                cmbDominios.EditValue = Environment.UserDomainName;
            else
                cmbDominios.ItemIndex = 0;
        }

        /// <summary>
        /// Método que se va a ejecutar al hacer click en el botón "Aceptar" o en "Cambiar Clave"
        /// </summary>
        /// <param name="pChangePassword">Parámetro que determina si se hizo click o no en Cambiar clave</param>
        /// <returns></returns>
        private bool AcceptForm(bool pChangePassword)
        {
            try
            {
                //Validamos si los ErrorProviders tienen error
                if (!dxErrorProvider1.HasErrors && ValidateValues())
                {
                    //Autenticamos el usuario
                    AuthenticateUser();

                    //Validamos si el usuario posee Roles y el InitAuthorizationFactory
                    if (!ValidateRoles() || !FormBaseInitAuthorizationFactory())
                        return false;

                    //Validamos si el usuario Debe cambiar el password o si presionó el botón "Cambiar Clave"
                    if (!ValidateChangePassword(pChangePassword))
                        return false;

                    //Si pasa todas las validaciones establecemos el DialogResult en OK y devolvemos true
                    this.DialogResult = DialogResult.OK;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Fwk.Exceptions.FunctionalException funcionalEx)
            {
                this.MessageViewer.Title = "Mensaje de seguridad";
                this.MessageViewer.Show(funcionalEx);
                return false;
            }

            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void AuthenticateUser()
        {
     
            
            //string wSiteName = Environment.GetEnvironmentVariable("USERDNSDOMAIN");
            String wDomainName = string.Empty;
            if(cmbDominios.Enabled)
              wDomainName = cmbDominios.EditValue == null ? null : cmbDominios.EditValue.ToString();

            ///FormBase.AuthenticateUser(txtUserName.Text, txtPassword.Text, _AuthenticationMode, wDomainName, _IsEnvironmentUser, wSiteName.ToString());
            FormBase.AuthenticateUser(txtUserName.Text, txtPassword.Text, _AuthenticationMode, wDomainName, _IsEnvironmentUser);
        }

        private bool ValidateValues()
        {
            //Si el password está habilitado lo validamos, de lo contrario sólo validamos el nombre de usuario
            if (txtPassword.Enabled == true)
                return (txtUserName.ValidateValue() & txtPassword.ValidateValue());
            else
                return txtUserName.ValidateValue();
        }

        private bool ValidateRoles()
        {
            //Validamos que el usuario tenga roles
            if (FormBase.IndentityUserInfo.Roles.Count() == 0)
            {
                this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Error;
                this.MessageViewer.MessageBoxButtons = MessageBoxButtons.OK;
                this.MessageViewer.Title = "Mensaje de seguridad";
                this.MessageViewer.Show("El usuario no posee roles asociados");

                return false;
            }

            return true;
        }

        private bool FormBaseInitAuthorizationFactory()
        {
            string wMsgError = string.Empty;

            FormBase.InitAuthorizationFactory(out wMsgError);

            if (!string.IsNullOrEmpty(wMsgError))
            {
                this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Error;
                this.MessageViewer.MessageBoxButtons = MessageBoxButtons.OK;
                this.MessageViewer.Title = "Mensaje de seguridad";
                this.MessageViewer.Show(wMsgError);

                return false;
            }

            return true;
        }

        private bool ValidateChangePassword(Boolean pChangePassword)
        {
            //Validamos si el usuario debe Cambiar el password
            if (FormBase.IndentityUserInfo.MustChangePassword.Value)
            {
                FRM_UserChangePassword wFrmChangePassword = new FRM_UserChangePassword();

                //Le pasamos al Formulario de Cambio de Password el nombre de usuario
                wFrmChangePassword.Populate(txtUserName.Text);

                //Si devuelve OK significa que pasó las validaciones de cambio de password, entonces devolvemos True.
                if (wFrmChangePassword.ShowDialog() == DialogResult.OK)
                    return true;
                else
                    return false;
            }

            //Si el usuario no debe cambiar el password, validamos que el usuario haya hecho click en "Cambiar clave".
            else
            {
                if (pChangePassword)
                {
                    FRM_UserChangePassword wFrmChangePassword = new FRM_UserChangePassword();

                    //Le pasamos al Formulario de Cambio de Password el nombre de usuario
                    wFrmChangePassword.Populate(txtUserName.Text);
                
                    if (wFrmChangePassword.ShowDialog() == DialogResult.OK)
                        return true;
                    else
                        return false;
                }
                //Como el usuario no está obligado a cambiar la clave, no nos importa si la cambio o no así que siempre devolvemos true.
                return true;
            }
        }

        /// <summary>
        /// Establecemos si debemos bloquear o desbloquear el campo de Contraseña
        /// </summary>
        private void EnableDisablePassword()
        {
            if (cmdAuthMode.EditValue == null || cmbDominios.EditValue == null)
                return;
            txtPassword.Enabled = false;
            if (cmdAuthMode.EditValue.Equals(Convert.ToInt32(AuthenticationModeEnum.WindowsIntegrated).ToString()))
            {
                //Si es modo de Windows, validamos si el usuario y el Dominio coinciden con el del Environment
                if (txtUserName.Text.Equals(Environment.UserName) && cmbDominios.EditValue.Equals(Environment.UserDomainName))
                {
                    txtPassword.Text = string.Empty;
                    _IsEnvironmentUser = true;
                }
                else
                {
                    _IsEnvironmentUser = false;
                }
            }
        }

        #endregion

        #region Events

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                using (WaitCursorHelper waitn = new WaitCursorHelper(this))
                {
                    //Validamos el valor que devuelve AcceptForm para ver si debemos cerrar o no el Formulario de Login
                    if (AcceptForm(false))
                    {
                        this.Close();
                    }
                }
            }
            else
                this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Al presionar Enter en el Password, realizamos la misma validación que en el click del botón "Aceptar" o "Cambiar Clave"
            if (e.KeyChar == (int)Keys.Enter)
            {
                //Validamos el valor que devuelve AcceptForm para ver si debemos cerrar o no el Formulario de Login
                if (AcceptForm(false))
                    this.Close();
            }
        }

        private void commonEnumComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdAuthMode.EditValue == null)
                return;

            //Seteamos la contraseña en blanco
            txtPassword.Text = string.Empty;

            //Validamos el tipo de Enumeración seleccionada
            switch ((AuthenticationModeEnum)Convert.ToInt32(cmdAuthMode.EditValue))
            {
                case AuthenticationModeEnum.WindowsIntegrated:
                    EnableDisableFieldsByAuthenticationMode(true);
                    txtUserName.Text = Environment.UserName;
                    txtUserName.Enabled = false;
                    _IsEnvironmentUser = true;
                    cmbDominios.Enabled = false;
                    EnableDisablePassword();
                    btnChangePassword.Enabled = false;
                    break;

                case AuthenticationModeEnum.Mixed:
                    EnableDisableFieldsByAuthenticationMode(true);
                    cmbDominios.Enabled = false;
                    txtPassword.Enabled = true;
                    btnChangePassword.Enabled = true;
                    break;
                case AuthenticationModeEnum.LDAP:
                    EnableDisableFieldsByAuthenticationMode(true);
                    cmbDominios.Enabled = true;
                    txtPassword.Enabled = true;
                    btnChangePassword.Enabled = false;
                    break;
                default:
                    MessageViewer.Show("El modo de autenticación seleccionado no se encuentra configurado aún.");
                    EnableDisableFieldsByAuthenticationMode(false);
                    txtUserName.Enabled = false;
                    txtPassword.Enabled = false;
                    cmbDominios.Enabled = false;
                    btnChangePassword.Enabled = false;
                    break;
            }

            //Seteamos en blanco los ErrorProviders 
            dxErrorProvider1.SetError(txtUserName, string.Empty);
            dxErrorProvider1.SetError(txtPassword, string.Empty);

            txtUserName.Focus();

            //Guardamos el Modo de autenticación seleccionado
            _AuthenticationMode = (AuthenticationModeEnum)Enum.Parse(typeof(AuthenticationModeEnum), cmdAuthMode.EditValue.ToString());
        }

        private void EnableDisableFieldsByAuthenticationMode(bool pValue)
        {
            txtUserName.Enabled = pValue;
            aceptCancelButtonBar1.AceptButtonEnabled = pValue;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            //Validamos si debemos habilitar o deshabilitar el Password
            EnableDisablePassword();
        }

        private void cmbDominios_EditValueChanged(object sender, EventArgs e)
        {
            //Validamos si debemos habilitar o deshabilitar el Password
            EnableDisablePassword();
        }


        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //Validamos el valor que devuelve AcceptForm para ver si debemos cerrar o no el Formulario de Login
            if (AcceptForm(true))
                this.Close();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                dxErrorProvider1.SetError(txtUserName, "Por favor ingrese el nombre de usuario");
                e.Cancel = true;
            }
            else
                dxErrorProvider1.SetError(txtUserName, string.Empty);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                dxErrorProvider1.SetError(txtPassword, "Por favor ingrese la contraseña");
                e.Cancel = true;
            }
            else
                dxErrorProvider1.SetError(txtPassword, string.Empty);
        }

        #endregion

    }
}
