using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using CodeGenerator.Back.Common;
using Fwk.Bases;

namespace CodeGenerator.Back.ObjectModel
{
	/// <summary>
	/// Clase que se utiliza como punto de partida para generación de código.
	/// </summary>
	/// <remarks>
	/// Contiene información para armado de namespaces y generación de código asociado con una entidad de negocio y sus entidades relacionadas.
	/// </remarks>
	/// <author>Marcelo Oviedo</author>
	public class EntityGenerationInfo
	{
		#region [Private fields]

    
		private List<EntityInfo> _Entities;
        private TemplateSettingObject _TemplateSettingObject = null;

        public TemplateSettingObject TemplateSettingObject
        {
            get { return _TemplateSettingObject; }
            set { _TemplateSettingObject = value; }
        }
		#endregion

        
		#region [Public properties]

       
		/// <summary>
		/// Entidad principal de negocio para la que se generará código.
		
		/// <author>Marcelo Oviedo</author>
        public List<EntityInfo> Entities
        {
            get { return _Entities; }
            set { _Entities = value; }
        }

		#endregion
        
		
	}
}
