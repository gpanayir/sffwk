using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using Fwk.HelperFunctions;

namespace WindowsLogViewer
{
    public partial class ctrlFilter : DevExpress.XtraEditors.XtraUserControl
    {
        #region fields
        Filter _Filter;
        private String _NotAllowedCharacters = @"!#<>/\?)(¿'´{}^%&=+*~";
        [Category("WindowsLogViewer")]
        public bool GroupUserVisible
        {
            set { groupBox3.Visible = value; }
            get { return groupBox3.Visible; }
        }

        [Category("WindowsLogViewer")]
        public bool DateVisible
        {
            set { checkBox1.Visible = dateTimePicker1.Visible = value; }
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
        public Filter GetSingleFilter()
        {
            SetFilter();

            return _Filter;


        }

        public void RefreshSingleFilter()
        {
            if (Validate() == false) return;
        }
        Filters _Filters;
        [Browsable(false)]
        public Filters Filters
        {
            get
            {
                return _Filters;
            }
   
        }
        public void RefreshFilters() 
        {
            if (Validate() == false) return;

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
        /// <summary>
        /// Establece los valores del filtro generico
        /// </summary>
        void SetFilter()
        {
            if (dxErrorProvider1.HasErrors)
            {
                _Filter = null;
                return;
            }
            //Valor que me determina si al menos un valor del filtro fue establecido
            int valuesCounter = 0;
            _Filters = new Filters();
            if (_Filter == null)
                _Filter = new Filter();

            if (comboBox_Log.SelectedIndex > 0)
            {
                _Filter.EventLog.WinLog = (WindowsLogsType)Enum.Parse(typeof(WindowsLogsType), comboBox_Log.Text.Trim());
                valuesCounter++;
            }
            if (comboBox_EntryType.SelectedIndex > 0)
            {
                _Filter.EventLog.EntryType = (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), comboBox_EntryType.Text);
                valuesCounter++;
            }
            if (!string.IsNullOrEmpty(txtCategory.Text.Trim()))
            {
                _Filter.EventLog.Category = txtCategory.Text;
                valuesCounter++;
            }
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                _Filter.EventLog.UserName = txtUserName.Text;

                valuesCounter++;
            }
            if (!string.IsNullOrEmpty(txtMachineName.Text.Trim()))
            {
                _Filter.EventLog.MachineName = txtMachineName.Text;
                valuesCounter++;
            }
            if (!string.IsNullOrEmpty(txtAuditedPc.Text))
            {
                _Filter.EventLog.AuditMachineName = txtAuditedPc.Text;
                valuesCounter++;
            }
            if (!string.IsNullOrEmpty(txtSource.Text.Trim()))
            {
                _Filter.EventLog.Source = txtSource.Text;
                valuesCounter++;
            }
            if (!string.IsNullOrEmpty(txtEventId.Text.Trim()))
            {
                _Filter.EventLog.FillEventId(txtEventId.Lines);
                valuesCounter++;
            }
            if (checkBox1.Checked)
            {
                _Filter.EventLog.TimeGenerated = dateTimePicker1.Value;
                valuesCounter++;
            }
            else
            {
                _Filter.EventLog.TimeGenerated = null;
            }
            if (valuesCounter ==0)
                _Filter = null;
        }
        #endregion

        public ctrlFilter()
        {
            InitializeComponent();
            comboBox_Log.SelectedIndex = 0;
            comboBox_EntryType.SelectedIndex = 0;

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

            if (_Filter.EventLog.EventID.Count > 0)
                txtEventId.Lines = FormatFunctions.GetStringBuilderWhitSeparator<Int64>(_Filter.EventLog.EventID, '\n').ToString().Split('\n');

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
           
           
        }


        bool Validate()
        {
            dxErrorProvider1.ClearErrors();
            long l;
            try
            {
                foreach (string s in txtEventId.Lines)
                {
                    l = long.Parse(s);

                }
            }
            catch (FormatException)
            {
                dxErrorProvider1.SetError(txtEventId, "Todos los numeros de evento deben ser numericos");
                return false;
            }
            
            return true;
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!String.IsNullOrEmpty(_NotAllowedCharacters))
            {
                if (_NotAllowedCharacters.Contains(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                    return;
                }
            }
     
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = checkBox1.Checked;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }








       
    }
}
