using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controls;
using Fwk.Security;

namespace Fwk.UI.Security.Controls
{
    [DefaultEvent("OnSelectRule")]
    public partial class UC_RuleSelector : UC_UserControlBase
    {
        public event System.EventHandler OnSelectRule;
        private FwkAuthorizationRule _SelectedRule;
        public static List<FwkAuthorizationRule> Rules;

        [Browsable(false)]
        public FwkAuthorizationRule SelectedRule
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

            FwkAuthorizationRuleBindingSource.DataSource = Rules;
            grdRules.RefreshDataSource();
        }

        private void grdRules_Click(object sender, EventArgs e)
        {
            _SelectedRule = (FwkAuthorizationRule)((System.Windows.Forms.BindingSource)grdRules.DataSource).Current;
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
