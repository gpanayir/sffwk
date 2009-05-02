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

namespace SecurityAppBlock.Admin
{
    public partial class frmAdmin : Form
    {

        public frmAdmin()
        {
            InitializeComponent();
           

           

            this.assingRulesControl1.Init();
            this.assingRoles1.Init();
            this.rolesAdmin1.Init();
            this.createRulesControl1.Init();
            this.userAdmminControl1.Init();
        }

        


        private void button2_Click(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser();
        }

        private void assingRoles1_NewSecurityInfoCreated(object sender)
        {
            this.assingRulesControl1.Init();
            this.createRulesControl1.Init();
            this.userAdmminControl1.Init();
        }

        private void rolesAdmin1_NewSecurityInfoCreated(object sender)
        {
            this.assingRulesControl1.Init();
            this.assingRoles1.Init();
            
            this.createRulesControl1.Init();
            this.userAdmminControl1.Init();
        }

        private void userAdmminControl1_NewSecurityInfoCreated(object sender)
        {
            this.assingRulesControl1.Init();
            this.assingRoles1.Init();
            this.createRulesControl1.Init();
            this.rolesAdmin1.Init();
            
        }

        private void createRulesControl1_NewSecurityInfoCreated(object sender)
        {
           
        }

        private void assingRulesControl1_NewSecurityInfoCreated(object sender)
        {
       
        }




       

       
        

       
    }
}
