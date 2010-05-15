using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevExpress.XtraEditors;

namespace WindowsLogViewer
{
    public partial class frmFilter : XtraForm
    {
        bool _IsNew = true;
        Filter _Filter;

        public Filter Filter
        {
            get
            {

                if (_Filter == null)
                    _Filter = new Filter();

                if (!string.IsNullOrEmpty(txtCategory.Text))
                    _Filter.EventLog.Category = txtCategory.Text;

                if (!string.IsNullOrEmpty(txtUserName.Text))
                    _Filter.EventLog.UserName = txtUserName.Text;
                if (!string.IsNullOrEmpty(txtName.Text))
                    _Filter.Name = txtName.Text;
                if (!string.IsNullOrEmpty(txtMachineName.Text))
                    _Filter.EventLog.MachineName = txtMachineName.Text;

                if (!string.IsNullOrEmpty(txtAuditedPc.Text))
                    _Filter.EventLog.AuditMachineName = txtAuditedPc.Text;

                if (!string.IsNullOrEmpty(txtSource.Text))
                    _Filter.EventLog.Source = txtSource.Text;

                _Filter.EventLog.TimeWritten = dateTimePicker1.Value;

                if (comboBox_Log.SelectedIndex != 0)
                    _Filter.EventLog.WinLog = (WindowsLogsType)Enum.Parse(typeof(WindowsLogsType), comboBox_Log.Text); 

                if (comboBox_EntryType.SelectedIndex != 0)
                    _Filter.EventLog.EntryType = (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), comboBox_EntryType.Text);



                return _Filter;

            }
            set { _Filter = value; }
        }

        public frmFilter()
        {
            InitializeComponent();
       
            comboBox_Log.SelectedIndex = 0;
            comboBox_EntryType.SelectedIndex = 0;
        }

        public frmFilter(bool isNew)
        {
            InitializeComponent();
            _IsNew = isNew;
            comboBox_Log.SelectedIndex = 0;
            comboBox_EntryType.SelectedIndex = 0;
        }

        public void Populate(Filter pFilter)
        {
            if (pFilter == null) return;
            _Filter = pFilter;
            
            txtName.Text = _Filter.Name;

            if (!_IsNew)
                txtName.Enabled = false;

            txtUserName.Text = _Filter.EventLog.UserName;
            txtMachineName.Text = _Filter.EventLog.MachineName;
            txtAuditedPc.Text = _Filter.EventLog.AuditMachineName;
            txtSource.Text = _Filter.EventLog.Source;
            txtCategory.Text = _Filter.EventLog.Category;

            if (_Filter.EventLog.TimeWritten != null)
                dateTimePicker1.Value = _Filter.EventLog.TimeWritten.Value;

            if (_Filter.EventLog.WinLog != null)
                comboBox_Log.SelectedIndex = comboBox_Log.FindString(_Filter.EventLog.WinLog.Value.ToString());

            if (_Filter.EventLog.EntryType != null)
                comboBox_EntryType.SelectedIndex = comboBox_EntryType.FindString(_Filter.EventLog.EntryType.Value.ToString());




        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            

            if (_IsNew && frmMain.UserProfile.Filters.Exists(p => p.Name.Equals(txtName.Text)))
            {
                MessageBox.Show("The filter named " + txtName.Text + " alredy existe in folter colection");
                txtName.SelectAll();
                txtName.Focus();
                
                
                return;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
