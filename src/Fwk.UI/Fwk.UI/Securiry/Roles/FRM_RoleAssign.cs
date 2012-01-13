using System;
using Fwk.Security.Common;
using Fwk.UI.Forms;


namespace Fwk.UI.Security
{
    public partial class FRM_RoleAssign : FormDialogBase
    {
        public Rol SelectedRol
        {
            get { return uC_RoleMain1.SelectedRole; }
        }
        public FRM_RoleAssign()
        {
            InitializeComponent();
        }

       

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, System.Windows.Forms.DialogResult result)
        {
            this.DialogResult = result;
            this.Close();
        }

      
        
                        
    }
}
