using System;

using Fwk.UI.Controls.Menu;
using Fwk.Security.Common;
using Fwk.Security;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Web.Security;
using Fwk.Configuration;
using System.ComponentModel;
using Fwk.Security.BE;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using System.Collections.Generic;
using Fwk.UI.Common;
using System.Runtime.Remoting.Messaging;
using Fwk.UI.Controller;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Fwk.UI.Controls;
using DevExpress.XtraEditors;


namespace Fwk.UI.Security.Controls.Rules
{
    [ToolboxItem(true)]
    public partial class UC_RulesMain : UC_UserControlBase
    {
        
        #region Members
        FwkCategoryList _Categories;
        FwkCategory _SelectedCategory;
        FwkAuthorizationRuleAuxList _SelectedRules = new FwkAuthorizationRuleAuxList();
        FwkAuthorizationRuleAux _FwkAuthorizationRule;

        [Browsable(false)]
        public FwkAuthorizationRuleAux SelectedRule
        {
            get { return _FwkAuthorizationRule; }
        }

        public bool AllowRulesMultiSelect
        {
            get { return grdViewRulesByCategory.OptionsSelection.MultiSelect; }
            set {  grdViewRulesByCategory.OptionsSelection.MultiSelect = value; }
        }
        #endregion

        #region Constructor
        public UC_RulesMain()
        {
            InitializeComponent();
        }
        #endregion


        private void toolBarControl1_ToolBarButtonClick(object sender, ButtonClickArgs<Fwk.UI.Controls.Menu.ButtonBase> e)
        {
            if (e.ButtonClicked.GetType() == typeof(SimpleButton))
            {               
                switch (e.ButtonClicked.Id)
                {
                    case "btnEditRules":
                        break;  
                    default:
                        break;
                }
            }
        }

        
        private void treeList1_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                _SelectedCategory = (FwkCategory)treeList1.GetDataRecordByNode(treeList1.FocusedNode);

                bindingSourceRules.DataSource = _SelectedCategory.FwkRulesInCategoryList;

                grdRulesByCategory.RefreshDataSource();
            }
        }


        #region PopulateSync

        /// <summary>
        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
        /// </summary>
        public void PopulateAsync()
        {
            Exception ex = null;
            Fwk.UI.Common.HelperFunctions.DelegateWithOutAndRefParameters s = new Fwk.UI.Common.HelperFunctions.DelegateWithOutAndRefParameters(Populate);

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

                Fwk.UI.Common.HelperFunctions.DelegateWithOutAndRefParameters del = (Fwk.UI.Common.HelperFunctions.DelegateWithOutAndRefParameters)result.AsyncDelegate;
                del.EndInvoke(out ex, res);

                treeList1.BeginUnboundLoad();
                this.rulesCategoryBEListBindingSource.DataSource = _Categories;
              
                treeList1.RefreshDataSource();
                treeList1.EndUnboundLoad();
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
                _Categories = SecurityController.SearchAllRulesCategory();
            
            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }
        }
  
        #endregion

        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
        }

        public FwkAuthorizationRuleAuxList GetSelectedRules()
        {
            FwkAuthorizationRuleAux wFwkAuthorizationRule;
           
            _SelectedRules.Clear();
            foreach (int row in grdViewRulesByCategory.GetSelectedRows())
            {
                wFwkAuthorizationRule = (FwkAuthorizationRuleAux)grdViewRulesByCategory.GetRow(row);
                _SelectedRules.Add(wFwkAuthorizationRule);
            }

            return _SelectedRules;
        }

       

        private void grdViewRulesByCategory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (((BindingSource)grdViewRulesByCategory.DataSource).Current == null)
                return;
            _FwkAuthorizationRule = ((FwkAuthorizationRuleAux)((BindingSource)grdViewRulesByCategory.DataSource).Current);

        }
       
    }
}
