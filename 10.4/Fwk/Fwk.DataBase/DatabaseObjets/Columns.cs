using System;
using System.Data;
using System.Linq;
using Fwk.Bases;
using System.Xml.Serialization;


namespace Fwk.DataBase.DataEntities
{
    /// <summary>
    /// Contiene las columnas de un objeto Table .-
    /// </summary>
    [XmlRoot("Columns"), SerializableAttribute]
    public class Columns : Entities<Column>
    {
        /// <summary>
        /// Metodo estatico que retorna un objeto Columns apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>Columns</returns>
        public static Columns GetColumnsFromXml(String pXml)
        {
            //return (Columns)Entity.GetObjectFromXml(typeof(Columns), pXml);
            return Columns.GetFromXml<Columns>(pXml);
        }

        /// <summary>
        /// Obtiene una columna determinada .- 
        /// </summary>
        /// <param name="name">Nombre de columna  a buscar.-</param>
        /// <returns>Column, retorna null si no la encuentra.-</returns>
        public Column GetColumn(string name)
        {
            return this.Where(p => p.Name.Equals(name)).FirstOrDefault<Column>();
        }
       
    }

    /// <summary>
    /// Descripción breve de Campo.
    /// </summary>
    [XmlInclude(typeof(Column)), Serializable]
    public class Column : Entity  
    {
        #region  privatge members
        private int _prec;
        private int _scale;

      
        private Boolean _Selected = true;
        private string _Name;
        private string _Computed;
        private string _Type;
        private System.Data.SqlDbType _DbSqlType;
        private string _CSharpDataType;
        private Int32 _Length;
        private System.Boolean _IsIdentity;
        private System.Boolean _Nullable;
        private System.Boolean _KeyField = false;
        private System.Boolean _Autogenerated;

        
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor
        /// </summary>
        public Column()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pName"></param>
        public Column(string pName)
        {
            _Name = pName;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pType"></param>
        /// <param name="pLength"></param>
        public Column(string pName, string pType, Int32 pLength)
        {
            _Name = pName;
            _Type = pType;
            _Length = pLength;
        }
        #endregion

        #region [Public Properties]

        /// <summary>
        /// Scale
        /// </summary>
        [XmlElement(ElementName = "Scale", IsNullable = false, DataType = "int")]
        public int Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        /// <summary>
        /// Precicion
        /// </summary>
        [XmlElement(ElementName = "prec", IsNullable = false, DataType = "int")]
        public int Prec
        {
            get { return _prec; }
            set { _prec = value; }
        }

        /// <summary>
        /// Selected
        /// </summary>
        [XmlElement(ElementName = "Selected", IsNullable = false, DataType = "boolean")]
        public Boolean Selected
        {
            get { return _Selected; }
            set { _Selected = value; }
        }

        /// <summary>
        /// CSharpDataType
        /// </summary>
        [XmlElement(ElementName = "CSharpDataType", IsNullable = true, DataType = "string")]
        public string CSharpDataType
        {
            get { return _CSharpDataType; }
            set { _CSharpDataType = value; }
        }

        /// <summary>
        /// IsIdentity
        /// </summary>
        [XmlElement(ElementName = "IsIdentity", IsNullable = false, DataType = "boolean")]
        public System.Boolean IsIdentity
        {
            get { return _IsIdentity; }
            set { _IsIdentity = value; }
        }

        /// <summary>
        /// Length
        /// </summary>
        [XmlElement(ElementName = "Length", IsNullable = false, DataType = "int")]
        public Int32 Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        /// <summary>
        /// Name
        /// </summary>
        [XmlElement(ElementName = "Name", IsNullable = true, DataType = "string")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Tetorna string DbSqlType
        /// </summary>
        [XmlElement(ElementName = "Type", IsNullable = true, DataType = "string")]
        public string Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                _DbSqlType = Fwk.HelperFunctions.TypeFunctions.ConvertSQLToDbSql(value);
                //				m_CSharpDataType = ConvertirSqlCSahrp(value);
            }

        }

        /// <summary>
        /// DbSqlType
        /// </summary>
        public System.Data.SqlDbType DbSqlType
        {
            get { return _DbSqlType; }
            set { _DbSqlType = value; }
        }

        /// <summary>
        /// Computed
        /// </summary>
        [XmlElement(ElementName = "Computed", IsNullable = true, DataType = "string")]
        public string Computed
        {
            get { return _Computed; }
            set { _Computed = value; }
        }

        /// <summary>
        /// Nullable
        /// </summary>
        [XmlElement(ElementName = "Nullable", IsNullable = false, DataType = "boolean")]
        public Boolean Nullable
        {
            get { return _Nullable; }
            set { _Nullable = value; }
        }
        /// <summary>
        /// Indica si el campo es clave de la tabla que representa la entidad en el repositorio de datos.
        /// </summary>
        /// <author>Marcelo Oviedo</author>
        [XmlElement(ElementName = "KeyField", IsNullable = false, DataType = "boolean")]
        public System.Boolean KeyField
        {
            get { return _KeyField; }
            set { _KeyField = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Autogenerated", IsNullable = false, DataType = "boolean")]
        public System.Boolean Autogenerated
        {
            get { return _Autogenerated; }
            set { _Autogenerated = value; }
        }
   
        #endregion

        


        
    }
}

