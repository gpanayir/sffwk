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
    public delegate void ObjectDomainChangeHandler(FwkIdentity pFwkIdentity);

    [DefaultEvent("ObjectDomainChangeEvent")]
    public partial class DomainUsers : UserControl
    {

        FwkActyveDirectory _FwkActyveDirectory;
        public event ObjectDomainChangeHandler ObjectDomainChangeEvent;
        void OnObjectDomainChange()
        {
            if (ObjectDomainChangeEvent != null)
                ObjectDomainChangeEvent(_FwkIdentityCurrent);
        }
        List<FwkIdentity> _DomainUsers;
        FwkIdentity _FwkIdentityCurrent;
       
        

        public DomainUsers()
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
                throw new Exception("El dominio no fue inicializado. ");
            }

           _DomainUsers = _FwkActyveDirectory.GetAllUsers();

           fwkIdentityBindingSource.DataSource = _DomainUsers;
        }
        public void Populate(List<FwkIdentity> pDomainUsers)
        {
            if (_FwkActyveDirectory == null)
            {
                throw new Exception("El dominio no fue inicializado. ");
            }

            _DomainUsers = pDomainUsers;

            fwkIdentityBindingSource.DataSource = _DomainUsers;
        }

        private void txDomainUserName_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    using (new WaitCursorHelper(this))
                    {
                        fwkIdentityBindingSource.DataSource = ObjectDomain.FilterByName(txDomainUserName.Text, _DomainUsers);
                    }
                }
        }

        private void btnFilterUsers_Click(object sender, EventArgs e)
        {
            using (new WaitCursorHelper(this))
            {
                fwkIdentityBindingSource.DataSource = ObjectDomain.FilterByName(txDomainUserName.Text, _DomainUsers);
            }
            
        }





        private void grdDomainUsers_Click(object sender, EventArgs e)
        {
            if (ObjectDomainChangeEvent == null) return;

            if (grdDomainUsers.CurrentRow == null) return;
            if (grdDomainUsers.CurrentRow.DataBoundItem == null) return;

            _FwkIdentityCurrent = (FwkIdentity)grdDomainUsers.CurrentRow.DataBoundItem;
            OnObjectDomainChange();
        }

      


    }
}
