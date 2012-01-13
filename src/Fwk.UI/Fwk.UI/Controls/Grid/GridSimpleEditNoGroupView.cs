using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Fwk.UI.Controls
{
    /// <summary>
    /// Vista de el control GridSimpleEditNoGroup
    /// </summary>
    public class GridSimpleEditNoGroupView : DevExpress.XtraGrid.Views.Grid.GridView
    {

        protected override string ViewName
        {
            get
            {
                return "GridSimpleEditNoGroupView";
            }
        }

        public GridSimpleEditNoGroupView() : base()
        {
            
        }

        public GridSimpleEditNoGroupView(GridControl grid) : base(grid)
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            //this.Name = "Grv";
            this.OptionsCustomization.AllowColumnMoving = false;
            this.OptionsCustomization.AllowFilter = false;
            this.OptionsCustomization.AllowGroup = false;
            this.OptionsDetail.AllowZoomDetail = false;
            this.OptionsFilter.AllowColumnMRUFilterList = false;
            this.OptionsFilter.AllowFilterEditor = false;
            this.OptionsFilter.AllowMRUFilterList = false;
            this.OptionsMenu.EnableColumnMenu = false;
            this.OptionsMenu.EnableFooterMenu = false;
            this.OptionsMenu.EnableGroupPanelMenu = false;
            this.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.OptionsView.ShowGroupPanel = false;
            this.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();    
            
        }
       
    }
}
