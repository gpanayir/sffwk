using Fwk.UI.Controls;
namespace Fwk.UI.Security.Controls
{
    partial class UC_RuleSelector
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
            this.grdRules = new Fwk.UI.Controls.GridNoEditWithGroup();
            this.authorizationRuleDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridNoEditWithGroupView1 = new Fwk.UI.Controls.GridNoEditWithGroupView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSelectedRule = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorizationRuleDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNoEditWithGroupView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRules
            // 
            this.grdRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRules.DataSource = this.authorizationRuleDataBindingSource;
            this.grdRules.Location = new System.Drawing.Point(3, 8);
            this.grdRules.MainView = this.gridNoEditWithGroupView1;
            this.grdRules.Name = "grdRules";
            this.grdRules.Size = new System.Drawing.Size(543, 295);
            this.grdRules.TabIndex = 0;
            this.grdRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridNoEditWithGroupView1});
            this.grdRules.DoubleClick += new System.EventHandler(this.grdRules_DoubleClick);
            this.grdRules.Click += new System.EventHandler(this.grdRules_Click);
            // 
            // authorizationRuleDataBindingSource
            // 
            this.authorizationRuleDataBindingSource.DataSource = typeof(Microsoft.Practices.EnterpriseLibrary.Security.Configuration.AuthorizationRuleData);
            // 
            // gridNoEditWithGroupView1
            // 
            this.gridNoEditWithGroupView1.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gridNoEditWithGroupView1.Appearance.EvenRow.BackColor2 = System.Drawing.SystemColors.ButtonFace;
            this.gridNoEditWithGroupView1.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridNoEditWithGroupView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridNoEditWithGroupView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName});
            this.gridNoEditWithGroupView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridNoEditWithGroupView1.GridControl = this.grdRules;
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
            // colName
            // 
            this.colName.Caption = "Rul name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 82;
            // 
            // lblSelectedRule
            // 
            this.lblSelectedRule.Location = new System.Drawing.Point(11, 8);
            this.lblSelectedRule.Name = "lblSelectedRule";
            this.lblSelectedRule.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedRule.TabIndex = 1;
            // 
            // UC_RuleSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelectedRule);
            this.Controls.Add(this.grdRules);
            this.Name = "UC_RuleSelector";
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorizationRuleDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNoEditWithGroupView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fwk.UI.Controls.GridNoEditWithGroup grdRules;
        private Fwk.UI.Controls.GridNoEditWithGroupView gridNoEditWithGroupView1;
        private System.Windows.Forms.BindingSource authorizationRuleDataBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.LabelControl lblSelectedRule;
    }
}
