//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//using Fwk.CodeGenerator.Common;
//using fwkDataEntities = Fwk.DataBase.DataEntities;

//namespace Fwk.CodeGenerator.Common
//{
//    /// <summary>
//    /// Clase que mantiene información sobre un método de una entidad.
//    /// </summary>
//    /// <remarks>
//    /// Se utiliza en el proceso de generación de código.
//    /// </remarks>
	
//    /// <author>Marcelo Oviedo</author>
//    public class MethodInfo
//    {

//        #region [Private fields]

//        private string _Name;
//        private MethodActionType _Action;
//        private MethodParameterType _ParameterType;
//        private MethodReturnType _ReturnType;
//        private bool _PerformBatch;
//        private List<ParameterInfo> _Parameters;
		

//        private EntityInfo _Entity = null;

//        public EntityInfo Entity
//        {
//            get { return _Entity; }
//            set { _Entity = value; }
//        }
       

//        private string _ProcedureName;

//        #endregion

//        #region [Public properties]

//        /// <summary>
//        /// Nombre del método.
//        /// </summary>
		
//        /// <author>Marcelo Oviedo</author>
//        public string Name
//        {
//            get { return _Name; }
//            set { _Name = value; }
//        }

//        /// <summary>
//        /// Acción a llevar a cabo por el método.
//        /// </summary>
//        /// <author>Marcelo Oviedo</author>
//        public MethodActionType Action
//        {
//            get { return _Action; }
//            set 
//            { 
//                _Action = value;

				
//            }
//        }

//        /// <summary>
//        /// Tipo de parámetros que recibe el método.
//        /// </summary>
		
//        /// <author>Marcelo Oviedo</author>
//        public MethodParameterType ParameterType
//        {
//            get { return _ParameterType; }
//            set { _ParameterType = value; }
//        }

//        /// <summary>
//        /// Tipo de retorno del método.
//        /// </summary>
		
//        /// <author>Marcelo Oviedo</author>
//        public MethodReturnType ReturnType
//        {
//            get { return _ReturnType; }
//            set { _ReturnType = value; }
//        }

//        /// <summary>
//        /// Indica si hay que realizar una ejecución en batch.
//        /// </summary>
		
//        /// <author>Marcelo Oviedo</author>
//        public bool PerformBatch
//        {
//            get { return _PerformBatch; }
//            set { _PerformBatch = value; }
//        }

//        /// <summary>
//        /// Lista de parámetros del método.
//        /// </summary>
		
//        /// <author>Marcelo Oviedo</author>
//        public List<ParameterInfo> Parameters
//        {
//            get 
//            {
                
//                return _Parameters; 
//            }
//            set { _Parameters = value; }
//        }

		

//        /// <summary>
//        /// Nombre del procedimiento almacenado relacionado con el método.
//        /// </summary>
//        /// <remarks>
//        /// Solo permite asignarlo cuando el método no es de tipo Built-in
//        /// </remarks>
//        /// <author>Marcelo Oviedo</author>
//        public string ProcedureName
//        {
//            get 
//            { 
//                return _ProcedureName; 
//            }
//            set 
//            {
//                //if (!this.BuiltIn)
//                //{
//                //    _ProcedureName = value;
//                //}
//            }
//        }

		

//        #endregion

//        #region [Private methods]

//        /// <summary>
//        /// Verifica si el campo debe ser mapeado a un parámetro del método de acuerdo a la Acción asociada.
//        /// </summary>
//        /// <param name="pTableFieldInfo">Campo de la entidad que se desea comprobar.</param>
//        /// <returns>Verdadero si hay que copiarlo como parámetro del método.</returns>
//        /// <author>Marcelo Oviedo</author>
//        private static bool CheckMappingNeed(fwkDataEntities.Column pTableFieldInfo, MethodActionType pMethodActionType)
//        {

//            //Si es GetAllPaginated o  GetAll = False
//            bool wResult = false;

//            //                     Si KeyField  o  (No KeyField Y (Insert o Update o Get) = True
//            wResult = wResult && (pTableFieldInfo.KeyField || (!pTableFieldInfo.KeyField && Convert.ToBoolean(pMethodActionType & (MethodActionType.Insert | MethodActionType.Update |  MethodActionType.SearchByParam))));
//            return wResult;
//        }

