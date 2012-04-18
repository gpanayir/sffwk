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
    /// Vista de el control GridNoEditWithGroup
    /// </summary>
    public class GridNoEditWithGroupView : DevExpress.XtraGrid.Views.Grid.GridView
    {

        protected override string ViewName
        {
            get
            {
                return "GridNoEditWithGroupView";
            }
        }

        public GridNoEditWithGroupView() : base()
        {
            
        }

        public GridNoEditWithGroupView(GridControl grid) : base(grid)
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Appearance.EvenRow.BackColor2 = System.Drawing.SystemColors.ButtonFace;
            this.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Appearance.EvenRow.Options.UseBackColor = true;
            this.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.GroupPanelText = "Arrastre el encabezado de la columna por la cual desea agrupar aquí";
            this.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.OptionsBehavior.Editable = false;
            this.OptionsCustomization.AllowRowSizing = true;
            this.OptionsDetail.AllowZoomDetail = false;
            this.OptionsFilter.AllowColumnMRUFilterList = false;
            this.OptionsFilter.AllowFilterEditor = false;
            this.OptionsFilter.AllowMRUFilterList = false;
            this.OptionsMenu.EnableFooterMenu = false;
            this.OptionsView.RowAutoHeight = true;
            this.OptionsView.ShowAutoFilterRow = true;
            this.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();         
        }
       
    }
}
