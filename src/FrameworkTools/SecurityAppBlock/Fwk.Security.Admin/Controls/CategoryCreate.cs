using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Web.Security;
  
namespace Fwk.Security.Admin.Controls
{
    public partial class CategoryCreate : SecurityControlBase
    {
       
        FwkCategory _ParentFwkCategory;
        
        private IAuthorizationProvider ruleProvider;
        public override string AssemblyConditionControl
        {
            get
            {
                return typeof(CategoryCreate).AssemblyQualifiedName;
            }
        }


        public override void Initialize()
        {
            using (new WaitCursorHelper(this))
            {
                this.ruleProvider = AuthorizationFactory.GetAuthorizationProvider("RuleProvider_Fwk");
                this.fwkCategoryBindingSource.DataSource = FwkMembership.GetRuleCategories(Membership.ApplicationName);
                lstBoxRules.DataSource = FwkMembership.GetRulesList(Membership.ApplicationName);
                lstBoxRules.Refresh();
            }
        }

        public CategoryCreate()
        {
            InitializeComponent();
        }

        private void grdAllRules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreateNewRol_Click(object sender, EventArgs e)
        {
            FwkCategory wFwkCategory = new FwkCategory();

            wFwkCategory.Name = txtRuleName.Text.Trim();
            wFwkCategory.ParentCategoryId = _ParentFwkCategory.CategoryId;
            wFwkCategory.FwkRulesInCategoryList = new List<FwkRulesInCategory>();
            FwkRulesInCategory wFwkRulesInCategory = null;
            FwkAuthorizationRule wFwkAuthorizationRule = null;
            foreach (object obj in lstBoxRules.CheckedItems)
            {
                wFwkRulesInCategory = new FwkRulesInCategory();

                wFwkAuthorizationRule = (FwkAuthorizationRule)obj;
                wFwkRulesInCategory.RuleName = wFwkAuthorizationRule.Name;

                wFwkCategory.FwkRulesInCategoryList.Add(wFwkRulesInCategory);
            }
            
            FwkMembership.CreateCategory(wFwkCategory,Membership.ApplicationName);
               
        }
     

        private void treeList1_Click(object sender, EventArgs e)
        {
            if(treeList1.FocusedNode != null)
                 _ParentFwkCategory = (FwkCategory)treeList1.GetDataRecordByNode(treeList1.FocusedNode);
        }

        
    }
}
