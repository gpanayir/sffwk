using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Fwk.Bases;
using helper = Fwk.HelperFunctions;
using System.ComponentModel;

namespace Fwk.Bases.Test
{


    [XmlRoot("ClienteCollectionBE_2"), SerializableAttribute]
    public class ClienteCollectionBE_2 : Entities<ClienteBE>
    {
        /// <summary>
        /// Metodo estatico que retorna on objeto ClienteCollectionBE apartir de un xml.-
        /// </summary>
        /// <param name="pxml">String con el xml</param>
        /// <returns>ClienteCollectionBE</returns>
        public static ClienteCollectionBE_2 GetClienteCollectionBE(String pxml)
        {
            return (ClienteCollectionBE_2)Entity.GetObjectFromXml(typeof(ClienteCollectionBE), pxml);
        }
    }


    [XmlInclude(typeof(ClienteBE_2)), Serializable]
    public class ClienteBE_2 : Entity
    {


        #region [Atributes]

        private int? _IdCliente;
        private DateTime? _FechaNacimiento;
        private string _Nombre;
        private string _Apellido;
        private int? _Edad;

        #endregion



        #region [Properties]
        [XmlElement(ElementName = "IdCliente", DataType = "int")]
        public int? IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        [XmlElement(ElementName = "FechaNacimiento", DataType = "dateTime")]
        public DateTime? FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set
            {
                AddHistory("FechaNacimiento", _FechaNacimiento);
                _FechaNacimiento = value;
            }
        }

        [XmlElement(ElementName = "Nombre", DataType = "string")]
        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                AddHistory("Nombre", _Nombre);
                _Nombre = value;
            }
        }

        [XmlElement(ElementName = "Apellido", DataType = "string")]
        public string Apellido
        {
            get { return _Apellido; }
            set
            {
                AddHistory("Apellido", _Apellido);
                _Apellido = value;
            }
        }

        [XmlElement(ElementName = "Edad", DataType = "int")]
        public int? Edad
        {
            get { return _Edad; }
            set
            {
                AddHistory("Edad", _Edad);
                _Edad = value;
            }
        }

        #endregion


        /// <summary>
        /// Metodo estatico que retorna on objeto ClienteBE apartir de un xml.-
        /// </summary>
        /// <param name="pxml">String con el xml</param>
        /// <returns>ClienteBE</returns>
        public static ClienteBE GetClienteBE(String pxml)
        {
            return (ClienteBE)Entity.GetObjectFromXml(typeof(ClienteBE), pxml);
        }

    }
}
