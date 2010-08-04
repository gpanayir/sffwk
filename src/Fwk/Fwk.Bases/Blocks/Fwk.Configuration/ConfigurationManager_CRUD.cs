using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Configuration.Common;

namespace Fwk.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public class ConfigurationManager_CRUD
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConfigProvider"></param>
        /// <param name="groupName"></param>
        /// <param name="property"></param>
        public static void AddProperty(string pConfigProvider,string groupName, Key property)
        {
            ConfigurationManager.AddProperty(pConfigProvider, groupName, property);
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConfigProvider"></param>
        /// <param name="propertyName"></param>
        /// <param name="groupName"></param>
        public static void RemoveProperty(string pConfigProvider,  string groupName,string propertyName)
        {
            ConfigurationManager.RemoveProperty(pConfigProvider, groupName, propertyName);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConfigProvider"></param>
        /// <param name="group"></param>
        public static void AddGroup(string pConfigProvider, Group group)
        {
            ConfigurationManager.AddGroup(pConfigProvider,  group);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConfigProvider"></param>
        /// <param name="groupName"></param>
        public static void RemoveGroup(string pConfigProvider, string groupName)
        {
            ConfigurationManager.RemoveGroup(pConfigProvider, groupName);
        }
    }
}
