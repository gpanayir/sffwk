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
    public delegate void ObjectDomainChangeHandler(ADUser user);
    
    [DefaultEvent("ObjectDomainChangeEvent")]
    public partial class DomainUsers : UserControl
    {

        ADHelper _ADHelper;
        public event ObjectDomainChangeHandler ObjectDomainChangeEvent;
        void OnObjectDomainChange()
        {
            if (ObjectDomainChangeEvent != null)
                ObjectDomainChangeEvent(_CurrentUserName);
        }
        List<ADUser> _DomainUsers;
        ADUser _CurrentUserName;
       
        

        public DomainUsers()
        {
            InitializeComponent();
        }


        public void Initialize(String pDomainName)
        {
            _ADHelper = new ADHelper(pDomainName);
        }

        public void Populate()
        {
            if (_ADHelper == null)
            {
                throw new Exception("El dominio no fue inicializado. ");
            }

           _DomainUsers = _ADHelper.Users_SearchByGroup("");

           fwkIdentityBindingSource.DataSource = _DomainUsers;
        }
        public void Populate(string groupName)
        {
            if (_ADHelper == null)
            {
                throw new Exception("El dominio no fue inicializado. ");
            }

            _DomainUsers = _ADHelper.Users_SearchByGroup(groupName); ;

            fwkIdentityBindingSource.DataSource = _DomainUsers;
        }

        private void txDomainUserName_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    using (new WaitCursorHelper(this))
                    {
                        //fwkIdentityBindingSource.DataSource = ObjectDomain.FilterByName(txDomainUserName.Text, _DomainUsers);
                    }
                }
        }

        private void btnFilterUsers_Click(object sender, EventArgs e)
        {
            using (new WaitCursorHelper(this))
            {
                //fwkIdentityBindingSource.DataSource = ObjectDomain.FilterByName(txDomainUserName.Text, _DomainUsers);
            }
            
        }





        private void grdDomainUsers_Click(object sender, EventArgs e)
        {
            if (ObjectDomainChangeEvent == null) return;

            if (grdDomainUsers.CurrentRow == null) return;
            if (grdDomainUsers.CurrentRow.DataBoundItem == null) return;

            _CurrentUserName = (ADUser)grdDomainUsers.CurrentRow.DataBoundItem;
            OnObjectDomainChange();
        }

      


    }
}
