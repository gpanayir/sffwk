namespace Fwk.UI.Security.Controls
{
    partial class UC_RolesGrid
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
            this.bindingRoles = new System.Windows.Forms.BindingSource(this.components);
            this.grdRoles = new DevExpress.XtraGrid.GridControl();
            this.grdRolesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSelectedRol = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRolesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingRoles
            // 
            this.bindingRoles.DataSource = typeof(Fwk.UI.Security.Controls.RolGrid);
            // 
            // grdRoles
            // 
            this.grdRoles.DataSource = this.bindingRoles;
            this.grdRoles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdRoles.Location = new System.Drawing.Point(0, 23);
            this.grdRoles.MainView = this.grdRolesView;
            this.grdRoles.Name = "grdRoles";
            this.grdRoles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdRoles.Size = new System.Drawing.Size(249, 223);
            this.grdRoles.TabIndex = 9;
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
            this.grdRolesView.OptionsMenu.EnableColumnMenu = false;
            this.grdRolesView.OptionsMenu.EnableFooterMenu = false;
            this.grdRolesView.OptionsSelection.InvertSelection = true;
            this.grdRolesView.OptionsSelection.MultiSelect = true;
            this.grdRolesView.OptionsView.ShowColumnHeaders = false;
            this.grdRolesView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grdRolesView.OptionsView.ShowGroupPanel = false;
            this.grdRolesView.OptionsView.ShowHorzLines = false;
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
            this.colChecked.Visible = true;
            this.colChecked.VisibleIndex = 0;
            this.colChecked.Width = 48;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colRolName
            // 
            this.colRolName.Caption = "Nombre del rol";
            this.colRolName.FieldName = "RolName";
            this.colRolName.Name = "colRolName";
            this.colRolName.OptionsColumn.AllowEdit = false;
            this.colRolName.OptionsColumn.ReadOnly = true;
            this.colRolName.OptionsFilter.AllowAutoFilter = false;
            this.colRolName.OptionsFilter.AllowFilter = false;
            this.colRolName.Visible = true;
            this.colRolName.VisibleIndex = 1;
            this.colRolName.Width = 112;
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
            this.colDescription.Width = 194;
            // 
            // lblSelectedRol
            // 
            this.lblSelectedRol.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSelectedRol.Appearance.Options.UseFont = true;
            this.lblSelectedRol.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSelectedRol.Location = new System.Drawing.Point(0, 0);
            this.lblSelectedRol.Name = "lblSelectedRol";
            this.lblSelectedRol.Size = new System.Drawing.Size(249, 19);
            this.lblSelectedRol.TabIndex = 34;
            this.lblSelectedRol.Text = "lblRol";
            // 
            // UC_RolesGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelectedRol);
            this.Controls.Add(this.grdRoles);
            this.Name = "UC_RolesGrid";
            this.Size = new System.Drawing.Size(249, 246);
            this.Load += new System.EventHandler(this.UC_RolesGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRolesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingRoles;
        private DevExpress.XtraGrid.Views.Grid.GridView grdRolesView;
        private DevExpress.XtraGrid.Columns.GridColumn colRolName;
        private DevExpress.XtraEditors.LabelControl lblSelectedRol;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colChecked;
        private DevExpress.XtraGrid.GridControl grdRoles;
    }
}
