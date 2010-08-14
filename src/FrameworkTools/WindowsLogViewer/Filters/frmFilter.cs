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
        public Filter GetFilter()
        {
            return ctrlFilter1.GetSingleFilter();
        }        
            
           
        

        public frmFilter()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Valido solo para edicion de filtro
        /// </summary>
        /// <param name="pFilter"></param>
        public frmFilter(Filter pFilter)
        {
            InitializeComponent();
            if (pFilter == null) return;
            ctrlFilter1.Populate(pFilter);
            _IsNew = false;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            ctrlFilter1.RefreshSingleFilter();
            Filter f = ctrlFilter1.GetSingleFilter();
            if (f == null) return;
            if (_IsNew && frmMain.UserProfile.Filters.Exists(p => p.Id.Equals(f.Id)))
            {
                MessageBox.Show("The similar filter " + f.Name + " alredy existe in tabs colection");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
        }


    }
}
