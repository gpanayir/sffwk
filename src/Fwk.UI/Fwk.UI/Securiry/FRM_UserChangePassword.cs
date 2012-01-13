using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Fwk.UI.Forms;

namespace Fwk.UI.Security.Controls
{
    public partial class FRM_UserChangePassword : FormDialogBase
    {
        public FRM_UserChangePassword()
        {
            InitializeComponent();
        }
        //TODO: arreglar canel acept
        //protected override bool SaveForm()
        //{
        //    try
        //    {
        //        //Validamos si se pudo cambiar o no el password
        //        if (uC_UserChangePassword1.ChangePassword())
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionViewer.Show(ex);
        //        return false;
        //    }
        //}

        public void Populate(string pUserName)
        {
            //Seteamos la property UserName del UserControl
            uC_UserChangePassword1.UserName = pUserName;
        }
        //TODO: arreglar canel acept
        //protected override bool CancelForm()
        //{
        //    this.Close();
        //    return true;
        //}

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            //if (result == DialogResult.OK)
            //{
                //TODO: arreglar canel acept
                //if (this.SaveForm())
                //{
                //    //Si se pudieron realizar los cambios devolvemos un Dialog Result = OK
                //    this.DialogResult = result;
                //    this.Close();
                //}
            //}
            //else
                //TODO: arreglar canel acept CancelForm();
        }

    }
}
