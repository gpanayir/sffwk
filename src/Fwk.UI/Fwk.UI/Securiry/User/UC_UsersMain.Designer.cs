using Fwk.UI.Controls;
using Fwk.Security.Common;
namespace Fwk.UI.Security.Controls
{
    partial class UC_UsersMain
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colActiveFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolBarControl1 = new Fwk.UI.Controls.Menu.UC_ToolBarControl();
            this.grdUsers = new Fwk.UI.Controls.GridNoEditWithGroup();
            this.bindingUsersList = new System.Windows.Forms.BindingSource(this.components);
            this.gridNoEditWithGroupView1 = new Fwk.UI.Controls.GridNoEditWithGroupView();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLockedOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textFind1 = new Fwk.UI.Controls.UC_TextFind();
            this.chkActiveFlag = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingUsersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNoEditWithGroupView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActiveFlag.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colActiveFlag
            // 
            this.colActiveFlag.FieldName = "ActiveFlag";
            this.colActiveFlag.Name = "colActiveFlag";
            this.colActiveFlag.OptionsColumn.AllowEdit = false;
            this.colActiveFlag.OptionsColumn.AllowShowHide = false;
            this.colActiveFlag.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colActiveFlag.OptionsFilter.AllowAutoFilter = false;
            this.colActiveFlag.OptionsFilter.AllowFilter = false;
            // 
            // toolBarControl1
            // 
            this.toolBarControl1.AcceptButton = null;
            this.toolBarControl1.AllowCheckAuthorization = false;
            this.toolBarControl1.CancelButton = null;
            this.toolBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarControl1.Location = new System.Drawing.Point(0, 0);
            this.toolBarControl1.Name = "toolBarControl1";
            this.toolBarControl1.Size = new System.Drawing.Size(847, 66);
            this.toolBarControl1.TabIndex = 0;
            this.toolBarControl1.ToolBar = null;
            this.toolBarControl1.ToolBarButtonClick += new Fwk.UI.Controls.Menu.ToolBarButtonClickHandler(this.toolBarControl1_ToolBarButtonClick);
            // 
            // grdUsers
            // 
            this.grdUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUsers.DataSource = this.bindingUsersList;
            this.grdUsers.Location = new System.Drawing.Point(0, 98);
            this.grdUsers.MainView = this.gridNoEditWithGroupView1;
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.Size = new System.Drawing.Size(847, 364);
            this.grdUsers.TabIndex = 1;
            this.grdUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridNoEditWithGroupView1});
            // 
            // bindingUsersList
            // 
            this.bindingUsersList.DataSource = typeof(UserList);
            // 
            // gridNoEditWithGroupView1
            // 
            this.gridNoEditWithGroupView1.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gridNoEditWithGroupView1.Appearance.EvenRow.BackColor2 = System.Drawing.SystemColors.ButtonFace;
            this.gridNoEditWithGroupView1.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridNoEditWithGroupView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridNoEditWithGroupView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colUserName,
            this.colIsLockedOut,
            this.colEmail,
            this.colActiveFlag});
            this.gridNoEditWithGroupView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            styleFormatCondition1.Appearance.BorderColor = System.Drawing.Color.Silver;
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBorderColor = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colActiveFlag;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = false;
            this.gridNoEditWithGroupView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridNoEditWithGroupView1.GridControl = this.grdUsers;
            this.gridNoEditWithGroupView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.gridNoEditWithGroupView1.GroupPanelText = "Arrastre el encabezado de la columna por la cual desea agrupar aquí";
            this.gridNoEditWithGroupView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridNoEditWithGroupView1.Name = "gridNoEditWithGroupView1";
            this.gridNoEditWithGroupView1.OptionsBehavior.Editable = false;
            this.gridNoEditWithGroupView1.OptionsCustomization.AllowFilter = false;
            this.gridNoEditWithGroupView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridNoEditWithGroupView1.OptionsCustomization.AllowRowSizing = true;
            this.gridNoEditWithGroupView1.OptionsDetail.AllowZoomDetail = false;
            this.gridNoEditWithGroupView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridNoEditWithGroupView1.OptionsFilter.AllowFilterEditor = false;
            this.gridNoEditWithGroupView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridNoEditWithGroupView1.OptionsMenu.EnableColumnMenu = false;
            this.gridNoEditWithGroupView1.OptionsMenu.EnableFooterMenu = false;
            this.gridNoEditWithGroupView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridNoEditWithGroupView1.OptionsView.RowAutoHeight = true;
            this.gridNoEditWithGroupView1.OptionsView.ShowGroupPanel = false;
            this.gridNoEditWithGroupView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.gridNoEditWithGroupView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFullName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridNoEditWithGroupView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "Nombre";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.AllowEdit = false;
            this.colFullName.OptionsColumn.AllowShowHide = false;
            this.colFullName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colFullName.OptionsFilter.AllowAutoFilter = false;
            this.colFullName.OptionsFilter.AllowFilter = false;
            this.colFullName.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 0;
            this.colFullName.Width = 213;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Usuario";
            this.colUserName.FieldName = "Name";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.AllowShowHide = false;
            this.colUserName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colUserName.OptionsFilter.AllowAutoFilter = false;
            this.colUserName.OptionsFilter.AllowFilter = false;
            this.colUserName.Width = 224;
            // 
            // colIsLockedOut
            // 
            this.colIsLockedOut.Caption = "Bloqueado";
            this.colIsLockedOut.FieldName = "IsLockedOut";
            this.colIsLockedOut.Name = "colIsLockedOut";
            this.colIsLockedOut.OptionsColumn.AllowEdit = false;
            this.colIsLockedOut.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colIsLockedOut.OptionsColumn.AllowShowHide = false;
            this.colIsLockedOut.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colIsLockedOut.OptionsColumn.ReadOnly = true;
            this.colIsLockedOut.OptionsFilter.AllowAutoFilter = false;
            this.colIsLockedOut.OptionsFilter.AllowFilter = false;
            this.colIsLockedOut.Width = 220;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "Mail";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.AllowEdit = false;
            this.colEmail.OptionsColumn.AllowShowHide = false;
            this.colEmail.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colEmail.OptionsFilter.AllowAutoFilter = false;
            this.colEmail.OptionsFilter.AllowFilter = false;
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 1;
            this.colEmail.Width = 221;
            // 
            // textFind1
            // 
            this.textFind1.Location = new System.Drawing.Point(3, 62);
            this.textFind1.Name = "textFind1";
            this.textFind1.Size = new System.Drawing.Size(438, 30);
            this.textFind1.TabIndex = 2;
            this.textFind1.OnFindTextBoxEnter += new System.EventHandler(this.textFind1_OnFindTextBoxEnter);
            this.textFind1.OnFindClick += new System.EventHandler(this.textFind1_OnFindClick);
            // 
            // chkActiveFlag
            // 
            this.chkActiveFlag.Location = new System.Drawing.Point(466, 68);
            this.chkActiveFlag.Name = "chkActiveFlag";
            this.chkActiveFlag.Properties.Caption = "Mostrar usuarios no vigentes";
            this.chkActiveFlag.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkActiveFlag.Properties.DisplayValueChecked = "Vigentes";
            this.chkActiveFlag.Properties.DisplayValueGrayed = "Todos";
            this.chkActiveFlag.Properties.DisplayValueUnchecked = "No vigentes";
            this.chkActiveFlag.Size = new System.Drawing.Size(191, 22);
            this.chkActiveFlag.TabIndex = 41;
            this.chkActiveFlag.ToolTip = "Indica si el usuario estara activo o vigente.-";
            this.chkActiveFlag.CheckedChanged += new System.EventHandler(this.chkActiveFlag_CheckedChanged);
            // 
            // UC_UsersMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkActiveFlag);
            this.Controls.Add(this.textFind1);
            this.Controls.Add(this.grdUsers);
            this.Controls.Add(this.toolBarControl1);
            this.Name = "UC_UsersMain";
            this.Size = new System.Drawing.Size(847, 462);
            this.Load += new System.EventHandler(this.UC_UsersMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingUsersList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNoEditWithGroupView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActiveFlag.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Controls.Menu.UC_ToolBarControl toolBarControl1;
        private GridNoEditWithGroup grdUsers;
        private GridNoEditWithGroupView gridNoEditWithGroupView1;
        private System.Windows.Forms.BindingSource bindingUsersList;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLockedOut;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private Fwk.UI.Controls.UC_TextFind textFind1;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraEditors.CheckEdit chkActiveFlag;
        private DevExpress.XtraGrid.Columns.GridColumn colActiveFlag;

    }
}
