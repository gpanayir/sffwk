using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CodeGenerator.Back.Common
{
    /// <summary>
    /// Regla de mapeo de tipo de dato de base de datos.
    /// </summary>
	/// <remarks>
	/// Especifica que tipo de datos generar para una propiedad de una entidad de negocio y como se genera el parámetro en stored procedures, a partir del tipo de dato del campo en la base de datos.
	/// </remarks>
	
	/// <author>Marcelo Oviedo</author>
    public class DBTypeElement : ConfigurationElement
    {

        #region [Public properties]
        /// <summary>
        /// Nombre de la regla. Es el identificador de una regla
        /// por lo tanto este nombre no debe repetirse.
        /// </summary>
		
		/// <author>Marcelo Oviedo</author>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true), StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
			set
			{
				this["name"] = value;
			}
        }

        /// <summary>
        /// Tipo de datos de .Net e:System.String
        /// </summary>
		/// <author>Marcelo Oviedo</author>
        [ConfigurationProperty("targettype", IsRequired = true, IsKey = false), 
         StringValidator(InvalidCharacters = @" ~!@#$%^&*(){}/;'""|\")]
        public string TargetType
        {
            get
            {
				return (string)this["targettype"];
            }
			set
			{
				this["targettype"] = value;
			}
        }

		/// <summary>
		/// Especifica el indicador de tipo de dato nullable.
		/// </summary>
		/// <date>2006-03-28T00:00:00</date>
		/// <author>Marcelo Oviedo</author>
		[ConfigurationProperty("nullabletoken", IsRequired = true, IsKey = false),
		 StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
		public string NullableToken
		{
			get
			{
				return (string)this["nullabletoken"];
			}
			set
			{
				this["nullabletoken"] = value;
			}
		}


		/// <summary>
        /// Tipo de datos de .Net para reprecentar tipos de SQL -->System.Data.DbType
		/// </summary>
		/// <date>2006-03-21T00:00:00</date>
		/// <author>Marcelo Oviedo</author>
		[ConfigurationProperty("targetdbtype", IsRequired = true, IsKey = false),
		 StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
		public string TargetDBType
		{
			get
			{
				return (string)this["targetdbtype"];
			}
			set
			{
				this["targetdbtype"] = value;
			}
		}

		/// <summary>
		/// Patrón de generación para parámetro de stored procedures.
		/// </summary>
		/// <remarks>
		/// Los tags de reemplazo van entre corchetes, y están disponibles para su utilización los siguientes datos:
		/// 
		/// <list type="bullet">
		/// <item>Name</item>
		/// <item>Direction</item>
		/// <item>Type</item>
		/// <item>Length</item>
		/// <item>Precision</item>
		/// <item>Scale</item>
		/// </list>
		/// </remarks>
		/// <author>Marcelo Oviedo</author>
		[ConfigurationProperty("parameterpattern", IsRequired = true, IsKey = false),
		 StringValidator(InvalidCharacters = @"@~!#$%^&*{}/;'""|\")]
		public string ParameterPattern
		{
			get
			{
				return (string)this["parameterpattern"];
			}
			set
			{
				this["parameterpattern"] = value;
			}
		}

        /// <summary>
        /// Patron de prefijos fijados por los standares de configuracion
        /// </summary>
        /// <remarks>
        /// Los prefijos son:
        /// <list type="bullet">
        /// <item>i = int</item>
        /// </list>
        /// </remarks>
        /// <author>Marcelo Oviedo</author>
        [ConfigurationProperty("patternprefixtype", IsRequired = true, IsKey = false),
         StringValidator(InvalidCharacters = @"~!#$%^&*{}/;'""|\")]
        public string PatternPrefixType
        {
            get
            {
                return (string)this["patternprefixtype"];
            }
            set
            {
                this["patternprefixtype"] = value;
            }
        }

        /// <summary>
        /// Tipo de datos de esquemas XSD
        /// </summary>
        [ConfigurationProperty("targetschematype", IsRequired = true, IsKey = false),
        StringValidator(InvalidCharacters = @"~!#$%^&*{}/;'""|\")]
        public string TargetSchemaType
        {
            get
            {
                return (string)this["targetschematype"];
            }
            set
            {
                this["targetschematype"] = value;
            }
        }
		#endregion
    }
}
