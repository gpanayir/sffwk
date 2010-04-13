using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyDirectoryReplace
{
    public partial class ReplacePatternControl : UserControl
    {
        ReplacePattern _ReplacePaternList = new ReplacePattern();
        public event EventHandler  OnRemoveEvent;
        protected void OnRemove()
        {
            if (OnRemoveEvent != null)
                OnRemoveEvent(this, new EventArgs());
        }
        public bool RemoveVisible
        {
            get { return btnRemove.Visible; }
            set { btnRemove.Visible = value; }
            
        }
    
        [Browsable(false)]
        public ReplacePattern ReplacePatern
        {
            get
            {
                _ReplacePaternList.TextNew = txtNewText.Text;
                _ReplacePaternList.TextOld = txtOldText.Text;
                _ReplacePaternList.ReplaceContent = chkReplaceContentFile.Checked;

                return _ReplacePaternList;
            }
            
        }
        public void Populate(ReplacePattern pReplacePatern)
        {
            _ReplacePaternList = pReplacePatern;
            txtNewText.Text = _ReplacePaternList.TextNew;
            txtOldText.Text = _ReplacePaternList.TextOld;
            chkReplaceContentFile.Checked = _ReplacePaternList.ReplaceContent;

        }
        public ReplacePatternControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnRemove();
        }
    }
}
