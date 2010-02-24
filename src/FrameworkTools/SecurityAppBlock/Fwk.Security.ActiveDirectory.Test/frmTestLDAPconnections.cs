using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.ActiveDirectory;
namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class frmTestLDAPconnections : Form
    {
        ADHelper _ADHelper;
        public frmTestLDAPconnections()
        {
            InitializeComponent();
            StringBuilder str = new StringBuilder();
            str.Append("Prueba de AD Helper como instancia.-");
            str.Append("Es ncesario ingresar los datos debajo para crear un objeto autenticado de AD Helper");
            label2.Text = str.ToString();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                _ADHelper = new ADHelper(txtPath.Text, txtLoginName.Text, txtPassword.Text);
                lstDomains.DataSource = _ADHelper.Domain_GetList1();
                label4.Text = _ADHelper.LDAPPath;
            }
            catch (Exception ex)
            {
                lblResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _ADHelper = new ADHelper(txtPath2.Text, txtLoginName.Text, txtPassword.Text);
                lstDomains.DataSource = _ADHelper.Domain_GetList1();
                label4.Text = _ADHelper.LDAPPath;
            }
            catch (Exception ex)
            {
                lblResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                _ADHelper = new ADHelper(txtPath3.Text, txtLoginName.Text, txtPassword.Text);
                lstDomains.DataSource = _ADHelper.Domain_GetList1();
                label4.Text = _ADHelper.LDAPPath;
            }
            catch (Exception ex)
            {
                lblResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                _ADHelper = new ADHelper(txtDomain.Text);
                lstDomains.DataSource = _ADHelper.Domain_GetList1();
                label4.Text = _ADHelper.LDAPPath;
            }
            catch (Exception ex)
            {
                lblResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }
    }
}
