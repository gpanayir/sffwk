using System;

namespace CodeGenerator.Back.Common
{
	/// <summary>
	/// Acción a realizar por un procedimiento almacenado.
	/// </summary>
	/// <remarks>
	/// Se utiliza en el proceso de generación de código de procedimientos almacenados. Los tipos de acciones pueden dividirse en dos conjuntos: <b>built-in</b> (<see cref="Insert"/>, <see cref="Update"/>, <see cref="Delete"/>, <see cref="Get"/>, <see cref="GetAll"/> y <see cref="GetAllPaginated"/>) y <b>generados por el usuario</b> (<see cref="GetByParam"/> y <see cref="Other"/>). La diferencia radica en el proceso de construcción de código a seguir de acuerdo al tipo de Acción de cada método, en los del primer tipo el usuario no tiene ningún control acerca de las opciones de generación (salvo lo que se pueda modificar mediante la alteración de los templates), mientras que el los del segundo tiene mayor libertad para definir las propiedades de cada método.
	/// </remarks>
	/// <author>Marcelo Oviedo</author>
	[Flags()]
    public enum MethodActionType
	{
		/// <summary>
		/// Inserción de un registro.
		/// </summary>
		Insert = 1,
		/// <summary>
		/// Actualización de un registro.
		/// </summary>
		Update = 2,
		/// <summary>
		/// Borrado de un registro.
		/// </summary>
		Delete = 4,
		/// <summary>
		/// Búsqueda de un registro por clave primaria.
		/// </summary>
		Get = 8,
		/// <summary>
		/// Búsqueda de todos los registros de la tabla.
		/// </summary>
		GetAll = 16,
        /// <summary>
        /// Búsqueda de todos los registros de la tabla por páginas.
        /// </summary>
		GetAllPaginated = 32,
		/// <summary>
		/// Búsqueda por parámetros.
		/// </summary>
		GetByParam = 64,
		/// <summary>
		/// Otro tipo de Acción.
		/// </summary>
		Other = 128
	}

    //public enum SelectedObject
    //{
    //    Tables = 0,
    //    StoreProcedures = 1,
    //    Schema = 2
    //}

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

	/// <summary>
	/// Capa a la que pertenece un componente.
	/// </summary>
	
	/// <author>Marcelo Oviedo</author>
	public enum ComponentLayer
	{
		/// <summary>
		/// Business entity.
		/// </summary>
		BE,
		/// <summary>
		/// Business component.
		/// </summary>
		BC,
		/// <summary>
		/// Data access component.
		/// </summary>
		DAC,
		/// <summary>
		/// Table data gateway.
		/// </summary>
		TDG,
        /// <summary>
        /// Service
        /// </summary>
        SVC,
        /// <summary>
        /// Common interfaces
        /// </summary>
        ISVC,

         /// <summary>
        /// Common interfaces
        /// </summary>
        SP
	}
}
