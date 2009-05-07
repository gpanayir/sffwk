﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.HelperFunctions.Caching;
using System.Windows.Forms;
using System.Reflection;

namespace Fwk.ServiceManagement.Tools.Win32
{
    internal class SettingStorage
    {
        public static Storage Storage = new Storage();





        private static FwkCache _FwkCache;

         static SettingStorage()
        {
            try
            {
                _FwkCache = new FwkCache();

                if (_FwkCache.CheckIfCachingExists(Assembly.GetExecutingAssembly().GetName().Name))

                    Storage = (Storage)_FwkCache.GetItemFromCache(Assembly.GetExecutingAssembly().GetName().Name);
                else
                    Storage = new Storage();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Save()
        {
            _FwkCache.SaveItemInCache(Assembly.GetExecutingAssembly().GetName().Name, Storage,true);
        }
    }
    [Serializable]
    struct Storage
    {
        public string _AssemblyPath;
    }
}
