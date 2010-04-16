using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using System.Web.Security;

namespace Fwk.Security.Admin.Controls
{
    public partial class UserCretate : SecurityControlBase
    {
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void OnNewSecurityInfoCreated()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// </summary>
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(UserAssingRoles).AssemblyQualifiedName;
            }
        }
        public UserCretate()
        {
            InitializeComponent();
        }
        public override void  Initialize()
        {}

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            string wMessage = string.Empty;
            using (new WaitCursorHelper(this))
            {
                try
                {
                    MembershipCreateStatus wStatus = MembershipCreateStatus.Success;
                    if (string.IsNullOrEmpty(txtAnsw.Text) && string.IsNullOrEmpty(txtQuest.Text))
                        FwkMembership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text);
                    else
                        FwkMembership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text, txtQuest.Text, txtAnsw.Text, chkApproved.Checked, out wStatus, frmAdmin.Provider.Name);

                    switch (wStatus)
                    {
                        case MembershipCreateStatus.InvalidEmail:
                            {
                                wMessage = "Invalid Email";
                                break;
                            }

                        case MembershipCreateStatus.InvalidPassword:
                            {
                                wMessage = "Invalid Password";
                                break;
                            }
                        case MembershipCreateStatus.InvalidQuestion:
                            {
                                wMessage = "Invalid Question";
                                break;
                            }
                        case MembershipCreateStatus.InvalidUserName:
                            {
                                wMessage = "Invalid Username";
                                break;
                            }
                        case MembershipCreateStatus.DuplicateEmail:
                            {
                                wMessage = "Duplicate Email";
                                break;
                            }
                        case MembershipCreateStatus.Success:
                            {
                                wMessage = String.Format(Properties.Resources.UserCreatedMessage, txtUserName.Text);
                                break;
                            }

                    }
                    MessageViewInfo.Show(wMessage);
                    this.Initialize();
                    OnNewSecurityInfoCreated();
                }
                catch (Exception ex)
                {
                    MessageViewInfo.Show(ex);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (FwkMembership.ValidateUser(txtUserName.Text, txtPassword.Text, frmAdmin.Provider.Name))
            {
                MessageViewInfo.Show("Log sussefully");
            }
            else
            {
                MessageViewInfo.Show("Log not sussefully");
            }
        }
    }
}
