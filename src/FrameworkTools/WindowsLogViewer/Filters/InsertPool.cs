//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Diagnostics;
//using Microsoft.Practices.EnterpriseLibrary.Data;
//using System.Data.Common;
//using System.Data;
//using System.Drawing;
//using WindowsLogViewer.Properties;
//using System.Timers;

//namespace WindowsLogViewer
//{
//    public delegate void DelegateWithOutAndRefParameters(out Exception ex, task t);


//    public class InsertPool
//    {
//        Timer deamon;
//        bool ocuped = false;
//        public InsertPool()
//        {
//            deamon = new Timer(2000);
//            deamon.Elapsed += new ElapsedEventHandler(deamon_Elapsed);
//        }

//        void deamon_Elapsed(object sender, ElapsedEventArgs e)
//        {
//            if (ocuped == false)
//            {
//                deamon.Stop();
//                if (_Queue.Count > 0)
//                    InsertAsync(_Queue.Dequeue());
//            }
//        }

//        Queue<task> _Queue = new Queue<task>();

//        public void Insert(List<EventLog> pEventLogList, AuditMachine pAuditMachine)
//        {
//            task t = new task(pEventLogList, pAuditMachine);
//            if (ocuped)
//                _Queue.Enqueue(t);

//            else
//            {

//                InsertAsync(t);
//            }

//        }



//        /// <summary>
//        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
//        /// </summary>
//        void InsertAsync(task t)
//        {
//            ocuped = true;

//            Exception ex = null;
//            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Insert);

//            s.BeginInvoke(out ex,
//                t, new AsyncCallback(EndInsert), null);
//        }

//        /// <summary>
//        /// Fin de el metodo populate que fue llamado de forma asincrona
//        /// </summary>
//        /// <param name="res"></param>
//        void EndInsert(IAsyncResult res)
//        {
//            Exception ex;


//            AsyncResult result = (AsyncResult)res;

//            DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
//            del.EndInvoke(out ex, res);

//            ocuped = false;
//            deamon.Start();
//        }

//        /// <summary>
//        /// Carga Dominios relacionados entre al objeto _RelatedDomains que esta bindiado a la grilla
//        /// </summary>
//        void Insert(out Exception ex, task t)
//        {
//            ex = null;

//            try
//            {
//                LogDAC.Insert(t.List, t.AuditMachine.WinLog, t.AuditMachine.MachineName);

//            }
//            catch (Exception err)
//            {
//                err.Source = "Origen de datos";
//                ex = err;
//            }
//        }



//    }




//    public class task
//    {

//        public task(List<EventLog> pList, AuditMachine pAuditMachine)
//        {

//            _List = pList;
//            _AuditMachine = pAuditMachine;
//        }
//        List<EventLog> _List;

//        public List<EventLog> List
//        {
//            get { return _List; }

//        }
//        AuditMachine _AuditMachine;
//        public AuditMachine AuditMachine
//        {
//            get { return _AuditMachine; }

//        }
//    }
//}
