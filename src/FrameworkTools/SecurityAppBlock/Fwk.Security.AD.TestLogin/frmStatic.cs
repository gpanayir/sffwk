using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.ActiveDirectory;

namespace Fwk.Security.AD.TestLogin
{
    public partial class frmStatic : Form
    {
        public frmStatic()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                //lblCheckResult.Text = ADHelper.User_CheckLogin(txtDomain.Text, txtLoginName.Text, txtPassword.Text).ToString();
            }
            catch (Exception ex)
            {
                lblCheckResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

        }

        private void lblCheckResult_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDomain_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtLoginName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
