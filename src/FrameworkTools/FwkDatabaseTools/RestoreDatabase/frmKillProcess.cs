using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Caching;

namespace RestoreDatabase
{
    public partial class frmKillProcess : Form
    {
        public frmKillProcess()
        {
            InitializeComponent();
            Init();

        }

        private void btnKillProcess_Click(object sender, EventArgs e)
        {
            DataTable wDtt = null;
            try
            {

                KillProceessEngine.KillProcess(GetConfigSetting());
                MessageBox.Show("All the processes were killed satisfactorily..");

                if (wViewAll.Checked)
                    wDtt = KillProceessEngine.SearchProcess(GetConfigSetting());
                else
                    wDtt = KillProceessEngine.SearchProcess(txtDataBaseName.Text, GetConfigSetting());

                grdLogRegistry.DataSource = wDtt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnWho_Click(object sender, EventArgs e)
        {
            DataTable wDtt = null;
            try
            {
                if (wViewAll.Checked)
                    wDtt = KillProceessEngine.SearchProcess(GetConfigSetting());
                else
                    wDtt = KillProceessEngine.SearchProcess(txtDataBaseName.Text, GetConfigSetting());

                grdLogRegistry.DataSource = wDtt;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdLogRegistry_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Windows.Forms.DataGridView wDataGridView = (System.Windows.Forms.DataGridView)sender;

            txtDataBaseName.Text = wDataGridView.Rows[e.RowIndex].Cells["dbname"].Value.ToString();
        }



        private void btnRestore_Click(object sender, EventArgs e)
        {
            KillProceessEngine.RestoreDataBase(txtDataBaseName.Text, txtBackUpSource.Text, GetConfigSetting());
            MessageBox.Show("Restore Ok..", "KillProcess");

        }





        private void frmKillProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigSetting wConfig =GetConfigSetting();
          


            var wConfigSettings = from item in _ConfigSettings
                                  where
                                  (item.BackUpSource.Trim() == wConfig.BackUpSource.Trim())
                                  &&
                                  (item.Server.Trim() == wConfig.Server.Trim())
                                  &&
                                  (item.DataBaseName.Trim() == wConfig.DataBaseName.Trim())


                                  select item;


            if (wConfigSettings.Count<ConfigSetting>() == 0)
            {
                _ConfigSettings.Add(wConfig);
                _FwkCache.ClearAll();
                _FwkCache.SaveItemInCache("KillProcessConfigSettings", _ConfigSettings);
            }
        }
        ConfigSetting GetConfigSetting()
        {
            ConfigSetting wConfig = new ConfigSetting();
            wConfig.BackUpSource = txtBackUpSource.Text.Trim();
            wConfig.DataBaseName = txtDataBaseName.Text.Trim();
            wConfig.Server = txtServer.Text.Trim();
            wConfig.User = txtUser.Text.Trim();
            wConfig.Password = txtPassword.Text.Trim();

            return wConfig;
        }
        private void frmKillProcess_Load(object sender, EventArgs e)
        {

        }


        FwkCache _FwkCache;
        ConfigSettings _ConfigSettings = null;
        ConfigSetting _ConfigSetting = null;
        void Init()
        {

            _FwkCache = new FwkCache();

            _ConfigSettings = (ConfigSettings)_FwkCache.GetItemFromCache("KillProcessConfigSettings");

            if (_ConfigSettings == null)
            {
                _ConfigSettings = new ConfigSettings();
            }

            configSettingBindingSource.DataSource = _ConfigSettings;
            if (_ConfigSettings.Count > 0)
            {
                fwkFlatComboBox1.SelectedIndex = 0;

                _ConfigSetting = (ConfigSetting)fwkFlatComboBox1.SelectedItem;
            }
        }

        private void fwkFlatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ConfigSetting = (ConfigSetting)fwkFlatComboBox1.SelectedItem;
            if (_ConfigSetting != null)
                currentSetting.DataSource = _ConfigSetting.Clone();
        }
    }
}