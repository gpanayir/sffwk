using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using WindowsLogViewer.Properties;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using DevExpress.XtraEditors;

namespace WindowsLogViewer
{
    enum ConnectionStatus { Started, Paused, Error }
    public partial class AuditControl : XtraUserControl
    {
        Filter _AuditMachine;
        private bool started = false;
        public event EventHandler MessageSelected;
        public event EventHandler CloseEventLog;
       
        List<EventLogEntry> _LogList = new List<EventLogEntry>();
   
        [Browsable(false)]
        public Filter AuditMachine
        {
            get { return _AuditMachine; }
            set { _AuditMachine = value; }
        }

        public AuditControl()
        {
            InitializeComponent();
          
        }
   

        /// <summary>
        /// Muestro aqui el texto del mensage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((System.Windows.Forms.BindingSource)(dataGridView2.DataSource)).Current.GetType() != typeof(EventLogEntry)) 
                return;

            EventLogEntry rf = (EventLogEntry)((System.Windows.Forms.BindingSource)(dataGridView2.DataSource)).Current;
            if (rf == null) return;
            MessageSelected(rf, new EventArgs());
        }

        /// <summary>
        /// Si hay una nueva entrada la agrego a ala coleccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventLogControl_EntryWritten(object sender, EntryWrittenEventArgs e)
        {


            if (IsValidEntry(e.Entry))
            {
                _LogList.Add(e.Entry);
                this.eventLogEntryBindingSource.DataSource = null;
                this.eventLogEntryBindingSource.DataSource = _LogList;
                PaintUnboundedCells();
                dataGridView2.RefreshEdit();
                dataGridView2.Refresh();
            }
        }

        /// <summary>
        /// Determina si la entrada cumple con el filtro 
        /// </summary>
        /// <param name="pEntry"></param>
        /// <returns></returns>
        bool IsValidEntry(EventLogEntry pEntry)
        {

            // El filtro por los campos restantes esta implisito en  this.EventLogControl 

            if (_AuditMachine.EventLog.EventID.Count > 0)
                if (!_AuditMachine.EventLog.EventID.Contains<Int64>(pEntry.InstanceId)) return false;

            if (_AuditMachine.EventLog.EntryType != null)
                if (_AuditMachine.EventLog.EntryType != pEntry.EntryType) return false;
            
            if (!string.IsNullOrEmpty( _AuditMachine.EventLog.Source))
                if (_AuditMachine.EventLog.Source.Equals(pEntry.Source, StringComparison.OrdinalIgnoreCase)) return false;

            if (!string.IsNullOrEmpty(_AuditMachine.EventLog.Category))
                if (_AuditMachine.EventLog.Category.Equals(pEntry.Category, StringComparison.OrdinalIgnoreCase)) return false;


            if (!string.IsNullOrEmpty(_AuditMachine.EventLog.UserName))
                if (_AuditMachine.EventLog.UserName.Equals(pEntry.UserName, StringComparison.OrdinalIgnoreCase)) return false;

           

            return true;
        }


