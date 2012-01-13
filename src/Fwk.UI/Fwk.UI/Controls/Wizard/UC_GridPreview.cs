using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid; //Para la grilla
using DevExpress.XtraGrid.Views.Grid;
using Fwk.UI.Common; //Para la vista de la grilla

namespace Fwk.UI.Controls.Wizard
{
    [ToolboxItem (true)]
    public partial class UC_GridPreview : UC_UserControlBase
    {

        #region Members

        private DataOriginTypeEnum _FileType = DataOriginTypeEnum.DataBase;
        public event EventHandler OnPreviewClick;
 
        #endregion

        #region Properties

        public DataOriginTypeEnum FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }

        public GridControl Grid
        {
            get { return grdPreview; }
            set { grdPreview = value; }
        }

        public GridView GridView
        {
            get { return grdPreviewView1; }
            set { grdPreviewView1 = value; }
        }

        #endregion

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (OnPreviewClick != null)
                OnPreviewClick(sender, e);
        }

        public void Populate(DataTable wDataSource)
        {
            grdPreviewView1.Columns.Clear();

            if (wDataSource == null)
                grdPreview.DataSource = null;
            
            else
            {
                grdPreview.DataSource = wDataSource;
                grdPreview.RefreshDataSource();
                grdPreviewView1.BestFitColumns();
            }
        }

        public UC_GridPreview()
        {
            InitializeComponent();
        }

    }
}
