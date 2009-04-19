using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;

namespace Fwk.Security.ActiveDirectory.Test
{
    public delegate void DomainGroupChangeHandler(ObjectDomainGroup pGroup);

    [DefaultEvent("DomainGroupChangeEvent")]
    public partial class DomainGoups : UserControl
    {
        FwkActyveDirectory _FwkActyveDirectory;
        public event DomainGroupChangeHandler DomainGroupChangeEvent;

        void OnObjectDomainChange()
        {
            if (DomainGroupChangeEvent != null)
                DomainGroupChangeEvent(_FwkIdentityCurrent);
        }
        List<ObjectDomainGroup> _DomainGoups;
        ObjectDomainGroup _FwkIdentityCurrent;

        public DomainGoups()
        {
            InitializeComponent();

          
        }


        public void Initialize(String pDomainName)
        {
            _FwkActyveDirectory = new FwkActyveDirectory(pDomainName);
        }

        public void Populate()
        {
            if (_FwkActyveDirectory == null)
            {
                throw new Exception("El dominio no fue inicializado.");
            }

            _DomainGoups = _FwkActyveDirectory.GetAllGroups();
            objectDomainGroupBindingSource.DataSource = _DomainGoups;

        }
        public void Populate(List<ObjectDomainGroup> pObjectDomainGroup)
        {
            _DomainGoups = pObjectDomainGroup;
            objectDomainGroupBindingSource.DataSource = _DomainGoups;
        }
        private void grdDomainGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DomainGroupChangeEvent == null) return;
            if (grdDomainGroups.CurrentRow == null) return;
            if (grdDomainGroups.CurrentRow.DataBoundItem == null) return;

            _FwkIdentityCurrent = ((ObjectDomainGroup)grdDomainGroups.CurrentRow.DataBoundItem);
            OnObjectDomainChange();
        }

        private void btnFilterGroup_Click(object sender, EventArgs e)
        {
            using (new WaitCursorHelper(this))
            {
                objectDomainGroupBindingSource.DataSource = ObjectDomain.FilterByName(txtDomainGroupName.Text, _DomainGoups);
            }
        }

        private void txtDomainGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (new WaitCursorHelper(this))
                {
                    objectDomainGroupBindingSource.DataSource = ObjectDomain.FilterByName(txtDomainGroupName.Text, _DomainGoups);
                }
            }
        }

    
    }
}
