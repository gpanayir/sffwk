using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions; 
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ProjectReferencesCreator
{
    public partial class frmMain : Form
    {
        List<Reference> _list = new List<Reference>();
        Reference selectedReference;
        int indexCounter = 0;
        public frmMain()
        {
            InitializeComponent();
        }


        private void btnFindRootFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
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


                errorProvider1.SetError(txtReference, "La ruta especificada no existe");
                errCount++;
            }
            else
            { errorProvider1.SetError(txtReference, ""); }

            if (_list.Exists(p => p.Path.Equals(txtReference.Text.Trim())))
            {
                errorProvider1.SetError(txtReference, "La ruta especificada ya esta agregada en la lista");
                errCount++;
            }
            return errCount == 0;

        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (ValidateFolders())
            {
                _list.Add(new Reference(txtReference.Text, _list.Count));
                indexCounter++;
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
        {
            //_list.Add(new Reference(@"C:\Projects\Pruebas\xxx\Libraries\", 0));
            //_list.Add(new Reference(@"C:\Projects\arquitectura\Fwk\trunk\src\", 1));
            //_list.Add(new Reference(@"C:\Projects\Pruebas\", 2));

            referenceBindingSource.DataSource = _list;

            dataGridView1.RefreshEdit();
            dataGridView1.Refresh();
        }



        private void benRemove_Click(object sender, EventArgs e)
        {
            int removedIndex = selectedReference.Index;
            _list.Remove(selectedReference);
            Reindex();

            referenceBindingSource.ResetBindings(true);



            if (_list.Count == 0)
            {
                SetUpDownRemovebuttons(selectedReference);
                return;
            }
            if (_list.Count != 0 && removedIndex != _list.Count)
            {
                selectedReference = (Reference)_list.First<Reference>(p => p.Index == removedIndex);
                SetUpDownRemovebuttons(selectedReference);
            }

        }

        /// <summary>
        /// Mueve hacia arriba la fila seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {

            //busco la referencia que ocupara la posicion de la referencia seleccionada
            Reference wReference = (Reference)_list.First<Reference>(p => p.Index == selectedReference.Index - 1);
            //intercambio las rutas
            IrtercambioValores(selectedReference, wReference);

            this.dataGridView1.EndEdit();
            dataGridView1.Refresh();

            //Selecciono en la grilla la pocicion nueva de la actual fila
            dataGridView1.Rows[wReference.Index].Selected = true;
            selectedReference = wReference;
            SetUpDownRemovebuttons(selectedReference);
        }


        /// <summary>
        /// Mueve hacia abajo la actual fila
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {

            Reference wReference = (Reference)_list.First<Reference>(p => p.Index == selectedReference.Index + 1);
            IrtercambioValores(selectedReference, wReference);
            this.dataGridView1.EndEdit();
            dataGridView1.Refresh();
            dataGridView1.Rows[wReference.Index].Selected = true;
            selectedReference = wReference;
            SetUpDownRemovebuttons(selectedReference);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            selectedReference = (Reference)((System.Windows.Forms.BindingSource)dataGridView1.DataSource).Current;

            SetUpDownRemovebuttons(selectedReference);
        }


        void Reindex()
        {
            int i = 0;
            foreach (Reference r in _list)
            {
                r.Index = i;
                i++;
            }
        }
        /// <summary>
        /// Habilita deshabilita botones de ordenamiento de las referencias y boton de eliminado de las mismas .-
        /// </summary>
        /// <param name="r"></param>
        void SetUpDownRemovebuttons(Reference r)
        {
            txtReference.Text = r.Path;
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            if (_list.Count == 0)
            {
                btnRemove.Enabled = false;
                return;
            }
            if (r.Index == 0 && _list.Count > 1)
            {

                btnDown.Enabled = true;
                return;
            }
            //Si es el ultimo
            if (r.Index == _list.Count - 1 && _list.Count != 1)
            {
                btnUp.Enabled = true;
                return;
            }
            if (r.Index > 0 && r.Index < _list.Count - 1)
            {
                btnUp.Enabled = true;
                btnDown.Enabled = true;
            }
        }
        /// <summary>
        /// Realiza intercambio de referencias : Solo intercambia la ruta y mantiene el indice
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        void IrtercambioValores(Reference r1, Reference r2)
        {
            Reference raux = r2.Clone<Reference>();

            r2.Path = r1.Path;
            r1.Path = raux.Path;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (frmPerform frm = new frmPerform(txtRoot.Text.Trim(), _list))
            {
    
                frm.ShowDialog();
               
            }
        }
    }

    public class Reference : Fwk.Bases.Entity
    {

        public Reference(string p, int i)
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
