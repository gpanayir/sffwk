using System;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;

using Fwk.UI.Common;
using Fwk.UI.Forms;

namespace Fwk.UI.Security
{
    public partial class FRM_RoleDelete : FormDialogBase
    {
        public FRM_RoleDelete()
        {
            InitializeComponent();
        }


        internal void Populate(string pRoleName)
        {
            uC_RoleDelete1.Populate(pRoleName);
        }

       void SaveForm()
        {
            try
            {
                using (new WaitCursorHelper(this))
                {
                    uC_RoleDelete1.DeleteRole();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageViewer.Show(ex);
            }
        }

       

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                SaveForm();
                this.DialogResult = result;
            }
            else
            {
                this.DialogResult = result;
                this.Close();
            }
        }

       
   
    }
}
