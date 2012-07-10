using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using System.Windows.Forms;


namespace Fwk.UI.Common.TreeList
{
    /// <summary>
    /// Operation for calculate the checked, unchecked and indeterminated nodes in the DevExpress.Treelist
    /// </summary>
    public class CalcCheckedNodesOperation : TreeListOperation
    {
        private List<TreeListNode> checkedNodes = new List<TreeListNode>();
        /// <summary>
        /// Get Checked nodes in the Tree
        /// </summary>
        public List<TreeListNode> CheckedNodes { get { return checkedNodes; } }        
        private List<TreeListNode> checkedIndeterminateNodes = new List<TreeListNode>();
        /// <summary>
        /// Get Checked nodes in the Tree include the indeterminated nodes 
        /// </summary>
        public List<TreeListNode> CheckedIndeterminateNodes { get { return checkedIndeterminateNodes; } }
        private List<TreeListNode> unCheckedNodes = new List<TreeListNode>();
        /// <summary>
        /// Get UnChecked nodes in the Tree
        /// </summary>
        public List<TreeListNode> UnCheckedNodes { get { return unCheckedNodes; } }  

        public override void Execute(TreeListNode node)
        {
            if (node.CheckState == CheckState.Checked)
                checkedNodes.Add(node);
            if (node.CheckState == CheckState.Checked || node.CheckState == CheckState.Indeterminate)
                checkedIndeterminateNodes.Add(node);
            if (node.CheckState != CheckState.Checked)
                unCheckedNodes.Add(node);
        }
    }

    /// <summary>
    /// Operation for calculate the checked,unchecked and indeterminated nodes children  for a TreeListNode parent node  in the DevExpress.Treelist
    /// </summary>
    public class CalcCheckedChildrenOperation : CalcCheckedNodesOperation
    {
        private TreeListNode parent;
        private bool isCalculationStart = false;
        public CalcCheckedChildrenOperation(TreeListNode parent) { this.parent = parent; }

        public override void Execute(TreeListNode node)
        {
            if (node.HasAsParent(parent)) base.Execute(node);
        }

        public override bool CanContinueIteration(TreeListNode node)
        {
            if (isCalculationStart && !node.HasAsParent(parent)) return false;
            if (node == parent) isCalculationStart = true;
            return true;
        }

        public override bool NeedsVisitChildren(TreeListNode node)
        {
            return node == parent || node.HasAsParent(parent) || parent.HasAsParent(node);
        }

    }

    /// <summary>
    /// Do Check operation for all nodes in a TreeList
    /// </summary>
    public class CheckAllNodesOperation : TreeListOperation
    {
       public override void Execute(TreeListNode node)
       {
           node.CheckState = CheckState.Checked;
        }
    }

    /// <summary>
    /// Do check node operation for all children node for a TreelistNode parent
    /// </summary>
    public class CheckAllNodesChildrenOperation : CheckAllNodesOperation
    {
        private TreeListNode parent;
        private bool isCalculationStart = false;

        public CheckAllNodesChildrenOperation(TreeListNode parent) { this.parent = parent; }

        public override void Execute(TreeListNode node)
        {
            if (node.HasAsParent(parent)) base.Execute(node);
        }

        public override bool CanContinueIteration(TreeListNode node)
        {
            if (isCalculationStart && !node.HasAsParent(parent)) return false;
            if (node == parent) isCalculationStart = true;
            return true;
        }

        public override bool NeedsVisitChildren(TreeListNode node)
        {
            return node == parent || node.HasAsParent(parent) || parent.HasAsParent(node);
        }

    }


    /// <summary>
    /// Do UnCheck operation for all nodes in a TreeList
    /// </summary>
    public class UnCheckAllNodesOperation : TreeListOperation
    {
        public override void Execute(TreeListNode node)
        {
            node.CheckState = CheckState.Unchecked;
        }
    }

    /// <summary>
    /// Do UnCheck node operation for all children node for a TreelistNode parent
    /// </summary>
    public class UnCheckAllNodesChildrenOperation : UnCheckAllNodesOperation
    {
        private TreeListNode parent;
        private bool isCalculationStart = false;

        public UnCheckAllNodesChildrenOperation(TreeListNode parent) { this.parent = parent; }

        public override void Execute(TreeListNode node)
        {
            if (node.HasAsParent(parent)) base.Execute(node);
        }

        public override bool CanContinueIteration(TreeListNode node)
        {
            if (isCalculationStart && !node.HasAsParent(parent)) return false;
            if (node == parent) isCalculationStart = true;
            return true;
        }

        public override bool NeedsVisitChildren(TreeListNode node)
        {
            return node == parent || node.HasAsParent(parent) || parent.HasAsParent(node);
        }

    }

}
