using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controller;
using Fwk.Security.ISVC.SearchUsersByParam;
using Fwk.Security.Common;
using Fwk.UI.Controls;


namespace Fwk.UI.Security.Controls
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class UC_UserAdmin : UC_UserControlBase
    {
        #region Members
        const string NoChangedPwd = "......";
        Fwk.UI.Common.ActionTypes _Action;
        User _UsersBE;
        private RolList _UserRolList;
        #endregion

        #region Properties
        [Browsable(false)]
        public Fwk.UI.Controls.TextBox TextUserFirstName
        {
            get { return txtUserFirstName; }
            set { txtUserFirstName = value; }
        }

        [Browsable(false)]
        public Fwk.UI.Common.ActionTypes Action
        {
            get { return _Action; }
        }

        /// <summary>
        /// Login (Nombre de usuario del sistema) que se desea crear
        /// </summary>
        [Browsable(false)]
        public User UsersBE
        {
            get { return _UsersBE; }
        }
        #endregion

        public UC_UserAdmin()
        {
            InitializeComponent();
        }

        #region Validations

        void ValidateControls()
        {
            if (!txtUserFirstName.ValidateValue())
            {
                dxErrorProvider1.SetError(txtUserFirstName, txtUserFirstName.ErrorText);
                txtUserFirstName.Focus();
                return;
            }
            if (!txtUserName.ValidateValue())
            {
                dxErrorProvider1.SetError(txtUserName, txtUserName.ErrorText);
                txtUserName.Focus();
                return;
            }
            if (!txtUserLastName.ValidateValue())
            {
                dxErrorProvider1.SetError(txtUserLastName, txtUserLastName.ErrorText);
                txtUserLastName.Focus();
                return;
            }

            if (!txtEmail.ValidateValue())
            {
                dxErrorProvider1.SetError(txtEmail, txtEmail.ErrorText);
                txtEmail.Focus();
                return;
            }
            if (!txtPassword.ValidateValue())
            {
                dxErrorProvider1.SetError(txtPassword, txtPassword.ErrorText);
                txtPassword.Focus();
                return;
            }

        }

        private void txtUserFirstName_Validating(object sender, CancelEventArgs e)
        {
            ValidateText(txtUserFirstName);
        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateText(txtUserName);
        }

        private void txtUserLastName_Validating(object sender, CancelEventArgs e)
        {
            ValidateText(txtUserLastName);
        }


        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateText(txtEmail);
        }



        private void txtPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            //Si el Password No está en blanco validamos
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                //Validamos si son iguales Password y Confirmación
                if (!String.Equals(txtPassword.Text, txtPasswordConfirm.Text))
                {
                    dxErrorProvider1.SetError(txtPassword, string.Empty);

                    //Validamos si está en blanco la Confirmación
                    //if (!string.IsNullOrEmpty(txtPasswordConfirm.Text))
                    //{
                    //    txtPasswordConfirm.Text = string.Empty;
                    //}

                    ////Si está en blanco le damos el foco
                    //else
                    //{
                    //    txtPasswordConfirm.Focus();
                    //}

                    
                    //txtPasswordConfirm.Text = string.Empty;
                    dxErrorProvider1.SetError(txtPasswordConfirm, "La clave y la confirmación son diferentes");
                    e.Cancel = true;
                }

                //si son iguales seteamos los dos dxErrorprovider lo seteamos blanco
                else
                {
                    dxErrorProvider1.SetError(txtPassword, String.Empty);
                    dxErrorProvider1.SetError(txtPasswordConfirm, String.Empty);
                }
            }

            //Si el password está en Blanco seteamos el dxErrorProvider del Password y el de la Confirmación lo seteamos en blanco
            else
            {
                dxErrorProvider1.SetError(txtPassword, txtPassword.ErrorText);
                dxErrorProvider1.SetError(txtPasswordConfirm, String.Empty);
            }
        }


        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPasswordConfirm_Validating(sender, new CancelEventArgs());
        }

        void ValidateText(Fwk.UI.Controls.TextBox txt)
        {
            if (!txt.ValidateValue())
            {
                dxErrorProvider1.SetError(txt, txt.ErrorText);
                txt.Focus();
            }
            else
                dxErrorProvider1.SetError(txt, String.Empty);
        }
        #endregion


        private void btnAddRol_Click(object sender, EventArgs e)
        {
            using (FRM_RoleAssign frm = new FRM_RoleAssign())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    uC_RolesGrid1.Initialize();
                    uC_RolesGrid1.PopulatePreChecked(_UserRolList);
                }
            }
        }

        /// <summary>
        /// Limpia el contenido de los controles
        /// </summary>
        public bool CreateUser()
        {
            ValidateControls();
            bool wNotHasErrors = !dxErrorProvider1.HasErrors;
            if (wNotHasErrors)
                try
                {
                    FillUser(true);
                    SecurityController.CreateUser(_UsersBE, _UserRolList);
                }
                catch (Exception e)
                {
                    ExceptionViewer.Show(e);
                    wNotHasErrors = false;
                }
            //Si tiene errores retorna false
            return wNotHasErrors;
        }

        internal bool UpdateUser()
        {
            ValidateControls();
            bool wNotHasErrors = !dxErrorProvider1.HasErrors;
            if (wNotHasErrors)

                try
                {
                    FillUser(false);
                    SecurityController.UpdateUser(_UsersBE, _UserRolList);
                }
                catch (Exception e)
                {
                    ExceptionViewer.Show(e);
                    wNotHasErrors = false;
                }
            //Si tiene errores retorna false
            return wNotHasErrors;
        }


        /// <summary>
        /// Carga el user control con los datos del usuario.-
        /// </summary>
        /// <param name="pUsersBE"></param>
        /// <param name="pAction"></param>
        public void Populate(User pUsersBE, Fwk.UI.Common.ActionTypes pAction)
        {
            _Action = pAction;
            ClearControls();

            if (pAction == Fwk.UI.Common.ActionTypes.Edit)
            {
                Enable(true);
                txtUserName.Enabled = false;
                _UsersBE = pUsersBE;

                _UserRolList = SecurityController.GetAllRoles(_UsersBE.UserName);
                uC_RolesGrid1.Initialize();
                uC_RolesGrid1.PopulatePreChecked(_UserRolList);

            }

            if (pAction == Fwk.UI.Common.ActionTypes.Read)
            {
                Enable(false);
                uC_RolesGrid1.Initialize();
                uC_RolesGrid1.PopulatePreChecked(_UserRolList);
                _UsersBE = pUsersBE;
            }

            if (pAction == Fwk.UI.Common.ActionTypes.Create)
            {
                Enable(true);
                _UsersBE = new User();
                uC_RolesGrid1.Initialize();
                uC_RolesGrid1.UnchekAllRoles();
            }


            if (pAction == Fwk.UI.Common.ActionTypes.Edit || pAction == Fwk.UI.Common.ActionTypes.Read)
            {
                txtUserFirstName.Text = pUsersBE.FirstName;
                txtUserLastName.Text = pUsersBE.LastName;
                txtUserName.Text = pUsersBE.UserName;
                txtPassword.Text = NoChangedPwd;
                txtPasswordConfirm.Text = NoChangedPwd;
                //txtDNI.Text = pUsersBE.DNI;

                txtEmail.Text = pUsersBE.Email;
                chkApprove.Checked = pUsersBE.IsApproved;
                chkMustChangePassword.Checked = pUsersBE.MustChangePassword.Value;
                //TODO Revisar tema de aproved user
                if (pUsersBE.IsApproved)
                    chkActiveFlag.CheckState = CheckState.Checked;
                else
                    chkActiveFlag.CheckState = CheckState.Unchecked;
            }
        }


        /// <summary>
        /// Carga la clase userbe con los datos del formulario
        /// </summary>
        void FillUser(bool iscreate)
        {
            _UsersBE.FirstName = txtUserFirstName.Text;
            _UsersBE.LastName = txtUserLastName.Text;
            _UsersBE.UserName = txtUserName.Text;

            if (txtPassword.Text.Trim().Equals(NoChangedPwd))
                _UsersBE.Password = String.Empty;
            else
                _UsersBE.Password = txtPassword.Text;

            //_UsersBE.DNI = txtDNI.Text;
            _UsersBE.Email = txtEmail.Text;
            _UsersBE.IsApproved = chkApprove.Checked;
            //_UsersBE.ActiveFlag = chkActiveFlag.Checked;
            _UsersBE.ModifiedByUserId = Fwk.UI.Forms.FormBase.IndentityUserInfo.UserId;
            _UsersBE.ModifiedDate = System.DateTime.Now;
            _UsersBE.MustChangePassword = chkMustChangePassword.Checked;
            ///Si son distintos es por que hubo cambios

            if (iscreate)
            {
                _UserRolList = this.uC_RolesGrid1.CheckedRoles;
                return;
            }

            //Si es un Update verifico el cambio en roles
            if (RolesHasChanged())
                _UserRolList = this.uC_RolesGrid1.CheckedRoles;
            else
                _UserRolList = null;//Esto es para q el servicio no realize actualizacion de roles 
        }

        bool RolesHasChanged()
        {
            if (_UserRolList.Count != this.uC_RolesGrid1.CheckedRoles.Count)
                return true;

            foreach (Rol rol in _UserRolList)
            {
                //Si en la lista de chequeados no existe el rol del usuario
                if (!this.uC_RolesGrid1.CheckedRoles.Exists(r => r.RolName.Equals(rol.RolName)))
                    return true;
            }
            return false;
        }


        public void ClearControls()
        {
            txtUserFirstName.Text = String.Empty;
            txtUserLastName.Text = String.Empty;
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtPasswordConfirm.Text = String.Empty;
            txtDNI.Text = string.Empty;
            txtEmail.Text = String.Empty;
            chkApprove.Checked = false;
            chkActiveFlag.Checked = true;
            chkMustChangePassword.Checked = true;
            txtUserFirstName.Focus();
        }

        void Enable(bool enable)
        {
            txtUserFirstName.Enabled = enable;
            txtUserLastName.Enabled = enable;
            txtUserName.Enabled = enable;
            txtPassword.Enabled = enable;
            txtPasswordConfirm.Enabled = enable;
            txtEmail.Enabled = enable;
            txtDNI.Enabled = enable;
            chkApprove.Enabled = enable;
            chkActiveFlag.Enabled = enable;
            chkMustChangePassword.Enabled = enable;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (_Action == Fwk.UI.Common.ActionTypes.Edit)
                txtPassword.Text = string.Empty;
        }

    }
}
