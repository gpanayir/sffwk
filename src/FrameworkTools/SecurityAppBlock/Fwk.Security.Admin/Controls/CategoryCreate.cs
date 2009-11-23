﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using System.Web.Security;
using System.Runtime.Remoting.Messaging;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils;

namespace Fwk.Security.Admin.Controls
{
    public partial class CategoryCreate : SecurityControlBase
    {
        List<FwkCategory> _CategoryList;
        FwkCategory _ParentFwkCategory;
        List<FwkAuthorizationRuleAux> _RuleList;
      
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

                _RuleList = FwkMembership.GetRulesAuxList(Membership.ApplicationName);
                fwkAuthorizationRuleBindingSource.DataSource = _RuleList;
                grdRules.RefreshDataSource();
            }
        }
       
        public CategoryCreate()
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

        #region Eventos y Métodos Drag hacia otro componente
        TreeListHitInfo _TreeListHitInfo;
        GridHitInfo _GridHitInfo = null;
        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            _TreeListHitInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y)); ;
        }

        private void treeList1_MouseMove(object sender, MouseEventArgs e)
        {
           

        }
        #endregion
        #region (Grilla) Eventos y Métodos Drag hacia otro componente 
        private void grdRules_MouseDown(object sender, MouseEventArgs e)
        {
            //Calculamos el punto de impacto en la vista para tener datos
            _GridHitInfo = grdViewRules.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void grdRules_MouseMove(object sender, MouseEventArgs e)
        {
            if (_GridHitInfo == null || e.Button != MouseButtons.Left || _GridHitInfo.HitTest == GridHitTest.RowIndicator)
                return;

            Rectangle dragRect = new Rectangle(new Point(_GridHitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                                                                                    _GridHitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);

            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
                if (_GridHitInfo.InRowCell)
                {
                    FwkAuthorizationRuleAux rule = null;
                    List<FwkAuthorizationRuleAux> wRuleList = new List<FwkAuthorizationRuleAux>();
                    //Recorro todas las filas seleccionadas y obtengo el UserId y el Name y los agrego a la lista de usuarios
                    foreach (int wFila in grdViewRules.GetSelectedRows())
                    {
                        //rule = new FwkRulesInCategory(((NamedConfigurationElement)(grdViewRules.GetRow(wFila))).Name);
                        rule = (FwkAuthorizationRuleAux)(grdViewRules.GetRow(wFila));
                        wRuleList.Add(rule.Clone < FwkAuthorizationRuleAux>());
                    }

                    grdRules.DoDragDrop(wRuleList, DragDropEffects.Move);

                    //Dejamos seleccionada a la fila que tiene el foco
                    grdViewRules.SelectRow(grdViewRules.FocusedRowHandle);
                }
            }
        }
        #endregion

        #region Eventos y Métodos Drop en el tree
        private void treeList1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }
        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            TreeListNode wOverNode = null;
            TreeListHitInfo wHitInfo = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            if (wHitInfo.Node != null)
                wOverNode = wHitInfo.Node;

            List<FwkAuthorizationRuleAux> wRuleList = (List<FwkAuthorizationRuleAux>)e.Data.GetData(typeof(List<FwkAuthorizationRuleAux>));

            if (wRuleList != null)
            {
                //FwkAuthorizationRuleAux wRule2;
                _ParentFwkCategory = (FwkCategory)treeList1.GetDataRecordByNode(wHitInfo.Node);

                #region Add Rules to Category
                foreach (FwkAuthorizationRuleAux rule in wRuleList)
                {
                    if (!_ParentFwkCategory.FwkRulesInCategoryList.Any<FwkAuthorizationRuleAux>(p => p.Name == rule.Name))
                    {
                        //wRule2 = new FwkAuthorizationRuleAux();
                        //wRule2.Name = rule.Name;
                        //wRule2.CategoryId = _ParentFwkCategory.CategoryId;
                        _ParentFwkCategory.FwkRulesInCategoryList.Add(rule.Clone < FwkAuthorizationRuleAux>());
                        _ParentFwkCategory.EntityState = Fwk.Bases.EntityState.Changed;
                    }
                }
                #endregion
            }
            //Si cambiaron una o mas reglas
            if (_ParentFwkCategory.EntityState == Fwk.Bases.EntityState.Changed)
            {
                FwkMembership.CreateRuleInCategory(_ParentFwkCategory, Membership.ApplicationName);
                //Agrego las rules a la grilla sobre
                grdRulesByCategory.DataSource = _ParentFwkCategory.FwkRulesInCategoryList;
                grdRulesByCategory.RefreshDataSource();
                treeList1.RefreshDataSource();
                _ParentFwkCategory.EntityState = Fwk.Bases.EntityState.Unchanged;
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

        private void treeList1_GetStateImage(object sender, GetStateImageEventArgs e)
        {
           
            //if(e.Node.GetDisplayText("Name") == "Folder")
                e.NodeImageIndex  = e.Node.Expanded ? 1 : 0;

            //else if(e.Node.GetDisplayText("Type") == "File") e.NodeImageIndex = 2;
            //else e.NodeImageIndex = 3;
        }

       

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (_ParentFwkCategory == null) return;
            try
            {
                DialogResult d = DialogResult.Yes;
                
                if (FwkMembership.CategoryContainChilds(_ParentFwkCategory, Membership.ApplicationName))
                {
                    MessageViewInfo.MessageBoxButtons = MessageBoxButtons.YesNo;
                    MessageViewInfo.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Question;
                   d= MessageViewInfo.Show("This Rule category contains sub categories");
               
                }
                if (d == DialogResult.Yes)
                {
                    FwkMembership.RemoveCategory(_ParentFwkCategory, Membership.ApplicationName);
                    MessageViewInfo.Show("Category was successfully removed");
                    

                }
                MessageViewInfo.MessageBoxButtons = MessageBoxButtons.OK;
                PopulateAsync();
            }
            catch (Exception ex)
            {

                MessageViewInfo.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
                
            }
        }

        private void textEdit1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                errorProvider1.SetError(textEdit1, "Category name must not be empty");
            }
            else
            {
                errorProvider1.SetError(textEdit1, string.Empty);
            }
        }

      

       

        private void popupContainerEdit_AddText_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (_ParentFwkCategory == null)
            {
                lblParentCategoryName.Text = String.Empty;
                chkUseParent.Enabled = false;
            }
            else
            {
                chkUseParent.Enabled = true;
                lblParentCategoryName.Text = _ParentFwkCategory.Name;
            }
        }

        private void simpleButton_OkCreateCategory_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textEdit1.Text) && _ParentFwkCategory!=null)
                if (FwkMembership.ExistCategory(textEdit1.Text.Trim(), _ParentFwkCategory.CategoryId, Membership.ApplicationName))
                {
                    MessageViewInfo.Show(string.Format("Category {0} already exist", textEdit1.Text.Trim()));
                    return;
                }
            Create();
        } 
        void Create()
        {

            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageViewInfo.Show("Category name must not be empty");
                textEdit1.Focus();
            }
            FwkCategory wFwkCategory = new FwkCategory();

            wFwkCategory.Name = textEdit1.Text.Trim();
            if (chkUseParent.Checked)
                wFwkCategory.ParentId = _ParentFwkCategory.CategoryId;
            else
                wFwkCategory.ParentId = 0;


            try
            {
                FwkMembership.CreateCategory(wFwkCategory, Membership.ApplicationName);
                MessageViewInfo.Show("Category was successfully created");
                PopulateAsync();
            }
            catch (Exception ex)
            { throw ex; }
        }



        private void txtrulenameEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            RuleFilter();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            RuleFilter();
        }

        void RuleFilter()
        {
            if (string.IsNullOrEmpty(txtrulenameEdit.Text))
            {
                fwkAuthorizationRuleBindingSource.DataSource = _RuleList;
                grdRules.RefreshDataSource();
            }

            var list = from u in _RuleList
                       where u.Name.ToUpper().Contains(txtrulenameEdit.Text.ToUpper())
                       select u;

            fwkAuthorizationRuleBindingSource.DataSource = list.ToList<FwkAuthorizationRuleAux>();
            grdRules.RefreshDataSource();
        }

       

    }
}
