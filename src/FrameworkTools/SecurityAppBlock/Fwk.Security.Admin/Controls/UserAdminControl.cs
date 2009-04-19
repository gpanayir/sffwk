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
            if (grdUsers1.CurrentRow == null) return;
            String wUserName = ((User)grdUsers1.CurrentRow.DataBoundItem).UserName;
            lblRolesByUser.Text = "User roles " + wUserName;
            using (new WaitCursorHelper(this))
            {
                grdRoles1.DataSource = FwkMembership.GetRolesForUser(wUserName);
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

    

    }
}
