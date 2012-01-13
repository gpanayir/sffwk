using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Forms;
using Fwk.UI.Security.Controls;

namespace Fwk.UI.Test
{
    public partial class SecurityTest : FormBase
    {
        public SecurityTest()
        {
            InitializeComponent();
        }

        private void SecurityTest_Load(object sender, EventArgs e)
        {
            //Cargamos el Formulario de Autenticación
            FRM_AuthenticationForm wAuthForm = new FRM_AuthenticationForm();

            //Antes de mostrar el formulario de Autenticación validamos que tenga modos de Autenticación acticados.
            if (wAuthForm.LoadAuthenticationModes())
            {
                if (wAuthForm.ShowDialog() != DialogResult.OK)
                    Fwk.UI.Controls.SimpleMessageView.Show("Fallo en la autenticación del usuario", "Login", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Warning);
                else
                    navBarControl1.Enabled = true;
            }
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UC_UsersMain wUserMain = new UC_UsersMain();
            
            DevExpress.XtraTab.XtraTabPage wPagina = xtraTabControl1.TabPages.Add();
            wPagina.Text = wUserMain.Name;
            wPagina.Controls.Add(wUserMain);
            wPagina.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            wUserMain.Dock = DockStyle.Fill;         
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UC_RoleMain wRoleMain = new UC_RoleMain();
            DevExpress.XtraTab.XtraTabPage wPagina = xtraTabControl1.TabPages.Add();
            wPagina.Text = wRoleMain.Name;
            wPagina.Controls.Add(wRoleMain);
            wPagina.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            wRoleMain.Dock = DockStyle.Fill;     
        }

      

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UC_RuleSelector wRuleSelector = new UC_RuleSelector();
            DevExpress.XtraTab.XtraTabPage wPagina = xtraTabControl1.TabPages.Add();
            wPagina.Text = wRuleSelector.Name;
            wPagina.Controls.Add(wRuleSelector);
            wPagina.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            wRuleSelector.Dock = DockStyle.Fill;
            wRuleSelector.populate();
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage.Dispose();
        }

      
    }
}
