using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraGrid.Views.Base;
using Fwk.Configuration;

namespace Fwk.UI.Controls.ImportControls
{
    [System.ComponentModel.ToolboxItem(true)]
    public class UC_TXTColumnsEditor : UC_UserControlBase
    {
        #region [Designer Code]
        private Fwk.UI.Controls.GridSimpleEditNoGroup grdTxtColumns;
        private System.Windows.Forms.BindingSource tXTColumnsBindingSource;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraGrid.Columns.GridColumn colIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colLength;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit edtName;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit edtLength;
        private Fwk.UI.Controls.GridSimpleEditNoGroupView gridSimpleEditNoGroupView1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grdTxtColumns = new Fwk.UI.Controls.GridSimpleEditNoGroup();
            this.tXTColumnsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridSimpleEditNoGroupView1 = new Fwk.UI.Controls.GridSimpleEditNoGroupView();
            this.colIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtLength = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTxtColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tXTColumnsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSimpleEditNoGroupView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLength)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTxtColumns
            // 
            this.grdTxtColumns.DataSource = this.tXTColumnsBindingSource;
            this.grdTxtColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTxtColumns.Location = new System.Drawing.Point(0, 0);
            this.grdTxtColumns.MainView = this.gridSimpleEditNoGroupView1;
            this.grdTxtColumns.Name = "grdTxtColumns";
            this.grdTxtColumns.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.edtLength,
            this.edtName});
            this.grdTxtColumns.Size = new System.Drawing.Size(375, 419);
            this.grdTxtColumns.TabIndex = 0;
            this.grdTxtColumns.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSimpleEditNoGroupView1});
            // 
            // tXTColumnsBindingSource
            // 
            this.tXTColumnsBindingSource.DataSource = typeof(TXTColumns);
            // 
            // gridSimpleEditNoGroupView1
            // 
            this.gridSimpleEditNoGroupView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIndex,
            this.colName,
            this.colLength});
            this.gridSimpleEditNoGroupView1.GridControl = this.grdTxtColumns;
            this.gridSimpleEditNoGroupView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridSimpleEditNoGroupView1.Name = "gridSimpleEditNoGroupView1";
            this.gridSimpleEditNoGroupView1.NewItemRowText = "Haga click aquí para agregar una nueva fila";
            this.gridSimpleEditNoGroupView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridSimpleEditNoGroupView1.OptionsCustomization.AllowFilter = false;
            this.gridSimpleEditNoGroupView1.OptionsCustomization.AllowGroup = false;
            this.gridSimpleEditNoGroupView1.OptionsDetail.AllowZoomDetail = false;
            this.gridSimpleEditNoGroupView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridSimpleEditNoGroupView1.OptionsFilter.AllowFilterEditor = false;
            this.gridSimpleEditNoGroupView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridSimpleEditNoGroupView1.OptionsMenu.EnableColumnMenu = false;
            this.gridSimpleEditNoGroupView1.OptionsMenu.EnableFooterMenu = false;
            this.gridSimpleEditNoGroupView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridSimpleEditNoGroupView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridSimpleEditNoGroupView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridSimpleEditNoGroupView1.OptionsView.ShowGroupPanel = false;
            this.gridSimpleEditNoGroupView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridSimpleEditNoGroupView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridSimpleEditNoGroupView1_RowUpdated);
            // 
            // colIndex
            // 
            this.colIndex.ColumnEdit = this.edtName;
            this.colIndex.FieldName = "Index";
            this.colIndex.Name = "colIndex";
            // 
            // edtName
            // 
            this.edtName.AutoHeight = false;
            this.edtName.Mask.EditMask = "([a-zA-Z])([A-zA-Z0-9]){0,19}";
            this.edtName.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.edtName.Name = "edtName";
            // 
            // colName
            // 
            this.colName.Caption = "Columna";
            this.colName.ColumnEdit = this.edtName;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowMove = false;
            this.colName.OptionsColumn.AllowShowHide = false;
            this.colName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colName.OptionsFilter.AllowAutoFilter = false;
            this.colName.OptionsFilter.AllowFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 239;
            // 
            // colLength
            // 
            this.colLength.Caption = "Largo";
            this.colLength.ColumnEdit = this.edtLength;
            this.colLength.FieldName = "Length";
            this.colLength.Name = "colLength";
            this.colLength.OptionsColumn.AllowMove = false;
            this.colLength.OptionsColumn.AllowShowHide = false;
            this.colLength.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLength.OptionsFilter.AllowAutoFilter = false;
            this.colLength.OptionsFilter.AllowFilter = false;
            this.colLength.Visible = true;
            this.colLength.VisibleIndex = 1;
            this.colLength.Width = 98;
            // 
            // edtLength
            // 
            this.edtLength.AutoHeight = false;
            this.edtLength.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtLength.IsFloatValue = false;
            this.edtLength.Mask.EditMask = "N00";
            this.edtLength.MaxValue = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.edtLength.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edtLength.Name = "edtLength";
            // 
            // TXTColumnsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.grdTxtColumns);
            this.Name = "TXTColumnsEditor";
            this.Size = new System.Drawing.Size(375, 419);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.TXTColumnsEditor_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.grdTxtColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tXTColumnsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSimpleEditNoGroupView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLength)).EndInit();
            this.ResumeLayout(false);

        }

        public UC_TXTColumnsEditor()
        {
            InitializeComponent();
            _index = 0;
        }
        #endregion

        #region [Fields]
        private TXTColumns _columns;
        private int _index;
        #endregion

        #region [Public Methods]
        public void LoadColumns(TXTColumns columns)
        {
            _columns = columns;
            //grdTxtColumns.DataSource = columns;
            tXTColumnsBindingSource.DataSource = columns;
            tXTColumnsBindingSource.ResetBindings(false);
        }
        #endregion

       
        private void gridSimpleEditNoGroupView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            
            TXTColumn txtColumn = (TXTColumn)e.Row;
            if (!txtColumn.IsValidLength())
            {
                txtColumn.Length = 1;
            }

            if (!txtColumn.IsValidName())
            {
                txtColumn.Name = String.Format("Columna{0}", _index);
                _index++;
            }
              
        }

        
        public bool IsValidRows()
        {
            if (gridSimpleEditNoGroupView1.RowCount <= 0)
            {
                //TODO: ver que pasa con el archivo de configuración
                //gridSimpleEditNoGroupView1.DeleteSelectedRows();
                //gridSimpleEditNoGroupView1.AddNewRow();

                //gridSimpleEditNoGroupView1.SetColumnError(gridSimpleEditNoGroupView1.Columns["Name"],
                //    ConfigurationManager.GetProperty("ImportFileExceptionMessage", "ImportarGrillaSinColumna"));
                return false;
            }
            return true;
        }

        private void TXTColumnsEditor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gridSimpleEditNoGroupView1.RowCount <= 0)
                e.Cancel = true;
        }
    }
}
