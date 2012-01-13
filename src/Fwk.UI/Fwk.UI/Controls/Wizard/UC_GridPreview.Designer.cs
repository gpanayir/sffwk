namespace Fwk.UI.Controls.Wizard
{
    partial class UC_GridPreview
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
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.grdPreview = new DevExpress.XtraGrid.GridControl();
            this.grdPreviewView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreviewView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(315, 3);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(83, 23);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Vista previa";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // grdPreview
            // 
            this.grdPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPreview.Location = new System.Drawing.Point(0, 28);
            this.grdPreview.MainView = this.grdPreviewView1;
            this.grdPreview.Name = "grdPreview";
            this.grdPreview.Size = new System.Drawing.Size(398, 154);
            this.grdPreview.TabIndex = 1;
            this.grdPreview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdPreviewView1,
            this.gridView2});
            // 
            // grdPreviewView1
            // 
            this.grdPreviewView1.GridControl = this.grdPreview;
            this.grdPreviewView1.Name = "grdPreviewView1";
            this.grdPreviewView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdPreview;
            this.gridView2.Name = "gridView2";
            // 
            // UC_GridPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdPreview);
            this.Controls.Add(this.btnPreview);
            this.MinimumSize = new System.Drawing.Size(398, 182);
            this.Name = "UC_GridPreview";
            this.Size = new System.Drawing.Size(398, 182);
            ((System.ComponentModel.ISupportInitialize)(this.grdPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreviewView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraGrid.GridControl grdPreview;
        private DevExpress.XtraGrid.Views.Grid.GridView grdPreviewView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}
