
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System;
using System.Data;

namespace Fwk.Security.Configuration.Unity
{
    /// <summary>
    /// This type supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
    /// Represents the process to create the container policies required to create a <see cref="FwkAuthorizationRuleProvider"/>.
    /// </summary>
    public class FwkAuthorizationRuleProviderPolicyCreator : IContainerPolicyCreator
    {
        void IContainerPolicyCreator.CreatePolicies(
            IPolicyList policyList,
            string instanceName,
            ConfigurationElement configurationObject,
            IConfigurationSource configurationSource)
        {

            FwkAuthorizationRuleProviderData castConfigurationObject = (FwkAuthorizationRuleProviderData)configurationObject;

            PolicyBuilder<FwkAuthorizationRuleProvider, FwkAuthorizationRuleProviderData> wPolicyBuilder =
            new PolicyBuilder<FwkAuthorizationRuleProvider, FwkAuthorizationRuleProviderData>(
                    instanceName,
                    castConfigurationObject,
                    c => new FwkAuthorizationRuleProvider(CreateRulesDictionary(c.Rules)));


            wPolicyBuilder.AddPoliciesToPolicyList(policyList);
        }

        private static IDictionary<string, IAuthorizationRule> CreateRulesDictionary(
            IEnumerable<AuthorizationRuleData> rulesCollection)
        {
            IDictionary<string, IAuthorizationRule> authorizationRules = new Dictionary<string, IAuthorizationRule>();
           

            foreach (AuthorizationRuleData ruleData in rulesCollection)
            {
                authorizationRules.Add(ruleData.Name, ruleData);
            }

            return authorizationRules;
        }


        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>DataSet</returns>
        /// <Date>2008-12-13T22:02:22</Date>
        /// <Author>moviedo</Author>
        public static DataTable GetAll()
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase("SqlServices");
                wCmd = wDataBase.GetStoredProcCommand("aspnet_Rules_s");


                return wDataBase.ExecuteDataSet(wCmd).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}