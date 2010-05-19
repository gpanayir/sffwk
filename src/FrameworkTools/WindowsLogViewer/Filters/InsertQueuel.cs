using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Timers;
using System.Diagnostics;
namespace WindowsLogViewer
{
    public delegate void DelegateWithOutAndRefParameters(out Exception ex, object t);


    public class InsertPool
    {
        Timer deamon;
        bool ocuped = false;
        public InsertPool()
        {
            deamon = new Timer(2000);
            deamon.Elapsed += new ElapsedEventHandler(deamon_Elapsed);
        }

        void deamon_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (ocuped == false)
            {
                deamon.Stop();
                if (_Queue.Count > 0)
                    InsertAsync(_Queue.Dequeue());
            }
        }

        Queue<task> _Queue = new Queue<task>();

        public void Insert(EventLogEntryCollection pEventLogList, Filter pAuditMachine)
        {
            task t = new task(pEventLogList, pAuditMachine);
            if (ocuped)
                _Queue.Enqueue(t);

            else
            {

                InsertAsync(t);
            }

        }



        /// <summary>
        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
        /// </summary>
        void InsertAsync(task t)
        {
            ocuped = true;

            Exception ex = null;
            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Insert);

            s.BeginInvoke(out ex, t, new AsyncCallback(EndInsert), null);
        }

        /// <summary>
        /// Fin de el metodo populate que fue llamado de forma asincrona
        /// </summary>
        /// <param name="res"></param>
        void EndInsert(IAsyncResult res)
        {
            Exception ex;


            AsyncResult result = (AsyncResult)res;

            DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
            del.EndInvoke(out ex, res);

            ocuped = false;
            deamon.Start();
        }

        /// <summary>
        /// Carga Dominios relacionados entre al objeto _RelatedDomains que esta bindiado a la grilla
        /// </summary>
        void Insert(out Exception ex, object o)
        {
            ex = null;
            task t = (task)o;
            try
            {
                LogDAC.Insert(t.List, t.AuditMachine.EventLog.WinLog.Value.ToString(), t.AuditMachine.EventLog.AuditMachineName);

            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }
        }



    }




    public class task
    {

        public task(EventLogEntryCollection pList, Filter pAuditMachine)
        {

            _List = pList;
            _AuditMachine = pAuditMachine;
        }
        EventLogEntryCollection _List;

        public EventLogEntryCollection List
        {
            get { return _List; }

        }
        Filter _AuditMachine;
        public Filter AuditMachine
        {
            get { return _AuditMachine; }

        }
    }
}
