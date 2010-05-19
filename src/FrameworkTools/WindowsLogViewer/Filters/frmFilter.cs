using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevExpress.XtraEditors;

namespace WindowsLogViewer
{
    public partial class frmFilter : XtraForm
    {
        bool _IsNew = true;

        /// <summary>
        /// 
        /// </summary>
        public Filter Filter
        {
            get
            {
                return ctrlFilter1.Filters[0];
            }
            set { ctrlFilter1.Filters[0] = value; }
        }

        public frmFilter()
        {
            InitializeComponent();
        }

        public frmFilter(bool isNew)
        {
            InitializeComponent();
            _IsNew = isNew;
        }

        public void Populate(Filter pFilter)
        {
            if (pFilter == null) return;
            ctrlFilter1.Filters.Add( pFilter);
            ctrlFilter1.Populate(pFilter);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_IsNew && frmMain.UserProfile.Filters.Exists(p => p.Id.Equals(ctrlFilter1.Filters[0])))
            {
                MessageBox.Show("The similar filter " + ctrlFilter1.Filters[0].Name + " alredy existe in tabs colection");
                return;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
