using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;

namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// 
    /// </summary>
    public class DomainUrlInfo : Entity
    {

        string domainName;

        /// <summary>
        /// Nombre de dominio
        /// </summary>
        public string DomainName
        {
            get { return domainName; }
            set { domainName = value; }
        }
        string lDAPPath;

        /// <summary>
        /// Url del dominio
        /// </summary>
        public string LDAPPath
        {
            get { return lDAPPath; }
            set { lDAPPath = value; }
        }
        string usr;

        /// <summary>
        /// Usuario
        /// </summary>
        public string Usr
        {
            get { return usr; }
            set { usr = value; }
        }
        string pwd;

        /// <summary>
        /// Password
        /// </summary>
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
    }
}
