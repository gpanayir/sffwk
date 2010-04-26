﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Fwk.Security;

namespace Fwk.Security.Admin.Controls
{
  
    public partial class RulesCheckControl : SecurityControlBase
    {


        public RulesCheckControl()
        {
            InitializeComponent();
        }

        private void authorizeUsingIdentityRoleRulesButton_Click(object sender, EventArgs e)
        {


            if (this.identityTextBox.Text.CompareTo(String.Empty) != 0 && this.rulesComboBox.SelectedIndex != -1)
            {
                string identity = this.identityTextBox.Text;
                string rule = ((Microsoft.Practices.EnterpriseLibrary.Security.Configuration.AuthorizationRuleData)
                    this.rulesComboBox.SelectedItem).Name;

                // Get the roles for the current user and create an IPrincipal
                string[] roles = Roles.GetRolesForUser(identity);
                IPrincipal principal = new GenericPrincipal(new GenericIdentity(identity), roles);



                Cursor = System.Windows.Forms.Cursors.WaitCursor;


                //if (ControlsFactory.ruleProvider != null)
                //{

                    this.DisplayAuthorizationResults(string.Format(Properties.Resources.IdentityRoleMessage, identity, String.Join(",", roles)));
                    bool wAuthorized = false;
                    // Try to authorize using selected rule
                    try
                    {
                        wAuthorized = ControlsFactory.Authorize(principal, rule);
                    }
                    catch (Exception ex)
                    {
                        if (string.IsNullOrEmpty(FwkMembership.GetRule(rule,frmAdmin.Provider.Name).expression.Trim()))
                        {
                            wAuthorized = false;

                            fwkMessageViewInfo.Show("Regla no contiene exoprecion o roles asociados");
                        }
                        else
                            fwkMessageViewInfo.Show(ex);
                    }

                    if (wAuthorized)
                    {

                        this.DisplayAuthorizationResults(string.Format(Properties.Resources.RuleResultTrueMessage, rule) + Environment.NewLine);
                    }
                    else
                    {
                        this.DisplayAuthorizationResults(string.Format(Properties.Resources.RuleResultFalseMessage, rule) + Environment.NewLine);
                    }


                //}
                Cursor = System.Windows.Forms.Cursors.Arrow;
            }
        }

        public override void Initialize()
        {
            // inicializo Fwk Authorization provider y cathcing security provider
            // ASP.NET Membership y Profile providers no se inicializan de esta manera.
            //this.ruleProvider = AuthorizationFactory.GetAuthorizationProvider("RuleProvider_Fwk");
            
            //this.cache = SecurityCacheFactory.GetSecurityCacheProvider("ProveedorAlmacenCaching");


            rulesComboBox.DataSource = FwkMembership.GetRulesList(Membership.ApplicationName);
        
        }




         void DisplayAuthorizationResults(string results)
        {
            this.authorizationResultsTextBox.Text += results + Environment.NewLine;

            this.authorizationResultsTextBox.SelectAll();
            this.authorizationResultsTextBox.ScrollToCaret();
        }
    }
}
