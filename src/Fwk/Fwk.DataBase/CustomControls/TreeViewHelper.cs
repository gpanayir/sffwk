using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using Promi_Fwk_DataEntities = Fwk.DataBase.DataEntities;
using Promi_Fwk_DataBase = Fwk.DataBase;


namespace Fwk.DataBase.CustomControls
{
   
    /// <summary>
    /// 
    /// </summary>
    public class TreeViewHelper
    {
        private static event AddElementHandler _AddElementEvent;

        /// <summary>
        /// 
        /// </summary>
        private static void OnAddElementEvent()
        {

            if (_AddElementEvent != null)
                _AddElementEvent();
        }
        /// <summary>
        /// 
        /// </summary>
        public static event AddElementHandler AddElementEvent
        {
            add
            {
                _AddElementEvent = (AddElementHandler)Delegate.Combine(_AddElementEvent, value);
            }
            remove
            {
                _AddElementEvent = (AddElementHandler)Delegate.Remove(_AddElementEvent, value);
            }
        }

        #region Tables
        /// <summary>
        /// Carga el arbol con todas las tablas .- 
        /// </summary>
        /// <param name="pTreeView">Nodo</param>
        /// <param name="pTables">Tablas</param>
        public static void LoadTreeView(TreeView pTreeView, Promi_Fwk_DataEntities.Tables pTables)
        {
            pTreeView.Nodes.Clear();    
            foreach (Promi_Fwk_DataEntities.Table wTable in pTables)
            {
                TreeNode wTreeNode = new TreeNode();
                wTreeNode.Checked = false;
                
                wTreeNode.Text = wTable.Name;
                pTreeView.Nodes.Add(wTreeNode);
                LoadColumnsNodes(wTreeNode, wTable);

                OnAddElementEvent();
            }
           
        }

        /// <summary>
        /// Carga las coluimnas al nodo pParentNode.-
        /// </summary>
        /// <param name="pParentNode">Nodo padre </param>
        /// <param name="pTable"></param>
        private static void LoadColumnsNodes(TreeNode pParentNode, Promi_Fwk_DataEntities.Table pTable)
        {

            foreach (Promi_Fwk_DataEntities.Column wColumn in pTable.Columns)
            {

                String nullable = wColumn.Nullable ? "NULL" : String.Empty;

                TreeNode wTreeNode = new TreeNode();
                wTreeNode.Checked = false;
                wTreeNode.Text = wColumn.Name + " " + wColumn.Type + " " + nullable;
                wTreeNode.Tag = wColumn.Name;
                wTreeNode.ImageIndex = 5;
                wTreeNode.SelectedImageIndex = 5;
                pParentNode.Nodes.Add(wTreeNode);
            }
        }

        internal static void FillColumns(TreeNode pTreeNodePadre, Fwk.DataBase.DataEntities.Table pTable)
        {
            if (pTable.IsColumnsLoaded) return;

            Promi_Fwk_DataBase.Metadata wMetadata = new Metadata();

            wMetadata.Table_FillColumns(pTable);

            LoadColumnsNodes(pTreeNodePadre, pTable);

        }

        #endregion

        #region Store Procedures
        /// <summary>
        /// Carga el arbol con todas los Store Procedures .- 
        /// </summary>
        /// <param name="pTreeView">Nodo</param>
        /// <param name="pStoreProcedures">StoreProcedures</param>
        public static void LoadTreeView(TreeView pTreeView, Promi_Fwk_DataEntities.StoreProcedures pStoreProcedures)
        {
            pTreeView.Nodes.Clear();
            foreach (Promi_Fwk_DataEntities.StoreProcedure wStoreProcedure in pStoreProcedures)
            {
                TreeNode wTreeNode = new TreeNode();
                wTreeNode.Checked = false;

                wTreeNode.Text = wStoreProcedure.Name;
                pTreeView.Nodes.Add(wTreeNode);
                LoadParameteresNodes(wTreeNode, wStoreProcedure);

                OnAddElementEvent();
            }

        }

        /// <summary>
        /// Carga los parametros al nodo pParentNode  (StoreProcedure).-
        /// </summary>
        /// <param name="pParentNode">Nodo padre </param>
        /// <param name="pStoreProcedure">Store Procedure</param>
        private static void LoadParameteresNodes(TreeNode pParentNode, Promi_Fwk_DataEntities.StoreProcedure pStoreProcedure)
        {

            foreach (Promi_Fwk_DataEntities.SPParameter wParameter in pStoreProcedure.Parameters)
            {
                TreeNode wTreeNode = new TreeNode();
                wTreeNode.Checked = false;
                wTreeNode.Text = wParameter.Type + " " + wParameter.Name;
                wTreeNode.Tag = wParameter.Name;
                wTreeNode.ImageIndex = 5;
                wTreeNode.SelectedImageIndex = 5;
                pParentNode.Nodes.Add(wTreeNode);
            }
        }

        internal static void FillParameters(TreeNode pTreeNodePadre, Fwk.DataBase.DataEntities.StoreProcedure pStoreProcedure)
        {
            if (pStoreProcedure.IsParametersLoaded) return;

            Promi_Fwk_DataBase.Metadata wMetadata = new Metadata();

            wMetadata.StoreProcedures_FillParameters(pStoreProcedure);

            LoadParameteresNodes(pTreeNodePadre, pStoreProcedure);

        }

        #endregion


        /// <summary>
        /// Agrega un nodo a un nodo padre con informaci�n sobre una tabla relacionada a la que �ste representa.
        /// </summary>
        /// <param name="pParentNode">Nodo padre.</param>
        /// <param name="pText">Texto a mostrar.</param>
        /// <param name="pRelatedFields">Lista de relaciones entre campos.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        private static TreeNode AddChildNode(TreeNode pParentNode, string pText, FieldRelationList pRelatedFields)
        {
            TreeNode wTreeNode = new TreeNode(pText);

            wTreeNode.Checked = false;
            wTreeNode.Tag = pRelatedFields;
            pParentNode.Nodes.Add(wTreeNode);

            return wTreeNode;
        }

        /// <summary>
        /// Agrega un nodo a un nodo padre con informaci�n sobre una tabla relacionada a la que �ste representa.
        /// </summary>
        /// <param name="pParentNode">Nodo padre.</param>
        /// <param name="pText">Texto a mostrar.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        private static TreeNode AddChildNode(TreeNode pParentNode, string pText)
        {
            TreeNode wTreeNode = new TreeNode(pText);

            wTreeNode.Checked = false;
            wTreeNode.Tag = pText;
            pParentNode.Nodes.Add(wTreeNode);

            return wTreeNode;
        }




        /// <summary>
        /// Destilda los nodos hijos de un nodo padre.
        /// </summary>
        /// <param name="pNode">Nodo padre.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        public static void UncheckChildNodes(TreeNode pNode)
        {
            Boolean Checked = pNode.Checked;

            foreach (TreeNode wNode in pNode.Nodes)
            {
                wNode.Checked = pNode.Checked;
                UncheckChildNodes(wNode);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParentNode"></param>
        /// <returns></returns>
        public static bool HasSelectedNodes(TreeNode ParentNode)
        {
            Boolean wCheck = false;
            foreach (TreeNode child in ParentNode.Nodes)
            {
                if (child.Checked) wCheck = true;
            }

            return wCheck;
        }
    }
}
