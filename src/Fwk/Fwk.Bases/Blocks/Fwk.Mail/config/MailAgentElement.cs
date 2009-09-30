using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Fwk.Logging.Targets;
using Fwk.Logging;

namespace Fwk.ConfigSection
{
    /// <summary>

    /// </summary>
    /// <date>2009/08/31</date>
    /// <author>moviedo</author>
    public class MailAgentElement : ConfigurationElement
    {
        #region <constructor>
        /// <summary>
        /// Constructor de RuleElement.
        /// </summary>
        public MailAgentElement() { }
        #endregion

        #region <public properties>
        /// <summary>
        /// Nombre de la regla. Es el identificador de una regla
        /// por lo tanto este nombre no debe repetirse.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true), StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        [ConfigurationProperty("hostMail", IsRequired = true, IsKey = false), 
         StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        public string HostMail
        {
            get
            {
                return (string)this["hostMail"];
            }
        }



        /// <summary>
        /// 
        /// 
        /// </summary>
        [ConfigurationProperty("inboxUrl", IsRequired = true, IsKey = false), 
         StringValidator(InvalidCharacters = @" <>")]
        public string InboxUrl
        {
            get
            {
                return (string)this["inboxUrl"];
            }
        }



    

        [ConfigurationProperty("refreshTime", DefaultValue = "0", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MaxValue = 1000, MinValue = 0)]
        public int RefreshTime
        {
            get
            {
                return (int)this["refreshTime"];
            }
        }

        /// <summary>
        /// </summary>
        [ConfigurationProperty("useSSL")]
        public bool UseSSL
        {
            get
            {
                return (bool)this["useSSL"];
            }
        }
        #endregion
    }
}
