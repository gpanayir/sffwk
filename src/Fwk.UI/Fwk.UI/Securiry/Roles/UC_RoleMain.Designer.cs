using Fwk.Security.BE;

namespace Fwk.UI.Security.Controls
{
    partial class UC_RoleMain
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolBarControl1 = new Fwk.UI.Controls.Menu.UC_ToolBarControl();
            this.bindingRoles = new System.Windows.Forms.BindingSource(this.components);
            this.grdRoles = new DevExpress.XtraGrid.GridControl();
            this.grdRolesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemoveRules = new DevExpress.XtraEditors.SimpleButton();
            this.lblSelectedRol = new DevExpress.XtraEditors.LabelControl();
            this.btnAddSelectedRules = new DevExpress.XtraEditors.SimpleButton();
            this.grdRules = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FwkAuthorizationRuleListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdViewRules = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridNoEditWithGroupView1 = new Fwk.UI.Controls.GridNoEditWithGroupView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRolesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FwkAuthorizationRuleListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNoEditWithGroupView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBarControl1
            // 
            this.toolBarControl1.AcceptButton = null;
            this.toolBarControl1.AllowCheckAuthorization = false;
            this.toolBarControl1.CancelButton = null;
            this.toolBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarControl1.Location = new System.Drawing.Point(0, 0);
            this.toolBarControl1.Name = "toolBarControl1";
            this.toolBarControl1.Size = new System.Drawing.Size(672, 58);
            this.toolBarControl1.TabIndex = 0;
            this.toolBarControl1.ToolBar = null;
            this.toolBarControl1.ToolBarButtonClick += new Fwk.UI.Controls.Menu.ToolBarButtonClickHandler(this.toolBarControl1_ToolBarButtonClick);
            // 
            // bindingRoles
            // 
            this.bindingRoles.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // grdRoles
            // 
            this.grdRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRoles.DataSource = this.bindingRoles;
            this.grdRoles.Location = new System.Drawing.Point(11, 97);
            this.grdRoles.MainView = this.grdRolesView;
            this.grdRoles.Name = "grdRoles";
            this.grdRoles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdRoles.Size = new System.Drawing.Size(246, 338);
            this.grdRoles.TabIndex = 36;
            this.grdRoles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdRolesView});
            // 
            // grdRolesView
            // 
            this.grdRolesView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChecked,
            this.colRolName,
            this.colDescription});
            this.grdRolesView.GridControl = this.grdRoles;
            this.grdRolesView.Name = "grdRolesView";
            this.grdRolesView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.grdRolesView.OptionsCustomization.AllowFilter = false;
            this.grdRolesView.OptionsCustomization.AllowGroup = false;
            this.grdRolesView.OptionsCustomization.AllowQuickHideColumns = false;
            this.grdRolesView.OptionsFilter.AllowFilterEditor = false;
            this.grdRolesView.OptionsMenu.EnableColumnMenu = false;
            this.grdRolesView.OptionsMenu.EnableFooterMenu = false;
            this.grdRolesView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdRolesView.OptionsView.ShowGroupPanel = false;
            this.grdRolesView.OptionsView.ShowIndicator = false;
            this.grdRolesView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdRolesView_FocusedRowChanged);
            // 
            // colChecked
            // 
            this.colChecked.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colChecked.FieldName = "Checked";
            this.colChecked.Name = "colChecked";
            this.colChecked.OptionsFilter.AllowAutoFilter = false;
            this.colChecked.OptionsFilter.AllowFilter = false;
            this.colChecked.Width = 48;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colRolName
            // 
            this.colRolName.Caption = "Roles";
            this.colRolName.FieldName = "RolName";
            this.colRolName.Name = "colRolName";
            this.colRolName.OptionsColumn.AllowEdit = false;
            this.colRolName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colRolName.OptionsColumn.AllowMove = false;
            this.colRolName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colRolName.OptionsColumn.ReadOnly = true;
            this.colRolName.OptionsFilter.AllowAutoFilter = false;
            this.colRolName.OptionsFilter.AllowFilter = false;
            this.colRolName.Visible = true;
            this.colRolName.VisibleIndex = 0;
            this.colRolName.Width = 153;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Desc";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.OptionsFilter.AllowAutoFilter = false;
            this.colDescription.OptionsFilter.AllowFilter = false;
            this.colDescription.Width = 153;
            // 
            // btnRemoveRules
            // 
            this.btnRemoveRules.Image = global::Fwk.UI.Properties.Resources.file_del_16;
            this.btnRemoveRules.Location = new System.Drawing.Point(421, 97);
            this.btnRemoveRules.Name = "btnRemoveRules";
            this.btnRemoveRules.Size = new System.Drawing.Size(106, 23);
            this.btnRemoveRules.TabIndex = 34;
            this.btnRemoveRules.Text = "Quitar reglas ";
            this.btnRemoveRules.Click += new System.EventHandler(this.btnRemoveRules_Click);
            // 
            // lblSelectedRol
            // 
            this.lblSelectedRol.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSelectedRol.Appearance.Options.UseFont = true;
            this.lblSelectedRol.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSelectedRol.Location = new System.Drawing.Point(17, 76);
            this.lblSelectedRol.Name = "lblSelectedRol";
            this.lblSelectedRol.Size = new System.Drawing.Size(225, 19);
            this.lblSelectedRol.TabIndex = 33;
            // 
            // btnAddSelectedRules
            // 
            this.btnAddSelectedRules.Image = global::Fwk.UI.Properties.Resources.file_new_16;
            this.btnAddSelectedRules.Location = new System.Drawing.Point(299, 97);
            this.btnAddSelectedRules.Name = "btnAddSelectedRules";
            this.btnAddSelectedRules.Size = new System.Drawing.Size(106, 23);
            this.btnAddSelectedRules.TabIndex = 12;
            this.btnAddSelectedRules.Text = "Agregar reglas ";
            this.btnAddSelectedRules.Click += new System.EventHandler(this.btnAddSelectedRules_Click);
            // 
            // grdRules
            // 
            this.grdRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRules.ContextMenuStrip = this.contextMenuStrip1;
            this.grdRules.DataSource = this.FwkAuthorizationRuleListBindingSource;
            this.grdRules.Location = new System.Drawing.Point(297, 126);
            this.grdRules.MainView = this.grdViewRules;
            this.grdRules.Name = "grdRules";
            this.grdRules.Size = new System.Drawing.Size(367, 308);
            this.grdRules.TabIndex = 32;
            this.grdRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewRules,
            this.gridView3});
            this.grdRules.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdRules_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 26);
            // 
            // removeSelectedsToolStripMenuItem
            // 
            this.removeSelectedsToolStripMenuItem.Image = global::Fwk.UI.Properties.Resources.file_del_16;
            this.removeSelectedsToolStripMenuItem.Name = "removeSelectedsToolStripMenuItem";
            this.removeSelectedsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.removeSelectedsToolStripMenuItem.Text = "Quitar";
            this.removeSelectedsToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedsToolStripMenuItem_Click);
            // 
            // FwkAuthorizationRuleListBindingSource
            // 
            this.FwkAuthorizationRuleListBindingSource.DataSource = typeof(Fwk.Security.FwkAuthorizationRule);
            // 
            // grdViewRules
            // 
            this.grdViewRules.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.grdViewRules.GridControl = this.grdRules;
            this.grdViewRules.Name = "grdViewRules";
            this.grdViewRules.OptionsFilter.AllowFilterEditor = false;
            this.grdViewRules.OptionsLayout.Columns.AddNewColumns = false;
            this.grdViewRules.OptionsMenu.EnableColumnMenu = false;
            this.grdViewRules.OptionsMenu.EnableFooterMenu = false;
            this.grdViewRules.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdViewRules.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.grdViewRules.OptionsSelection.InvertSelection = true;
            this.grdViewRules.OptionsSelection.MultiSelect = true;
            this.grdViewRules.OptionsSelection.UseIndicatorForSelection = false;
            this.grdViewRules.OptionsView.ShowColumnHeaders = false;
            this.grdViewRules.OptionsView.ShowDetailButtons = false;
            this.grdViewRules.OptionsView.ShowGroupPanel = false;
            this.grdViewRules.OptionsView.ShowIndicator = false;
            this.grdViewRules.OptionsView.ShowVertLines = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.grdRules;
            this.gridView3.Name = "gridView3";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(301, 78);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(155, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Reglas vinculadas con el rol";
            // 
            // gridNoEditWithGroupView1
            // 
            this.gridNoEditWithGroupView1.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gridNoEditWithGroupView1.Appearance.EvenRow.BackColor2 = System.Drawing.SystemColors.ButtonFace;
            this.gridNoEditWithGroupView1.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridNoEditWithGroupView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridNoEditWithGroupView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridNoEditWithGroupView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.gridNoEditWithGroupView1.GroupPanelText = "Arrastre el encabezado de la columna por la cual desea agrupar aquí";
            this.gridNoEditWithGroupView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridNoEditWithGroupView1.Name = "gridNoEditWithGroupView1";
            this.gridNoEditWithGroupView1.OptionsBehavior.Editable = false;
            this.gridNoEditWithGroupView1.OptionsCustomization.AllowRowSizing = true;
            this.gridNoEditWithGroupView1.OptionsDetail.AllowZoomDetail = false;
            this.gridNoEditWithGroupView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridNoEditWithGroupView1.OptionsFilter.AllowFilterEditor = false;
            this.gridNoEditWithGroupView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridNoEditWithGroupView1.OptionsMenu.EnableFooterMenu = false;
            this.gridNoEditWithGroupView1.OptionsView.RowAutoHeight = true;
            this.gridNoEditWithGroupView1.OptionsView.ShowAutoFilterRow = true;
            this.gridNoEditWithGroupView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.gridNoEditWithGroupView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // UC_RoleMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdRoles);
            this.Controls.Add(this.toolBarControl1);
            this.Controls.Add(this.lblSelectedRol);
            this.Controls.Add(this.btnRemoveRules);
            this.Controls.Add(this.btnAddSelectedRules);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdRules);
            this.Name = "UC_RoleMain";
            this.Size = new System.Drawing.Size(672, 445);
            this.Load += new System.EventHandler(this.UC_RoleMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRolesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FwkAuthorizationRuleListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNoEditWithGroupView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fwk.UI.Controls.Menu.UC_ToolBarControl toolBarControl1;
        private System.Windows.Forms.BindingSource bindingRoles;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Fwk.UI.Controls.GridNoEditWithGroupView gridNoEditWithGroupView1;
        private DevExpress.XtraGrid.GridControl grdRules;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewRules;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.BindingSource FwkAuthorizationRuleListBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnAddSelectedRules;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedsToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl lblSelectedRol;
        private DevExpress.XtraEditors.SimpleButton btnRemoveRules;
        public DevExpress.XtraGrid.GridControl grdRoles;
        private DevExpress.XtraGrid.Views.Grid.GridView grdRolesView;
        private DevExpress.XtraGrid.Columns.GridColumn colChecked;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colRolName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;

    }
}
