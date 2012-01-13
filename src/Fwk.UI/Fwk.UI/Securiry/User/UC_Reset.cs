using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Common;
using Fwk.UI.Controls;

namespace Fwk.UI.Security.Controls
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class UC_Reset : UC_UserControlBase
    {
        private string _userName;

        #region [Properties]
        public String UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        #endregion

        public UC_Reset()
        {
            InitializeComponent();
        }

        public void ResetPassword()
        {
            //TODO: VEr eso ..esta usando sin servicios
            //string pass = Fwk.Security.FwkMembership.ResetUserPassword(_userName);
            //Fwk.Security.FwkMembership.ChangeUserPassword(_userName, pass, txtnewPassword.Text);
        }
    }
}
