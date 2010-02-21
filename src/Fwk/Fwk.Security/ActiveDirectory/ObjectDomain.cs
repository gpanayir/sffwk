using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Fwk.Security.Common
{
    [Serializable]
    public class ObjectDomain:Fwk.Bases.Entity
    {
        string _Name, _FullName, _Category ;

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        /// <summary>
        /// Nombre completo EJ: Marcelo Fabian Oviedo
        /// </summary>
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        public ObjectDomain()
        { }

        public ObjectDomain(string pName)
        {
            _Name = pName;

        }

        public static List<T> FilterByName<T>(String pName, List<T> pSource)   where T : ObjectDomain
        {

            if (pSource == null) return null;

            List<T> wObjectDomainList_Aux = new List<T>();



            IEnumerable<T> list = from s in pSource
                                             where
                                                 (s.Name.StartsWith(pName, StringComparison.OrdinalIgnoreCase) || String.IsNullOrEmpty(pName))

                                             select s;

            foreach (T s in list)
            {
                wObjectDomainList_Aux.Add(s);
            }

            return wObjectDomainList_Aux;

        }
    }
    public class ObjectDomainGroup : ObjectDomain
    {
        private List<FwkIdentity> _ActiveDirectoryUsers = null;
        List<ObjectDomainGroup> _ActiveDirectoryMembersGroups = null;

        public List<ObjectDomainGroup> ActiveDirectoryMembersGroups
        {
            get { return _ActiveDirectoryMembersGroups; }
            set
            {
                if (_ActiveDirectoryMembersGroups == null)
                    FillUsers();
                _ActiveDirectoryMembersGroups = value;
            }
        }
    
        public List<FwkIdentity> Users
        {
            get
            {
                if (_ActiveDirectoryUsers == null)
                    FillUsers();
                return _ActiveDirectoryUsers;
            }

        }

        #region Declarations
        string _CN;
        List<String> _OU;
        public string CN
        {
            get { return _CN; }
            set { _CN = value; }
        }



        public List<String> OU
        {
            get { return _OU; }
            set { _OU = value; }
        }
        private string _FirstName,  _UserPrincipalName,  _DistinguishedName, _Description, _Domain;

        public string Domain
        {
            get { return _Domain; }
            set { _Domain = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string DistinguishedName
        {
            get { return _DistinguishedName; }
            set { _DistinguishedName = value; }
        }

       

        /// <summary>
        /// Nombre usuario como moviedo@actionline.com
        /// </summary>
        public string UserPrincipalName
        {
            get { return _UserPrincipalName; }
            set { _UserPrincipalName = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string FirstName
        {
            get { return _FirstName; }
        }

      
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIsLogin"></param>
        /// <param name="pAuthenticationType"></param>
        /// <param name="pDirectoryEntry"></param>
        public ObjectDomainGroup(System.DirectoryServices.DirectoryEntry pDirectoryEntry)
        {
            
            if (pDirectoryEntry.Properties.Contains("sAMAccountName"))
            {
                base.Name = pDirectoryEntry.Properties["sAMAccountName"][0].ToString(); //Nombre usuario como aaguirre
                _CN = base.Name;
            }
            if (pDirectoryEntry.Properties.Contains("userPrincipalName"))
                _UserPrincipalName = pDirectoryEntry.Properties["userPrincipalName"][0].ToString();//Nombre usuario como aaguirre@actionline.com
            if (pDirectoryEntry.Properties.Contains("name"))
                base.FullName = pDirectoryEntry.Properties["name"][0].ToString(); //Nombre completo
           
            if (pDirectoryEntry.Properties.Contains("sAMAccountType"))
                _FirstName = pDirectoryEntry.Properties["sAMAccountType"][0].ToString();
            if (pDirectoryEntry.Properties.Contains("objectCategory"))
                base.Category = pDirectoryEntry.Properties["objectCategory"][0].ToString();
            
            //ej:CN=GS_Comite_comunicacion_RW,OU=Seguridad,DC=actionlinecba,DC=org
            if (pDirectoryEntry.Properties.Contains("distinguishedName"))
            {
                _DistinguishedName = pDirectoryEntry.Properties["distinguishedName"][0].ToString();
                SetNameInfo(_DistinguishedName);
            }
            if (pDirectoryEntry.Properties.Contains("description"))
                _Description = pDirectoryEntry.Properties["description"][0].ToString();

            
            
        }

        /// <summary>
        /// Constructor vasio. 
        /// Deja null CN y OU.
        /// </summary>
        public ObjectDomainGroup() { _ActiveDirectoryUsers = new List<FwkIdentity>(); }

        /// <summary>
        /// Info de active directory respecto al grupo. No es el nombre 
        /// </summary>
        /// <param name="pNameInfo">Cadena: "CN=GS_Bin_Desarrollo_RW,OU=Seguridad,DC=actionlinecba,DC=org"</param>
        public ObjectDomainGroup(string pNameInfo)
        {
            _ActiveDirectoryUsers = new List<FwkIdentity>();
            SetNameInfo(pNameInfo);
        }

        void SetNameInfo(string pNameInfo)
        {
            int i =0;
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
                    _OU.Add( propAux[1]);
                    i++;
                }
                
            }
        }


        void FillUsers()
        {

            FwkActyveDirectory _FwkActyveDirectory = new FwkActyveDirectory(_Domain);
            _FwkActyveDirectory.GetUsersForGroup(this.Name, out _ActiveDirectoryUsers,out _ActiveDirectoryMembersGroups);
        }

        /// <summary>
        /// Vuelve a cargar los grupos del cual es muiembro desde el dominio
        /// </summary>
        public void RefreshADUsers()
        {
            FillUsers();
        }
    }
}
