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
using Fwk.Bases.FrontEnd.Controls;

namespace Fwk.Security.Admin.Controls
{
    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class CreateRoles : SecurityControlBase
    {

        public override string AssemblyConditionControl
        {
            get
            {
                return typeof(CreateRoles).AssemblyQualifiedName;
            }
        }
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        public CreateRoles()
        {
            InitializeComponent();
        }

        private void btnCreateNewRol_Click(object sender, EventArgs e)
        {
            using (new WaitCursorHelper(this))
            {
                try
                {
                    FwkMembership.CreateRole(txtRolName.Text);

                    fwkMessageViewInfo.Show(string.Format(Properties.Resources.RolCreatedMessage, txtRolName.Text));
                    Initialize();
                    NewSecurityInfoCreatedHandler();
                }
                catch (Exception ex)
                {
                    FwkMessageView.Show(ex, "Rol creation  ", System.Windows.Forms.MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                }
            }
        }
        public override void Initialize()
        {
            using (new WaitCursorHelper(this))
            {
                rolListBindingSource.DataSource = FwkMembership.GetAllRoles();
                grdRoles.Refresh();
            }
        }

        private void grdRoles2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdRoles.CurrentRow == null) return;
            
            using (new WaitCursorHelper(this))
            {
                grdUsers.DataSource = FwkMembership.GetUsersDetailedInRole(((Rol)grdRoles.CurrentRow.DataBoundItem).RolName);
                grdUsers.Refresh();
            }
        }
    }
}
