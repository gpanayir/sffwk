using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;

namespace Fwk.Wizard
{
    public partial class ctrlTreeViewTables : UserControl
    {
        private TableCollection _Tables;
        private Table _SelectedTable = null;

        public  static event SelectElementHandler SelectElementHandler;
        public void OnSelectObjectEvent()
        {
            if (SelectElementHandler != null)
                SelectElementHandler();
        }

        /// <summary>
        /// Indica la tabla seleccionada en el arbol .-
        /// </summary>
        public Table SelectedTable
        {
            get { return _SelectedTable; }
            set { _SelectedTable = value; }
        }
        
        

        /// <summary>
        /// Conjunto de tablas en el arbol.-
        /// </summary>
        public TableCollection Tablas
        {
            get { return _Tables; }
            set { _Tables = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ctrlTreeViewTables()
        {

            InitializeComponent();
        }



        /// <summary>
        /// Metodo que permite cargar las tablas en el arbol.
        /// </summary>
        public void LoadTreeView()
        {
            if (_Tables == null)
                LoadFromDataBase();

          
            //TreeViewHelper.AddElementEvent += new AddElementHandler(TreeViewHelper_AddElementEvent);

            //lblTreeViewSelected.Text = "Generando arbol..";
            if (_Tables == null)
            {
                this.tvwChilds.Nodes.Clear();
                //TreeViewHelper.AddElementEvent -= new AddElementHandler(TreeViewHelper_AddElementEvent);
                return;
            }
            if (_Tables.Count == 0)
            {
                this.tvwChilds.Nodes.Clear();
                //TreeViewHelper.AddElementEvent -= new AddElementHandler(TreeViewHelper_AddElementEvent);
                return;
            }

            TreeViewHelper.LoadTreeView(this.tvwChilds, _Tables);

            _SelectedTable = _Tables[0];
      


            lblTreeViewSelected.Text = String.Empty;
            ProgressBar.Visible = false;
         
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.tvwChilds.Nodes.Clear();
        
        }

        private void LoadFromDataBase()
        {
            //lblTreeViewSelected.Text = "Cargando tables desde la base de datos..";
    

            //Fwk.DataBase.Metadata Metadata = new Metadata();
            //Metadata.AddElementEvent += new AddElementHandler(Metadata_AddElementEvent);
            //Metadata.LoadTables();
            //this._Tables = Metadata.Tables;



            //Metadata.AddElementEvent -= new AddElementHandler(Metadata_AddElementEvent);
        }

        ///// <summary>
        ///// Retorna las tablas seleccionadas en el tree view.-
        ///// </summary>
        ///// <returns></returns>
        //public  TableCollection GetSelectedTables()
        //{
        //    if (_Tables == null) return null;

        //    TableCollection wTablesSelected = new Tables();
        //    foreach (Table wTable in _Tables)
        //    {
        //       if(wTable.Checked )
        //        wTablesSelected.Add (_Tables[ _Tables.IndexOf(wTable)]);
                
        //    }

        //    return wTablesSelected;
        //}


        //private void ctrlTreeViewTables_Load(object sender, EventArgs e)
        //{

        //}

    

        #region [Events]

        private void tvwChilds_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Level == 0)
            {
                Table wTable = (Table)e.Node.Tag;
                ///TODO: Ver Checked
                //wTable.Checked = e.Node.Checked;
                //if (wTable.IsColumnsLoaded == false)
                if(e.Node.Nodes.Count ==0)
                {
                    TreeViewHelper.LoadColumnsNodes(e.Node, wTable);
                    OnSelectObjectEvent();
                }

                this.tvwChilds.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwChilds_AfterCheck);
                this.tvwChilds.BeforeCheck -= new TreeViewCancelEventHandler(this.tvwChilds_BeforeCheck);    
                TreeViewHelper.UncheckChildNodes(e.Node);
                this.tvwChilds.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwChilds_AfterCheck);
                this.tvwChilds.BeforeCheck += new TreeViewCancelEventHandler(this.tvwChilds_BeforeCheck);   
            }

            if (e.Node.Level == 1)
            {
                Column wColumn = (Column)e.Node.Tag;
                //wColumn.Selected = e.Node.Checked;

                if (!TreeViewHelper.HasSelectedNodes(e.Node.Parent))
                {
                    e.Node.Parent.Checked = false;
                }
            }
        }
        private void tvwChilds_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            //Nivel de tablas
            if (e.Node.Level == 1)
            {
                if (e.Node.Parent.Text != _SelectedTable.Name)
                {
                    
                    _SelectedTable = (Table)e.Node.Parent.Tag;

                    lblTreeViewSelected.Text = _SelectedTable.Name;
                    OnSelectObjectEvent();

                }

            }
        }

       

        private void tvwChilds_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (this.tvwChilds.SelectedNode == null) return;

            if (this.tvwChilds.SelectedNode.Level == 0)
            {
          
                _SelectedTable = (Table)this.tvwChilds.SelectedNode.Tag;
                lblTreeViewSelected.Text = _SelectedTable.Name;
              
                if (e.Node.Nodes.Count == 0)
                {
                    TreeViewHelper.LoadColumnsNodes(this.tvwChilds.SelectedNode, _SelectedTable);
                    OnSelectObjectEvent();
                }

               
            }

            if (this.tvwChilds.SelectedNode.Level == 1)
            {
                lblTreeViewSelected.Text = _SelectedTable .Name + "." + this.tvwChilds.SelectedNode.Text.Substring(0, this.tvwChilds.SelectedNode.Text.IndexOf(" "));
            }
        }

      

        void Metadata_AddElementEvent()
        {
            if (this.ProgressBar.Value == this.ProgressBar.Maximum - 1)
                this.ProgressBar.Maximum++;

            this.ProgressBar.Value++;

        }
        #endregion

       
    }
}
