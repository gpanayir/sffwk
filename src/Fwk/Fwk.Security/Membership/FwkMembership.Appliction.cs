using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Fwk.Security
{
    public partial class FwkMembership
    {

        /// <summary>
        /// Retorna el GUID de la aplicación busca en la bse de datos configurada por defecto 
        /// </summary>
        /// <param name="pCompanyId">Nombre de la aplicación </param>
        /// <returns>GUID de la aplicacion</returns>
        public static string GetApplicationID(String pCompanyId)
        {

            String wApplicationId = String.Empty;
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(FwkMembership.ConnectionStringName);
                wCmd = wDataBase.GetStoredProcCommand("[aspnet_Personalization_GetApplicationId]");

                // ApplicationName
                wDataBase.AddInParameter(wCmd, "ApplicationName", System.Data.DbType.String, pCompanyId);


                wDataBase.AddOutParameter(wCmd, "ApplicationId", System.Data.DbType.Guid, 64);

                wDataBase.ExecuteScalar(wCmd);

                wApplicationId = Convert.ToString(wDataBase.GetParameterValue(wCmd, "ApplicationId"));

                return wApplicationId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Obtiene de la bases de datos aspnet y tabla aspnet_Applications el Guid de la Aplicacion
        /// </summary>
        /// <param name="pApplicationName"></param>
        /// <param name="pCompanyId"></param>
        /// <returns></returns>
        public static Guid GetApplication(string pApplicationName, string pCompanyId)
        {

            Guid wApplicationNameId = new Guid();
            try
            {

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pCompanyId].ConnectionString))
                {

                    aspnet_Application app = dc.aspnet_Applications.First<aspnet_Application>(p => p.LoweredApplicationName.Equals(pApplicationName.ToLower()));

                    if (app != null)
                        wApplicationNameId = app.ApplicationId;
                }




                return wApplicationNameId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
