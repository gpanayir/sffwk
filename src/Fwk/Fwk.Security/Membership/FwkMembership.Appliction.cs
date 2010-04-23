using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Fwk.Exceptions;

namespace Fwk.Security
{
    public partial class FwkMembership
    {

        /// <summary>
        /// Retorna el GUID de la aplicación busca en la bse de datos configurada por defecto 
        /// </summary>
        /// <param name="pCompanyId">Nombre de la aplicación </param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>GUID de la aplicacion</returns>
        public static string GetApplicationID(String pCompanyId,string providerName)
        {

            String wApplicationId = String.Empty;
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(GetProvider_ConnectionStringName(providerName));
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
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }



        /// <summary>
        /// Obtiene de la bases de datos aspnet y tabla aspnet_Applications el Guid de la Aplicacion
        /// </summary>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static Guid GetApplication(string applicationName, string companyId)
        {

            Guid wApplicationNameId = new Guid();
            try
            {

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[companyId].ConnectionString))
                {

                    aspnet_Application app = dc.aspnet_Applications.First<aspnet_Application>(p => p.LoweredApplicationName.Equals(applicationName.ToLower()));

                    if (app != null)
                        wApplicationNameId = app.ApplicationId;
                }




                return wApplicationNameId;
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000"; throw te;
            }
        }

    }
}
