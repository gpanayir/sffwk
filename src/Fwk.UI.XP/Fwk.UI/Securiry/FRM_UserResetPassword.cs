using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controls;
using Fwk.UI.Forms;
using Fwk.UI.Controller;

namespace Fwk.UI.Security.Controls
{
    public partial class FRM_UserResetPassword : FormDialogBase
    {
      
        private string _userName;

        public FRM_UserResetPassword(string pUserName)
        {
            InitializeComponent();
            _userName = pUserName;
        }
   

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    SecurityController.UserResetPassword(_userName, txtnewPassword.Text);
                }
                catch (Exception ex)
                {
                    this.MessageViewer.Show(ex);
                }
            }
            if (result == System.Windows.Forms.DialogResult.Cancel)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

   }
}
