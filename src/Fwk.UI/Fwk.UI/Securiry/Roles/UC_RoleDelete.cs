using System;
using Fwk.UI.Controller;
using Fwk.UI.Controls;

namespace Fwk.UI.Security.Controls
{
    public partial class UC_RoleDelete : UC_UserControlBase
    {
        
        public UC_RoleDelete()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obtiene los roles y carga el combo
        /// </summary>
        public void Populate(String pRole)
        {
            // Carga el combo
            //SecurityController.RolesGetAll().ForEach(item => cmbRoles.Properties.Items.Add(item.RolName));
            txtRoles.Text = pRole;
        }


        public void DeleteRole()
        {
            SecurityController.DeleteRole(txtRoles.Text);
            Fwk.UI.Controls.SimpleMessageView.Show("El rol ha sido eliminado con éxito", "Pelsoft", System.Windows.Forms.MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Information);
        }

        private void txtRoles_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtRoles.Text))
                dxErrorProvider1.SetError(txtRoles, "El valor no es válido.");
            else
                dxErrorProvider1.SetError(txtRoles, "");
        }
        
    }
}
