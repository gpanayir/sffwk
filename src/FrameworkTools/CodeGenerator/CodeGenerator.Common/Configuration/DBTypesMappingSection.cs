using System;
using System.Configuration;
using System.Collections.Generic;

namespace Fwk.CodeGenerator.Common
{

    /// <summary>
    /// Sección 'DBTypesMappingSection' del archivo de configuración App.Config.
    /// </summary>
	
	/// <author>Marcelo Oviedo</author>
    public class DBTypesMappingSection : ConfigurationSection
    {
        #region [Private members]

		static DBTypesMappingSection _Current;
		DBTypeElement _DBTypeElement;
		
		#endregion

        #region [Constructors]

		/// <summary>
		/// Constructor estático de DBTypesMappingSection.
		/// </summary>
		/// <remarks>
		/// Inicializa el la instancia de <see>Current</see>.
		/// </remarks>
		/// <author>Marcelo Oviedo</author>
		static DBTypesMappingSection()
		{
			_Current = (DBTypesMappingSection)System.Configuration.ConfigurationManager.GetSection("DBTypesMapping");
		}

        /// <summary>
		/// Constructor de DBTypesMappingSection.
        /// </summary>
		
		/// <author>Marcelo Oviedo</author>
        public DBTypesMappingSection()
        {
            _DBTypeElement = new DBTypeElement();
        }
        #endregion

        #region [Public properties]


		/// <summary>
		/// Sección actual de configuración de mapeo de tipo de datos.
		/// </summary>
		/// <author>Marcelo Oviedo</author>
		public static DBTypesMappingSection Current
		{
			get {
                
                return DBTypesMappingSection._Current;
            }
			set { DBTypesMappingSection._Current = value; }
		}

        /// <summary>
        /// Colección de reglas de mapeo. 
        /// </summary>
		/// <author>Marcelo Oviedo</author>
		[ConfigurationProperty("DBTypes", IsDefaultCollection = false)]
        public DBTypeElementCollection DBTypes
        {
            get
            {
				DBTypeElementCollection wDBTypeElementCollection = (DBTypeElementCollection)base["DBTypes"];
                return wDBTypeElementCollection;
            }
        }

		/// <summary>
		/// Indicador de inicio de parámetro. 
		/// </summary>
		/// <author>Marcelo Oviedo</author>
		[ConfigurationProperty("ParameterToken", IsDefaultCollection = false)]
		public string ParameterToken
		{
			get
			{
				return (string)base["ParameterToken"];
			}
			set
			{
				base["ParameterToken"] = value;
			}
		}

		/// <summary>
		/// Indicador de parámetro de entrada. 
		/// </summary>
		/// <author>Marcelo Oviedo</author>
		[ConfigurationProperty("InputParameter", IsDefaultCollection = false)]
		public string InputParameter
		{
			get
			{
				return (string)base["InputParameter"];
			}
			set
			{
				base["InputParameter"] = value;
			}
		}

		/// <summary>
		/// Indicador de parámetro de salida. 
		/// </summary>
		/// <author>Marcelo Oviedo</author>
		[ConfigurationProperty("OutputParameter", IsDefaultCollection = false)]
		public string OutputParameter
		{
			get
			{
				return (string)base["OutputParameter"];
			}
			set
			{
				base["OutputParameter"] = value;
			}
		}

		/// <summary>
		/// Indicador de parámetro de entrada/salida. 
		/// </summary>
		/// <author>Marcelo Oviedo</author>
		[ConfigurationProperty("InputOutputParameter", IsDefaultCollection = false)]
		public string InputOutputParameter
		{
			get
			{
				return (string)base["InputOutputParameter"];
			}
			set
			{
				base["InputOutputParameter"] = value;
			}
		}

		/// <summary>
		/// Cadena que representa el valor nulo por defecto para parámetros nullables.
		/// </summary>
		/// <date>2007-5-25T00:00:00</date>
		/// <author>Marcelo Oviedo</author>
		[ConfigurationProperty("DefaultNullParameter", IsDefaultCollection = false)]
		public string DefaultNullParameter
		{
			get
			{
				return (string)base["DefaultNullParameter"];
			}
			set
			{
				base["DefaultNullParameter"] = value;
			}
		}

        #endregion
    }
}
 