using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Fwk.Bases;
using helper = Fwk.HelperFunctions;

namespace Fwk.Fwk.BackEnd.Implementation
{


    [XmlInclude(typeof(Telefono)), Serializable]
    public class Telefono : Entity
    {
        public Telefono()  { }

        #region [Properties]


        #region [Numero]

        private int _Numero;
        private bool _NumeroIsNull = true;


        [XmlElement(ElementName = "Numero", IsNullable = false, DataType = "int")]
        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; _NumeroIsNull = true; }
        }


        /// Indica si Numero es null o no.-
        /// </summary>
        [XmlIgnore]
        public bool NumeroIsNull
        {
            get { return _NumeroIsNull; }
            set { _NumeroIsNull = value; }
        }

        #endregion

        #region [Caracteristica]

        private String _Caracteristica;
        private bool _CaracteristicaIsNull = true;


        [XmlElement(ElementName = "Caracteristica", IsNullable = false, DataType = "string")]
        public String Caracteristica
        {
            get { return _Caracteristica; }
            set { _Caracteristica = value; _CaracteristicaIsNull = true; }
        }


        /// Indica si Caracteristica es null o no.-
        /// </summary>
        [XmlIgnore]
        public bool CaracteristicaIsNull
        {
            get { return _CaracteristicaIsNull; }
            set { _CaracteristicaIsNull = value; }
        }

        #endregion


        #endregion

        

    }
    public class TelefonoCollection : Entities<Telefono>
    {
       
        
    }

    [XmlInclude(typeof(ItemBE)), Serializable]
    public class ItemBE : Entity
    {

        public ItemBE()
        {

        }


        #region [Properties]


        #region [Descripcion]

        private String _Descripcion;
        private bool _DescripcionIsNull = true;


        [XmlElement(ElementName = "Descripcion", IsNullable = false, DataType = "string")]
        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; _DescripcionIsNull = true; }
        }


        /// Indica si Descripcion es null o no.-
        /// </summary>
        [XmlIgnore]
        public bool DescripcionIsNull
        {
            get { return _DescripcionIsNull; }
            set { _DescripcionIsNull = value; }
        }

        #endregion

        #region [Cantidad]

        private int _Cantidad;
        private bool _CantidadIsNull = true;


        [XmlElement(ElementName = "Cantidad", IsNullable = false, DataType = "int")]
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; _CantidadIsNull = true; }
        }


        /// Indica si Cantidad es null o no.-
        /// </summary>
        [XmlIgnore]
        public bool CantidadIsNull
        {
            get { return _CantidadIsNull; }
            set { _CantidadIsNull = value; }
        }

        #endregion


        #endregion

        #region [Override methods]

        /// <summary>
        /// Obtine un xml producto de la serializacion de la clase ItemBE
        /// </summary>
        /// <returns>string con el xml de la serializacion</returns>
        public override string GetXml()
        {
            return base.SerializeToXml(this);
        }

        /// <summary>
        /// Obtine un dataset producto de la serializacion de la clase ItemBEBE
        /// </summary>
        /// <returns>Dataset</returns>
        public System.Data.DataSet GetDataSet()
        {
            return base.GetDataSet(this);
        }
        #endregion

    }
    public class ItemBECollection : Entities<ItemBE>
    {
      

    }

    [XmlInclude(typeof(Vendedores)), Serializable]
    public class Vendedores : Entity
    {

        public Vendedores()
        {

        }


        #region [Properties]

        #region [Nombre]

        private String _Nombre;
        private bool _NombreIsNull = true;

        [XmlElement(ElementName = "Nombre", IsNullable = false, DataType = "string")]
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; _NombreIsNull = true; }
        }


        /// Indica si Nombre es null o no.-
        /// </summary>
        [XmlIgnore]
        public bool NombreIsNull
        {
            get { return _NombreIsNull; }
            set { _NombreIsNull = value; }
        }

        #endregion

        #region [Apellido]

        private String _Apellido;
        private bool _ApellidoIsNull = true;


        [XmlElement(ElementName = "Apellido", IsNullable = false, DataType = "string")]
        public String Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; _ApellidoIsNull = true; }
        }


        /// Indica si Apellido es null o no.-
        /// </summary>
        [XmlIgnore]
        public bool ApellidoIsNull
        {
            get { return _ApellidoIsNull; }
            set { _ApellidoIsNull = value; }
        }

        #endregion

        #endregion

        

    }

    [XmlInclude(typeof(FacturaBE)), Serializable]
    public class FacturaBE : Entity
    {

        public FacturaBE()
        {

        }


        #region [Properties]


        #region [NumeroCliente]

        private int _NumeroCliente;
        private bool _NumeroClienteIsNull = true;


        [XmlElement(ElementName = "NumeroCliente", IsNullable = false, DataType = "int")]
        public int NumeroCliente
        {
            get { return _NumeroCliente; }
            set { _NumeroCliente = value; _NumeroClienteIsNull = true; }
        }


        /// Indica si NumeroCliente es null o no.-
        /// </summary>
        [XmlIgnore]
        public bool NumeroClienteIsNull
        {
            get { return _NumeroClienteIsNull; }
            set { _NumeroClienteIsNull = value; }
        }

        #endregion

        #region [NombreCliente]

        private String _NombreCliente;
        private bool _NombreClienteIsNull = true;


        [XmlElement(ElementName = "NombreCliente", IsNullable = false, DataType = "string")]
        public String NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; _NombreClienteIsNull = true; }
        }


        /// Indica si NombreCliente es null o no.-
        /// </summary>
        [XmlIgnore]
        public bool NombreClienteIsNull
        {
            get { return _NombreClienteIsNull; }
            set { _NombreClienteIsNull = value; }
        }

        #endregion

        #region [FechaFactura]

        private DateTime _FechaFactura;
        private bool _FechaFacturaIsNull = true;


        [XmlElement(ElementName = "FechaFactura", IsNullable = false, DataType = "dateTime")]
        public DateTime FechaFactura
        {
            get { return _FechaFactura; }
            set { _FechaFactura = value; _FechaFacturaIsNull = true; }
        }


        /// Indica si FechaFactura es null o no.-
        /// </summary>
        [XmlIgnore]
        public bool FechaFacturaIsNull
        {
            get { return _FechaFacturaIsNull; }
            set { _FechaFacturaIsNull = value; }
        }

        #endregion


        #endregion

        

    }
}
