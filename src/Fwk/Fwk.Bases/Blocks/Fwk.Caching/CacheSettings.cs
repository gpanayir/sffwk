using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace Fwk.HelperFunctions.Caching
{
    /// <summary>
    /// Clase Utilizada para Deserializar la configuracion para Cada Servicio Cacheable.
    /// </summary>
    /// <author>moviedo</author>
    /// <date>29/11/2007
    /// </date>
    [Serializable]
    public class CacheSettings
    {
        private Boolean _CacheOnServerSide = false;

        /// <summary>
        /// Bandera que indica si los resultados de la ejecucion del servicio seran primero intentados
        /// otener desde la cache del lado del servidor
        /// </summary>
        /// <example>
        /// <para>
        /// El siguiente ejemplo determina que el servicio se levantara de la cache del 
        /// lado del despachador de servicio.-
        /// </para>
        /// <code>
        /// BuscarPaisesClienteRequest req = new BuscarPaisesRequest();
        /// req.ResponseCacheId = req.ServiceName + "RRHH";
        /// req.CacheOnServerSide = true;
        /// </code>|
        /// </example>
        public Boolean CacheOnServerSide
        {
            get { return _CacheOnServerSide; }
            set { _CacheOnServerSide = value; }
        }
        private Boolean _CacheOnClientSide = false;

        /// <summary>
        /// Bandera que indica si los resultados de la ejecucion del servicio seran primero intentados
        /// otener desde la cache del lado del cliente
        /// </summary>
        /// <example>
        /// <para>
        /// El siguiente ejemplo determina que el servicio se levantara de la cache del 
        /// lado del despachador de servicio.-
        /// </para>
        /// <code>
        /// BuscarPaisesClienteRequest req = new BuscarPaisesRequest();
        /// req.CacheSettings.ResponseCacheId = req.ServiceName + "RRHH";
        /// req.CacheSettings.CacheOnClientSide = true;
        /// </code>
        /// </example>
        public Boolean CacheOnClientSide
        {
            get { return _CacheOnClientSide; }
            set { _CacheOnClientSide = value; }
        }


        private String _ResponseCacheId;

        /// <summary>
        /// Identificador de la cache para el caso de que el servicio este cacheado 
        /// tanto en el lado del cliente como en el servidor.
        /// Puede proporcionarle cualquier identificador de cache. Por ejemplo:
        /// 1- El mismo nombre del servicio
        /// 2 - Nombre de servicio mas fecha
        /// 2 - Nombre de servicio mas Dominio/ Area donde corra el cliente o servidor 
        ///  
        /// Si este valor es = Empty() y alguna de las CacheOnClientSide o CacheOnServerSide estan establecidas en true
        /// se asume el Id de la cache del servicio con el nombre del servicio.-
        /// </summary>
        /// <example>
        /// <para>
        /// El siguiente ejemplo determina que el servicio se levantara de la cache del 
        /// lado del despachador de servicio.-
        /// </para>
        /// <coede>
        /// BuscarPaisesClienteRequest req = new BuscarPaisesRequest();
        /// req.ResponseCacheId = req.ServiceName + "RRHH";
        /// req.CacheOnServerSide = true;
        /// </coede>
        /// </example>
        public String ResponseCacheId
        {
            get { return _ResponseCacheId; }
            set { _ResponseCacheId = value; }
        }



        private CacheItemPriority _Priority;

        ///<summary>
        ///Especifica la prioridad relativa de los elementos almacenados en el objeto Cache.  <see cref="CacheItemPriority"/>
        ///AboveNormal Los elementos de la memoria caché con este nivel de prioridad tienen menos posibilidades de ser eliminados cuando el servidor libera la memoria del sistema que aquéllos que tengan asignada una prioridad Normal.  
        ///BelowNormal Los elementos de la memoria caché con este nivel de prioridad tienen más posibilidad de ser eliminados cuando el servidor libera la memoria del sistema que aquéllos que tengan asignada una prioridad Normal.  
        ///Default El valor predeterminado para la prioridad de un elemento de la memoria caché es Normal.  
        ///High Los elementos de la memoria caché con este nivel de prioridad son los que menos posibilidades tienen de ser eliminados de la memoria caché cuando el servidor libera la memoria del sistema.  
        ///Low Los elementos de la memoria caché con este nivel de prioridad son los que más posibilidades tienen de ser eliminados de la memoria caché cuando el servidor libera la memoria del sistema.  
        ///Normal Los elementos de la memoria caché con este nivel de prioridad podrán ser eliminados de la memoria caché cuando el servidor libere la memoria del sistema sólo después de eliminarse los elementos con la prioridad Low o BelowNormal. Éste es el valor predeterminado.  
        ///NotRemovable Los elementos de la memoria caché con este nivel de prioridad no se eliminarán de la memoria caché cuando el servidor libere la memoria del sistema. Sin embargo, los elementos con este nivel de prioridad se quitan junto con otros elementos en función de la fecha de caducidad absoluta o variable del elemento.   
        /// </summary>
        public CacheItemPriority Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }

        private Double _ExpirationTime = 0;
        private Fwk.HelperFunctions.DateFunctions.TimeMeasuresEnum _TimeMeasuresEnum = DateFunctions.TimeMeasuresEnum.FromDays;

        /// <summary>
        /// Medida de tiempo q se usa para reprecentar ExpirationTime 
        /// pueden ser dias, horas, minutos, segundos
        /// Por defecto es FromDays.-
        /// </summary>
        public Fwk.HelperFunctions.DateFunctions.TimeMeasuresEnum TimeMeasures
        {
            get { return _TimeMeasuresEnum; }
            set { _TimeMeasuresEnum = value; }
        }
        /// <summary>
        /// Valor que indica la cantidad de dias que la cache espera a ser eliminada del cache repository.-
        /// Se pueden utilizar fracciones de dia.-
        /// </summary>
        public Double ExpirationTime
        {
            get { return _ExpirationTime; }
            set { _ExpirationTime = value; }
        }



        private String _CacheManagerName;

        /// <summary>
        /// Determina el nombre de la configuracion de la cache
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///   <cachingConfiguration defaultCacheManager="ConfigurationIsolatedManager">
        ///     <cacheManagers>
        ///         <add expirationPollFrequencyInSeconds="60" 
        ///             maximumElementsInCacheBeforeScavenging="1000"
        ///             numberToRemoveWhenScavenging="60" 
        ///             backingStoreName="NullStorage"
        ///             name="ConfigurationManager" />
        /// ]]>
        /// </code> 
        ///</example>
        public String CacheManagerName
        {
            get { return _CacheManagerName; }
            set { _CacheManagerName = value; }
        }


        bool _RefreshOnExpired = false;

        /// <summary>
        /// Indica si el tiempo de expitracion del item cacheado se renuevan al volver a consultarlos
        /// </summary>
        public bool RefreshOnExpired
        {
            get { return _RefreshOnExpired; }
            set { _RefreshOnExpired = value; }
        }

    }
}
