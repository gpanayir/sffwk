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

namespace Fwk.UI.Security.Controls
{
    public partial class FRM_UserResetPassword : FormDialogBase
    {
        public FRM_UserResetPassword(string pUserName)
        {
            InitializeComponent();
            uC_Reset1.UserName = pUserName;
        }

        //protected override bool SaveForm()
        //{
        //    try
        //    {
        //        uC_Reset1.ResetPassword();
        //    }
        //    catch(Exception ex)
        //    {
        //        this.MessageViewer.Show(ex);
        //        return false;
        //    }
        //    return true;
        //}

        //protected override bool CancelForm()
        //{
        //    return true;
        //}

   }
}
