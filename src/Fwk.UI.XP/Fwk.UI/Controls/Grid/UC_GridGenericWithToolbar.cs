using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.UI.Controls.Menu;


namespace Fwk.UI.Controls
{
    /// <summary>
    /// Generic XtraGrid with ToolbarControl
    /// </summary>
    [DefaultEvent("OnButtonClick")]
    public partial class UC_GenericGridWithToolbar : UC_UserControlBase
    {

        private String m_ToolbarFile = String.Empty;

        /// <summary>
        /// Delegate for ToolBarButton
        /// </summary>
        /// <param name="sender">ButtonBase</param>
        public delegate void OnToolBarButtonHandler(Object sender);
        /// <summary>
        /// ToolBar Button Click Event
        /// </summary>
        public event OnToolBarButtonHandler OnButtonClick;
                
        
        // Browseables Properties
        #region Grid Properties

        [Browsable(true)]
        [Category("Grid and Toolbar")]
        public Object GridDataSource
        {
            get
            {
                return this.gridSimpleEditNoGroup1.DataSource;
            }
            set
            {   
                this.gridSimpleEditNoGroup1.DataSource = value;
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Grid and Toolbar")]
        public AnchorStyles GridAnchor
        {
            get
            {
                return this.gridSimpleEditNoGroup1.Anchor;
            }
            set
            {
                this.gridSimpleEditNoGroup1.Anchor = value;
            }
        }
        
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Grid and Toolbar")]
        public DockStyle GridDock
        {
            get
            {
                return this.gridSimpleEditNoGroup1.Dock;
            }
            set
            {
                this.gridSimpleEditNoGroup1.Dock = value;
            }
        }
             
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Grid and Toolbar")]
        public Boolean GridVisible
        {
            get
            {
                return this.gridSimpleEditNoGroup1.Visible;
            }
            set
            {
                this.gridSimpleEditNoGroup1.Visible = value;
            }
        }
              
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Grid and Toolbar")]
        public Boolean GridEnabled
        {
            get
            {
                return this.gridSimpleEditNoGroup1.Enabled;
            }
            set
            {
                this.gridSimpleEditNoGroup1.Enabled = value;
            }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        [Category("Grid and Toolbar")]
        public Boolean GridEditable
        {
            get
            {
                return this.gridSimpleEditNoGroupView1.OptionsBehavior.Editable;
            }
            set
            {
                this.gridSimpleEditNoGroupView1.OptionsBehavior.Editable = value;
            }
        }

        #endregion

        #region ToolBar Properties

        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Grid and Toolbar")]
        public Boolean ToolbarVisible
        {
            get
            {
                return this.toolBar1.Visible;
            }
            set
            {
                this.toolBar1.Visible = value;                
            }
        }
               
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Grid and Toolbar")]
        public Boolean ToolbarEnabled
        {
            get
            {
                return this.toolBar1.Enabled;
            }
            set
            {
                this.toolBar1.Enabled = value;                
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Grid and Toolbar")]
        public AnchorStyles ToolbarAnchor
        {
            get
            {
                return this.toolBar1.Anchor;
            }
            set
            {
                this.toolBar1.Anchor = value;
            }
        }
                
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Grid and Toolbar")]
        public DockStyle ToolbarDock
        {
            get
            {
                return this.toolBar1.Dock;
            }
            set
            {
                this.toolBar1.Dock = value;
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Grid and Toolbar")]        
        public String ToolbarFromFile
        {
            get 
            {
                return m_ToolbarFile;            
            }
            set
            {   
                this.toolBar1.LoadToolBarFromFile(value);
                m_ToolbarFile = value;
            }
        }

        #endregion
        // **********************
        
        /// <summary>
        /// Constructor
        /// </summary>
        public UC_GenericGridWithToolbar()
        {
            InitializeComponent();            
        }
        

        /// <summary>
        /// Add  a column to XtraGrid
        /// </summary>
        /// <param name="pCaption">Column Caption</param>
        /// <param name="pFieldName">Column bind field name</param>
        /// <param name="pName">Column Name</param>
        /// <param name="pVisible">Column Visibility</param>
        /// <param name="pColumnIndex">Column order index</param>
        public void AddBindableGridColumn(String pCaption,String pFieldName,String pName,Boolean pVisible,Int32 pColumnIndex)
        {
            DevExpress.XtraGrid.Columns.GridColumn wColumn = new DevExpress.XtraGrid.Columns.GridColumn();

            wColumn.Caption = pCaption;
            wColumn.FieldName = pFieldName;
            wColumn.Name = pName;            
            wColumn.Visible = pVisible;
            wColumn.VisibleIndex = pColumnIndex;

            this.gridSimpleEditNoGroupView1.Columns.Insert(this.gridSimpleEditNoGroupView1.Columns.Count,wColumn);

        }

        /// <summary>
        /// Add  a column to XtraGrid
        /// </summary>
        /// <param name="pColumn">XtraGrid Column to Add</param>
        public void AddBindableGridColumn(DevExpress.XtraGrid.Columns.GridColumn pColumn)
        {
            this.gridSimpleEditNoGroupView1.Columns.Add(pColumn);
        }

        /// <summary>
        /// Add  a column to XtraGrid
        /// </summary>
        /// <param name="pColumn">XtraGrid Column to Add</param>
        /// <param name="pColumnIndex">Column Index</param>
        public void AddBindableGridColumn(DevExpress.XtraGrid.Columns.GridColumn pColumn, Int32 pColumnIndex)
        {
            this.gridSimpleEditNoGroupView1.Columns.Insert(pColumnIndex,pColumn);
        }

        /// <summary>
        /// Add  a column to XtraGrid
        /// </summary>
        /// <param name="pColumns">XtraGrid Column array to Add</param>
        public void AddBindableGridColumn(DevExpress.XtraGrid.Columns.GridColumn[] pColumns)
        {
            this.gridSimpleEditNoGroupView1.Columns.AddRange(pColumns);
        }

        void toolBar1_ToolBarButtonClick(object sender, ButtonClickArgs<Fwk.UI.Controls.Menu.ButtonBase> e)
        {
            OnButtonClick(e.ButtonClicked);
        }

      
       
    }
}
