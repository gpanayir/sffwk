using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
namespace Fwk.HelperFunctions.Caching
{

    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCacheMannager
    {
       
        public static IServiceContract Get(IRequest pRequest)
        {
            IRequest req = (IRequest)pRequest;
            IServiceContract wResult;
            object wItemInCache = null;
            if (string.IsNullOrEmpty(req.CacheSettings.ResponseCacheId))
                req.CacheSettings.ResponseCacheId = req.ServiceName;

            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(pRequest.CacheSettings.CacheManagerName);

            //TODO: Agregar manejo de error para catching
            wItemInCache = wFwkCache.GetItemFromCache(req.CacheSettings.ResponseCacheId);


            if (wItemInCache == null)
            {
                wResult = null;
            }
            else
            {
                wResult = (IServiceContract)wItemInCache;
            }


            return wResult;
        }

        public static void Add(IServiceContract pRequest, IServiceContract pResult)
        {
            IRequest req = (IRequest)pRequest;

         

            if (string.IsNullOrEmpty(req.CacheSettings.ResponseCacheId))
                req.CacheSettings.ResponseCacheId = pRequest.ServiceName;

            //Almaceno el resultado en la cache
            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(req.CacheSettings.CacheManagerName);

            wFwkCache.SaveItemInCache(
                req.CacheSettings.ResponseCacheId,
                pResult,
                req.CacheSettings.Priority,
                req.CacheSettings.ExpirationTime, req.CacheSettings.TimeMeasures, req.CacheSettings.RefreshOnExpired);

            
        }
        public static void ClearAll(String pCacheMannagerName)
        {
            KwkCacheFactory.GetFwkCache(pCacheMannagerName).ClearAll();

        }

    }
}
