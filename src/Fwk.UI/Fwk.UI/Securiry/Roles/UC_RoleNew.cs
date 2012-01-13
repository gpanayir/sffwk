using System;
using System.Windows.Forms;
using Fwk.Security.Common;
using Fwk.Bases.FrontEnd.Controls;
using Fwk.UI.Controller;
using System.ComponentModel;
using Fwk.UI.Controls;

namespace Fwk.UI.Security.Controls
{
    public partial class UC_RoleNew : UC_UserControlBase
    {
        bool _RoleExists = false;

        public bool RoleExists
        {
            get { return _RoleExists; }
            set { _RoleExists = value; }
        }

        public bool HasError
        {
            get { return dxErrorProvider1.HasErrors; }
        }


        [BrowsableAttribute(false)]
        public string RolName
        {
            get { return txtCreateRole.Text.Trim(); }
        }

        public UC_RoleNew()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea un nuevo role
        /// </summary>
        public void CreateNewRole()
        {
            using (new WaitCursorHelper(this))
            {
                try
                {
                    if (!txtCreateRole.ValidateValue())
                    {
                        dxErrorProvider1.SetError(txtCreateRole, txtCreateRole.ErrorText);
                        txtCreateRole.Focus();
                        return;
                    }

                    if (!String.IsNullOrEmpty(txtCreateRole.Text))
                    {
                        SecurityController.CreateRole(txtCreateRole.Text);

                        this.MessageViewer.Show(string.Format(Properties.Resources.security_UserCreatedMessage, txtCreateRole.Text));
                    }
                }

                catch (Exception ex)
                {
                    //Validamos que el rol no exista
                    //Debería ser implementado de otra manera.
                    if (ex.Message.Contains(string.Format("Role {0} already exists", txtCreateRole.Text)))
                    {
                        _RoleExists = true;
                        MessageViewer.Show(string.Format("El rol {0} ya existe", txtCreateRole.Text));
                    }
                    else
                    {
                        _RoleExists = false;
                        this.ExceptionViewer.Show(ex);
                    }
                }
            }
        }

        private void txtCreateRole_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtCreateRole.Text))
            {
                dxErrorProvider1.SetError(txtCreateRole, "Debe ingresar un nombre");
                txtCreateRole.Focus();
                e.Cancel = true;
            }
            else
            {
                dxErrorProvider1.SetError(txtCreateRole, string.Empty);
            }
        }

        private void UC_RoleNew_Load(object sender, EventArgs e)
        {

        }

        public void SetFocus()
        {
            txtCreateRole.Focus();
        }

    }
}
