using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.Back.ObjectModel
{
	/// <summary>
	/// Clase que mantiene información acerca sobre atributos de una entidad.
	/// </summary>
	/// <remarks>
	/// Se utiliza en el proceso de generación de código. Tiene correlación con los campos de la tabla que representa la entidad de negocio en el repositorio de datos.
	/// </remarks>
	/// <author>Marcelo Oviedo</author>
    public abstract class FieldInfo
	{
		#region [Private fields]

		private int _Length;
		private string _Name;
		private bool _Nullable;
		private int _Precision;
		private int _Scale;
		private string _Type;
        private Boolean _Selected;

        public Boolean Selected
        {
            get { return _Selected; }
            set { _Selected = value; }
        }

		#endregion

		#region [Public properties]

		/// <summary>
		/// Tamaño del campo.
		/// </summary>
		/// <author>Marcelo Oviedo</author>
		public int Length
		{
			get { return _Length; }
			set { _Length = value; }
		}

		/// <summary>
		/// Nombre del campo.
		/// </summary>
		
		/// <author>Marcelo Oviedo</author>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		/// <summary>
		/// Indica si esl campo puede ser nulo.
		/// </summary>
		
		/// <author>Marcelo Oviedo</author>
		public bool Nullable
		{
			get { return _Nullable; }
			set { _Nullable = value; }
		}

		/// <summary>
		/// Precisión.
		/// </summary>
		
		/// <author>Marcelo Oviedo</author>
		public int Precision
		{
			get { return _Precision; }
			set { _Precision = value; }
		}

		/// <summary>
		/// Escala del campo (cantidad de posiciones decimales).
		/// </summary>
		
		/// <author>Marcelo Oviedo</author>
		public int Scale
		{
			get { return _Scale; }
			set { _Scale = value; }
		}

		/// <summary>
		/// Tipo de dato.
		/// </summary>
		
		/// <author>Marcelo Oviedo</author>
		public string Type
		{
			get { return _Type; }
			set { _Type = value; }
		}

		#endregion
	}
}