        public void ClearLogs()
        {
            _LogList.Clear();
            this.eventLogEntryBindingSource.DataSource = null;
            dataGridView2.RefreshEdit();
            dataGridView2.Refresh();
        }

       
        /// <summary>
        /// Comienso la lectura de las entradas de eventos de la pc.-
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (started)
            {
                SetStatus(ConnectionStatus.Paused, string.Empty);
            }
            else
            {
                ClearLogs();
                try
                {
                   
                   PopulateAsync(this.EventLogControl.Entries);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        

      
        void SetStatus(ConnectionStatus s,string err)
        {
            switch (s)
            {
                case ConnectionStatus.Paused:
                    {
                       
                        btnStart.Text = "Start";
                        btnStart.Image = (Image)Resources.play;
                        pictureStatus.Image = (Image)Resources.ball_yellow;
                        lblStatus.Text = "Paused";
                        this.EventLogControl.EnableRaisingEvents = false;
                        btnClearLogs.Enabled = false;
                        break;
                    }
                case ConnectionStatus.Started:
                    {
                       
                        btnStart.Text = "Pause";
                        btnStart.Image = (Image)Resources.play_pause;
                        pictureStatus.Image = (Image)Resources.ball_green;
                        lblStatus.Text = "Started";
                        this.EventLogControl.EnableRaisingEvents = true;
                        btnClearLogs.Enabled = true;
                        break;
                    }
                case ConnectionStatus.Error:
                    {
                        btnStart.Text = "Start";
                        btnStart.Image = (Image)Resources.play_pause;
                        pictureStatus.Image = (Image)Resources.ball_red;
                        lblStatus.Text = "Error on connect";
                        lblError.Text = err;
                        this.EventLogControl.EnableRaisingEvents = false;
                        btnClearLogs.Enabled = false;
                        MessageBox.Show(err);
                        break;
                    }
            }
            started = !started;
        }

        public void Populate(Filter pAuditMachine)
        {
            try
            {
                _AuditMachine = pAuditMachine;
                this.EventLogControl.Log = _AuditMachine.EventLog.WinLog.Value.ToString();
                this.EventLogControl.MachineName = _AuditMachine.EventLog.AuditMachineName;
                this.EventLogControl.Source = _AuditMachine.EventLog.Source;

                if (_AuditMachine.EventLog.AuditMachineName.Equals("."))
                    this.lblAuditedMachine.Text = "(local)";
                else
                    this.lblAuditedMachine.Text = _AuditMachine.EventLog.AuditMachineName;

                this.lblWinLog.Text = _AuditMachine.EventLog.WinLog.Value.ToString();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you wont to remove all logs from this machineName: " + _AuditMachine.EventLog.AuditMachineName, "Windows event logs", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

                
                EventLogControl.Clear();
                ClearLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.EventLogControl.EnableRaisingEvents = false;
            this.EventLogControl.Close();
            CloseEventLog(this,new EventArgs());
        }

       

     


        Image GetImage(System.Diagnostics.EventLogEntryType type)
        {
            switch (type)
            {
                case System.Diagnostics.EventLogEntryType.Error:
                case System.Diagnostics.EventLogEntryType.FailureAudit:
                    {
                        return (Image)Resources.error_16;

                    }
                case System.Diagnostics.EventLogEntryType.Information:
                case System.Diagnostics.EventLogEntryType.SuccessAudit:
                    {
                        return (Image)Resources.info;

                    }
                case System.Diagnostics.EventLogEntryType.Warning:
                    {
                        return (Image)Resources.warning_16;

                    }


            }
            return null;
        }
        void PaintUnboundedCells()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Index > -1)
                {
                    System.Diagnostics.EventLogEntryType type = (System.Diagnostics.EventLogEntryType)row.Cells[1].Value;
                    row.Cells[0].Value = GetImage(type);
                }
            }
        }

        List<EventLogEntry> GetValidEntries(EventLogEntryCollection entries)
        {
            List<EventLogEntry> entriesFiltered = new List<EventLogEntry>();
            foreach (EventLogEntry entry in entries)
            {
                if (IsValidEntry(entry))
                {
                    entriesFiltered.Add(entry);
                }
                
            }
            return entriesFiltered;
        }
        void Fill(List<EventLogEntry> pEventLogEntryCollection)
        {
            foreach (EventLogEntry entry in pEventLogEntryCollection)
            {
                _LogList.Add(entry);
            }
        }
   

        #region PopulateSync

        /// <summary>
        /// Carga de manera asincrona los EventLogEntryCollection  en la grilla.-
        /// </summary>
        public void PopulateAsync(EventLogEntryCollection entries)
        {

            btnStart.Enabled = false;
            btnClearLogs.Enabled = false;
            Exception ex = null;
            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Populate);

            s.BeginInvoke(out ex, entries, new AsyncCallback(EndPopulate), null);
        }

        /// <summary>
        /// Fin de el metodo populate que fue llamado de forma asincrona
        /// </summary>
        /// <param name="res"></param>
        void EndPopulate(IAsyncResult res)
        {
            Exception ex;

            if (this.InvokeRequired)
            {
                AsyncCallback d = new AsyncCallback(EndPopulate);
                try
                {
                    this.Invoke(d, new object[] { res });

                }
                catch (Exception)
                {
                    
                }
            }
            else
            {
                AsyncResult result = (AsyncResult)res;

                DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
                del.EndInvoke(out ex, res);

                if (ex != null)
                {
                    SetStatus(ConnectionStatus.Error, ex.Message);
                    this.EventLogControl.EnableRaisingEvents = false;
                    return;
                }
                this.eventLogEntryBindingSource.DataSource = _LogList;
                PaintUnboundedCells();
                dataGridView2.RefreshEdit();
                dataGridView2.Refresh();
                this.EventLogControl.EnableRaisingEvents = true;

                LogDAC.TaskPool.Insert(this.EventLogControl.Entries, _AuditMachine);
                SetStatus(ConnectionStatus.Started, string.Empty);
                btnStart.Enabled = true;
                btnClearLogs.Enabled = true;
            }
        }

        /// <summary>
        /// Carga eventos a la grilla
        /// </summary>
        void Populate(out Exception ex,object o)
        {
            ex = null;

            try
            {
                _LogList = GetValidEntries(((EventLogEntryCollection)o));
                //_((EventLogEntryCollection)o)
                //Fill((List<EventLogEntry>)o);

            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }
        }

        #endregion

     


    }
}
