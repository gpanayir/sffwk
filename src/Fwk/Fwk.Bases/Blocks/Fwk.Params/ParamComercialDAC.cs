using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Bases;
using System.Linq;
using Fwk.Params.BE;


namespace Fwk.Params.Back
{
    public class ParamDAC
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pParamTypeId">Tipo (gasto, clase, forma pago etc)</param>
        /// <param name="pParamRefId">Relacion con otro param</param>
        /// <param name="vigente">Vigentes o no</param>
        /// <returns></returns>
        public static ParamList GetByParams(int? pParamTypeId, int? pParamRefId, bool? vigente, string cnnStringName)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;

            ParamList list = new ParamList();
            ParamBE wParamBE = null;
            try
            {
                wDatabase = DatabaseFactory.CreateDatabase(cnnStringName);
                wCmd = wDatabase.GetStoredProcCommand("Param_s_ByParam");


                wDatabase.AddInParameter(wCmd, "ParamTypeId", System.Data.DbType.Int32, pParamTypeId);
                wDatabase.AddInParameter(wCmd, "ParamRefId", System.Data.DbType.Int32, pParamRefId);
                wDatabase.AddInParameter(wCmd, "Vigente", System.Data.DbType.Boolean, vigente);
        
                
                IDataReader reader = wDatabase.ExecuteReader(wCmd);

                #region Fill wGastoBECollection
                while (reader.Read())
                {
                    wParamBE = new ParamBE();
                    
                      wParamBE.ParamId = Convert.ToInt32(reader["ParamId"]);
                    if (reader["ParamTypeId"] != DBNull.Value)
                        wParamBE.ParamTypeId = Convert.ToInt32(reader["ParamTypeId"]);
                    
                        wParamBE.Name = reader["Nombre"].ToString().Trim();

                    if (reader["ParamRefId"] != DBNull.Value)
                        wParamBE.ParamRefId = Convert.ToInt32(reader["ParamRefId"]);

                    list.Add(wParamBE);

                }
                #endregion

                reader.Dispose();

                return list;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Obtiene una lista d
        /// </summary>
        /// <returns></returns>
        public static ParamTypeList SearchAllParamType(int? pIdTipo)
        {

            ParamTypeList wList = new ParamTypeList();
            ParamTypeBE wBE = null;
            try
            {
                using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings["PelsoftGastos"].ConnectionString))
                {
                    var rulesinCat = from s in dc.ParamTypes where s.ParamTypeRefId == pIdTipo select s;
                    foreach (Fwk.ConfigData.ParamType tp in rulesinCat.ToList<Fwk.ConfigData.ParamType>())
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
        /// <param name="pParamBE"></param>
        /// <param name="pUserId"></param>
        /// <param name="pCompanyId"></param>
        public static void Create(ParamBE pParamBE, Guid pUserId,string pCompanyId)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;

            try
            {
                wDatabase = DatabaseFactory.CreateDatabase("PelsoftGastos");
                wCmd = wDatabase.GetStoredProcCommand("Param_i");

                wDatabase.AddOutParameter(wCmd, "ParamId", DbType.Int32, 4);

                wDatabase.AddInParameter(wCmd, "@ParamTypeId", System.Data.DbType.Int32, pParamBE.ParamTypeId.Value);

                if(pParamBE.ParamRefId!=null)
                    wDatabase.AddInParameter(wCmd, "@ParamRefId", System.Data.DbType.Int32, pParamBE.ParamRefId);

                wDatabase.AddInParameter(wCmd, "Nombre", System.Data.DbType.String, pParamBE.Name);

                wDatabase.AddInParameter(wCmd, "UserId", DbType.Guid, pUserId);

                wDatabase.AddInParameter(wCmd, "CompanyId", System.Data.DbType.String, pCompanyId);

                if (!string.IsNullOrEmpty(pParamBE.Description))
                    wDatabase.AddInParameter(wCmd, "Descripcion", System.Data.DbType.String, pParamBE.Description);

                wDatabase.ExecuteNonQuery(wCmd);
                pParamBE.ParamId = (System.Int32)wDatabase.GetParameterValue(wCmd, "ParamId");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pParamId"></param>
        public static void Delete(int pParamId)
        {

            Database wDatabase = null;
            DbCommand wCmd = null;

            try
            {
                wDatabase = DatabaseFactory.CreateDatabase("PelsoftGastos");
                wCmd = wDatabase.GetStoredProcCommand("Param_d");

                /// IdTipoGasto
                wDatabase.AddInParameter(wCmd, "ParamId", System.Data.DbType.Int32, pParamId);


                wDatabase.ExecuteNonQuery(wCmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsUsed(int id)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;

            try
            {
                wDatabase = DatabaseFactory.CreateDatabase("PelsoftGastos");
                wCmd = wDatabase.GetStoredProcCommand("Param_g_IsUsed");
                wDatabase.AddInParameter(wCmd, "ParamId", System.Data.DbType.Int32, id);
            

                wDatabase.AddOutParameter(wCmd, "Used", System.Data.DbType.Boolean,1);
                
                wDatabase.ExecuteNonQuery(wCmd);

                return (System.Boolean)wDatabase.GetParameterValue(wCmd, "Used");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}