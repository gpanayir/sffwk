using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Fwk.Bases;
using helper = Fwk.HelperFunctions;

namespace Fwk.Bases.Test.Services
{
    //[XmlInclude(typeof(Param)), Serializable]
    [XmlRoot("Param"), SerializableAttribute]
    public class CrearFacturaContadoREQ:Entity
    {
        private FacturaBE _FacturaBE = new FacturaBE();

        public FacturaBE FacturaBE
        {
            get { return _FacturaBE; }
            set { _FacturaBE = value; }
        }
    }


    [XmlInclude(typeof(FacturaBE)), Serializable]
    public class FacturaBE : Entity
    {
        #region [Atributes]
        private ItemCollectionBE _ItemCollectionBE = new ItemCollectionBE();

        private DateTime? _FechaFactura;
        private string _NombreCliente;
        private int? _NumeroCliente;

        #endregion

        #region [Properties]
        [XmlElement(ElementName = "ItemCollectionBE")]
        public ItemCollectionBE ItemCollectionBE
        {
            get { return _ItemCollectionBE; }
            set { _ItemCollectionBE = value; }
        }

        [XmlElement(ElementName = "FechaFactura", DataType = "dateTime")]
        public DateTime? FechaFactura
        {
            get { return _FechaFactura; }
            set { _FechaFactura = value; }
        }

        [XmlElement(ElementName = "NombreCliente", DataType = "string")]
        public string NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; }
        }


        [XmlElement(ElementName = "NumeroCliente", DataType = "int")]
        public int? NumeroCliente
        {
            get { return _NumeroCliente; }
            set { _NumeroCliente = value; }
        }

        #endregion

        /// <summary>
        /// Metodo estatico que retorna on objeto FacturaBE apartir de un xml.-
        /// </summary>
        /// <param name="pxml">String con el xml</param>
        /// <returns>FacturaBE</returns>
        public static FacturaBE GetFacturaBE(String pxml)
        {
            return (FacturaBE)Entity.GetObjectFromXml(typeof(FacturaBE), pxml);
        }
    }

    [XmlRoot("ItemCollectionBE"), SerializableAttribute]
    public class ItemCollectionBE : Entities<ItemBE>
    {
        /// <summary>
        /// Metodo estatico que retorna on objeto ItemCollectionBE apartir de un xml.-
        /// </summary>
        /// <param name="pxml">String con el xml</param>
        /// <returns>ItemBE</returns>
        public static ItemCollectionBE GetItemCollectionBE(String pxml)
        {
            return (ItemCollectionBE)Entity.GetObjectFromXml(typeof(ItemCollectionBE), pxml);
        }
    }

    [XmlInclude(typeof(ItemBE)), Serializable]
    public class ItemBE : Entity
    {
        #region [Atributes]

        private string _Descripcion;
        private int? _Cantidad;

        #endregion

        #region [Properties]

        public ItemBE()
        {


        }


        [XmlElement(ElementName = "Descripcion", DataType = "string")]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }



        [XmlElement(ElementName = "Cantidad", DataType = "int")]
        public int? Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        #endregion

        /// <summary>
        /// Metodo estatico que retorna on objeto ItemBE apartir de un xml.-
        /// </summary>
        /// <param name="pxml">String con el xml</param>
        /// <returns>ItemBE</returns>
        public static ItemBE GetItemBE(String pxml)
        {
            return (ItemBE)Entity.GetObjectFromXml(typeof(ItemBE), pxml);
        }
    }
}


