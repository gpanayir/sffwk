using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace WindowsLogViewer
{
    public partial class ctrlFilter : DevExpress.XtraEditors.XtraUserControl
    {
        #region fields
        Filter _Filter;

        [Category("WindowsLogViewer")]
        public bool GroupUserVisible
        {
            set { groupBox3.Visible = value; }
            get { return groupBox3.Visible; }
        }

        [Category("WindowsLogViewer")]
        public bool DateVisible
        {
            set { lblDate.Visible = dateTimePicker1.Visible = value; }
            get { return dateTimePicker1.Visible; }
        }
        [Category("WindowsLogViewer")]
        public bool ServerNameEnabled
        {
            set { txtAuditedPc.Enabled = value; }
            get { return txtAuditedPc.Enabled; }
        }
        [Category("WindowsLogViewer")]
        public bool WinLogEnabled
        {
            set { comboBox_Log.Enabled = value; }
            get { return comboBox_Log.Enabled; }
        }

        /// <summary>
        /// Este campo se utiliza cuando se quiere retornar un filtro solo, por mas que se allan 
        /// ingresado mas de un valor en uno de los campos. 
        /// </summary>
        [Browsable(false)]
        public Filter SingleFilter
        {
            get
            {
                if (!DesignMode)
                {

                    if (_Filter == null)
                        _Filter = new Filter();

                    if (comboBox_Log.SelectedIndex != 0)
                        _Filter.EventLog.WinLog = (WindowsLogsType)Enum.Parse(typeof(WindowsLogsType), comboBox_Log.Text);

                    if (comboBox_EntryType.SelectedIndex != 0)
                        _Filter.EventLog.EntryType = (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), comboBox_EntryType.Text);

                    if (!string.IsNullOrEmpty(txtCategory.Text))
                        _Filter.EventLog.Category = txtCategory.Text;

                    if (!string.IsNullOrEmpty(txtUserName.Text))
                        _Filter.EventLog.UserName = txtUserName.Text;


                    if (!string.IsNullOrEmpty(txtMachineName.Text))
                        _Filter.EventLog.MachineName = txtMachineName.Text;

                    if (!string.IsNullOrEmpty(txtAuditedPc.Text))
                        _Filter.EventLog.AuditMachineName = txtAuditedPc.Text;

                    if (!string.IsNullOrEmpty(txtSource.Text))
                        _Filter.EventLog.Source = txtSource.Text;

                    if (!string.IsNullOrEmpty(txtEventId.Text))
                        _Filter.EventLog.EventID = Convert.ToInt64(txtEventId.Text);

                    _Filter.EventLog.TimeWritten = dateTimePicker1.Value;

                  
                }
                return _Filter;

            }
            set { _Filter = value; }
        }

        Filters _Filters;
        [Browsable(false)]
        public Filters Filters
        {
            get
            {
                if (!DesignMode)
                {
                    SetFilter();
                    Filter f = null;
                    _Filters.Clear();
                    //Crea tantos filtros como cantidad de maquinas o servers a auditar esten en el campo txtAuditedPc
                    foreach (string s in txtAuditedPc.Lines)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            f = (Filter.GetFromXml<Filter>(_Filter.GetXml()));
                            f.EventLog.AuditMachineName = s;
                     
                            _Filters.Add(f);
                        }
                    }
                }
                return _Filters;
            }
            set { _Filters = value; }
        }

        void SetFilter()
        {
            _Filters = new Filters();
            if (_Filter == null)
                _Filter = new Filter();

            if (!string.IsNullOrEmpty(txtCategory.Text))
                _Filter.EventLog.Category = txtCategory.Text;

            if (!string.IsNullOrEmpty(txtUserName.Text))
                _Filter.EventLog.UserName = txtUserName.Text;


            if (!string.IsNullOrEmpty(txtMachineName.Text))
                _Filter.EventLog.MachineName = txtMachineName.Text;

            if (!string.IsNullOrEmpty(txtAuditedPc.Text))
                _Filter.EventLog.AuditMachineName = txtAuditedPc.Text;

            if (!string.IsNullOrEmpty(txtSource.Text))
                _Filter.EventLog.Source = txtSource.Text;

            if (!string.IsNullOrEmpty(txtEventId.Text))
                _Filter.EventLog.EventID = Convert.ToInt64(txtEventId.Text);

            _Filter.EventLog.TimeWritten = dateTimePicker1.Value;

            if (comboBox_Log.SelectedIndex > 0)
                _Filter.EventLog.WinLog = (WindowsLogsType)Enum.Parse(typeof(WindowsLogsType), comboBox_Log.Text.Trim());

            if (comboBox_EntryType.SelectedIndex > 0)
                _Filter.EventLog.EntryType = (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), comboBox_EntryType.Text);


            

        }
        #endregion

        public ctrlFilter()
        {
            InitializeComponent();

        
        }
        public void Populate(Filter pFilter)
        {
           

            if (pFilter == null) return;
            _Filter = pFilter;

      

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

       


        private void ctrlFilter_Load(object sender, EventArgs e)
        {
            txtAuditedPc.Focus();
            comboBox_Log.SelectedIndex = 0;
            comboBox_EntryType.SelectedIndex = 0;
        }
    }
}
