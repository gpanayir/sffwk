using System;
using System.Windows.Forms;
using Fwk.Configuration;
using System.ComponentModel;
using Fwk.Security.BE;
using Fwk.Security.ISVC.SearchAllRules;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Linq;
using Fwk.Security.Common;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using Fwk.Security;
using DevExpress.XtraEditors.Controls;
using Fwk.UI.Controller;
using Fwk.UI.Common;
using Fwk.UI.Controls.Menu;
using Fwk.UI.Controls;


namespace Fwk.UI.Security.Controls
{
    [ToolboxItem(true)]
    public partial class UC_RoleMain : Fwk.UI.Controls.UC_UserControlBase
    {
        #region Members
        RolGridList _SelectedRoleGridList = new RolGridList();
        private Rol _SelectedRole;
        private RolGridList _AllRoleList;
        private FwkAuthorizationRuleAuxList _CurrenRulesForRole;
        private FwkAuthorizationRuleAuxList _AllRulesList = null;
        #endregion

        #region Properties
        [Browsable(false)]
        public Rol SelectedRole
        {
            get { return _SelectedRole; }
        }

        [Browsable(false)]
        public RolList SelectedRoles
        {
            get
            {
                return GetSelected();
            }
        }
        [Browsable(false)]
        public RolList CheckedRoles
        {
            get
            {
                return GetChecked();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public RolList AllRoles
        {
            get
            {
                return Fwk.UI.Controller.SecurityController.AllRolList;
            }
        }
        #endregion

        #region Constructor
        public UC_RoleMain()
        {
            InitializeComponent();

            if (!Fwk.HelperFunctions.EnvironmentFunctions.IsInDesigntime())
                toolBarControl1.LoadToolBarFromFile(ConfigurationManager.GetProperty("ApplicationMenu", "SecurityRolesToolbar"));
			
        }
        #endregion


        RolList GetSelected()
        {
            _SelectedRoleGridList.Clear();

            foreach (int i in grdRolesView.GetSelectedRows())
            {
                _SelectedRoleGridList.Add((RolGrid)grdRolesView.GetRow(i)); // agrega siempre
            }

            RolList wRolGridList = new RolList();
            IEnumerable<Rol> selectedList = from r in _SelectedRoleGridList select new Rol { Description = r.RolName, RolName = r.RolName };
            wRolGridList.AddRange(selectedList);
            return wRolGridList;
        }

        RolList GetChecked()
        {
            _SelectedRoleGridList.Clear();

            foreach (int i in grdRolesView.GetSelectedRows())
            {
                if ((bool)grdRolesView.GetRowCellValue(i, colChecked))
                    _SelectedRoleGridList.Add((RolGrid)grdRolesView.GetRow(i)); // agrega si esta en modo OnlyChecked y esta chequeado
            }

            RolList wRolGridList = new RolList();
            IEnumerable<Rol> selectedList = from r in _SelectedRoleGridList select new Rol { Description = r.RolName, RolName = r.RolName };
            wRolGridList.AddRange(selectedList);
            return wRolGridList;
        }

        private void Initialize(bool loadRol)
        {
            _AllRulesList = Fwk.UI.Controller.SecurityController.SearchAllRules();
            _AllRoleList = new RolGridList(Fwk.UI.Controller.SecurityController.AllRolList);

            bindingRoles.DataSource = _AllRoleList;

            grdRoles.RefreshDataSource();
            grdRolesView.RefreshData();

            grdRolesView.SelectRow(0);

            if (loadRol)
            {
                _SelectedRole = ((RolGrid)((BindingSource)grdRoles.DataSource).Current).GetRol();
                LoadRol();
            }
        }


        #region [Botones Toolbar]

        private void ViewDeleteRolw()
        {
            using (FRM_RoleDelete frm = new FRM_RoleDelete())
            {
                frm.Populate(((RolGrid)(bindingRoles.Current)).RolName);
                frm.ShowDialog();
                Fwk.UI.Controller.SecurityController.RefreshSecurity();
                Initialize(true);
            }
        }

        private void ViewNewRole()
        {
            using (FRM_RoleNew frm = new FRM_RoleNew())
            {
                //Preguntamos si el rol esta en blanco de manera que se vuelva a mostrar el diálogo
                while (string.IsNullOrEmpty(frm._RolName))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(frm._RolName) && !frm.RoleExists)
                        {
                            lblSelectedRol.Text = frm._RolName;

                            Fwk.UI.Controller.SecurityController.RefreshSecurity();
                            Initialize(false);
                            //Selecciono el rol recientemente creado
                            _SelectedRole = ((RolGrid)_AllRoleList.First<RolGrid>(p => p.RolName.Equals(frm._RolName))).GetRol();
                            LoadRol();
                        }
                    }
                    else
                        return;
                }
            }
        }


        /// <summary>
        /// TODO: quitar este metodo
        /// </summary>
        private void ViewAssingRole()
        {
            using (FRM_RoleAssign wRoleAssing = new FRM_RoleAssign())
            {
                wRoleAssing.ShowDialog();
                Fwk.UI.Controller.SecurityController.RefreshSecurity();
                Initialize(true);
            }
        }

        #endregion

        #region [Eventos]


        private void toolBarControl1_ToolBarButtonClick(object sender, ButtonClickArgs<Fwk.UI.Controls.Menu.ButtonBase> e)
        {
            if (e.ButtonClicked.GetType() == typeof(Fwk.UI.Controls.Menu.ButtonBase))
            {

                switch (e.ButtonClicked.Id)
                {
                    case "btnNewRole":
                        ViewNewRole();
                        break;
                    case "btnRoleDelete":
                        ViewDeleteRolw();
                        break;
                    case "btnRoleAssing":
                        ViewAssingRole();
                        break;
                    default:
                        break;
                }
            }
        }