//        /// <summary>
//        /// Verifica si el campo debe ser mapeado a un parámetro del método de acuerdo a la Acción asociada.
//        /// </summary>
//        /// <param name="pTableFieldInfo">Campo de la entidad que se desea comprobar.</param>
//        /// <returns>Verdadero si hay que copiarlo como parámetro del método.</returns>
//        /// <author>Marcelo Oviedo</author>
//        private static bool CheckMappingNeed(fwkDataEntities.SPParameter pTableFieldInfo,MethodActionType pMethodActionType)
//        {   //Si es GetAllPaginated o  GetAll = False
//            bool wResult = false;
//            //                     Si KeyField  o  (No KeyField Y (Insert o Update o Get o ) = True
//            wResult = wResult && (Convert.ToBoolean(pMethodActionType & (MethodActionType.Insert | MethodActionType.Update | MethodActionType.SearchByParam)));
//            return wResult;
//        }

//        /// <summary>
//        /// Genera los parámetros de un método basandose en los campos de la tabla.
//        /// </summary>
//        /// <remarks>
//        /// Si el método es de tipo Built-in y añn no se han generado los parámetros, revisa campo por campo para determinar si alguno de estos es necesario como parámetro del método.
//        /// </remarks>
//        /// <author>Marcelo Oviedo</author>
//        public static void GenerateParameters(MethodInfo pMethodInfo)
//        {


//            if (pMethodInfo.Entity.Table != null )
//                {


//                    foreach (fwkDataEntities.Column wColumn in pMethodInfo.Entity.Table.Columns)
//                    {
//                        if (CheckMappingNeed(wColumn,<Template name=))
//                        {
//                            ParameterInfo wParameterInfo = null;

//                            try
//                            {
//                                wParameterInfo = new ParameterInfo(pMethodInfo);
//                                wParameterInfo.Name = wColumn.Name;
//                                wParameterInfo.Type = wColumn.Type;
//                                wParameterInfo.Length = wColumn.Length;
//                                //wParameterInfo.Precision = wTableFieldInfo.Precision;
//                                //wParameterInfo.Scale = wTableFieldInfo.Scale;
//                                wParameterInfo.Nullable = wColumn.Nullable;
//                                wParameterInfo.Selected = wColumn.Selected;
//                                wParameterInfo.Direction = ((<Template name= == MethodActionType.Insert) && wColumn.Autogenerated) ? ParameterDirection.Output : ParameterDirection.Input;
//                                pMethodInfo.Parameters.Add(wParameterInfo);
//                            }
//                            finally
//                            {
//                                wParameterInfo = null;
//                            }

//                        }

//                    }
//                }
//                if (pMethodInfo.Entity.StoredProcedure != null )//&& pMethodInfo.BuiltIn)
//                {
//                    foreach (fwkDataEntities.SPParameter wSPParameter in pMethodInfo.Entity.StoredProcedure.Parameters)
//                    {
//                        if (CheckMappingNeed(wSPParameter,<Template name=))
//                        {
//                            ParameterInfo wParameterInfo = null;

//                            try
//                            {
//                                wParameterInfo = new ParameterInfo(pMethodInfo);
//                                wParameterInfo.Name = wSPParameter.Name;
//                                wParameterInfo.Type = wSPParameter.Type;
//                                wParameterInfo.Length = wSPParameter.Length;
//                                //wParameterInfo.Precision = wSPParameter.Precision;
//                                //wParameterInfo.Scale = wSPParameter.Scale;
//                                wParameterInfo.Nullable = wSPParameter.Nullable;
//                                wParameterInfo.Selected = wSPParameter.Selected;
//                                wParameterInfo.Direction = (<Template name= == MethodActionType.Insert) ? ParameterDirection.Output : ParameterDirection.Input;
//                                pMethodInfo.Parameters.Add(wParameterInfo);
//                            }
//                            finally
//                            {
//                                wParameterInfo = null;
//                            }

//                        }

//                    }

//                }
            
//        }

//        #endregion

//        #region [Constructors]

//        /// <summary>
//        /// Constructor.
//        /// </summary>
//        /// <param name="pEntity">Entidad a la que pertenece el método.</param>
		
//        /// <author>Marcelo Oviedo</author>
//        public MethodInfo(EntityInfo pEntityInfo)
//        {
//            _ProcedureName = string.Empty;
//            _Parameters = new List<ParameterInfo>();
           
			
//            _Entity = pEntityInfo;
//        }

//        #endregion

//    }
//}
