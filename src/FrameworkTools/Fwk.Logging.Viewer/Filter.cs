using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Logging.Viewer
{
    public delegate void OnFilterChangedHandler(Event eventFilter, DateTime endDate);

    public partial class Filter : UserControl
    {
        bool cmbType_init = true;
        public event OnFilterChangedHandler OnFilterChanged;
        public Filter()
        {
            InitializeComponent();

            cmbType.SelectedIndex = 0;
        }

        bool Validate()
        {
            //Fecha desde > fecha fin
            if (dtStartDate.Value.CompareTo(dtEndDate.Value) > 0)
            {
                errorProvider1.SetError(dtEndDate, "Fecha desde debe ser menor a fecha hasta");
                return false;
            }

            return true;
        }

        void SetFilter()
        {
            errorProvider1.Clear();
            Event wEventFilter = new Event();
            DateTime wEndDate = Fwk.HelperFunctions.DateFunctions.NullDateTime;

            if (cmbType.SelectedIndex == 0)
                wEventFilter.LogType = EventType.None;
            else
               wEventFilter.LogType = (EventType)Enum.Parse(typeof(EventType), cmbType.Text);

            if (chDates.Checked)
            {
                if ((dtStartDate.Value.CompareTo(dtEndDate.Value)) != 0)
                {
                    wEndDate = dtEndDate.Value;
                }
                wEventFilter.LogDate = dtStartDate.Value;
            }
            if (!string.IsNullOrEmpty(txtText.Text))
            {
                wEventFilter.AppId = txtText.Text;
                wEventFilter.Source = txtText.Text;
                wEventFilter.Machine = txtText.Text;
                wEventFilter.User = txtText.Text;
            }
            if (OnFilterChanged != null)
                OnFilterChanged(wEventFilter, wEndDate);
        }
        public void Refresh()
        {
            cmbType.SelectedIndex = 0;
            txtText.Text = string.Empty;
            chDates.Checked = false;
        }
        private void chDates_CheckedChanged(object sender, EventArgs e)
        {
          dtStartDate.Enabled =  dtEndDate.Enabled = chDates.Checked;
          SetFilter();
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtText.Text))
            {
                SetFilter();
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType_init == false)
            {
                SetFilter();
            }
            cmbType_init = false;
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (Validate())
            {
                SetFilter();
            }
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (Validate())
            {
                SetFilter();
            }
        }
    }
}
