﻿namespace Fwk.Security.Admin
{
    partial class UsersGrid
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
            this.label9 = new System.Windows.Forms.Label();
            this.userByAppBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastActivityDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLockedOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userByAppBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::Fwk.Security.Admin.Properties.Resources.Users;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(4, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 28);
            this.label9.TabIndex = 18;
            this.label9.Text = "Users";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userByAppBindingSource
            // 
            this.userByAppBindingSource.DataSource = typeof(Fwk.Security.Common.User);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(7, 42);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(373, 22);
            this.textEdit1.TabIndex = 19;
            this.textEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit1_KeyPress);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.userByAppBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(7, 71);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(703, 474);
            this.gridControl1.TabIndex = 20;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserName,
            this.colFirstName,
            this.colLastName,
            this.colLastActivityDate,
            this.colIsLockedOut,
            this.colIsApproved});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.ReadOnly = true;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 2;
            // 
            // colFirstName
            // 
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.OptionsColumn.AllowEdit = false;
            this.colFirstName.OptionsColumn.ReadOnly = true;
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 0;
            // 
            // colLastName
            // 
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.OptionsColumn.AllowEdit = false;
            this.colLastName.OptionsColumn.ReadOnly = true;
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 1;
            // 
            // colLastActivityDate
            // 
            this.colLastActivityDate.FieldName = "LastActivityDate";
            this.colLastActivityDate.Name = "colLastActivityDate";
            this.colLastActivityDate.OptionsColumn.AllowEdit = false;
            this.colLastActivityDate.OptionsColumn.ReadOnly = true;
            this.colLastActivityDate.Visible = true;
            this.colLastActivityDate.VisibleIndex = 3;
            // 
            // colIsLockedOut
            // 
            this.colIsLockedOut.FieldName = "IsLockedOut";
            this.colIsLockedOut.Name = "colIsLockedOut";
            this.colIsLockedOut.OptionsColumn.AllowEdit = false;
            this.colIsLockedOut.OptionsColumn.ReadOnly = true;
            this.colIsLockedOut.Visible = true;
            this.colIsLockedOut.VisibleIndex = 4;
            // 
            // colIsApproved
            // 
            this.colIsApproved.FieldName = "IsApproved";
            this.colIsApproved.Name = "colIsApproved";
            this.colIsApproved.OptionsColumn.AllowEdit = false;
            this.colIsApproved.OptionsColumn.ReadOnly = true;
            this.colIsApproved.Visible = true;
            this.colIsApproved.VisibleIndex = 5;
            // 
            // UsersGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UsersGrid";
            this.Size = new System.Drawing.Size(713, 548);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userByAppBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource userByAppBindingSource;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastActivityDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLockedOut;
        private DevExpress.XtraGrid.Columns.GridColumn colIsApproved;
    }
}
