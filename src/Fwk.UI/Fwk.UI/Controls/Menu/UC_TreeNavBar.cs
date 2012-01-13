using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Fwk.UI.Controls.Menu
{
    public delegate void OnNodeClickHandler(TreeNodeButton node);
    [ToolboxItem(false)]
    [DefaultEvent("OnNodeClick")]
    public partial class UC_TreeNavBar : DevExpress.XtraEditors.XtraUserControl
    {
        TreeNodeButton _SelectedNode;

        public TreeNodeButton SelectedNode
        {
            get { return _SelectedNode; }
            set { _SelectedNode = value; }
        }
        bool _OnInitLoad = true;
        public event OnNodeClickHandler OnNodeClick;
        public event EventHandler OnTreeViewClick;
        TreeNodeButtons _Nodes;


        void OnMenuItemClick(TreeNodeButton node)
        {
            if (OnNodeClick != null)
                OnNodeClick(node);
        }
        public UC_TreeNavBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Refresh()
        {

            treeList1.RefreshDataSource();

            treeList1.ExpandAll();
            base.Refresh();
        }

        /// <summary>
        /// Restablece el valor estatico de MenuItemSurveyList
        /// </summary>
        /// <param name="pMenuBarTreeNodes"></param>
        /// <returns></returns>
        public void Populate(TreeNodeButtons pMenuBarTreeNodes)
        {
            treeList1.FocusedNodeChanged -= new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            treeList1.BeginUpdate();

            _Nodes = pMenuBarTreeNodes;//TreeNodeButtons.GetFromXml<TreeNodeButtons>(pMenuBarTreeNodes.GetXml());
            menuBarTreeNodeBindingSource.DataSource = _Nodes;

            treeList1.RefreshDataSource();

            treeList1.EndUpdate();

            treeList1.ExpandAll();
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (_OnInitLoad)
                return;
            if (e.Node == null)
                return;
            if (e.Node.TreeList.FocusedColumn == null)
                return;

            _SelectedNode = (TreeNodeButton)treeList1.GetDataRecordByNode(e.Node);
            if (_SelectedNode != null)
                OnMenuItemClick(_SelectedNode);
        }

        private void UC_TreeNavBar_Load(object sender, EventArgs e)
        {
            _OnInitLoad = false;
        }

        private void UC_TreeNavBar_Click(object sender, EventArgs e)
        {
            if (OnTreeViewClick != null)
                OnTreeViewClick(this, new EventArgs());
        }

        private void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            if (!e.Node.HasChildren && !e.FocusedNode)
            {
                e.NodeImageIndex = 2;
                return;
            }
            if (!e.Node.HasChildren && e.FocusedNode)
            {
                e.NodeImageIndex = 3;
                return;
            }
            if (e.Node.HasChildren && e.Node.Expanded && e.FocusedNode)
                e.NodeImageIndex = 1;
            else
                e.NodeImageIndex = 0;

        }

    }
}
