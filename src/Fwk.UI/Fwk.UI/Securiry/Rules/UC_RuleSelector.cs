using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Fwk.UI.Controls;

namespace Fwk.UI.Security.Controls
{
    [DefaultEvent("OnSelectRule")]
    public partial class UC_RuleSelector : UC_UserControlBase
    {
        public event System.EventHandler OnSelectRule;
        private AuthorizationRuleData _SelectedRule;
        public static List<AuthorizationRuleData> Rules;

        [Browsable(false)]
        public AuthorizationRuleData SelectedRule
        {
            get { return _SelectedRule; }
            set { _SelectedRule = value; }
        }
        public UC_RuleSelector()
        {
            InitializeComponent();
        }
        public void populate()
        {

            authorizationRuleDataBindingSource.DataSource = Rules;
            grdRules.RefreshDataSource();
        }

        private void grdRules_Click(object sender, EventArgs e)
        {
            _SelectedRule = (AuthorizationRuleData)((System.Windows.Forms.BindingSource)grdRules.DataSource).Current;
            if (_SelectedRule != null)
                lblSelectedRule.Text = _SelectedRule.Name;
        }

        private void grdRules_DoubleClick(object sender, EventArgs e)
        {
            if (OnSelectRule != null)
                OnSelectRule(_SelectedRule, e);
        }
    }
}
