

using System.Collections.Generic;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration.Unity;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Fwk.Security.Configuration.Unity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace Fwk.Security.Configuration
{
    /// <summary>
    /// Represents the configuration data for an
    /// <see cref="Microsoft.Practices.EnterpriseLibrary.Security.AuthorizationRuleProvider"/>.
    /// </summary>
    [Assembler(typeof(FwkAuthorizationRuleProviderAssembler))]
    [ContainerPolicyCreator(typeof(FwkAuthorizationRuleProviderPolicyCreator))]
    public class FwkAuthorizationRuleProviderData : AuthorizationProviderData
    {
        private const string rulesProperty = "rules";

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="FwkAuthorizationRuleProviderData"/> class.
        /// </summary>
        public FwkAuthorizationRuleProviderData()
        {

        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="AuthorizationRuleProviderData"/> class.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        public FwkAuthorizationRuleProviderData(string name)
            : base(name, typeof(FwkAuthorizationRuleProviderData))
        {
            if (_Rules == null)
                _Rules = FwkMembership.GetRules( Membership.ApplicationName);

        }


        /// <summary>
        /// Database connection string for rules
        /// </summary>

        [ConfigurationProperty("connectionStringName", IsKey = true, DefaultValue = "", IsRequired = true)]
        public string ConnectionStringName
        {
            get
            {
                return (string)this["connectionStringName"];
            }
            set
            {
                this["connectionStringName"] = value;
            }
        }

        NamedElementCollection<FwkAuthorizationRule> _Rules = new NamedElementCollection<FwkAuthorizationRule>();
        /// <summary>
        /// Gets or sets the list of rules associated with
        /// the provider.
        /// </summary>
        /// <value>A collection of <see cref="AuthorizationRuleData"/>.</value>
        [ConfigurationProperty(rulesProperty, IsRequired = false)]
        public NamedElementCollection<FwkAuthorizationRule> Rules
        {
            get
            {
                if (_Rules.Count == 0 && !String.IsNullOrEmpty((string)this["connectionStringName"]))
                {
                    //FwkMembership.ConnectionStringName = this["connectionStringName"].ToString().Trim();
                    _Rules = FwkMembership.GetRules( Membership.ApplicationName);
                }
                return _Rules;
            }
        }


    }

    /// <summary>
    /// This type supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
    /// Represents the process to build an <see cref="AuthorizationRuleProvider"/> described by an <see cref="AuthorizationRuleProviderData"/> configuration object.
    /// </summary>
    /// <remarks>This type is linked to the <see cref="AuthorizationRuleProviderData"/> type and it is used by the <see cref="AuthorizationProviderCustomFactory"/> 
    /// to build the specific <see cref="IAuthorizationProvider"/> object represented by the configuration object.
    /// </remarks>
    public class FwkAuthorizationRuleProviderAssembler : IAssembler<IAuthorizationProvider, AuthorizationProviderData>
    {
        /// <summary>
        /// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
        /// Builds a <see cref="AuthorizationRuleProvider"/> based on an instance of <see cref="AuthorizationRuleProviderData"/>.
        /// </summary>
        /// <seealso cref="AuthorizationProviderCustomFactory"/>
        /// <param name="context">The <see cref="IBuilderContext"/> that represents the current building process.</param>
        /// <param name="objectConfiguration">The configuration object that describes the object to build. Must be an instance of <see cref="AuthorizationRuleProviderData"/>.</param>
        /// <param name="configurationSource">The source for configuration objects.</param>
        /// <param name="reflectionCache">The cache to use retrieving reflection information.</param>
        /// <returns>A fully initialized instance of <see cref="AuthorizationRuleProvider"/>.</returns>
        public IAuthorizationProvider Assemble(IBuilderContext context, 
            AuthorizationProviderData objectConfiguration, 
            IConfigurationSource configurationSource, 
            ConfigurationReflectionCache reflectionCache)
        {

            FwkAuthorizationRuleProviderData castedObjectConfiguration = (FwkAuthorizationRuleProviderData)objectConfiguration;

            IDictionary<string, IAuthorizationRule> authorizationRules = new Dictionary<string, IAuthorizationRule>();
            foreach (FwkAuthorizationRule ruleData in castedObjectConfiguration.Rules)
            {
                authorizationRules.Add(ruleData.Name, ruleData);
            }

            IAuthorizationProvider createdObject
                = new AuthorizationRuleProvider(authorizationRules);

            return createdObject;
        }
    }
}