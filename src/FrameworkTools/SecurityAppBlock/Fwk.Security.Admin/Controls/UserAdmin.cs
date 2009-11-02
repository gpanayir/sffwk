﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using Fwk.Security;
using System.Web.Security;
using System.Web.Profile;

namespace Fwk.Security.Admin.Controls
{
    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class UserAdmin : SecurityControlBase
    {  

        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(UserAdmin).AssemblyQualifiedName;
            }
        }
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        public UserAdmin()
        {
            InitializeComponent();
        }

       
        public override void Initialize()
        {
            using (new WaitCursorHelper(this))
            {
                usersGrid1.Initialize();
                bindingSourceRoles1.DataSource = FwkMembership.GetAllRoles();
                FillRolesByUser();
            }
        }





        void FillRolesByUser()
        {
            if (usersGrid1.CurrentUser == null) return;

            lblRolesByUser.Text = "User roles " + usersGrid1.CurrentUser.UserName;

        }

        private void btnUsersList_Click(object sender, EventArgs e)
        {
            
            usersGrid1.Initialize();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (usersGrid1.CurrentUser == null)
            {
                btnRemove.Enabled = false;
                btnUpdate.Enabled = false;
                return;
            }
            String wUserName = usersGrid1.CurrentUser.UserName;
            


            try
            {
                FwkMembership.DeleteUser(wUserName);
                MessageViewInfo.Show("User was successfully removed");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }


            lblRolesByUser.Text = string.Empty;
            txtEmail.Text = String.Empty;
            txtUserName.Text = String.Empty;
            btnRemove.Enabled = false;
            btnUpdate.Enabled = false;
            usersGrid1.Initialize();

        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            User wUser = usersGrid1.CurrentUser;
            

            User wpdatedUser = new User(txtUserName.Text);
            wpdatedUser.Email = txtEmail.Text;
            wpdatedUser.Comment = txtComments.Text;
            wpdatedUser.IsApproved = chkApproved.Checked;

            wpdatedUser.AnswerPassword = txtAnsw.Text;
            wpdatedUser.QuestionPassword = txtQuest.Text;

            try
            {
                FwkMembership.UpdateUser(wpdatedUser, wUser.UserName);
                MessageViewInfo.Show("User was successfully updated");
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private void usersGrid1_OnUserChange(User user, RolList roles)
        {
            if (usersGrid1.CurrentUser == null)
            {
                btnRemove.Enabled = false;
                btnUpdate.Enabled = false;
                return;
            }

            lblRolesByUser.Text = "User roles " + usersGrid1.CurrentUser.UserName;
            txtEmail.Text = usersGrid1.CurrentUser.Email;
            txtUserName.Text = usersGrid1.CurrentUser.UserName;
            txtQuest.Text = usersGrid1.CurrentUser.QuestionPassword;
            txtAnsw.Text = usersGrid1.CurrentUser.AnswerPassword;
            chkApproved.Checked = usersGrid1.CurrentUser.IsApproved;
            txtComments.Text = usersGrid1.CurrentUser.Comment;
            btnRemove.Enabled = true;
            btnUpdate.Enabled = true;



            using (new WaitCursorHelper(this))
            {
                grdRoles1.DataSource = roles;
            }
        }

    

    }
}
