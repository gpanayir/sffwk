using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controller;

using Fwk.UI.Controls;

namespace Fwk.UI.Security.Controls
{
    public partial class UC_UserChangePassword : UC_UserControlBase
    {
        #region Members
        
        private String _UserName;

        #endregion

        #region Properties

        public String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        #endregion

        #region Constructor

        public UC_UserChangePassword()
        {
            InitializeComponent();
        }

        #endregion

       

        private void UC_UserChangePassword_Load(object sender, EventArgs e)
        {
            txtOldPassword.Focus();
        }

        private void txtPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (!String.Equals(txtNewPassword.Text, txtPasswordConfirm.Text))
                dxErrorProvider1.SetError(txtPasswordConfirm, "La nueva contraseña y su confirmación no coinciden");
            else
                dxErrorProvider1.SetError(txtPasswordConfirm, "");
        }

    }
}
