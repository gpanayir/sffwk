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
using DevExpress.XtraEditors.Controls;

namespace SecurityAppBlock.Admin.Controls
{
    public delegate void NewSecurityInfoCreatedHandler(object sender);

    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class AssingRoles : UserControl
    {
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        public AssingRoles()
        {
            InitializeComponent();
            using (new WaitCursorHelper(this))
            {


            }
        }

        private void btnAsignarRoles_Click(object sender, EventArgs e)
        {

            User wUserByApp = null;
            RolList wRolList = new RolList();
            using (new WaitCursorHelper(this))
            {
                if (grdUsers.CurrentRow != null)
                    wUserByApp = (User)grdUsers.CurrentRow.DataBoundItem;



                foreach (object obj in lstBoxRoles.CheckedItems)
                {
                    wRolList.Add((Rol)obj);
                }

                FwkMembership.CreateRolesToUser(wRolList, wUserByApp.UserName);

                bindingSourceUserRole.DataSource = FwkMembership.GetRolesForUser(wUserByApp.UserName);
                NewSecurityInfoCreatedHandler();
            }
        }



        internal void Init()
        {
            using (new WaitCursorHelper(this))
            {
                userByAppBindingSource.DataSource = FwkMembership.GetAllUsers();
                rolListBindingSource.DataSource = FwkMembership.GetAllRoles();

            }
        }

        private void grdUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdUsers.CurrentRow == null) return;
            User wUser = ((User)grdUsers.CurrentRow.DataBoundItem);

            using (new WaitCursorHelper(this))
            {
               
                bindingSourceUserRole.DataSource = FwkMembership.GetRolesForUser(wUser.UserName);
                lblSelectedUser.Text =  wUser.UserName;

            }
        }

        private void grdUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
