using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.Back.ObjectModel
{
	/// <summary>
	/// Clase que mantiene información acerca de parámetro de un procedimiento almacenado.
	/// </summary>
	/// <remarks>
	/// Se utiliza en el proceso de generación de código de parámetros de un procedimiento almacenado. Tiene correlación con los campos de la tabla que representa la entidad de negocio en el repositorio de datos.
	/// </remarks>
	
	/// <author>Marcelo Oviedo</author>
    public class ParameterInfo : FieldInfo
	{
		#region [Private fields]

		private System.Data.ParameterDirection _Direction;
		private MethodInfo _Method;

		#endregion

		#region [Public properties]

		/// <summary>
		/// Dirección del parámetro.
		/// </summary>
		
		/// <author>Marcelo Oviedo</author>
		public System.Data.ParameterDirection Direction
		{
			get { return _Direction; }
			set { _Direction = value; }
		}

		/// <summary>
		/// método al que pertenece el parámetro.
		/// </summary>
		
		/// <author>Marcelo Oviedo</author>
        public MethodInfo Method
		{
			get { return _Method; }
			set { _Method = value; }
		}

		#endregion

		#region [Constructor]

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="pMethod"></param>
		
		/// <author>Marcelo Oviedo</author>
		public ParameterInfo(MethodInfo pMethod)
		{
			_Method = pMethod;
		}

		#endregion


	}
}
