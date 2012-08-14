using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Fwk.Bases;
using System.Linq;
using Fwk.Params.BE;


namespace Fwk.Params.Back
{
    /// <summary>
    /// 
    /// </summary>
    public class ParamDAC
    {


        /// <summary>
        /// Retorna parametros por id, id padre, y filtra x vigentes o no vigentes
        /// </summary>
        /// <param name="paramTypeId">Tipo (gasto, clase, forma pago etc)</param>
        /// <param name="parentId">Relacion con otro param</param>
        /// <param name="enabled">Vigentes o no</param>
        /// <param name="culture">Cultura que se desea consultar: th-TH, en-US, es-AR etc etc</param>
        /// <param name="cnnStringName">Cadena de coneccion</param>
        /// <returns></returns>
        public static ParamList RetriveByParams(int? paramTypeId, int? parentId, bool? enabled,string culture, string cnnStringName)
        {


            ParamList wParamList = new ParamList();
            ParamBE wParamBE = null;
            try
            {
                using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString))
                {
                    var rulesinCat = from s in dc.fwk_Params where 
                                        (paramTypeId.HasValue || s.ParamTypeId.Equals(paramTypeId))
                                        &&
                                           (parentId.HasValue || s.ParentId.Equals(parentId))
                                        &&
                                           (enabled.HasValue || s.Enabled.Equals(enabled)
                                             &&
                                           (string.IsNullOrEmpty(culture) || s.Culture.Equals(culture)))
                                     select s;


                    foreach (Fwk.ConfigData.fwk_Param param_db in rulesinCat.ToList<Fwk.ConfigData.fwk_Param>())
                    {
                        wParamBE = new ParamBE();
                        wParamBE.ParamId = param_db.ParamId;
                        wParamBE.ParamTypeId = param_db.ParamTypeId;
                        wParamBE.ParentId = param_db.ParentId;
                        wParamBE.Name = param_db.Name;
                        wParamBE.Description = param_db.Description;
                        wParamBE.Enabled = param_db.Enabled;
                        wParamBE.Culture = param_db.Culture;
                        wParamBE.Id = param_db.Id;

                        wParamList.Add(wParamBE);
                    }
                }


                return wParamList;


            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }

        /// <summary>
        /// Retorna registros de la tabla ParamType por parametros. Permite filtrar por padre y vigencia
        /// </summary>
        /// <param name="parentId">Id tipo parametro padre</param>
        /// <param name="enabled">Vigencia</param>
        /// <param name="cnnStringName">Cadena de conexion</param>
        /// <returns></returns>
        public static ParamTypeList RetriveParamType(int? parentId,bool? enabled, string cnnStringName)
        {

            ParamTypeList wList = new ParamTypeList();
            ParamTypeBE wBE = null;
            try
            {
                using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString))
                {
                    var types = from s in dc.ParamTypes where

                                  (parentId.HasValue || s.ParentId.Equals(parentId))
                                        &&
                                           (enabled.HasValue || s.Enabled.Equals(enabled))
                                select s;
                    foreach (Fwk.ConfigData.ParamType tp in types.ToList<Fwk.ConfigData.ParamType>())
                    { 
                        wBE = new ParamTypeBE();

                        wBE.ParamTypeId = tp.ParamTypeId;
                        wBE.Name = tp.Name;

                        wList.Add(wBE);
                    }
                }


                return wList;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramBE"></param>
        /// <param name="userId"></param>
        /// <param name="cnnStringName"></param>
        public static void Create(ParamBE paramBE, Guid userId, string cnnStringName)
        {
            //Database wDatabase = null;
            //DbCommand wCmd = null;

            //try
            //{
            //    wDatabase = DatabaseFactory.CreateDatabase(cnnStringName);
            //    wCmd = wDatabase.GetStoredProcCommand("Param_i");

            //    wDatabase.AddOutParameter(wCmd, "ParamId", DbType.Int32, 4);

            //    wDatabase.AddInParameter(wCmd, "@ParamTypeId", System.Data.DbType.Int32, paramBE.ParamTypeId.Value);

            //    if(paramBE.ParentId!=null)
            //        wDatabase.AddInParameter(wCmd, "@ParentId", System.Data.DbType.Int32, paramBE.ParentId);

            //    wDatabase.AddInParameter(wCmd, "Name", System.Data.DbType.String, paramBE.Name);

            //    wDatabase.AddInParameter(wCmd, "UserId", DbType.Guid, userId);

            //    //wDatabase.AddInParameter(wCmd, "CompanyId", System.Data.DbType.String, pCompanyId);

            //    if (!string.IsNullOrEmpty(paramBE.Description))
            //        wDatabase.AddInParameter(wCmd, "Descripcion", System.Data.DbType.String, paramBE.Description);

            //    wDatabase.ExecuteNonQuery(wCmd);
            //    paramBE.ParamId = (System.Int32)wDatabase.GetParameterValue(wCmd, "ParamId");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            throw new NotImplementedException("Fwk Create Param no esta implementado");
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramId"></param>
        /// <param name="parentId"></param>
        /// <param name="cnnStringName"></param>
        public static void Delete(int? paramId,int? parentId,string cnnStringName)
        {

            //Database wDatabase = null;
            //DbCommand wCmd = null;

            //try
            //{
            //    wDatabase = DatabaseFactory.CreateDatabase(cnnStringName);
            //    wCmd = wDatabase.GetStoredProcCommand("Param_d");

            //    /// IdTipoGasto
            //    wDatabase.AddInParameter(wCmd, "ParamId", System.Data.DbType.Int32, paramId);


            //    wDatabase.ExecuteNonQuery(wCmd);

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            throw new NotImplementedException("Fwk Delete Param no esta implementado");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsUsed(int id)
        {
            //Database wDatabase = null;
            //DbCommand wCmd = null;

            //try
            //{
            //    wDatabase = DatabaseFactory.CreateDatabase("PelsoftGastos");
            //    wCmd = wDatabase.GetStoredProcCommand("Param_g_IsUsed");
            //    wDatabase.AddInParameter(wCmd, "ParamId", System.Data.DbType.Int32, id);
            

            //    wDatabase.AddOutParameter(wCmd, "Used", System.Data.DbType.Boolean,1);
                
            //    wDatabase.ExecuteNonQuery(wCmd);

            //    return (System.Boolean)wDatabase.GetParameterValue(wCmd, "Used");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            throw new NotImplementedException("Fwk Delete Param no esta implementado");
        }

    }
}