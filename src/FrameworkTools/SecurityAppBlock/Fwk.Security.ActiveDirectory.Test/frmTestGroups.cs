using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;
using System.Security.Permissions;
using Fwk.Security.Common;
using Fwk.Bases.FrontEnd.Controls;

namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class frmTestGroups : Form
    {
        //String[] _SelectedGroups;
    
        //FwkIdentity _FwkIdentityCurrent;

        public frmTestGroups()
        {
            InitializeComponent();
        }

        private void domainGoups2_DomainGroupChangeEvent(ADGroup pGroup)
        {
            //_CurrentObjectDomainGroup = pGroup;
            //txtXmlGroupInfo.Text = _CurrentObjectDomainGroup.GetXml();
           
          
            objectDomainGroupBindingSource.DataSource = pGroup;
            grdGroupInfo.Refresh();
            domainUsers1.Initialize(txtDomain.Text);
            domainUsers1.Populate(pGroup.Name);
            //domainGoups1.Populate(pGroup.ActiveDirectoryMembersGroups);
            System.Threading.Thread.Sleep(100);
            
        }

      

        private void btnSearchInDomain_Click(object sender, EventArgs e)
        {
            domainGoups2.Initialize(txtDomain.Text);
       

            using (new WaitCursorHelper(this))
            {
                domainGoups2.Populate();
             
            }
        }

        private void domainUsers1_ObjectDomainChangeEvent(FwkIdentity pFwkIdentity)
        {

        }
    }
}
