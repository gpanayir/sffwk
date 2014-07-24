using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Configuration.Common;

namespace ConfigurationApp.Forms
{
    public partial class frmExportXmlToBd : Form
    {
        #region << -Attributes- >>
        private enum AuthenticationModes
        {
            [Description("Autenticación SQL")]
            SqlAuthentication = 1,
            [Description("Autenticación de Windows")]
            IntegratedAuthentication = 2
        }

        private const string _ErrorColor = "#F8F4B3";
        #endregion

        #region << -Constructors- >>
        public frmExportXmlToBd()
        {
            InitializeComponent();
        }
        #endregion

        #region << -Events- >>
        private void frmExportXmlToBd_Load(object sender, EventArgs e)
        {
            try
            {
                cmbAuthenticationMode.Items.Add(ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.SqlAuthentication));
                cmbAuthenticationMode.Items.Add(ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.IntegratedAuthentication));
                cmbAuthenticationMode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDbCheck_Click(object sender, EventArgs e)
        {
            SqlConnection wConn = null;

            try
            {
                btnDbCheck.Enabled = false;
                wConn = CreateConnection();
                if (wConn == null)
                    return;

                wConn.Open();
                MessageBox.Show("Conexión Exitosa", "Probar Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Probar Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (wConn != null && wConn.State == ConnectionState.Open)
                    wConn.Close();
                btnDbCheck.Enabled = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Multiselect = false;
                openFileDialog1.FileName = string.Empty;
                
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;

                txtXml.Text = openFileDialog1.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SqlConnection wConn = null;
            SqlCommand wCmd = null;
            string wXmlText = string.Empty;
            ConfigurationFile wConfigFile = null;
            StringBuilder wBuilder = null;
            System.IO.FileInfo wFInfo = null;

            try
            {
                progressBar1.Value = 0;

                wConn = CreateConnection();
                if (wConn == null || !XmlValidationRequired())
                    return;

                progressBar1.Increment(2);

                //Obtengo los datos del xml
                wFInfo = new System.IO.FileInfo(txtXml.Text);
                wXmlText = Fwk.HelperFunctions.FileFunctions.OpenTextFile(txtXml.Text);
                wConfigFile = new ConfigurationFile();
                wConfigFile = ConfigurationFile.GetFromXml<ConfigurationFile>(wXmlText);
                if (wConfigFile.Groups == null)
                {
                    MessageBox.Show("No hay datos para migrar", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                progressBar1.Increment(48);

                wBuilder = new StringBuilder();
                foreach (Group wGrp in wConfigFile.Groups)
                {
                    foreach (Fwk.Configuration.Common.Key wKey in wGrp.Keys)
                    {
                        wBuilder.Append("INSERT INTO [dbo].[fwk_ConfigManager]([ConfigurationFileName],[group],[key],[encrypted],[value])VALUES(");
                        wBuilder.Append(string.Concat("'", wFInfo.Name, "', "));
                        wBuilder.Append(string.Concat("'", wGrp.Name, "', "));
                        wBuilder.Append(string.Concat("'", wKey.Name, "', "));
                        wBuilder.Append(string.Concat(Convert.ToInt32(wKey.Encrypted), ", "));
                        wBuilder.Append(string.Concat("'", wKey.Value.ToString().Replace("'", string.Empty), "'"));
                        wBuilder.Append(")");
                        wBuilder.AppendLine();
                    }
                }

                progressBar1.Increment(40);

                wConn.Open();
                wCmd = new SqlCommand(wBuilder.ToString(), wConn) { CommandType = CommandType.Text };
                wCmd.ExecuteNonQuery();

                progressBar1.Increment(10);

                MessageBox.Show("Exportación terminada exitosamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (wConn != null && wConn.State == ConnectionState.Open)
                    wConn.Close();
            }
        }


        private void cmbAuthenticationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAuthenticationMode.Text == ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.SqlAuthentication))
                {
                    txtUser.Enabled = true;
                    txtPassword.Enabled = true;
                }
                else
                {
                    txtUser.Enabled = false;
                    txtPassword.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        #endregion

        #region << -Methods- >>
        private bool DataBaseValidateRequired()
        {
            bool wValid = true;


            if (string.IsNullOrEmpty(txtServer.Text.Trim()))
            {
                txtServer.BackColor = Color.FromName(_ErrorColor);
                wValid = false;
            }
            else
                txtServer.BackColor = Color.White;

            if (string.IsNullOrEmpty(txtDataBase.Text.Trim()))
            {
                txtDataBase.BackColor = Color.FromName(_ErrorColor);
                wValid = false;
            }
            else
                txtDataBase.BackColor = Color.White;

            if (cmbAuthenticationMode.Text == ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.SqlAuthentication))
            {
                if (string.IsNullOrEmpty(txtUser.Text.Trim()))
                {
                    txtUser.BackColor = Color.FromName(_ErrorColor);
                    wValid = false;
                }
                else
                    txtUser.BackColor = Color.White;

                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    txtPassword.BackColor = Color.FromName(_ErrorColor);
                    wValid = false;
                }
                else
                    txtPassword.BackColor = Color.White;
            }

            return wValid;
        }

        private bool XmlValidationRequired()
        {
            bool wValid = true;

            if (string.IsNullOrEmpty(txtXml.Text))
            {
                txtXml.BackColor = Color.FromName(_ErrorColor);
                wValid = false;
            }
            if (!System.IO.File.Exists(txtXml.Text))
            {
                MessageBox.Show("Archivo XML inexistente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXml.BackColor = Color.FromName(_ErrorColor);
                wValid = false;
            }
            else
                txtXml.BackColor = Color.White;

            return wValid;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnectionStringBuilder wConnStr = null;
            SqlConnection wConn = null;

            if (!DataBaseValidateRequired())
                return null;
            wConnStr = new SqlConnectionStringBuilder();
            wConnStr.InitialCatalog = txtDataBase.Text.Trim();
            wConnStr.DataSource = txtServer.Text.Trim();
            wConnStr.IntegratedSecurity = (cmbAuthenticationMode.Text == ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.IntegratedAuthentication));
            wConnStr.PersistSecurityInfo = (cmbAuthenticationMode.Text == ConfigurationApp.Common.Helper.GetEnumDescription(AuthenticationModes.SqlAuthentication));
            if (txtUser.Enabled)
            {
                wConnStr.UserID = txtUser.Text.Trim();
                wConnStr.Password = txtPassword.Text.Trim();
            }

            wConn = new SqlConnection(wConnStr.ToString());

            return wConn;
        }

        #endregion

    }
}
