using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebExporter
{
    [Serializable]
    public class Store
    {
        static Fwk.Caching.FwkCache _FwkCache;

        public static Fwk.Caching.FwkCache FwkCache
        {
            get { return Store._FwkCache; }
            set { Store._FwkCache = value; }
        }
         static Store()
        {
            _FwkCache = new Fwk.Caching.FwkCache();
        }
        public  Store()
        {
        
            if (_FwkCache.CheckIfCachingExists("WebExporter"))
            {
                Store wStore = (Store)Store.FwkCache.GetItemFromCache("WebExporter");
                _Destination = wStore.Destination;
                _Source = wStore.Source;

                
            }
        }
        public static void Save(Store pStore)
        {
            _FwkCache.SaveItemInCache("WebExporter", pStore, true);
        }



        bool _ReplaceContentFile = false;

        public bool ReplaceContentFile
        {
            get { return _ReplaceContentFile; }
            set { _ReplaceContentFile = value; }
        }



        private string _Source;

        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        private string _Destination;

        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }
  

      
    }
}
