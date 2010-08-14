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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Fwk.Security.Admin.Controls
{
    [DefaultEvent("NewSecurityInfoCreated")]
    public partial class RulesAssingControl : SecurityControlBase
    {
        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// 
        /// </summary>
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(RulesAssingControl).AssemblyQualifiedName;
            }
        }
        public event NewSecurityInfoCreatedHandler NewSecurityInfoCreated;
        protected void NewSecurityInfoCreatedHandler()
        {
            if (NewSecurityInfoCreated != null)
                NewSecurityInfoCreated(this);
        }

        Rol _SelectedRol = null;
        User _SelectedUser = null;

        UserList _ExcludeUserList = new UserList();
        RolList _AssignedRolList = new RolList();

        List<Rol> selectedRoles = new List<Rol>();
        public RulesAssingControl()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            txtRuleName.Focus();
            using (new WaitCursorHelper(this))
            {
                try
                {
                    userBindingSource.DataSource = FwkMembership.GetAllUsers(frmAdmin.Provider.Name);
                    rolBindingSource.DataSource = FwkMembership.GetAllRoles(frmAdmin.Provider.Name);

                    if (userBindingSource.Count == 0) throw new Exception(string .Concat("La aplicaión ", frmAdmin.Provider.ApplicationName, " no contiene usuarios.-"));
                    if (rolBindingSource.Count == 0) throw new Exception(string .Concat("La aplicaión ", frmAdmin.Provider.ApplicationName, " no contiene roles.-"));
                }
                catch (Exception es)
                {
             
                    throw es;
                }

            }
        }


        private void grdAllRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAllRoles.CurrentRow == null) return;
            _SelectedRol = ((Rol)grdAllRoles.CurrentRow.DataBoundItem);

        }

        private void btnAddRol_Click(object sender, EventArgs e)
        {
            FillSelectedRoles();
            foreach (Rol selectedRol in selectedRoles)
            {

                if (!_AssignedRolList.Any<Rol>(rol => rol.RolName.Equals(selectedRol.RolName, StringComparison.OrdinalIgnoreCase)))
                {
                    _AssignedRolList.Add(new Rol(selectedRol.RolName));

                    grdAssignedRoles.DataSource = null;
                    grdAssignedRoles.DataSource = _AssignedRolList;
                }
            }
            txtRuleExpression.Text = FwkMembership.BuildRuleExpression(_AssignedRolList, _ExcludeUserList);
            NewSecurityInfoCreatedHandler();
        }
        
        void FillSelectedRoles()
        {
            selectedRoles.Clear();
            foreach (DataGridViewRow row in grdAllRoles.SelectedRows)
            {
                selectedRoles.Add(((Rol)row.DataBoundItem));
            }

        }
        private void grdAllUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAllUser.CurrentRow == null) return;
            _SelectedUser = ((User)grdAllUser.CurrentRow.DataBoundItem);
        }

        private void btnAddExcludedUser_Click(object sender, EventArgs e)
        {
           
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
                MessageViewInfo.Show(String.Format("The rule {0} exist", txtRuleName.Text));
                txtRuleName.Focus();
                return;
            }

            try
            {
                FwkAuthorizationRule wFwkAuthorizationRule = new FwkAuthorizationRule();
                wFwkAuthorizationRule.Name = txtRuleName.Text;
                wFwkAuthorizationRule.Expression = txtRuleExpression.Text;
                FwkMembership.CreateRule(wFwkAuthorizationRule, Membership.ApplicationName);
                MessageViewInfo.Show(String.Format(Properties.Resources.RuleCreatedMessage, txtRuleName.Text));
                NewSecurityInfoCreatedHandler();
            }
            catch (Exception ex)
            {
                MessageViewInfo.Show(ex);
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

            txtRuleExpression.Text = FwkMembership.BuildRuleExpression(_AssignedRolList, _ExcludeUserList);
        }

        private void removeSelectedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            foreach (DataGridViewRow row in grdAssignedRoles.SelectedRows)
            {

                _AssignedRolList.Remove(((Rol)row.DataBoundItem));

          
            }
            grdAssignedRoles.DataSource = null;
            grdAssignedRoles.DataSource = _AssignedRolList;
            txtRuleExpression.Text = FwkMembership.BuildRuleExpression(_AssignedRolList, _ExcludeUserList);
        }

        private void grdAssignedRoles_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void grdAllRoles_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void grdUserExcluded_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
       
    }
}
