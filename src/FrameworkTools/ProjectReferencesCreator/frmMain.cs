using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ProjectReferencesCreator
{
    public partial class frmMain : Form
    {
        List<Reference> _list = new List<Reference>();
        public frmMain()
        {
            InitializeComponent();
        }

        private void txtRoot_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFindRootFolder_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtRoot.Text = folderBrowserDialog1.SelectedPath;
            }
        }

       

        private void btnFindFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtReference.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void txtRoot_Validating(object sender, CancelEventArgs e)
        {

            //if (!System.IO.Directory.Exists(txtRoot.Text))
            //{


            //    errorProvider1.SetError(txtRoot, "La ruta especificada no existe");
            //    txtRoot.Focus();
            //}
            //else
            //{ errorProvider1.SetError(txtRoot, ""); }
        }

        private void txtReference_Validating(object sender, CancelEventArgs e)
        {
            //if (!System.IO.Directory.Exists(txtReference.Text))
            //{


            //    errorProvider1.SetError(txtReference, "La ruta especificada no existe");
            //    txtReference.Focus();
            //}
            //else
            //{ errorProvider1.SetError(txtReference, ""); }
        }

        bool ValidateFolders()
        {
            int errCount = 0;
            if (!System.IO.Directory.Exists(txtRoot.Text))
            {
                errorProvider1.SetError(txtRoot, "La ruta especificada no existe");
                errCount++;
            }
            else
            { errorProvider1.SetError(txtRoot, ""); }

            if (!System.IO.Directory.Exists(txtReference.Text))
            {


                errorProvider1.SetError(txtRoot, "La ruta especificada no existe");
                errCount++;
            }
            else
            { errorProvider1.SetError(txtReference, ""); }


            return errCount == 0;

        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (ValidateFolders())
            {
                _list.Add(new Reference(txtReference.Text,_list.Count ));
                referenceBindingSource.DataSource = null;
                referenceBindingSource.DataSource = _list;
           
          
          
                dataGridView1.RefreshEdit();
                dataGridView1.Refresh();
                btnUpdate.Enabled = true;
            }
        }

        private void txtReference_TextChanged(object sender, EventArgs e)
        {
            btnAddFolder.Enabled = !String.IsNullOrEmpty(txtReference.Text);
        }

      

        

       
        


        private void frmMain_Load(object sender, EventArgs e)
        {   _list.Add(new Reference("A", 0));
            _list.Add(new Reference("B", 1));
            _list.Add(new Reference("C", 2));
            _list.Add(new Reference("D", 3));
            referenceBindingSource.DataSource = _list;
         
            dataGridView1.RefreshEdit();
            dataGridView1.Refresh();
        }
        Reference selectedReference;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void benRemove_Click(object sender, EventArgs e)
        {
            //listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);

        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            string selecteP = selectedReference.Path;
            Reference wReference = (Reference)_list.First<Reference>(p => p.Index == selectedReference.Index -1);
            selectedReference.Path = wReference.Path;
            wReference.Path = selecteP;

            referenceBindingSource.DataSource = null;
            referenceBindingSource.DataSource = _list;
  
            dataGridView1.Refresh();
            dataGridView1.Rows[selectedReference.Index - 1].Selected = true;
        }

       

        private void btnDown_Click(object sender, EventArgs e)
        {
            string selecteP = selectedReference.Path;
            Reference wReference = (Reference)_list.First<Reference>(p => p.Index == selectedReference.Index + 1);
            selectedReference.Path = wReference.Path;
            wReference.Path = selecteP;
          
            referenceBindingSource.DataSource = null;
            referenceBindingSource.DataSource = _list;
           
            dataGridView1.Refresh();
            dataGridView1.Rows[selectedReference.Index + 1].Selected = true;
          
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            selectedReference = (Reference)((System.Windows.Forms.BindingSource)dataGridView1.DataSource).Current;

            txtReference.Text = selectedReference.Path;
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            if (_list.Count == 0) return;
            if (selectedReference.Index == 0 && _list.Count > 1)
            {

                btnDown.Enabled = true;
                return;
            }
            //Si es el ultimo
            if (selectedReference.Index == _list.Count - 1 && _list.Count != 1)
            {
                btnUp.Enabled = true;
                return;
            }
            if (selectedReference.Index > 0 && selectedReference.Index < _list.Count - 1)
            {
                btnUp.Enabled = true;
                btnDown.Enabled = true;
            }
        }

    }

    public class Reference
    {

        public  Reference(string p, int i)
        {
            path = p;
            index = i;
        }
        string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        int index;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
    }
}
