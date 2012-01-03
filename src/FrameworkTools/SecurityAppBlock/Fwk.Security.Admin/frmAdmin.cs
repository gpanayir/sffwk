using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Web.Security;
using Fwk.Security.Common;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Security.Principal;
using Fwk.Bases.FrontEnd.Controls;
using Fwk.Security;
using Fwk.Security.Admin.Controls;
using System.Reflection;

namespace Fwk.Security.Admin 
{
    public partial class frmAdmin : frmSecBase
    {
       SecurityControlBase currontSecurityControlBase;
        public static MembershipProvider Provider = Membership.Provider;
        public static Boolean CurrentProviderConnectedOk = false;
        public frmAdmin()
        {
    
            InitializeComponent();
            this.Text = string.Concat(this.Text, " version ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = FwkMembership.GetUser(Environment.UserName, frmAdmin.Provider.Name);
        }
        
        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                currontSecurityControlBase = ControlsFactory.Show(e.Link, this.panelControl1);
                //Esto se hace de esta manera ya que el tree listo no se carga correctamente la  primera vez que se levanta el control
                if (currontSecurityControlBase.GetType() == typeof(CategoryCreate))
                    ((CategoryCreate)currontSecurityControlBase).PopulateAsync();
            }
            catch (Exception ex)
            {
                base.MessageViewInfo.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }
            
           
        }

        private void cmbProviders_EditValueChanged(object sender, EventArgs e)
        {
            try
            {


                frmAdmin.Provider = Membership.Providers[cmbProviders.Text];

                string cnnString = FwkMembership.GetProvider_ConnectionString(frmAdmin.Provider.Name);
                Fwk.DataBase.CnnString cnn = new DataBase.CnnString("", cnnString);

                lblServer.Text = cnn.DataSource;
                lblDatabase.Text = cnn.InitialCatalog;
                DataBase.Metadata m = new DataBase.Metadata(cnn);
                
                if (m.TestConnection())
                {
                    CurrentProviderConnectedOk = true;
                    lblConnectionStatus.Text = "Connected";
                }
                else
                {
                    CurrentProviderConnectedOk = false;
                    lblConnectionStatus.Text = "Disconected";
                }
            }
            catch (Exception ex)
            {
                CurrentProviderConnectedOk = false;
                lblConnectionStatus.Text = "Disconected";
                base.MessageViewInfo.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }

            if (currontSecurityControlBase == null) return;
            try
            {

                currontSecurityControlBase.Initialize();
                
            }
            catch (Exception ex)
            {
                CurrentProviderConnectedOk = false;
                lblConnectionStatus.Text = "Disconected";
                base.MessageViewInfo.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            cmbProviders.Properties.DataSource = FwkMembership.GetAllMembershiproviderNameArray();
            cmbProviders.ItemIndex = 0;

        }

       
       
       
    }
}
