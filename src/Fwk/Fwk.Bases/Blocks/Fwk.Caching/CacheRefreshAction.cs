using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Fwk.HelperFunctions.Caching
{
    /// <summary>
    /// Clase que Determina la Accion a seguir cuando Cache hace Refresh.
    /// </summary>
    [Serializable]
    public class CacheRefreshAction : ICacheItemRefreshAction
    {
        private Boolean _RefreshOnExpired;
        private CacheManager _wCacheManager;

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
        public CacheRefreshAction(Boolean pRefreshOnExpired, CacheManager pCacheManager) 
        {
            _RefreshOnExpired = pRefreshOnExpired;
            _wCacheManager = pCacheManager;
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
            if (removalReason == CacheItemRemovedReason.Expired)
                if (_RefreshOnExpired == true)
                {
                    _wCacheManager.Add(removedKey, expiredValue);
                }
                else
                {
                    _wCacheManager.Remove(removedKey);
                }
            else
            {
                throw new Exception("No se puede acceder al item del Cache: Item " + removalReason.ToString());
            }
                
        }

        #endregion
    }
}
