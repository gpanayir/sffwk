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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList.Nodes;

namespace Fwk.Security.Admin.Controls
{
    public partial class RulesEditControl : SecurityControlBase
    {
        CategoryTree _CurrentCategory = null;
        Rol _SelectedRol = null;

        UserList _ExcludeUserList = new UserList();
        RolList _AssignedRolList = new RolList();
        FwkCategoryList _CategoryList;
        CategoryTreeList _CategoryTreeList;
        CategoryTree _ParentFwkCategory;
        List<AuthorizationRuleData> _RuleList;
        List<FwkAuthorizationRule> _AllRuleList;
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

                _AllRuleList = FwkMembership.GetRulesAuxList(frmAdmin.Provider.ApplicationName);
                fwkAuthorizationRuleBindingSource.DataSource = _AllRuleList;
                grdAllRules.RefreshDataSource();

                _CategoryList = FwkMembership.GetAllCategories(frmAdmin.Provider.ApplicationName);
                _CategoryTreeList = CategoryTreeList.Retrive_CategoryTreeList(_CategoryList);
                treeList1.BeginUnboundLoad();

                this.categoryTreeBindingSource.DataSource = _CategoryTreeList;
                treeList1.RefreshDataSource();
                treeList1.EndUnboundLoad();
                treeList1.ExpandAll();
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
                this.categoryTreeBindingSource.DataSource = _CategoryTreeList;
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
                _CategoryTreeList = CategoryTreeList.Retrive_CategoryTreeList(_CategoryList);
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
            //if (treeList1.FocusedNode != null)
            //{
            //    _ParentFwkCategory = (CategoryTree)treeList1.GetDataRecordByNode(treeList1.FocusedNode);
            //    aspnetRulesInCategoryBindingSource.DataSource = _ParentFwkCategory.FwkRulesInCategoryList;


            //    grdRulesByCategory.RefreshDataSource();
            //}
        }

