using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
namespace Fwk.Bases.FrontEnd.Controls.FwkGrid.Design
{
    [XmlRoot("ClienteCollection"), SerializableAttribute]
    public class ClienteCollection : Entities<Cliente>
    {
        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto ClienteBECollection apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>ClienteBECollection</returns>
        public static ClienteCollection GetClienteBECollectionFromXml(String pXml)
        {
            return (ClienteCollection)Entity.GetObjectFromXml(typeof(ClienteCollection), pXml);
        }
        #endregion
    }

    [XmlInclude(typeof(Cliente)), Serializable]
    public class Cliente : Entity
    {
        #region [Private Members]
        private int? m_IdCliente;
        private String m_Nombre ;
        private String m_Apellido;

        #endregion

        #region [Properties]

        #region [IdCliente]
        [XmlElement(ElementName = "IdCliente", DataType = "int")]
        public int? IdCliente
        {
            get { return m_IdCliente; }
            set { m_IdCliente = value; }
        }
        #endregion
        #region [Nombre]
        [XmlElement(ElementName = "Nombre", DataType = "string")]
        public String Nombre
        {
            get { return m_Nombre; }
            set { m_Nombre = value; }
        }
        #endregion
        #region [Apellido]
        [XmlElement(ElementName = "Apellido", DataType = "string")]
        public String Apellido
        {
            get { return m_Apellido; }
            set { m_Apellido = value; }
        }
        #endregion
        #endregion

        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto Cliente apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>Cliente</returns>
        public static Cliente GetClienteBEFromXml(String pXml)
        {
            return (Cliente)Entity.GetObjectFromXml(typeof(Cliente), pXml);
        }

        public override string ToString()
        {
            return m_Nombre;
        }
        #endregion
    }

}