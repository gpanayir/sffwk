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
        FwkCategoryList _CategoryList;
        FwkCategory _ParentFwkCategory;
        List<AuthorizationRuleData> _RuleList;
        FwkAuthorizationRule _CurrentRule;
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
                aspnetRulesInCategoryBindingSource.DataSource = _ParentFwkCategory.FwkRulesInCategoryList;


                grdRulesByCategory.RefreshDataSource();
            }
        }

        private void grdRulesByCategory_Click(object sender, EventArgs e)
        {

            Fwk.Security.FwkAuthorizationRule rule = (Fwk.Security.FwkAuthorizationRule)((BindingSource)grdRulesByCategory.DataSource).Current;
            if (rule == null) return;
            _CurrentRule = FwkMembership.GetRule(rule.Name, Membership.ApplicationName);
            if (_CurrentRule == null)
            {
                MessageViewInfo.Show("Esta regla y fue eliminada .- Es posible que la categoria seleccionada no esta sincronizada con las reglas.-");
                rolBindingSource.DataSource = null;
            }
            else
            {
                _AssignedRolList = new RolList();
                _ExcludeUserList = new UserList();
                FwkMembership.BuildRolesAndUsers_FromRuleExpression(_CurrentRule.Expression, out _AssignedRolList, out _ExcludeUserList);
                rolBindingSource.DataSource = _AssignedRolList;
            }

            grdRoles.RefreshDataSource();
        }

        private void removeSelectedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveItem();

        }

        private void btnFindRoles_Click(object sender, EventArgs e)
        {
            using (frmRolesFind frm = new frmRolesFind())
            {

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //Rol addedRole;
                    foreach (Rol rol in frm.SelectedRoleList)
                    {
                        if (!_AssignedRolList.Any(r => r.RolName.Trim().Equals(rol.RolName.Trim(), StringComparison.OrdinalIgnoreCase)))
                        {
                             //addedRole = new Rol(rol.RolName);
                            _AssignedRolList.Add(rol);
                        }
                    }
                    _CurrentRule.Expression = FwkMembership.BuildRuleExpression(_AssignedRolList, _ExcludeUserList);
                    FwkMembership.UpdateRule(_CurrentRule, frmAdmin.Provider.Name);


                    rolBindingSource.DataSource = _AssignedRolList;
                    grdRoles.RefreshDataSource();
                }



            }
        }

        private void grdRoles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveItem();
            }
        }

        void RemoveItem()
        {
            MessageViewInfo.MessageBoxButtons = MessageBoxButtons.YesNo;
            MessageViewInfo.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Question;
            if (MessageViewInfo.Show("Are you sure to remove selected roles from current rule : " + _CurrentRule.Name) == DialogResult.Yes)
            {
               
            
                foreach (int wFila in grdViewRoles.GetSelectedRows())
                {
                    _AssignedRolList.Remove((Rol)grdViewRoles.GetRow(wFila));
                }

                _CurrentRule.Expression = FwkMembership.BuildRuleExpression(_AssignedRolList, _ExcludeUserList);
                FwkMembership.UpdateRule(_CurrentRule,Membership.Provider.Name);

                rolBindingSource.DataSource = null;
                rolBindingSource.DataSource = _AssignedRolList;
                grdRoles.RefreshDataSource();
            }
            SetMessageViewToDefault();
        }
    }
}
