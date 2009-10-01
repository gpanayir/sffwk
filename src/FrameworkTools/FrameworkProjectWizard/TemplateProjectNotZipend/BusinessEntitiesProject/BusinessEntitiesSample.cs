using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;

namespace $BackendNamespace$.BusinessEntities
{

    [XmlRoot("BusinessEntitiesSampleCollection"), SerializableAttribute]
    public class BusinessEntitiesSampleCollection : Entities<BusinessEntitiesSample>
    {
        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto BusinessEntitiesSampleCollection apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>BusinessEntitiesSampleCollection</returns>
        public static BusinessEntitiesSampleCollection GetBusinessEntitiesSampleCollectionFromXml(String pXml)
        {
            return (BusinessEntitiesSampleCollection)Entity.GetObjectFromXml(typeof(BusinessEntitiesSampleCollection), pXml);
        }
        #endregion
    }

    [XmlInclude(typeof(BusinessEntitiesSample)), Serializable]
    public class BusinessEntitiesSample : Entity
    {

        //----------------------------
        // Implement your code here..
        //----------------------------

        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto BusinessEntitiesSample apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>BusinessEntitiesSample</returns>
        public static BusinessEntitiesSample GetBusinessEntitiesSampleFromXml(String pXml)
        {
            return (BusinessEntitiesSample)Entity.GetObjectFromXml(typeof(BusinessEntitiesSample), pXml);
        }
        #endregion
    }
}
