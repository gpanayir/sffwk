using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectReferencesCreator
{
    public partial class frmPerform : Form
    {
        string _RootPath;
        List<Reference> _List;
        public frmPerform(string rootPath, List<Reference> list)
        {
            InitializeComponent();

            _RootPath = rootPath;
            _List = list;

        }

         void Start()
        {
            ReferenceFileList.FinalizeEvent += new EventHandler(ReferenceFileList_FinalizeEvent);
            ReferenceFileList.StartReferencePatch(_RootPath, _List);
        }

        void ReferenceFileList_FinalizeEvent(object sender, EventArgs e)
        {
         
            pictureBox1.Visible = false;

            referenceFileListBindingSource.DataSource =((ReferenceFileList)sender);
            dataGridView1.RefreshEdit();
            dataGridView1.Refresh();
            ReferenceFileList.FinalizeEvent -= new EventHandler(ReferenceFileList_FinalizeEvent);

            
        }

        private void frmPerform_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
