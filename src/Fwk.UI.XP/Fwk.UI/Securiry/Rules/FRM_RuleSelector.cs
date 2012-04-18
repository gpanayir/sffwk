using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Forms;
using Fwk.Security.BE;
using Fwk.Security;

namespace Fwk.UI.Security.Controls
{
    [DefaultEvent("OnSelectRule")]
    public partial class FRM_RuleSelector : FormDialogBase
    {
        public event System.EventHandler OnSelectRule;

        [Browsable(false)]
        public bool AllowRulesMultiSelect
        {
            get { return uC_RulesMain1.AllowRulesMultiSelect; }
            set { uC_RulesMain1.AllowRulesMultiSelect = value; }
        }
        [Browsable(false)]
        public FwkAuthorizationRuleAuxList SelectedRules
        {
            get { return uC_RulesMain1.GetSelectedRules(); }
        }

        [Browsable(false)]
        public FwkAuthorizationRuleAux SelectedRule
        {
            get { return uC_RulesMain1.GetSelectedRules()[0]; }
        }
        public FRM_RuleSelector()
        {
            InitializeComponent();
        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                if (OnSelectRule != null)
                        OnSelectRule(uC_RulesMain1.GetSelectedRules(), new EventArgs());

                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }
        private void frmRuleSelector_Load(object sender, EventArgs e)
        {
            uC_RulesMain1.PopulateAsync();
        }
    }
}
