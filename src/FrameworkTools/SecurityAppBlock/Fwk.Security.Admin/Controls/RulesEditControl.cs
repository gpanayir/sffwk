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
using DevExpress.XtraTreeList;

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



                _CategoryList = FwkMembership.GetAllCategories(frmAdmin.Provider.ApplicationName);
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

                _CategoryList = FwkMembership.GetAllCategories(frmAdmin.Provider.ApplicationName);

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
            _CurrentRule = FwkMembership.GetRule(rule.Name, frmAdmin.Provider.ApplicationName);
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

        private void iAddNewCategory_Click(object sender, EventArgs e)
        {
            using (frmAddName frm = new frmAddName())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(frm.Tag.ToString()) && _CurrentCategory != null)
                        if (FwkMembership.ExistCategory(frm.Tag.ToString().Trim(), _CurrentCategory.CategoryId, frmAdmin.Provider.ApplicationName))
                        {
                            MessageViewInfo.Show(string.Format("Category {0} already exist", frm.Tag.ToString()));
                            return;
                        }
                        else
                            Create_Categoty(frm.Tag.ToString());
                }
            }


        }

        void Create_Categoty(string name)
        {


            FwkCategory wFwkCategory = new FwkCategory();

            wFwkCategory.Name = name;
            if (_ParentFwkCategory != null)
                wFwkCategory.ParentId = _ParentFwkCategory.CategoryId;
            else
                wFwkCategory.ParentId = 0;

            try
            {
                FwkMembership.CreateCategory(wFwkCategory, frmAdmin.Provider.ApplicationName);
                MessageViewInfo.Show("Category was successfully created");
                PopulateAsync();
            }
            catch (Exception ex)
            { throw ex; }

        }

        FwkCategory _CurrentCategory = null;
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
             _CurrentCategory = (FwkCategory)treeList1.GetDataRecordByNode(e.Node);
            //if (!String.IsNullOrEmpty(item.AssemblyInfo))
            //{
            //    AddContronToPannel(item, null);
            //}
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            TreeList tl = sender as TreeList;
            if (tl.FocusedNode != null)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (!tl.FocusedNode.Expanded && tl.FocusedNode.HasChildren)
                        tl.FocusedNode.Expanded = true;
                    else tl.MoveNextVisible();
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (tl.FocusedNode.Expanded)
                        tl.FocusedNode.Expanded = false;
                    else tl.MovePrevVisible();
                }
            }
        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            TreeList tl = sender as TreeList;
            if (tl.FocusedNode != null)
                if (tl.FocusedNode.HasChildren)
                    tl.FocusedNode.Expanded = !tl.FocusedNode.Expanded;
        }
        TreeListHitInfo _HitInfo = null;
        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            _HitInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y));
            _CurrentCategory = (FwkCategory)treeList1.GetDataRecordByNode(_HitInfo.Node);

            if (_CurrentCategory != null)
            {
                
            }
        }
    }
}
