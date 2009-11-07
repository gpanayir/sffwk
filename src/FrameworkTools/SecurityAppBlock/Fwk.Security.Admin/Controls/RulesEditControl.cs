using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Fwk.Security.Common;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using System.Web.Security;
using System.Runtime.Remoting.Messaging;

namespace Fwk.Security.Admin.Controls
{
    public partial class RulesEditControl : SecurityControlBase
    {
        Rol _SelectedRol = null;
        User _SelectedUser = null;
        UserList _ExcludeUserList = new UserList();
        RolList _AssignedRolList = new RolList();
        List<FwkCategory> _CategoryList;
        FwkCategory _ParentFwkCategory;
        List<AuthorizationRuleData> _RuleList;
        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// 
        /// </summary>
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(RulesEditControl).AssemblyQualifiedName;
            }
        }
     
        public override void Initialize()
        {
            //txtRuleName.Focus();
            using (new WaitCursorHelper(this))
            {
                //userBindingSource.DataSource = FwkMembership.GetAllUsers();
                rolBindingSource.DataSource = FwkMembership.GetAllRoles();
                grdAllRoles.Refresh();
       
        
            


                _CategoryList = FwkMembership.GetAllCategories(Membership.ApplicationName);
                treeList1.BeginUnboundLoad();
                
                this.fwkCategoryBindingSource.DataSource = _CategoryList;
                treeList1.RefreshDataSource();
                treeList1.EndUnboundLoad();
            }
        }
        public RulesEditControl()
        {
            InitializeComponent();
        }


        #region Async
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
                treeList1.BeginUnboundLoad();
                this.fwkCategoryBindingSource.DataSource = _CategoryList;
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

                _CategoryList = FwkMembership.GetAllCategories(Membership.ApplicationName);

            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }



        }

        #endregion


        private void treeList1_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                _ParentFwkCategory = (FwkCategory)treeList1.GetDataRecordByNode(treeList1.FocusedNode);

                grdRulesByCategory.DataSource = _ParentFwkCategory.FwkRulesInCategoryList;

                grdRulesByCategory.RefreshDataSource();
            }
        }
    }
}
