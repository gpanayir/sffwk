using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.UI.Controls
{

    [ToolboxItem(true)]
    [Designer(typeof(Designers.FwkControlDesigner))]
    [DefaultEvent("OnFindClick")]
    public partial class UC_TextFindContainer : DevExpress.XtraEditors.XtraUserControl
    {
        bool _FindExpanded = true;
        [Category("Fwk.Factory")]
        public event EventHandler OnFindClick;
        [Category("Fwk.Factory")]
        public event EventHandler OnFindTextBoxEnter;

        [Category("Fwk.Factory")]
        [Description("Editor de texto del control")]
        public DevExpress.XtraEditors.ButtonEdit TextEditor
        {
            get { return textEditor; }
            set { textEditor = value; }
        }
        public UC_TextFindContainer()
        {
            InitializeComponent();

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(false)]
        public Panel WorkingArea_Control
        {
            get
            {
                return this.Control_workingArea;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(false)]
        public Panel WorkingArea_Find
        {
            get
            {
                return this.Find_workingArea;
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            PerformExpand();
        }

        void PerformExpand()
        {
            if (_FindExpanded)
            {
                this.btnExpand.Image = global::Fwk.UI.Properties.Resources.Expand_16;
                this.Find_workingArea.Visible = true;
                // //btnSep.Visible = Find_workingArea.Visible = false;
                //this.WorkingArea_Find.Visible = true;
                //Control_workingArea.Top = panelControl_Find.Height + 6;
                //Control_workingArea.Height = this.Height - panelControl_Find.Top - panelControl_Find.Height -4;
            }
            else
            {
                this.btnExpand.Image = global::Fwk.UI.Properties.Resources.collapce_16;
                this.Find_workingArea.Visible = false;
                //btnSep.Visible = Find_workingArea.Visible = true;
                //Control_workingArea.Top = btnSep.Top + btnSep.Height + 1;
                //Control_workingArea.Height = this.Height - btnSep.Top - btnSep.Height - 4;
            }
            
            _FindExpanded = !_FindExpanded;
        }

        private void TextFindContainer_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                PerformExpand();
                //btnSep.Top = Find_workingArea.Top + Find_workingArea.Height + 1;
                //btnSep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                //        | System.Windows.Forms.AnchorStyles.Right)));
            }
        }



        

        private void txtFind_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (OnFindClick == null) return;
            FindEventArg arg = new FindEventArg();
            arg.Text = textEditor.Text;
            arg.IsAdvancedFind = _FindExpanded;
            if (OnFindClick != null)
                OnFindClick(this, arg);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (OnFindTextBoxEnter == null) return;
            if (e.KeyChar != (char)Keys.Enter) return;
            FindEventArg arg = new FindEventArg();
            arg.Text = textEditor.Text;
            arg.IsAdvancedFind = _FindExpanded;
            OnFindTextBoxEnter(this, arg);
        }

    }
}
