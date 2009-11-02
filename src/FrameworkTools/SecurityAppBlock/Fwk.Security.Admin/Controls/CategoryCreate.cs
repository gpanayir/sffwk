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
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Runtime.Remoting.Messaging;
  
namespace Fwk.Security.Admin.Controls
{
    public partial class CategoryCreate : SecurityControlBase
    {
        List<FwkCategory> _CategoryList;
        FwkCategory _ParentFwkCategory;
        
        private IAuthorizationProvider ruleProvider;
        public override string AssemblySecurityControl
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

              
                lstBoxRules.DataSource = FwkMembership.GetRulesList(Membership.ApplicationName);
                lstBoxRules.Refresh();
            }
        }

        public CategoryCreate()
        {
            InitializeComponent();
            treeList1.Enabled = chkParentCategory.Checked;
        }

       

        private void btnCreateNewRol_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtRuleName.Text))
            {
                MessageViewInfo.Show("Category name must not be empty");
                txtRuleName.Focus();
            }
            FwkCategory wFwkCategory = new FwkCategory();

            wFwkCategory.Name = txtRuleName.Text.Trim();
            if (chkParentCategory.Checked)
                wFwkCategory.ParentId = _ParentFwkCategory.CategoryId;
            else
                wFwkCategory.ParentId = 0;
            wFwkCategory.FwkRulesInCategoryList = new List<FwkRulesInCategory>();
            FwkRulesInCategory wFwkRulesInCategory = null;
       
            foreach (object obj in lstBoxRules.CheckedItems)
            {
                wFwkRulesInCategory = new FwkRulesInCategory();
                
                wFwkRulesInCategory.RuleName = ((NamedConfigurationElement)obj).Name;

                wFwkCategory.FwkRulesInCategoryList.Add(wFwkRulesInCategory);
            }

            try
            {
                FwkMembership.CreateCategory(wFwkCategory, Membership.ApplicationName);
                MessageViewInfo.Show("Category was successfully created");
                PopulateAsync();
            }
            catch(Exception ex)
            { throw ex; }
               
        }
     

        private void treeList1_Click(object sender, EventArgs e)
        {
            if(treeList1.FocusedNode != null)
                 _ParentFwkCategory = (FwkCategory)treeList1.GetDataRecordByNode(treeList1.FocusedNode);
        }

        private void CategoryCreate_Load(object sender, EventArgs e)
        {
            this.ruleProvider = AuthorizationFactory.GetAuthorizationProvider("RuleProvider_Fwk");
 
        }
        public delegate void DelegateWithOutAndRefParameters(out Exception ex);
        /// <summary>
        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
        /// </summary>
        public void PopulateAsync()
        {
            Exception ex = null;
            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Populate);

            s.BeginInvoke(out ex, new AsyncCallback(EndPopulate), null);


        }
        /// <summary>
        /// Fin de el metodo populate que fue llamado de forma asincrona
        /// </summary>
        /// <param name="res"></param>
        void EndPopulate(IAsyncResult res)
        {
            Exception ex;
            if (this.InvokeRequired)
            {
                AsyncCallback d = new AsyncCallback(EndPopulate);
                this.Invoke(d, new object[] { res });

            }
            else
            {
                AsyncResult result = (AsyncResult)res;


                DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
                del.EndInvoke(out ex, res);
                if (ex != null)
                {

                    throw ex;
                 
                }
                this.fwkCategoryBindingSource.DataSource = _CategoryList;
                
                treeList1.RefreshDataSource();
            }
        }

        /// <summary>
        /// Carga Dominios relacionados entre al objeto _RelatedDomains que esta bindiado a la grilla
        /// </summary>
        void Populate(out Exception ex)
        {
            ex = null;

            try
            {

                _CategoryList = FwkMembership.GetRuleCategories(Membership.ApplicationName);
   
            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }



        }

        private void chkParentCategory_CheckedChanged(object sender, EventArgs e)
        {
            treeList1.Enabled = chkParentCategory.Checked;
        }
       
    }
}
