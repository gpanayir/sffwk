using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.Security.Common;

namespace Fwk.Security.Admin.Controls
{
    public partial class frmChangePwd : DevExpress.XtraEditors.XtraForm
    {
        User _User;

        public frmChangePwd(User pUser)
        {

            InitializeComponent();

            _User = pUser;
            lblUser.Text += pUser.UserName;
            
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {
            try
            {
                string strNew = FwkMembership.ResetUserPassword(_User.UserName);
                if (FwkMembership.ChangeUserPassword(_User.UserName, strNew, txtPassword.Text.Trim()))

                    this.DialogResult = DialogResult.OK;
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    exceptionViewComponent1.Show(new Exception("Contraseña de usuario anterior no válida"));
                    
                }
                
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                exceptionViewComponent1.Show(ex);
               
                
            }
        
           this.Close();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }
    }
}