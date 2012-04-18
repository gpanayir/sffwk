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
    public partial class FRM_AuthenticationForm_ASPNet : FormBase
    {
        #region Members
        //static SingletonFactory<SecurityController> _Controllerfactory = new SingletonFactory<SecurityController>();
        

        public string Password
        {
            get { return txtPassword.Text; }
            
        }
        public PictureBox Auth_Picture
        {
            get { return this.imgTitle; }
            set { this.imgTitle= value; }
        }
        public string Auth_Title_Text
        {
            get { return this.lbllTitle.Text; }
            set { this.lbllTitle.Text = value; }
        }
        public Font Auth_Title_Font
        {
            get { return this.lbllTitle.Font ; }
            set { this.lbllTitle.Font = value; }
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
       
 

        #endregion

        #region Constructor
        
        public FRM_AuthenticationForm_ASPNet()
        {
            InitializeComponent();
        }
        public FRM_AuthenticationForm_ASPNet(string securityProvider)
        {
            SecurityController.WrapperSecurityProvider = securityProvider;
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
                this.MessageViewer.Title = "Mensaje de seguridad";
                this.ExceptionViewer.Show(ex);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void AuthenticateUser()
        {
            FormBase.AuthenticateUser(txtUserName.Text, txtPassword.Text, AuthenticationModeEnum.ASPNETMemberShips, string.Empty, false);
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

        /// <summary>
        /// Llama al formulario de cambio e clave si es necesario
        /// </summary>
        /// <param name="pChangePassword">India que si o si se deba cambiar</param>
        /// <returns></returns>
        private bool ValidateChangePassword(Boolean pChangePassword)
        {
            //Validamos si el usuario debe Cambiar el password
            //Si el usuario no debe cambiar el password, validamos que el usuario haya hecho click en "Cambiar clave". pChangePassword
            if (FormBase.IndentityUserInfo.MustChangePassword.Value || pChangePassword)
               return changepwd(txtUserName.Text);

            //Como el usuario no está obligado a cambiar la clave, no nos importa si la cambio o no así que siempre devolvemos true.
            return true;
        }

        /// <summary>
        /// Llama al formulario de cambio e clave
        /// </summary>
        /// <param name="userName">Nombre de usuario a mostrar</param>
        /// <returns></returns>
        bool changepwd(string userName)
        {
            using (FRM_UserChangePassword wFrmChangePassword = new FRM_UserChangePassword())
            {
                //Le pasamos al Formulario de Cambio de Password el nombre de usuario
                wFrmChangePassword.Populate(userName);
                //Si devuelve OK significa que pasó las validaciones de cambio de password, entonces devolvemos True.
                if (wFrmChangePassword.ShowDialog() == DialogResult.OK)
                    return true;
                else
                    return false;
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
                //Validamos el valor que devuelve AcceptForm para ver si debemos cerrar o no el Formulario de Login
                if (AcceptForm(false))
                {
                    this.Close();
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


        private void EnableDisableFieldsByAuthenticationMode(bool pValue)
        {
            txtUserName.Enabled = pValue;
            uC_AceptCancelButtonBar1.AceptButtonEnabled = pValue;
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
