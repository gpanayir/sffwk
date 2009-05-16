using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Fwk.HelperFunctions.Caching
{
    /// <summary>
    /// Componente que implementa la funcionalidad para aplicar caching .-
    /// </summary>
    /// <author>moviedo</author>
    /// <date>29/11/2007</date>
    public class FwkCache
    {

        #region "---[Enumeraciones]---"
        



        /// <summary>
        /// Enumeracion Utilizada en Metodo Ititiate que indica el tipo de Cache a utilizar.
        /// </summary>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public enum TypeOfCaching
        {
            /// <summary>
            /// Null Backing Store (almacen en memoria)
            /// </summary>
            NullStorage,
            /// <summary>
            /// Isolated Storage (almacen en disco)
            /// </summary>
            IsolatedStorage,
            /// <summary>
            /// Data Cache Storage 
            /// </summary>
            [Obsolete("Esta caracteristica no se implementa en el framework")]
            DataCacheStorage,
            /// <summary>
            /// A Custom Cache store 
            /// </summary>
            [Obsolete("Esta caracteristica no se implementa en el framework")]
            CustomCacheStorage

        }

       
        #endregion

        #region "---[Atributos Privados]---"

        private CacheManager _CacheManager;

        /// <summary>
        /// Esta clase reprecenta la interfaz a la cache factory.- 
        /// Desde los application blocks todas las operaciones de catching se
        /// llevan a cavo desde aqui.-
        /// </summary>
        public CacheManager CacheManager
        {
            get { return _CacheManager; }
            set { _CacheManager = value; }
        }

        String _CacheManagerName;
        /// <summary>
        /// Nombre  de la configuracion de cache 
        /// </summary>
        public String CacheManagerName
        {
            get { return _CacheManagerName; }
            set { _CacheManagerName = value; }
        }
        #endregion

        

        #region "---[Métodos]---"

        /// <summary>
        /// Asigna la cache por defecto
        /// </summary>
        public FwkCache()
        {
            try
            {
                this.CacheManager = (CacheManager)CacheFactory.GetCacheManager();
            }
            catch (System.TypeInitializationException e)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al inicuializar la configuracion de cache",e);
                te.ErrorId = "3000";
                throw te;
            }
        }

        /// <summary>
        /// Asigna la cache por nombre
        /// </summary>
        /// <param name="pCacheManagerName"></param>
        public FwkCache(String pCacheManagerName)
        {
            _CacheManagerName= pCacheManagerName;
            this.CacheManager = (CacheManager)CacheFactory.GetCacheManager(pCacheManagerName);
        }
        #region "---[Existencia de Ítem en Caché]---"
        /// <summary>
        /// Determino si el Item Existe en Caché
        /// </summary>
        /// <param name="pCahcheId">Claye del Ítem Guardado</param>
        /// <returns>Boolean: Indica si el Ítem se encuentra todavía en Caché</returns>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public Boolean CheckIfCachingExists(String pCahcheId)
        {

            return _CacheManager.Contains(pCahcheId);

        }



        #endregion

        #region "---[Guardar en Caché]---"


        #region "---[Guardado Simple]---"
        /// <summary>
        /// Guarda Ítem en Caché según una key especificada.
        /// </summary>
        /// <param name="pCahcheId">Claye del Ítem a Guardar</param>
        /// <param name="pObject">Ítem a Guardar</param>
        /// <returns>Indica si se pudo insertar el Objeto en Caché con el Key especificado</returns>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public  Boolean SaveItemInCache(String pCahcheId, Object pObject)
        {
            return SaveItemInCache(pCahcheId, pObject, false);
        }
        /// <summary>
        /// Guarda Ítem en Caché según una key especificada.
        /// </summary>
        /// <param name="pCahcheId">Claye del Ítem a Guardar</param>
        /// <param name="pObject">Ítem a Guardar</param>
        /// <param name="pReplaceIfExist">Si es = True y si existe algun item con el mismo Id lo reemplaza</param>
        /// <returns>Indica si se pudo insertar el Objeto en Caché con el Key especificado</returns>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public Boolean SaveItemInCache(String pCahcheId, Object pObject, Boolean pReplaceIfExist)
        {
            if (!pReplaceIfExist && CheckIfCachingExists(pCahcheId))
            {
                return false;
            }
            else
            {
                _CacheManager.Add(pCahcheId, pObject);
                return true;
            }

        }
        ///// <summary>
        ///// Guarda Ítem en Caché Generando Una Key Única.
        ///// </summary>
        ///// <param name="pObject">Ítem a Guardar</param>
        ///// <returns>Key Unica con la que se guardó el Ítem</returns>
        ///// <author>moviedo</author>
        ///// <date>29/11/2007</date>
        //public  String SaveItemInCache(Object pObject)
        //{
        //    try
        //    {
        //        String wCahcheId = Guid.NewGuid().ToString();

        //        _CacheManager.Add(wCahcheId, pObject);

        //        return wCahcheId;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ExceptionHelper.ProcessException(ex);
        //    }

        //}

        #endregion

        #region "---[Guardado con Prioridad y Tiempo de Expiracion]---"
        /// <summary>
        /// Guarda Ítem en Caché Generando Una Key Única.
        /// </summary>
        /// <param name="pObject">Ítem a Guardar</param>
        /// <param name="pPriority">Prioridad del Ítem en Caché</param>
        /// <param name="pDaysFromExpiration">Días para que el Ítem Expire</param>
        /// <returns>Key Unica con la que se guardó el Ítem</returns>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public  String SaveItemInCache(Object pObject, CacheItemPriority pPriority, Double pDaysFromExpiration)
        {

            String wCahcheId = Guid.NewGuid().ToString();

            SaveItemInCache(wCahcheId, pObject, pPriority, pDaysFromExpiration);
           

            return wCahcheId;

        }

        /// <summary>
        /// Guarda Ítem en Caché según una key especificada.
        /// </summary>
        /// <param name="pCahcheId">Claye del Ítem a Guardar</param>
        /// <param name="pObject">Ítem a Guardar</param>
        /// <param name="pPriority">Prioridad del Ítem en Caché</param>
        /// <param name="pDaysFromExpiration">Minutos para que el Ítem Expire</param>
        /// <returns>Indica si se pudo insertar el Objeto en Caché con el Key especificado</returns>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public Boolean SaveItemInCache(String pCahcheId, Object pObject, CacheItemPriority pPriority, Double pDaysFromExpiration)
        {

            if (CheckIfCachingExists(pCahcheId))
            {
                return false;
            }
            else
            {
                _CacheManager.Add(pCahcheId, pObject, pPriority, null, new SlidingTime(TimeSpan.FromDays(pDaysFromExpiration)));
                return true;
            }



        }

        /// <summary>
        /// Guarda Ítem en Caché según una key especificada.
        /// </summary>
        /// <param name="pCahcheId">Claye del Ítem a Guardar</param>
        /// <param name="pObject">Ítem a Guardar</param>
        /// <param name="pPriority">Prioridad del Ítem en Caché</param>
        /// <param name="pDateExpiration">Fecha para la cuál el Ítem Expirará</param>
        /// <returns>Indica si se pudo insertar el Objeto en Caché con el Key especificado</returns>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public  Boolean SaveItemInCache(String pCahcheId, Object pObject, CacheItemPriority pPriority, DateTime pDateExpiration)
        {
           
                if (CheckIfCachingExists(pCahcheId))
                {
                    return false;
                }
                else
                {
                    AbsoluteTime expireTime = new AbsoluteTime(pDateExpiration);
                    _CacheManager.Add(pCahcheId, pObject, pPriority, null, expireTime);
                    return true;
                }

           

        }

        /// <summary>
        /// Guarda Ítem en Caché Generando Una Key Única.
        /// </summary>
        /// <param name="pObject">Ítem a Guardar</param>
        /// <param name="pPriority">Prioridad del Ítem en Caché</param>
        /// <param name="pDateExpiration">Fecha para la cuál el Ítem Expirará</param>
        /// <returns>Key Unica con la que se guardó el Ítem</returns>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public  String SaveItemInCache(Object pObject,CacheItemPriority pPriority,DateTime pDateExpiration)
        {
            String wCahcheId = Guid.NewGuid().ToString();

     
            SaveItemInCache(wCahcheId, pObject, pPriority, pDateExpiration);
            //try
            //{
             

            //    _CacheManager.Add(wCahcheId, pObject, pPriority, null, expireTime);

            return wCahcheId;

            //}
            //catch (Exception ex)
            //{
            //    throw ExceptionHelper.ProcessException(ex);
            //}

        }

        #endregion

        #region "---[Guardado con Accion al Expirar]---"
        ///// <summary>
        ///// Guarda Ítem en Caché Generando Una Key Única.
        ///// </summary>
        ///// <param name="pObject">Ítem a Guardar</param>
        ///// <param name="pPriority">Prioridad del Ítem en Caché</param>
        ///// <param name="pDaysFromExpiration">Minutos para que el Ítem Expire</param>
        ///// <param name="pRefreshOnExpired">Indica si el Item Se volvera a guardar en Cache al Expirar</param>
        ///// <returns>Key Unica con la que se guardó el Ítem</returns>
        ///// <author>moviedo</author>
        ///// <date>29/11/2007</date>
        //public static String SaveItemInCache(Object pObject, CacheItemPriority pPriority, Double pDaysFromExpiration, Boolean pRefreshOnExpired)
        //{
        //    try
        //    {
        //        String wCahcheId = Guid.NewGuid().ToString();
        //        if (pRefreshOnExpired == true)
        //        {
        //            _CacheManager.Add(wCahcheId, pObject, pPriority, new CacheRefreshAction(true, _CacheManager), new SlidingTime(TimeSpan.FromDays(pDaysFromExpiration)));
        //        }
        //        else
        //        {
        //            _CacheManager.Add(wCahcheId, pObject, pPriority, new CacheRefreshAction(false, _CacheManager), new SlidingTime(TimeSpan.FromDays(pDaysFromExpiration)));
        //        }


        //        return wCahcheId;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ExceptionHelper.ProcessException(ex);
        //    }

        //}

        ///// <summary>
        ///// Guarda Ítem en Caché según una key especificada.
        ///// </summary>
        ///// <param name="pCahcheId">Claye del Ítem a Guardar</param>
        ///// <param name="pObject">Ítem a Guardar</param>
        ///// <param name="pPriority">Prioridad del Ítem en Caché</param>
        ///// <param name="pDaysFromExpiration">Minutos para que el Ítem Expire</param>
        ///// <param name="pRefreshOnExpired">Indica si el Item Se volvera a guardar en Cache al Expirar</param>
        ///// <returns>Indica si se pudo insertar el Objeto en Caché con el Key especificado</returns>
        ///// <author>moviedo</author>
        ///// <date>29/11/2007</date>
        //public static Boolean SaveItemInCache(String pCahcheId, Object pObject, CacheItemPriority pPriority, Double pDaysFromExpiration, Boolean pRefreshOnExpired)
        //{
        //    try
        //    {
        //        if (CheckIfCachingExists(pCahcheId))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            if (pRefreshOnExpired == true)
        //            {
        //                _CacheManager.Add(pCahcheId, pObject, pPriority, new CacheRefreshAction(true, _CacheManager), new SlidingTime(TimeSpan.FromDays(pDaysFromExpiration)));
        //            }
        //            else
        //            {
        //                _CacheManager.Add(pCahcheId, pObject, pPriority, new CacheRefreshAction(false, _CacheManager), new SlidingTime(TimeSpan.FromDays(pDaysFromExpiration)));
        //            }

        //            return true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ExceptionHelper.ProcessException(ex);
        //    }

        //}

        ///// <summary>
        ///// Guarda Ítem en Caché Generando Una Key Única
        ///// </summary>
        ///// <param name="pObject">Ítem a Guardar</param>
        ///// <param name="pPriority">Prioridad del Ítem en Caché</param>
        ///// <param name="pDateExpiration">Fecha para la cuál el Ítem Expirará</param>
        ///// <param name="pRefreshOnExpired">Indica si el Item Se volvera a guardar en Cache al Expirar</param>
        ///// <returns>Key Unica con la que se guardó el Ítem</returns>
        ///// <author>moviedo</author>
        ///// <date>29/11/2007</date>
        //public static String SaveItemInCache(Object pObject, CacheItemPriority pPriority, DateTime pDateExpiration, Boolean pRefreshOnExpired)
        //{
        //    try
        //    {
        //        String wCahcheId = Guid.NewGuid().ToString();

        //        AbsoluteTime expireTime = new AbsoluteTime(pDateExpiration);

        //        if (pRefreshOnExpired == true)
        //        {
        //            _CacheManager.Add(wCahcheId, pObject, pPriority, new CacheRefreshAction(true, _CacheManager), expireTime);
        //        }
        //        else
        //        {
        //            _CacheManager.Add(wCahcheId, pObject, pPriority, new CacheRefreshAction(false, _CacheManager), expireTime);
        //        }
        //        return wCahcheId;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ExceptionHelper.ProcessException(ex);
        //    }

        //}

        ///// <summary>
        ///// Guarda Ítem en Caché según una key especificada.
        ///// </summary>
        ///// <param name="pCahcheId">Claye del Ítem a Guardar</param>
        ///// <param name="pObject">Ítem a Guardar</param>
        ///// <param name="pPriority">Prioridad del Ítem en Caché</param>
        ///// <param name="pDateExpiration">Fecha para la cuál el Ítem Expirará</param>
        ///// <param name="pRefreshOnExpired">Indica si el Item Se volvera a guardar en Cache al Expirar</param>
        ///// <returns>Indica si se pudo guardar con la Key Pasada por parámetro</returns>
        ///// <author>moviedo</author>
        ///// <date>29/11/2007</date>
        //public static Boolean SaveItemInCache(String pCahcheId, Object pObject, CacheItemPriority pPriority, DateTime pDateExpiration, Boolean pRefreshOnExpired)
        //{
        //    try
        //    {
        //        if (CheckIfCachingExists(pCahcheId))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            AbsoluteTime expireTime = new AbsoluteTime(pDateExpiration);

        //            if (pRefreshOnExpired == true)
        //            {
        //                _CacheManager.Add(pCahcheId, pObject, pPriority, new CacheRefreshAction(true, _CacheManager), expireTime);
        //            }
        //            else
        //            {
        //                _CacheManager.Add(pCahcheId, pObject, pPriority, new CacheRefreshAction(false, _CacheManager), expireTime);
        //            }


        //            return true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ExceptionHelper.ProcessException(ex);
        //    }

        //}

        #endregion

        #endregion

        #region "---[Limpiar Cache]---"

        /// <summary>
        /// Borra todos los ítems de Caché
        /// </summary>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public  void ClearAll()
        {
            
                _CacheManager.Flush();
           

        }

        #endregion

        #region "---[Remove Ítem]---"
        /// <summary>
        /// Eliminar un Ítem de Caché
        /// </summary>
        /// <param name="pCahcheId">Claye del Ítem a Guardado</param>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public void RemoveItem(String pCahcheId)
        {

            _CacheManager.Remove(pCahcheId);

        }

        #endregion

        #region "---[Recuperar Ítems de Caché]---"
        /// <summary>
        /// Recupera un Ítem de Cache dependiendo del Identificador del mismo.
        /// </summary>
        /// <param name="pCahcheId">Clave con el que se guardó el objeto</param>
        /// <returns>Object: Objeto que se quiere recuperar de Caché</returns>
        /// <author>moviedo</author>
        /// <date>29/11/2007</date>
        public  Object GetItemFromCache(String pCahcheId)
        {
            
                return _CacheManager.GetData(pCahcheId);
          
        }
        #endregion

        #endregion

    }
}