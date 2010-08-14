using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Fwk.Caching
{
    /// <summary>
    /// Clase que Determina la Accion a seguir cuando Cache hace Refresh.
    /// </summary>
    [Serializable]
    public class CacheRefreshAction : ICacheItemRefreshAction
    {
        private Boolean _RefreshOnExpired;
        private string _CacheManagerName;

        /// <summary>
        /// 
        /// </summary>
        public Boolean RefreshOnExpired
        {
            get { return _RefreshOnExpired; }
            set { _RefreshOnExpired = value; }
        }


        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="pRefreshOnExpired"></param>
        /// <param name="pCacheManager"></param>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public CacheRefreshAction(Boolean pRefreshOnExpired, string pCacheManagerName) 
        {
            _RefreshOnExpired = pRefreshOnExpired;
            _CacheManagerName = pCacheManagerName;
        }

        #region ICacheItemRefreshAction Members

        /// <summary>
        /// En caso que se use: Metodo que es llamado cuando se refresca Cache y determina que hacer con los objetos
        /// que están cacheados cuando los mismo Expiran o Cuando surge algún otro motivo para remover el mismo.
        /// </summary>
        /// <param name="removedKey"></param>
        /// <param name="expiredValue"></param>
        /// <param name="removalReason"></param>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public void Refresh(string removedKey, object expiredValue, CacheItemRemovedReason removalReason)
        {
            FwkCache wCacheManager = KwkCacheFactory.GetFwkCache(_CacheManagerName);
            if (removalReason == CacheItemRemovedReason.Expired)
            {
                if (_RefreshOnExpired == true)
                {
                    wCacheManager.CacheManager.Add(removedKey, expiredValue);
                }
                else
                {
                    wCacheManager.CacheManager.Remove(removedKey);
                }
            }
            if (removalReason == CacheItemRemovedReason.Removed)
            {
                wCacheManager.CacheManager.Remove(removedKey);
            }
        }

        #endregion
    }
}
