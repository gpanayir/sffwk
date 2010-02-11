using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using Fwk.Bases;
using System.Diagnostics;
using System.Threading;

namespace TestServicePerformance
{
      public delegate void CheckEven(string msg, int threadNumber,double average,double totalTime);
    internal class RemotingWrapper
    {
        public event CheckEven MessageEvent;
        public ManualResetEvent[] doneEvents;
    
        Fwk.Remoting.FwkRemoteObject _RemoteObj;

        internal Fwk.Remoting.FwkRemoteObject RemoteObj
        {
            get { return _RemoteObj; }
        }

        Fwk.Bases.IServiceContract isvcReq;
        Fwk.Bases.IServiceContract isvcRes;
        internal void Init(string server, string port, string objectUri)
        {

            string url = string.Concat("tcp://", server, ":", port, @"/", objectUri);
            Init(url);
        }

        internal void Init(string url)
        {
            if (_RemoteObj != null)
                _RemoteObj = null;

            _RemoteObj = (Fwk.Remoting.FwkRemoteObject)Activator.GetObject(typeof(Fwk.Remoting.FwkRemoteObject), url);


        }

       

         internal void Start(string xml)
        {
            isvcReq = (Fwk.Bases.IServiceContract)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Request);
            isvcRes = (Fwk.Bases.IServiceContract)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Response);
            isvcReq.SetBusinessDataXml(xml);
             doneEvents = new ManualResetEvent[ControllerTest.Storage.StorageObject.Threads];

            for (int i = 0; i <= ControllerTest.Storage.StorageObject.Threads; i++)
            { 
                doneEvents[i] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(new WaitCallback(StartThread), i);
            }
        }

        void StartThread(object threadNumber)
        {
            double sumTotalMilliseconds = 0;
            for (int i = 0; i <= ControllerTest.Storage.StorageObject.Calls; i++)
            {
                Stopwatch watch = new Stopwatch();
                isvcRes = _RemoteObj.ExecuteService(isvcReq);
                watch.Stop();
                sumTotalMilliseconds  += watch.Elapsed.TotalMilliseconds;
            }

            double AVERAGE = sumTotalMilliseconds / ControllerTest.Storage.StorageObject.Calls;

            if (MessageEvent!=null)
                MessageEvent("Thread Nº", (int)threadNumber, AVERAGE, sumTotalMilliseconds);

            doneEvents[(int)threadNumber].Set();
        }

       


      

    }

    [Serializable]
    public class Store
    {
        int _Threads = 1;

        public int Threads
        {
            get { return _Threads; }
            set { _Threads = value; }
        }
         int _Calls = 1;

        public int Calls
        {
            get { return _Calls; }
            set { _Calls = value; }
        }


        string _XmlRequest = string.Empty;

             public string XmlRequest
        {
            get { return _XmlRequest; }
            set { _XmlRequest = value; }
        }
        string _server = string.Empty;

        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        string _objectUri = string.Empty;

        public string ObjectUri
        {
            get { return _objectUri; }
            set { _objectUri = value; }
        }
        string _port = "8085";

        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }


        string _svc = string.Empty;

        public string Svc
        {
            get { return _svc; }
            set { _svc = value; }
        }

        string _AssemblyPath = string.Empty;

        public string AssemblyPath
        {
            get { return _svc; }
            set { _svc = value; }
        }
        private ServiceConfiguration _SelectedServiceConfiguration = new ServiceConfiguration ();

     
        public ServiceConfiguration SelectedServiceConfiguration
        {
            get { return _SelectedServiceConfiguration; }
            set { _SelectedServiceConfiguration = value; }
        }
    }
}
