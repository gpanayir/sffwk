using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;


namespace Fwk.Security.ActiveDirectory
{

    /// <summary>
    /// 
    /// </summary>
    public class ADGroup
    {
        #region Properties
        List<String> _OU;
        List<String> _Users;
        string _Name, _FirstName, _Category, _Domain, _DistinguishedName, _Description, _CN;

        public string Domain
        {
            get { return _Domain; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public string FirstName
        {
            get { return _FirstName; }
        }
       

        public string Description
        {
            get { return _Description; }
        }

        /// <summary>
        /// Ejemplos:
        /// CN=GS_Comite_comunicacion_RW,OU=Seguridad,DC=actionlinecba,DC=org
        /// CN=GS_CalidadTP_R,OU=Avanzados,OU=Analistas,OU=Seguridad,DC=actionlinecba,DC=org
        /// </summary>
        public string DistinguishedName
        {
            get { return _DistinguishedName; }
        }

        /// <summary>
        /// Defines the Active Directory Schema category. For example, objectCategory = Person
        /// Ej: CN=Group,CN=Schema,CN=Configuration,DC=actionlinecba,DC=org
        /// </summary>
        public string Category
        {
            get { return _Category; }
        }

        /// <summary>
        ///  	Common Name
        /// </summary>
        public string CN
        {
            get { return _CN; }
        }


        /// <summary>
        /// Reprecenta la lista de unidades organizacionales del dominio
        /// OU = Organizational Unit 
        /// </summary>
        public List<String> OU
        {
            get { return _OU; }
            set { _OU = value; }
        }

        public List<String> Users
        {
            get { return _Users; }
        }

        #endregion

        public ADGroup()
        { }

        public ADGroup(DirectoryEntry directoryGroup, string domain)
        {

            String domainAddress;
            String domainName;
            String userPrincipalName = ADHelper.GetProperty(directoryGroup, ADProperties.USERPRINCIPALNAME);

            _Domain = domain;
            _Name = ADHelper.GetProperty(directoryGroup, ADProperties.NAME);

            _DistinguishedName = ADHelper.GetProperty(directoryGroup, ADProperties.DISTINGUISHEDNAME);

            _Description = ADHelper.GetProperty(directoryGroup, ADProperties.DESCRIPTION);

            _FirstName = ADHelper.GetProperty(directoryGroup, ADProperties.LOGINNAME);
            _Category = ADHelper.GetProperty(directoryGroup, ADProperties.OBJECTCATEGORY);

            if (!string.IsNullOrEmpty(userPrincipalName))
            {
                domainAddress = userPrincipalName.Split('@')[1];
            }
            else
            {
                domainAddress = String.Empty;
            }

            if (!string.IsNullOrEmpty(domainAddress))
            {

                domainName = domainAddress.Split('.').First();

            }

            else
            {

                domainName = String.Empty;

            }

            //if (pDirectoryEntry.Properties.Contains("sAMAccountName"))
            //{
            //    base.Name = pDirectoryEntry.Properties["sAMAccountName"][0].ToString(); //Nombre usuario como aaguirre
            //    _CN = base.Name;
            //}
            //if (pDirectoryEntry.Properties.Contains("userPrincipalName"))
            //    _UserPrincipalName = pDirectoryEntry.Properties["userPrincipalName"][0].ToString();//Nombre usuario como aaguirre@actionline.com
            //if (pDirectoryEntry.Properties.Contains("name"))
            //    base.FullName = pDirectoryEntry.Properties["name"][0].ToString(); //Nombre completo

            //if (pDirectoryEntry.Properties.Contains("sAMAccountType"))
            //    _FirstName = pDirectoryEntry.Properties["sAMAccountType"][0].ToString();
            //if (pDirectoryEntry.Properties.Contains("objectCategory"))
            //    base.Category = pDirectoryEntry.Properties["objectCategory"][0].ToString();

            //ej:CN=GS_Comite_comunicacion_RW,OU=Seguridad,DC=actionlinecba,DC=org
            if (!String.IsNullOrEmpty(_DistinguishedName))
            {
                SetNameInfo(_DistinguishedName);
            }
        
        }

        void SetNameInfo(string pNameInfo)
        {
            int i = 0;
            string[] propAux;
            _OU = new List<String>();
            foreach (string prop in pNameInfo.Split(','))
            {
                propAux = prop.Split('=');
                //if (propAux[0].CompareTo("CN") == 0)
                //{
                //    base.Name = propAux[1];
                //    _CN = base.Name;

                //}
                if (propAux[0].CompareTo("OU") == 0)
                {
                    _OU.Add(propAux[1]);
                    i++;
                }

            }
        }

    }
}