        private void UC_RoleMain_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                toolBarControl1.PerformAuthorization();
                Initialize(true);
            }
        }

        #endregion


        void LoadRol()
        {
            lblSelectedRol.Text = _SelectedRole.RolName;

            #region Carga de las reglas pertenecientes al rol
            var rules_byRol = from s in _AllRulesList where s.Expression.Contains(string.Concat("R:", _SelectedRole.RolName)) select s;
            _CurrenRulesForRole.AddRange(rules_byRol.ToList<FwkAuthorizationRuleAux>());
            FwkAuthorizationRuleListBindingSource.DataSource = _CurrenRulesForRole;
            grdRules.RefreshDataSource();
            #endregion
        }
        
        private void btnAddSelectedRules_Click(object sender, EventArgs e)
        {

            if (_SelectedRole == null)
            {
                MessageViewer.Show("Por favor seleccione un rol al cual agregarle las reglas seleccionadas");
                return;
            }

            using (FRM_RuleSelector frm = new FRM_RuleSelector())
            {
                FwkAuthorizationRuleAuxList wRulesForRole_ToUpdate;
                DialogResult wResult = frm.ShowDialog();
                if (wResult == DialogResult.OK)
                {
                    if (_CurrenRulesForRole == null)
                        _CurrenRulesForRole = new FwkAuthorizationRuleAuxList();

                    wRulesForRole_ToUpdate = new FwkAuthorizationRuleAuxList();
                    foreach (FwkAuthorizationRuleAux rules in frm.SelectedRules)
                    {
                        //Si la regla ya existia vinculada al rol no la agrega
                        if (!_CurrenRulesForRole.Any<FwkAuthorizationRuleAux>(p => p.Name.Equals(rules.Name, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            _CurrenRulesForRole.Add((FwkAuthorizationRuleAux)rules.Clone());
                            wRulesForRole_ToUpdate.Add((FwkAuthorizationRuleAux)rules.Clone());
                        }
                    }

                    Fwk.UI.Controls.SimpleMessageView.Show(string.Format("La/s regla/s fueron asociadas al rol {0} correctamente", _SelectedRole), "Pelsoft", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Information);

                    if (wRulesForRole_ToUpdate == null)
                        return;
                    if (wRulesForRole_ToUpdate.Count() == 0)
                        return;

                    Fwk.UI.Controller.SecurityController.RulesUpdateService(_SelectedRole, wRulesForRole_ToUpdate, false);
                    grdRules.RefreshDataSource();
                    
                    Initialize(true);
                }

            }

        }

        #region [Quit Rules]
        private void removeSelectedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuitRules();
        }

        private void btnRemoveRules_Click(object sender, EventArgs e)
        {
            QuitRules();
        }

        private void grdRules_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                QuitRules();
        }

        private void QuitRules()
        {
            FwkAuthorizationRuleAux wSelRulesBE;
            ///Lista auxiliar para reprecentar las reglas a mofdificar.-
            FwkAuthorizationRuleAuxList wRulesForRole_ToUpdate = new FwkAuthorizationRuleAuxList();
            if (_CurrenRulesForRole == null) _CurrenRulesForRole = new FwkAuthorizationRuleAuxList();

            System.Text.StringBuilder str = new System.Text.StringBuilder("Se eliminarán las siguientes reglas de la base de datos:");
            str.AppendLine(Environment.NewLine);

            foreach (int index in grdViewRules.GetSelectedRows())
            {
                wSelRulesBE = (FwkAuthorizationRuleAux)grdViewRules.GetRow(index);
                //Esta es la lista de reglas q se envian al controller para q le actualice el Rol (se los quite)
                wRulesForRole_ToUpdate.Add((FwkAuthorizationRuleAux)wSelRulesBE.Clone());
                str.AppendLine(wSelRulesBE.Name);
            }

            str.AppendLine();
            str.AppendLine("¿Desea continuar?");

            if (Fwk.UI.Controls.SimpleMessageView.Show(str.ToString(), "Pelsoft", MessageBoxButtons.YesNo, Fwk.UI.Common.MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SecurityController.RulesUpdateService(_SelectedRole, wRulesForRole_ToUpdate, true);
                Fwk.UI.Controls.SimpleMessageView.Show(string.Format("El rol {0} fue actualizado con éxito", _SelectedRole), "Pelsoft", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Information);
                grdViewRules.ClearSelection();
                Initialize(true);
            }
            
            
            //MessageViewer.MessageBoxIcon = Fwk.UI.Controls.MessageView.MessageBoxIcon.Question;
            //MessageViewer.MessageBoxButtons = MessageBoxButtons.OKCancel;
            
            //if (MessageViewer.Show(str.ToString()) == DialogResult.OK)
            //{
            //    Fwk.UI.Controller.SecurityController.RulesUpdateService(_SelectedRole, wRulesForRole_ToUpdate, true);
            //    grdViewRules.ClearSelection();

            //    Initialize(true);
            //}
            

            this.SetMessageViewInfoDefault();
        }

        #endregion

        private void grdRolesView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (((BindingSource)grdRoles.DataSource).Current == null)
                return;

            _SelectedRole = ((RolGrid)((BindingSource)grdRoles.DataSource).Current).GetRol();

            lblSelectedRol.Text = _SelectedRole.RolName;
            LoadRol();
        }

        private void uC_RolesGrid1_OnRolClick(object sender, EventArgs e)
        {
            _SelectedRole = (Rol)sender;

        }

    }
}
