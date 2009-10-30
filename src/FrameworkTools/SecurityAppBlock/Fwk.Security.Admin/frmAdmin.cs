using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Web.Security;
using Fwk.Security.Common;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Security.Principal;
using Fwk.Bases.FrontEnd.Controls;
using Fwk.Security;
using Fwk.Security.Admin.Controls;

namespace Fwk.Security.Admin
{
    public partial class frmAdmin : XtraForm
    {

        public frmAdmin()
        {
            InitializeComponent();
        

         
        }

        


        private void button2_Click(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser();
        }

       

   

    
        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ControlsFactory.Show(e.Link, this.panelControl1);
        }
       

       
        

       
    }
}
