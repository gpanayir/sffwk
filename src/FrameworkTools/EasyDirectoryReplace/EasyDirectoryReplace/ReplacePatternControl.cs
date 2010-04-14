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
        ReplacePattern _ReplacePattern = new ReplacePattern();
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
        public ReplacePattern ReplacePattern
        {
            get
            {
                _ReplacePattern.TextNew = txtNewText.Text;
                _ReplacePattern.TextOld = txtOldText.Text;
                _ReplacePattern.ReplaceContent = chkReplaceContentFile.Checked;

                return _ReplacePattern;
            }
            
        }
        public void Populate(ReplacePattern pReplacePatern)
        {
            _ReplacePattern = pReplacePatern;
            txtNewText.Text = _ReplacePattern.TextNew;
            txtOldText.Text = _ReplacePattern.TextOld;
            chkReplaceContentFile.Checked = _ReplacePattern.ReplaceContent;

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