        private void grdRulesByCategory_Click(object sender, EventArgs e)
        {

            //Fwk.Security.FwkAuthorizationRule rule = (Fwk.Security.FwkAuthorizationRule)((BindingSource)grdRulesByCategory.DataSource).Current;
            //if (rule == null) return;
            //_CurrentRule = FwkMembership.GetRule(rule.Name, frmAdmin.Provider.ApplicationName);
            //if (_CurrentRule == null)
            //{
            //    MessageViewInfo.Show("Esta regla y fue eliminada .- Es posible que la categoria seleccionada no esta sincronizada con las reglas.-");
            //    rolBindingSource.DataSource = null;
            //}
            //else
            //{
            //    _AssignedRolList = new RolList();
            //    _ExcludeUserList = new UserList();
            //    FwkMembership.BuildRolesAndUsers_FromRuleExpression(_CurrentRule.Expression, out _AssignedRolList, out _ExcludeUserList);
            //    rolBindingSource.DataSource = _AssignedRolList;
            //}

            //grdRoles.RefreshDataSource();
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
                FwkMembership.UpdateRule(_CurrentRule, Membership.Provider.Name);

                rolBindingSource.DataSource = null;
                rolBindingSource.DataSource = _AssignedRolList;
                grdRoles.RefreshDataSource();
            }
            SetMessageViewToDefault();
        }

        private void mAddNewCategory_Click(object sender, EventArgs e)
        {
            using (frmAddName frm = new frmAddName())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(frm.Tag.ToString()) && _CurrentCategory != null)
                        if (FwkMembership.ExistCategory(frm.Tag.ToString().Trim(), Convert.ToInt32(_CurrentCategory.Id), frmAdmin.Provider.ApplicationName))
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
                wFwkCategory.ParentId = Convert.ToInt32(_ParentFwkCategory.Id);
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
        private void mRemove_Click(object sender, EventArgs e)
        {
            if (_CurrentCategory.IsCategory == false)
            {
                //Obtengo el padre
                _ParentFwkCategory = _CategoryTreeList.Where(p => p.Id.Equals(_CurrentCategory.ParentId)).FirstOrDefault<CategoryTree>();
                _ParentFwkCategory.RemoveRule(_CurrentCategory.Id);
                _CategoryTreeList.RemoveItem(_CurrentCategory.Id);//No es necesario ya que se ejecurara luego --> PopulateAsync
                try
                {
                    FwkMembership.CreateRuleInCategory(_ParentFwkCategory.FwkCategory, frmAdmin.Provider.ApplicationName);
                    MessageViewInfo.Show("Rule was successfully removed from category");
                    PopulateAsync();
                }
                catch (Exception ex)
                { throw ex; }
            }
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
            //TreeList tl = sender as TreeList;
            //if (tl.FocusedNode != null)
            //    if (tl.FocusedNode.HasChildren)
            //        tl.FocusedNode.Expanded = !tl.FocusedNode.Expanded;
        }
        TreeListHitInfo _HitInfo = null;
        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            _HitInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y));
            if (_HitInfo.Node == null) return;
            _CurrentCategory = (CategoryTree)treeList1.GetDataRecordByNode(_HitInfo.Node);
            lblCurrentCategory.Text = _CurrentCategory.Name;

            mAddNewCategory.Enabled = _CurrentCategory.IsCategory;
            treeList1.SetFocusedNode(_HitInfo.Node);

        }

        #region (Tree List) Eventos y Métodos Drag hacia otro componente

        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            TreeListHitInfo wHitInfo = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            if (wHitInfo.Node == null)
                return;

            List<FwkAuthorizationRule> wRuleList = e.Data.GetData(typeof(List<FwkAuthorizationRule>)) as List<FwkAuthorizationRule>;

            if (wRuleList != null)
            {
            
                _CurrentCategory = (CategoryTree)treeList1.GetDataRecordByNode(wHitInfo.Node);
                lblCurrentCategory.Text = _CurrentCategory.Name;
                if (_CurrentCategory.IsCategory == false)
                {
                    return;
                }
                #region Add Rules to Category
                foreach (FwkAuthorizationRule rule in wRuleList)
                {
                    if (!_CurrentCategory.AnyRule(rule.Name))
                    {

                        CategoryTree newRule = _CurrentCategory.AddRule(rule);
                        this._CategoryTreeList.Add(newRule);
                        _CurrentCategory.EntityState = Fwk.Bases.EntityState.Changed;
                    }
                }
                #endregion
            }
            //Si cambiaron una o mas reglas
            if (_CurrentCategory.EntityState == Fwk.Bases.EntityState.Changed)
            {
                FwkMembership.CreateRuleInCategory(_CurrentCategory.FwkCategory, frmAdmin.Provider.ApplicationName);

                _CurrentCategory.EntityState = Fwk.Bases.EntityState.Unchanged;
                treeList1.RefreshDataSource();
                treeList1.ExpandAll();
            }
        }

        private void treeList1_DragOver(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.Move;
            //if (_ParentFwkCategory != null)
            //    if (_ParentFwkCategory.IsCategory == false)
            //    {
            //        e.Effect = DragDropEffects.None;

            //    }
            TreeListHitInfo hi = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            _CurrentCategory = (CategoryTree)treeList1.GetDataRecordByNode(hi.Node);
            if (_CurrentCategory == null)
                e.Effect = DragDropEffects.None;
            if (_CurrentCategory != null)
            {
                lblCurrentCategory.Text = _CurrentCategory.Name;

                if (_CurrentCategory.IsCategory)
                    e.Effect = DragDropEffects.Move;

                if (!_CurrentCategory.IsCategory)
                    e.Effect = DragDropEffects.None;
            }
            //TreeListNode node = GetDragNode(e.Data);
            //if (node == null)
            //{
            //    if (hi.HitInfoType == HitInfoType.Empty || hi.Node != null)
            //        e.Effect = DragDropEffects.Move;
            //    else
            //        e.Effect = DragDropEffects.None;
            //}

            SetDragCursor(e.Effect);
        }
        private TreeListNode GetDragNode(IDataObject data)
        {
            return data.GetData(typeof(TreeListNode)) as TreeListNode;
        }
        private void treeList1_DragLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void treeList1_DragEnter(object sender, DragEventArgs e)
        {
            //TreeListHitInfo hi = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            //_CurrentCategory = (CategoryTree)treeList1.GetDataRecordByNode(hi.Node);
            //if (_CurrentCategory == null)
            //    e.Effect = DragDropEffects.None;
            //if (_CurrentCategory != null)
            //{
            //    lblCurrentCategory.Text = _CurrentCategory.Name;

            //    if (_CurrentCategory.IsCategory)
            //        e.Effect = DragDropEffects.Move;

            //    if (!_CurrentCategory.IsCategory)
            //        e.Effect = DragDropEffects.None;
            //}

            //SetDragCursor(e.Effect);
        }
        private void SetDragCursor(DragDropEffects e)
        {
          
            

           // Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("<Fwk.Security.Admin>.<foldername(optional)>.<filename>.<filenameExtention>");
           
            if (e == DragDropEffects.Move)
                Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Fwk.Security.Admin.Resources.move_16.ico"));
            if (e == DragDropEffects.Copy)
                Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Fwk.Security.Admin.Resources.copy_24.ico"));
            if (e == DragDropEffects.None)
                Cursor = Cursors.No;
        }


        #endregion
        #region (Grilla) Eventos y Métodos Drag hacia otro componente
        GridHitInfo _GridHitInfo = null;
        private void gridView_AllRules_MouseDown(object sender, MouseEventArgs e)
        {
            _GridHitInfo = gridView_AllRules.CalcHitInfo(new Point(e.X, e.Y));
            _CurrentRule = ((FwkAuthorizationRule)gridView_AllRules.GetRow(_GridHitInfo.RowHandle));
            if (_CurrentRule != null)
                lblSelectedRule.Text = _CurrentRule.Name;
        }

        private void gridView_AllRules_MouseMove(object sender, MouseEventArgs e)
        {
            if (_GridHitInfo == null || e.Button != MouseButtons.Left || _GridHitInfo.HitTest == GridHitTest.RowIndicator)
                return;

            Rectangle dragRect = new Rectangle(new Point(_GridHitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                                                                                    _GridHitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);

            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
                //if (_GridHitInfo.InRowCell)
                //{
                FwkAuthorizationRule rule = null;
                List<FwkAuthorizationRule> wRuleList = new List<FwkAuthorizationRule>();
                //Recorro todas las filas seleccionadas y obtengo el UserId y el Name y los agrego a la lista de usuarios
                foreach (int wFila in gridView_AllRules.GetSelectedRows())
                {
                    //rule = new FwkRulesInCategory(((NamedConfigurationElement)(grdViewRules.GetRow(wFila))).Name);
                    rule = (FwkAuthorizationRule)(gridView_AllRules.GetRow(wFila));
                    wRuleList.Add(rule.Clone());
                }

                grdAllRules.DoDragDrop(wRuleList, DragDropEffects.Move);
                lblSelectedRule.Text = wRuleList[0].Name;
                //Dejamos seleccionada a la fila que tiene el foco
                //gridView_AllRules.SelectRow(gridView_AllRules.FocusedRowHandle);
                //}
            }
        }
   
        #endregion

       

      



    }



  
}
