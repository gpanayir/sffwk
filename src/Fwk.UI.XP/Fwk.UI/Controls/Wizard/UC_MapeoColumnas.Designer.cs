namespace Fwk.UI.Controls.Wizard
{
    partial class UC_MapeoColumnas
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.columnsMappingBEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDestino = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequerido = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsMappingBEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDestino)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.columnsMappingBEBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repDestino});
            this.gridControl1.Size = new System.Drawing.Size(495, 332);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // columnsMappingBEBindingSource
            // 
            this.columnsMappingBEBindingSource.DataSource = typeof(Fwk.UI.Controls.Wizard.BE.ColumnsMappingBE);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrigen,
            this.colDestino,
            this.colRequerido});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowRowSizing = true;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colOrigen
            // 
            this.colOrigen.Caption = "Origen";
            this.colOrigen.ColumnEdit = this.repDestino;
            this.colOrigen.FieldName = "ColumnSource";
            this.colOrigen.Name = "colOrigen";
            this.colOrigen.Visible = true;
            this.colOrigen.VisibleIndex = 1;
            // 
            // repDestino
            // 
            this.repDestino.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.repDestino.AutoHeight = false;
            this.repDestino.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDestino.Name = "repDestino";
            this.repDestino.NullText = "Seleccione el Destino ...";
            // 
            // colDestino
            // 
            this.colDestino.Caption = "Destino";
            this.colDestino.FieldName = "ColumnTarget";
            this.colDestino.Name = "colDestino";
            this.colDestino.OptionsColumn.AllowEdit = false;
            this.colDestino.Visible = true;
            this.colDestino.VisibleIndex = 0;
            // 
            // colRequerido
            // 
            this.colRequerido.Caption = "Requerido";
            this.colRequerido.FieldName = "Required";
            this.colRequerido.Name = "colRequerido";
            // 
            // UC_MapeoColumnas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "UC_MapeoColumnas";
            this.Size = new System.Drawing.Size(495, 332);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsMappingBEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDestino)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDestino;
        private DevExpress.XtraGrid.Columns.GridColumn colOrigen;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repDestino;
        private System.Windows.Forms.BindingSource columnsMappingBEBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colRequerido;
    }
}
