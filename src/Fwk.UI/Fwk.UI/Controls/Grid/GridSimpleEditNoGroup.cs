using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Grid;

namespace Fwk.UI.Controls
{
    /// <summary>
    /// Grilla simple para edición sin agrupador
    /// </summary>
    public class GridSimpleEditNoGroup : DevExpress.XtraGrid.GridControl
    {
        private GridView gridView1;
    
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new GridSimpleEditNoGroupInfoRegistrator());
        }

        protected override BaseView CreateDefaultView()
        {
            return CreateView("GridSimpleEditNoGroupView");
        }

        public GridSimpleEditNoGroup()
        {
            this.ProcessGridKey += new KeyEventHandler(GridSimpleEditNoGroup_ProcessGridKey);
        }

        void GridSimpleEditNoGroup_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {

                ((GridView)this.Views[0]).DeleteSelectedRows();
            }
        }

        private void InitializeComponent()
        {
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this;
            this.gridView1.Name = "gridView1";
            // 
            // GridSimpleEditNoGroup
            // 
            this.EmbeddedNavigator.Name = "";
            this.MainView = this.gridView1;
            this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
 
  }
}
