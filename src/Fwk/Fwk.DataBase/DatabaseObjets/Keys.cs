using System;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Fwk.DataBase.DataEntities
{
    /// <summary>
    /// Clase que reprecenta las claves de una tabla.-
    /// </summary>
    [XmlRoot("Keys"), SerializableAttribute]
    public class Keys : Entities<Key>
    {

        /// <summary>
        /// Metodo estatico que retorna un objeto Keys apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>Keys</returns>
        public static Keys GetSPParameterFromXml(String pXml)
        {
            return Keys.GetFromXml<Keys>(pXml); 
        }

        /// <summary>
        /// Obtiene una Key de la coleccion de Keys.-
        /// </summary>
        /// <param name="pKeyName">Nombre de la Index.-</param>
        /// <returns>Key</returns>
        public Key GetKey(string pKeyName)
        {
            return this.Find(new SearchEntityArg("Name", pKeyName));

        }
    }

	/// <summary>
	/// Clase que reprecenta una clave de la tabla
	/// </summary>
    [XmlInclude(typeof(Key)), Serializable]
    public class Key : Entity
	{
		private string _Name;
		private string _constraint_name;
		private string _constraint_type;
		private string _GroupName ;
    
     

        /// <summary>
        /// Nombre de la constrain
        /// </summary>
        [XmlElement(ElementName = "Name", IsNullable = true, DataType = "string")]	
		public  string Name
		{
			get{return  _Name;}
			set{ _Name = value;}
		}

        /// <summary>
        /// Nombre de una restricci�n -.
        /// </summary>
        [XmlElement(ElementName = "ConstraintName", IsNullable = true, DataType = "string")]
		public  string ConstraintName
		{
			get{return _constraint_name;}
			set{_constraint_name= value;}
		}

        /// <summary>
        ///  Tipo de una restricci�n -.
        /// </summary>
        [XmlElement(ElementName = "ConstraintType", IsNullable = true, DataType = "string")]
		public  string ConstraintType
		{
			get{return _constraint_type;}
			set{_constraint_type= value;}
		}

        /// <summary>
        /// Grupo al que pertenece la clave
        /// </summary>
        [XmlElement(ElementName = "GroupName", IsNullable = true, DataType = "string")]
		public  string GroupName
		{
			get{return _GroupName;}
			set{_GroupName= value;}
		}

        

	}

}
