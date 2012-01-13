using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList.ViewInfo;
using Fwk.UI.Controller;
using DevExpress.XtraGrid.Columns;


namespace Fwk.UI.Security.Controls
{
    [DefaultEvent("OnRolClick")]
    [ToolboxItem(true)]
    public partial class UC_RolesGrid : Fwk.UI.Controls.UC_UserControlBase
    {
        #region Members
        Rol _SelectedRole;
        RolGridList _AllRoles ;
        RolGridList _SelectedRoleGridList = new RolGridList ();
        bool _OnlyChecked = false;
        
        [Category("Bigbang")]
        public event EventHandler OnRolClick;
        #endregion

        #region Properties
        [Browsable(true)]
        [Category("Bigbang")]
        public bool OnlyChecked
        {
            get
            {
                return _OnlyChecked;
            }
            set 
            {
                _OnlyChecked = value;
            }
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
        #endregion

        #region Constructor
        public UC_RolesGrid()
        {
            InitializeComponent();
        }
        #endregion


        private void grdRolesView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (((BindingSource)grdRoles.DataSource).Current == null) 
                return;
            _SelectedRole = ((RolGrid)((BindingSource)grdRoles.DataSource).Current).GetRol();

            lblSelectedRol.Text = _SelectedRole.RolName;

            if (OnRolClick!=null)
                OnRolClick(_SelectedRole,new EventArgs ());
        }
      
        public  void Initialize()
        {
            #region Carga los roles  grdRoles y los mapea a una coleccion de roles de la grilla RolGridList
          
             _AllRoles = new RolGridList(Fwk.UI.Controller.SecurityController.AllRolList);

            bindingRoles.DataSource = _AllRoles;

            grdRoles.RefreshDataSource();
            grdRolesView.RefreshData();
            #endregion

            //Establezco la primera fila como la fila seleccionada
            grdRolesView.SelectRow(0);
            _SelectedRole = ((RolGrid)((BindingSource)grdRoles.DataSource).Current).GetRol();
       }

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
            RolList wRolList = new RolList();
            IEnumerable<Rol> selectedList = from r in _AllRoles where r.Checked select new Rol { Description = r.RolName, RolName = r.RolName };
            wRolList.AddRange(selectedList);
            return wRolList;
        }

        /// <summary>
        /// Chekea los roles de la grilla con los roles pasados por parametro
        /// </summary>
        /// <param name="checkedRoles">Lista de roles a marcar como chequeados</param>
        public void PopulatePreChecked(RolList checkedRoles)
        {
            if (checkedRoles == null) 
                return;

            foreach (RolGrid rol in _AllRoles)
            {
                rol.Checked = checkedRoles.Any<Rol>(p => p.RolName.Equals(rol.RolName));
            }

            grdRoles.RefreshDataSource();
        }

        public void UnchekAllRoles()
        {
            foreach (RolGrid rol in _AllRoles)
            {
                rol.Checked = false;
            }

            grdRoles.RefreshDataSource();
        }

        private void UC_RolesGrid_Load(object sender, EventArgs e)
        {
            //grdRolesView.BeginInit();
            //if (_OnlyChecked)
            //{
            //    colChecked.Visible = true;
            //    colDescription.OptionsColumn.AllowEdit = false;
            //    colRolName.OptionsColumn.AllowEdit = false;
            //    colRolName.OptionsColumn.ReadOnly = true;
            //    //grdRolesView.OptionsSelection.MultiSelect = false;
            //}
            //else
            //{
            //    colChecked.Visible = false;
            //}
            //grdRolesView.EndInit();
        }

    }
}
