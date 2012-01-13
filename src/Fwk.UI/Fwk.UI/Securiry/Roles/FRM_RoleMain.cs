using System;

using Fwk.Security.Common;
using System.ComponentModel;
using Fwk.UI.Forms;

namespace Fwk.UI.Security
{
    public partial class FRM_RoleMain : FormMDIChildBase
    {
        #region Members
        [Browsable(false)]
        public RolList SelectedRoles
        {
            get
            {
                return uC_RoleMain1.SelectedRoles;
            }
        }

        [Browsable(false)]
        public RolList CheckedRoles
        {
            get
            {
                return uC_RoleMain1.CheckedRoles;
            }

        }

        [Browsable(false)]
        public RolList AllRoles
        {
            get
            {
                return uC_RoleMain1.AllRoles;
            }
        }

        [Browsable(false)]
        public Rol SelectedRol
        {
            get{return uC_RoleMain1.SelectedRole;}
        }
        #endregion

        public FRM_RoleMain()
        {
            InitializeComponent();
        }

        private void uC_RoleMain1_Load(object sender, EventArgs e)
        {
            
        }

    }
}
