using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.HelperFunctions.Caching;
namespace Fwk.Bases.FrontEnd
{
    
    internal static class ClientCacheMannager
    {
        private static FwkCacheCollectionMannager _FwkCacheCollectionMannager;
         static ClientCacheMannager()
        {
            _FwkCacheCollectionMannager = new FwkCacheCollectionMannager();
        }




         public static IServiceContract Get(IRequest pRequest)
         {
             IRequest req = (IRequest)pRequest;
             IServiceContract wResult;
             object wAux = null;
             if (string.IsNullOrEmpty(req.CacheSettings.ResponseCacheId))
                 req.CacheSettings.ResponseCacheId = req.ServiceName;
            
             FwkCache wFwkCache = _FwkCacheCollectionMannager.GetFwkCache(pRequest.CacheSettings.CacheManagerName);

             //TODO: Agregar manejo de error para catching
             wAux =  wFwkCache.GetItemFromCache(req.CacheSettings.ResponseCacheId);
             

             if (wAux == null)
             {
                 wResult = null;
             }
             else
             {
                 wResult = (IServiceContract)wAux;
             }


             return wResult;
         }

        public static void Add(IServiceContract pRequest, IServiceContract pResult)
        {
            IRequest req = (IRequest)pRequest;

            if (req.CacheSettings.DaysForExpiration == 0)
                req.CacheSettings.DaysForExpiration = 1;

            if (string.IsNullOrEmpty(req.CacheSettings.ResponseCacheId))
                req.CacheSettings.ResponseCacheId = pRequest.ServiceName;

            //Almaceno el resultado en la cache
            FwkCache wFwkCache = _FwkCacheCollectionMannager.GetFwkCache(req.CacheSettings.CacheManagerName);

            wFwkCache.SaveItemInCache(
                req.CacheSettings.ResponseCacheId,
                pResult,
                req.CacheSettings.Priority,
                req.CacheSettings.DaysForExpiration);

            //wFwkCache.SaveItemInCache(req.CacheSettings.ResponseCacheId, pResult, true);
        }
        public  static void ClearAll(String pCacheMannagerName)
        {
            _FwkCacheCollectionMannager.GetFwkCache(pCacheMannagerName).ClearAll();
        
        }

    }
}
