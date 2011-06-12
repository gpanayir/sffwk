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

namespace Fwk.Security.Admin.Controls
{
    public delegate void NewSecurityInfoCreatedHandler(object sender);

    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class UserAssingRoles : SecurityControlBase
    {
        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// 
        /// </summary>
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(UserAssingRoles).AssemblyQualifiedName;
            }
        }

        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        public UserAssingRoles()
        {
            InitializeComponent();
           
        }

        private void btnAsignarRoles_Click(object sender, EventArgs e)
        {

            if (usersGrid1.CurrentUser == null) return;
            RolList wRolList = new RolList();
            using (new WaitCursorHelper(this))
            {
                foreach (object obj in lstBoxRoles.CheckedItems)
                {
                    wRolList.Add((Rol)obj);
                }

                FwkMembership.CreateRolesToUser(wRolList, usersGrid1.CurrentUser.UserName,frmAdmin.Provider.Name);

                bindingSourceUserRole.DataSource = FwkMembership.GetRolesForUser(usersGrid1.CurrentUser.UserName, frmAdmin.Provider.Name);

                NewSecurityInfoCreatedHandler();
            }
        }



        public override void Initialize()
        {
            using (new WaitCursorHelper(this))
            {
                rolListBindingSource.DataSource = FwkMembership.GetAllRoles(frmAdmin.Provider.Name);
                lstBoxRoles.Refresh();
                usersGrid1.Initialize();
            }
        }




        private void usersGrid1_OnUserChange(User user, RolList roles)
        {
            bindingSourceUserRole.DataSource = roles;
                lblSelectedUser.Text = user.UserName;
        }

        private void UserAssingRoles_Load(object sender, EventArgs e)
        {
            usersGrid1.Initialize();
        }

        

        

    }
}
