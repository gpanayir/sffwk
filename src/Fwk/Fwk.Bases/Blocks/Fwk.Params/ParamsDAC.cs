using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Fwk.Bases;
using System.Linq;
using Fwk.Params.BE;
using Fwk.ConfigData;


namespace Fwk.Params.Back
{
    /// <summary>
    /// 
    /// </summary>
    public class ParamDAC
    {


        /// <summary>
        /// Retorna parametros por id, id padre, y filtra x vigentes o no vigentes La cultura puede se String.Empty
        /// en cuyo caso no la tendra en cuenta para el filtro
        /// </summary>
        /// <param name="parentId">Relacion con otro param</param>
        /// <param name="enabled">Vigentes o no</param>
        /// <param name="culture">Cultura que se desea consultar: th-TH, en-US, es-AR etc etc</param>
        /// <param name="cnnStringName">Cadena de coneccion</param>
        /// <returns></returns>
        public static ParamList RetriveByParams(int? parentId, bool? enabled,string culture, string cnnStringName)
        {


            ParamList wParamList = new ParamList();
            ParamBE wParamBE = null;
            try
            {
                using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString))
                {
                    var rulesinCat = from s in dc.fwk_Params where 
                                        
                                        
                                           (!parentId.HasValue || s.ParentId.Equals(parentId))
                                        &&
                                           (!enabled.HasValue || s.Enabled.Equals(enabled)
                                             &&
                                           (string.IsNullOrEmpty(culture) || s.Culture.Equals(culture)))
                                     select s;


                    foreach (Fwk.ConfigData.fwk_Param param_db in rulesinCat.ToList<Fwk.ConfigData.fwk_Param>())
                    {
                        wParamBE = new ParamBE();
                        wParamBE.ParamId = param_db.ParamId;
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
        /// 
        /// </summary>
        /// <param name="paramBE"></param>
        /// <param name="userId"></param>
        /// <param name="cnnStringName"></param>
        public static void Create(ParamBE paramBE, Guid? userId, string cnnStringName)
        {
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString))
            {
                Fwk.ConfigData.fwk_Param param = new ConfigData.fwk_Param();
                param.Culture = paramBE.Culture;
                param.Description = paramBE.Description;
                param.Enabled = true;
                param.Name = paramBE.Name;
                param.ParamId = paramBE.ParamId;
                param.ParentId = paramBE.ParamTypeId;
                
                dc.fwk_Params.InsertOnSubmit(param);
                dc.SubmitChanges();
                paramBE.Id = param.Id;
                
            }
           
        }

       
        /// <summary>
        /// Permite eliminar por 
        /// solo parentId
        /// solo paramId
        /// por ambos
        /// no permite que ambos sean Null
        /// </summary>
        /// <param name="paramId"></param>
        /// <param name="parentId"></param>
        /// <param name="cnnStringName"></param>
        public static void Delete(int? paramId, int? parentId, string cnnStringName)
        {
            //no permite que ambos sean Null
            if (paramId.HasValue == false || parentId.HasValue == false)
                throw new Fwk.Exceptions.TechnicalException("Debe proporcinar almeno uno de los dos parametros");
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString))
            {
                var paramsList = dc.fwk_Params.Where(p => (paramId.HasValue == false || p.ParamId.Equals(paramId.Value)) &&
                       (parentId.HasValue == false || p.ParentId.Equals(parentId.Value)));
                foreach (fwk_Param p in paramsList)
                {
                    dc.fwk_Params.DeleteOnSubmit(p);
                }
                dc.SubmitChanges();

            }
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