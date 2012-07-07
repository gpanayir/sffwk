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

        private void iAddNewCategory_Click(object sender, EventArgs e)
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
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CurrentCategory.IsCategory == false)
            {
                //Obtengo el padre
                _ParentFwkCategory = _CategoryTreeList.Where(p => p.Id.Equals(_CurrentCategory.ParentId)).FirstOrDefault<CategoryTree>();
                _ParentFwkCategory.RemoveRule(_CurrentCategory.Id);
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


            iAddNewCategory.Enabled = _CurrentCategory.IsCategory;
            treeList1.SetFocusedNode(_HitInfo.Node);

        }

        #region (Grilla) Eventos y Métodos Drag hacia otro componente

        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            TreeListHitInfo wHitInfo = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            if (wHitInfo.Node == null)
                return;

            List<FwkAuthorizationRule> wRuleList = (List<FwkAuthorizationRule>)e.Data.GetData(typeof(List<FwkAuthorizationRule>));

            if (wRuleList != null)
            {
                //FwkAuthorizationRule wRule2;
                _ParentFwkCategory = (CategoryTree)treeList1.GetDataRecordByNode(wHitInfo.Node);
                if (_ParentFwkCategory.IsCategory == false)
                {

                    return;
                }
                #region Add Rules to Category
                foreach (FwkAuthorizationRule rule in wRuleList)
                {
                    if (!_ParentFwkCategory.Rules.Any<CategoryTree>(p => p.Name == rule.Name))
                    {
                        //wRule2 = new FwkAuthorizationRule();
                        //wRule2.Name = rule.Name;
                        //wRule2.CategoryId = _ParentFwkCategory.CategoryId;
                        CategoryTree newRule = _ParentFwkCategory.AddRule(rule);
                        this._CategoryTreeList.Add(newRule);
                        _ParentFwkCategory.EntityState = Fwk.Bases.EntityState.Changed;
                    }
                }
                #endregion
            }
            //Si cambiaron una o mas reglas
            if (_ParentFwkCategory.EntityState == Fwk.Bases.EntityState.Changed)
            {
                FwkMembership.CreateRuleInCategory(_ParentFwkCategory.FwkCategory, frmAdmin.Provider.ApplicationName);
                //Agrego las rules a la grilla sobre
                //grdRulesByCategory.DataSource = _ParentFwkCategory.FwkCategory.FwkRulesInCategoryList;
                //grdRulesByCategory.RefreshDataSource();
                //treeList1.RefreshDataSource();
                _ParentFwkCategory.EntityState = Fwk.Bases.EntityState.Unchanged;
                treeList1.RefreshDataSource();
                treeList1.ExpandAll();
            }
        }

        private void treeList1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            if (_ParentFwkCategory != null)
                if (_ParentFwkCategory.IsCategory == false)
                {
                    e.Effect = DragDropEffects.None;

                }
        }




        #endregion
        #region (Grilla) Eventos y Métodos Drag hacia otro componente
        GridHitInfo _GridHitInfo = null;
        private void gridView_AllRules_MouseDown(object sender, MouseEventArgs e)
        {
            _GridHitInfo = grdViewRulesByCategory.CalcHitInfo(new Point(e.X, e.Y));
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

                //Dejamos seleccionada a la fila que tiene el foco
                gridView_AllRules.SelectRow(gridView_AllRules.FocusedRowHandle);
                //}
            }
        }

        #endregion



    }

    public class CategoryTreeList : Fwk.Bases.Entities<CategoryTree>
    {
        public static CategoryTreeList Retrive_CategoryTreeList(FwkCategoryList pFwkCategoryList)
        {
            CategoryTreeList list = new CategoryTreeList();
            CategoryTreeList list2 = new CategoryTreeList();
            var wCategoryTreeList = from p in pFwkCategoryList select new CategoryTree(p);


            foreach (CategoryTree category in wCategoryTreeList)
            {
                if (category.Id == "11")
                {
                    string i = category.Id;
                }
                list.Add((CategoryTree)category.Clone());

                //CategoryTree rule = null;
                //foreach (FwkAuthorizationRule r in category.FwkCategory.FwkRulesInCategoryList)
                //{
                //    rule = new CategoryTree();
                //    rule.Name = r.Name.Trim();
                //    rule.ParentId = category.Id;
                //    rule.Id = string.Concat(category.id, "_", r.Name.Trim());
                //    rule.IsCategory = false;
                //}
                foreach (CategoryTree r in category.Rules)
                {
                    list.Add((CategoryTree)r.Clone());
                }
            }
            return list;
        }
    }

    public class CategoryTree : Fwk.Bases.Entity
    {
        public CategoryTree(FwkCategory pFwkCategory)
        {
            Rules = new List<CategoryTree>();
            this.FwkCategory = pFwkCategory;
            this.Id = pFwkCategory.CategoryId.ToString();

            this.Name = pFwkCategory.Name;
            if (pFwkCategory.ParentId.HasValue)
                ParentId = pFwkCategory.ParentId.Value.ToString();
            else
                ParentId = "0";

            if (pFwkCategory.FwkRulesInCategoryList != null)
            {

                CategoryTree rule = null;
                foreach (FwkAuthorizationRule r in pFwkCategory.FwkRulesInCategoryList)
                {
                    rule = new CategoryTree();
                    rule.Name = r.Name.Trim();
                    rule.ParentId = this.Id;
                    rule.Id = string.Concat(this.Id, "_", r.Name.Trim());
                    rule.IsCategory = false;
                    this.Rules.Add(rule);
                }
            }
        }
        public CategoryTree()
        {
            Rules = new List<CategoryTree>();
        }

        public CategoryTree AddRule(FwkAuthorizationRule pFwkAuthorizationRule)
        {
            CategoryTree rule = new CategoryTree();
            rule.Name = pFwkAuthorizationRule.Name.Trim();
            rule.ParentId = this.Id;
            rule.Id = string.Concat(this.Id, "_", pFwkAuthorizationRule.Name.Trim());
            rule.IsCategory = false;
            //this.Rules.Add(rule);
            FwkCategory.FwkRulesInCategoryList.Add(pFwkAuthorizationRule);
            return rule;
        }

        public void RemoveRule(string rule_id)
        {
            var r = this.Rules.Where(p => p.Id.Equals(rule_id)).FirstOrDefault();

            //for (int i = 0; i <= FwkCategory.FwkRulesInCategoryList.Count; i++)
            //{
            //    if (FwkCategory.FwkRulesInCategoryList[i].Name.Equals(r.Name))
            //    {
            //        FwkCategory.FwkRulesInCategoryList.RemoveAt(i);
            //        break;
            //    }
            //}
             var r1 = FwkCategory.FwkRulesInCategoryList.Where(p => p.Name.Trim().Equals(r.Name.Trim())).FirstOrDefault();
            FwkCategory.FwkRulesInCategoryList.Remove(r1);

            this.Rules.Remove(r);
        }

        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        bool _IsCategory = true;

        public bool IsCategory
        {
            get { return _IsCategory; }
            set { _IsCategory = value; }
        }

        public List<CategoryTree> Rules { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public FwkCategory FwkCategory { get; set; }


    }
}
