using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using Fwk.Security;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Web.Security;

namespace Fwk.Security.Admin.Controls
{
    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class AssingRulesControl : SecurityControlBase
    {
        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// 
        /// </summary>
        public override string AssemblyConditionControl
        {
            get
            {
                return typeof(AssingRulesControl).AssemblyQualifiedName;
            }
        }
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }
        //private ISecurityCacheProvider cache;	// Security cache to handle tokens
        private IAuthorizationProvider ruleProvider;
        Rol _SelectedRol = null;
        User _SelectedUser = null;

        UserList _ExcludeUserList = new UserList();
        RolList _AssignedRolList = new RolList();
        public AssingRulesControl()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            txtRuleName.Focus();
            using (new WaitCursorHelper(this))
            {
                userBindingSource.DataSource = FwkMembership.GetAllUsers();
                rolBindingSource.DataSource = FwkMembership.GetAllRoles();
                
                this.ruleProvider = AuthorizationFactory.GetAuthorizationProvider("RuleProvider_Fwk");
            }
        }


        private void grdAllRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAllRoles.CurrentRow == null) return;
            _SelectedRol = ((Rol)grdAllRoles.CurrentRow.DataBoundItem);

        }

        private void btnAddRol_Click(object sender, EventArgs e)
        {
            if (_SelectedRol != null)
            {
                var s = from rol in _AssignedRolList where rol.RolName == _SelectedRol.RolName select rol;
                if (!s.Any())
                {
                    _AssignedRolList.Add(new Rol(_SelectedRol.RolName));
   
                    grdAssignedRoles.DataSource = null;
                    grdAssignedRoles.DataSource = _AssignedRolList;
                }

            }
            BuildRulExpression();
            NewSecurityInfoCreatedHandler();
        }

        private void grdAllUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAllUser.CurrentRow == null) return;
            _SelectedUser = ((User)grdAllUser.CurrentRow.DataBoundItem);
        }

        private void btnAddExcludedUser_Click(object sender, EventArgs e)
        {
           
        }

        void BuildRulExpression()
        {
            StringBuilder wexpression = new StringBuilder();

            #region included roles
            if (_AssignedRolList.Count != 0)
            {
                wexpression.Append("(");
                foreach (Rol rol in _AssignedRolList)
                {
                    wexpression.Append("R:");
                    wexpression.Append(rol.RolName);
                    wexpression.AppendLine(" OR ");
                }
                wexpression.Remove(wexpression.Length - 5, 5);
                wexpression.Append(")");
            }
            #endregion

            #region Excluded users
            if (_ExcludeUserList.Count != 0)
            {
                if (_AssignedRolList.Count != 0)
                    wexpression.Append(" AND ");

                wexpression.Append("NOT (");
                foreach (User user in _ExcludeUserList)
                {
                    wexpression.Append("I:");
                    wexpression.Append(user.UserName);
                    wexpression.AppendLine(" OR ");
                }
                wexpression.Remove(wexpression.Length - 5, 5);
                wexpression.Append(")");
            }
            #endregion

            txtRuleExpression.Text = wexpression.ToString();
        }

       
       



        private void btnCreateRule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRuleName.Text))
            {
                errorProvider1.SetError(txtRuleName, "Rule name must not be empty");
                return;
            }
            if (FwkMembership.ExistRule(txtRuleName.Text.Trim(), Membership.ApplicationName))
            {
                fwkMessageViewInfo.Show(String.Format("The rule {0} exist", txtRuleName.Text));
                txtRuleName.Focus();
                return;
            }

            try
            {
                FwkAuthorizationRule wFwkAuthorizationRule = new FwkAuthorizationRule();
                wFwkAuthorizationRule.Name = txtRuleName.Text;
                wFwkAuthorizationRule.Expression = txtRuleExpression.Text;
                FwkMembership.CreateRules(wFwkAuthorizationRule, Membership.ApplicationName);
                fwkMessageViewInfo.Show(String.Format(Properties.Resources.RuleCreatedMessage, txtRuleName.Text));
                NewSecurityInfoCreatedHandler();
            }
            catch (Exception ex)
            {
                fwkMessageViewInfo.Show(ex);
            }

        }

        private void textRuleName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRuleName.Text))
            {
                errorProvider1.SetError(txtRuleName, "Rule name must not be empty");
            }
            else
            {
                errorProvider1.SetError(txtRuleName, string.Empty);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_SelectedUser != null)
            {
                var s = from usr in _ExcludeUserList where usr.UserName == _SelectedUser.UserName select usr;
                if (!s.Any())
                {
                    _ExcludeUserList.Add(new User(_SelectedUser.UserName));

                    grdUserExcluded.DataSource = null;
                    grdUserExcluded.DataSource = _ExcludeUserList;
                }

            }

            BuildRulExpression();
        }

       
    }
}
