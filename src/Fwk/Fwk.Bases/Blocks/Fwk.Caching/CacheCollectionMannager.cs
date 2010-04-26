using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Caching;


namespace Fwk.Caching
{
    /// <summary>
    /// Calse que mantiene las instancias de las cache manager de la aplicacion.-
    /// </summary>
    public static class KwkCacheFactory
    {
        static System.Collections.Generic.Dictionary<String, FwkCache> _CacheCollection;
        /// <summary>
        /// Diccionario generico con una coleccion de <see cref="FwkCache"/>
        /// </summary>
        public static System.Collections.Generic.Dictionary<String, FwkCache> CacheCollection
        {
            get { return _CacheCollection; }
            set { _CacheCollection = value; }
        }
        /// <summary>
        /// 
        /// </summary>
         static KwkCacheFactory()
        {
            _CacheCollection = new Dictionary<string, FwkCache>();
        }

        /// <summary>
        /// Inicializa la configuracion de cache definida  en App.Config
        /// Por ejemplo puede ser:
        /// "CacheListadosClientes"
        /// Si se pasa un StringEmpty se utilizara la configuracion por defecto :
        /// "cachingConfiguration: defaultCacheManager="ConfigurationIsolatedManager"
        /// </summary>
        /// <param name="pCacheManagerName">Determina el nombre de la configuracion de la cache</param>
        /// <author>moviedo</author>
        /// <date>29/11/2008</date>
        public static FwkCache GetFwkCache(string pCacheManagerName)
        {


            FwkCache wFwkCache;
            if (pCacheManagerName == null)
                pCacheManagerName = String.Empty;

            if (_CacheCollection.ContainsKey(pCacheManagerName))
                    return _CacheCollection[pCacheManagerName];

            //-------------Default cache setting
            if (string.IsNullOrEmpty(pCacheManagerName))
            {
                wFwkCache = new FwkCache();
                _CacheCollection.Add(String.Empty, wFwkCache);

            }
            else
            {
                wFwkCache = new FwkCache(pCacheManagerName);
                _CacheCollection.Add(pCacheManagerName, wFwkCache);
            }
            return wFwkCache;
        }







    }
}
