using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.Handler;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Registrator;

namespace Fwk.UI.Controls
{
    public class GridSimpleEditNoGroupInfoRegistrator: GridInfoRegistrator
    {

        public override string ViewName
        {
            get
            {
                return "GridSimpleEditNoGroupView";
            }
        }

        public override BaseView CreateView(GridControl grid)
        {
            return new GridSimpleEditNoGroupView(grid);
        }

    }
}
