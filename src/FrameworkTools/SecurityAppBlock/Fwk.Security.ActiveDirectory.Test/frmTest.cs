﻿using System;
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
    public partial class frmTest : Form
    {

        String[] _SelectedGroups;
        ObjectDomainGroup _CurrentObjectDomainGroup;
        FwkIdentity _FwkIdentityCurrent;
       

        public frmTest()
        {
            InitializeComponent();
                        //System.Web.Security.SqlMembershipProvider wSqlMembershipProvider = new System.Web.Security.SqlMembershipProvider();
            //wSqlMembershipProvider.ApplicationName = 
            using (new WaitCursorHelper(this))
            {
                try
                {
                    userByAppBindingSource.DataSource = FwkMembership.GetAllUsers();
                    rolListBindingSource.DataSource = FwkMembership.GetAllRoles();
                }
                catch (Exception ex)
                {
                    FwkMessageView.Show(ex, Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                }
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {

            using (new WaitCursorHelper(this))
            {
                try
                {
                    FwkMembership.CreateUser(_FwkIdentityCurrent.Name, txtPassword.Text,String.Empty);
                }
                catch (Exception ex)
                {
                    FwkMessageView.Show(ex, Properties.Resources.MessageBoxTitle, System.Windows.Forms.MessageBoxButtons.OK,
                        Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                }

            }
            userByAppBindingSource.DataSource = FwkMembership.GetAllUsers();
        }


        private void btnSearchInDomain_Click(object sender, EventArgs e)
        {
            domainGoups2.Initialize(txtDomain.Text);
            domainUsers1.Initialize(txtDomain.Text);
            
            using (new WaitCursorHelper(this))
            {
                domainGoups2.Populate();
                //domainUsers1.Populate();
            }
        }

        private void domainGoups2_ObjectDomainChangeEvent(ObjectDomainGroup pObjectDomainGroup)
        {
            _CurrentObjectDomainGroup = pObjectDomainGroup;
        }

        private void domainUsers1_ObjectDomainChangeEvent(FwkIdentity pFwkIdentity)
        {
            _FwkIdentityCurrent = pFwkIdentity;

            txtUserFullName.Text = pFwkIdentity.FullName;
            txtUserName.Text = pFwkIdentity.Name; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FwkActyveDirectory _FwkActyveDirectory = new FwkActyveDirectory("Alco");

           
            Int32 CA =_FwkIdentityCurrent.ActiveDirectoryGroups.Count;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.dataGridView1.DataSource = _FwkIdentityCurrent.ActiveDirectoryGroups;

        }

       
        

     
       

       

    }









}
