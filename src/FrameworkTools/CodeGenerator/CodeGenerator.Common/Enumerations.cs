using System;

namespace Fwk.CodeGenerator.Common
{
	

    

	/// <summary>
	/// Tipo a retornar por un método.
	/// </summary>
	
	/// <author>Marcelo Oviedo</author>
    public enum MethodReturnType
	{
		/// <summary>
		/// Sin valor de retorno.
		/// </summary>
		Void,
		/// <summary>
		/// DataSet.
		/// </summary>
		DataSet,
		/// <summary>
		/// DataSet paginado.
		/// </summary>
		PaginatedDataSet
	}

	/// <summary>
	/// Tipo de parámetro a recibir por un método.
	/// </summary>
	/// <author>Marcelo Oviedo</author>
    public enum MethodParameterType
	{
		/// <summary>
		/// Valores escalares.
		/// </summary>
		SimpleValues,
		/// <summary>
		/// Entidad de negocio.
		/// </summary>
		BE
			/*,
		SBE*/
	}

	
}
