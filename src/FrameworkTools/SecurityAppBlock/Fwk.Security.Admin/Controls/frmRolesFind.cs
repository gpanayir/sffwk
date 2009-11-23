using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;

namespace Fwk.Security.Admin.Controls
{
    public partial class frmRolesFind : Form
    {
        public frmRolesFind()
        {
            InitializeComponent();
            this.rolesGrid1.Initialize();
        }

        [Browsable(false)]
        public RolList SelectedRoleList
        {
            get
            {
                return this.rolesGrid1.SelectedRoleList;
            }

        }

      
        private void brnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }
    }
}
