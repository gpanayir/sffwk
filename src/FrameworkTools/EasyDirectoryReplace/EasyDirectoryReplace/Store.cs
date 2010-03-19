using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDirectoryReplace
{
    [Serializable]
    public class Store
    {
        static Fwk.HelperFunctions.Caching.FwkCache _FwkCache;

        public static Fwk.HelperFunctions.Caching.FwkCache FwkCache
        {
            get { return Store._FwkCache; }
            set { Store._FwkCache = value; }
        }
         static Store()
        {
            _FwkCache = new Fwk.HelperFunctions.Caching.FwkCache();
        }
        public  Store()
        {
        
            if (_FwkCache.CheckIfCachingExists("EasyDirectoryReplace"))
            {
                Store wStore = (Store)Store.FwkCache.GetItemFromCache("EasyDirectoryReplace");
                _Destination = wStore.Destination;
                _Source = wStore.Source;
                _NewText = wStore.NewText;
                _OldText = wStore.OldText;
                _ReplaceContentFile = wStore.ReplaceContentFile;
            }
        }
        public static void Save(Store pStore)
        {
            _FwkCache.SaveItemInCache("EasyDirectoryReplace", pStore,true);
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
        private string _NewText;

        public string NewText
        {
            get { return _NewText; }
            set { _NewText = value; }
        }

        private string _OldText;

        public string OldText
        {
            get { return _OldText; }
            set { _OldText = value; }
        }
    }
}
