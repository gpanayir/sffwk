using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using Fwk.Security;
using System.Web.Security;
using System.Web.Profile;

namespace SecurityAppBlock.Admin.Controls
{
    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class UserAdminControl : UserControl
    {
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        public UserAdminControl()
        {
            InitializeComponent();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {

            using (new WaitCursorHelper(this))
            {
                try
                {
                    FwkMembership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text);
                    fwkMessageViewInfo.Show(String.Format(Properties.Resources.UserCreatedMessage, txtUserName.Text));
                    this.Init();
                    NewSecurityInfoCreatedHandler();
                }
                catch (Exception ex)
                {
                    fwkMessageViewInfo.Show(ex);
                }

            }
        }

        internal void Init()
        {
            using (new WaitCursorHelper(this))
            {
                userByAppBindingSource.DataSource = FwkMembership.GetAllUsers();
                bindingSourceRoles1.DataSource = FwkMembership.GetAllRoles();
                FillRolesByUser();
            }
        }

      

        private void grdUsers1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdUsers1.CurrentRow == null)
            {
                btnRemove.Enabled = false;
                btnUpdate.Enabled = false;
                return;
            }
            User wUser = ((User)grdUsers1.CurrentRow.DataBoundItem);
            lblRolesByUser.Text = "User roles " + wUser.UserName;
            txtEmail.Text = wUser.Email;
            txtUserName.Text = wUser.UserName;
            btnRemove.Enabled = true;
            btnUpdate.Enabled = true;

            

            using (new WaitCursorHelper(this))
            {
                grdRoles1.DataSource = FwkMembership.GetRolesForUser(wUser.UserName);
            }
        }

        void FillRolesByUser()
        {
            if (grdUsers1.CurrentRow == null) return;
            String wUserName = ((User)grdUsers1.CurrentRow.DataBoundItem).UserName;
            lblRolesByUser.Text = "User roles " + wUserName;
            using (new WaitCursorHelper(this))
            {
                grdRoles1.DataSource = FwkMembership.GetRolesForUser(wUserName);
            }
        }

        private void btnUsersList_Click(object sender, EventArgs e)
        {
            userByAppBindingSource.DataSource = FwkMembership.GetAllUsers();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            String wUserName = ((User)grdUsers1.CurrentRow.DataBoundItem).UserName;
            FwkMembership.DeleteUser(wUserName);

            lblRolesByUser.Text = string.Empty;
            txtEmail.Text = String.Empty;
            txtUserName.Text = String.Empty;
            btnRemove.Enabled = false;
            btnUpdate.Enabled = false;
            userByAppBindingSource.DataSource = FwkMembership.GetAllUsers();

        }

        private void grdUsers1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdUsers1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            User wUser = ((User)grdUsers1.CurrentRow.DataBoundItem);
            

            User wpdatedUser = new User(txtUserName.Text);
            wpdatedUser.Email = txtEmail.Text;
            FwkMembership.UpdateUser(wpdatedUser,wUser.UserName);

            userByAppBindingSource.DataSource = FwkMembership.GetAllUsers();
        }

    

    }
}
