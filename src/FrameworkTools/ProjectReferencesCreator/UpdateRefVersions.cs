using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectReferencesCreator
{
    public partial class UpdateRefVersions : UserControl
    {
     
        ReferenceFileList _ReferenceFileList;

        public UpdateRefVersions(string rootPath, string newVersion)
        {
            InitializeComponent();
            

        }
        public UpdateRefVersions()
        {
            _ReferenceFileList = new ReferenceFileList();
            InitializeComponent();
        }
        public void ClearLogs()
        {
            _ReferenceFileList = new ReferenceFileList();
            referenceFileListBindingSource.DataSource = null;
            dataGridView1.RefreshEdit();
            dataGridView1.Refresh();
        }
        public void Start(string rootPath, string newVersion, ReferenceType pReferenceType)
        {
            ReferenceFileList.FinalizeEvent += new EventHandler(ReferenceFileList_FinalizeEvent);
            ReferenceFileList.StartReferenceVersion(rootPath, newVersion, pReferenceType);
        }

      
        void ReferenceFileList_FinalizeEvent(object sender, EventArgs e)
        {
     
            ReferenceFileList list = ((ReferenceFileList)sender);

            _ReferenceFileList.AddRange(list.Where<ReferenceFile>(p => p.Udated));

            referenceFileListBindingSource.DataSource = null;
            referenceFileListBindingSource.DataSource = _ReferenceFileList;
            dataGridView1.RefreshEdit();
            dataGridView1.Refresh();
            ReferenceFileList.FinalizeEvent -= new EventHandler(ReferenceFileList_FinalizeEvent);



        }

     

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReferenceFile rf = (ReferenceFile)((System.Windows.Forms.BindingSource)(dataGridView1.DataSource)).Current;
            if (rf == null) return;
            using (frmShowReferenceFile frm = new frmShowReferenceFile(rf))
            {
                frm.ShowDialog();
            }
        }
    }
}
