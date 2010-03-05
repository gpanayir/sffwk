using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// Clase que reprecenta un usuario de active directory.- 
    /// 1.       This class has read only properties for fetching First Name, Last Name, City, Login Name etc.
    /// 2.       Constructor of the class is taking one parameter of type DirectoryEntry class.
    /// 3.       In Constructor all the information about ADUser is getting fetched using static class ADProperties.
    /// 4.       There are two static functions inside this class. GetUser and GetProperty
    /// 5.       Get Property is returning a string which holds property of AD User.
    /// 6.       GetUser static function is returning an ADUser. 
    /// </summary>
    public class ADUser
    {
        #region Properties 

        private String _firstName;

        private String _middleName;

        private String _lastName;

        private String _loginName;

        private String _loginNameWithDomain;

        private String _streetAddress;

        private String _city;

        private String _state;

        private String _postalCode;

        private String _country;

        private String _homePhone;

        private String _extension;

        private String _mobile;

        private String _fax;

        private String _emailAddress;

        private String _title;

        private String _company;

        private String _manager;

        private String _managerName;

        private String _department;
        private String _UserAccountControl;

        /// <summary>
        /// Reprecenta la propiedad: userAccountControl Se utiliza para dehabilitar una cuenta.-
        /// Valor 514 dehabilita, mientras 512 mantiene la cuenta lista para logon.-
        /// </summary>
        public String UserAccountControl
        {
            get { return _UserAccountControl; }
        }
        
        public String Department
        {
            get { return _department; }
        }
        public String FirstName
        {
            get { return _firstName; }
        }

        public String MiddleName
        {
            get { return _middleName; }
        }

        public String LastName
        {
            get { return _lastName; }
        }

        public String LoginName
        {
           get { return _loginName; }
        }
        public String LoginNameWithDomain
        {
           get { return _loginNameWithDomain; }
       }
        public String StreetAddress
        {
           get { return _streetAddress; }
        }

        public String City
        {
            get { return _city; }
        }
        public String State
        {
            get { return _state; }
        }
        public String PostalCode
        {
            get { return _postalCode; }
        }
        public String Country
        {
            get { return _country; }
        }
        public String HomePhone
        {
            get { return _homePhone; }
        }
       public String Extension
        {
            get { return _extension; }
        }

        public String Mobile
        {

            get { return _mobile; }

        }
        public String Fax
        {
           get { return _fax; }
        }
        public String EmailAddress
        {
            get { return _emailAddress; }
       }

        public String Title
        {
            get { return _title; }
        }

        public String Company
        {
            get { return _company; }
        }

      
        List<string> _Groups;
       


        public String ManagerName
        {
            get { return _managerName; }

        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directoryUser"></param>
        public ADUser(DirectoryEntry directoryUser)
        {



            String domainAddress;
            String userPrincipalName = ADHelper.GetProperty(directoryUser, ADProperties.USERPRINCIPALNAME);
            String domainName;
            _UserAccountControl = ADHelper.GetProperty(directoryUser, ADProperties.USERACCOUNTCONTROL);
            _firstName = ADHelper.GetProperty(directoryUser, ADProperties.FIRSTNAME);

            _middleName = ADHelper.GetProperty(directoryUser, ADProperties.MIDDLENAME);

            _lastName = ADHelper.GetProperty(directoryUser, ADProperties.LASTNAME);

            _loginName = ADHelper.GetProperty(directoryUser, ADProperties.LOGINNAME);

            

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

            _loginNameWithDomain = String.Format(@"{0}\{1}", domainName, _loginName);

            _streetAddress = ADHelper.GetProperty(directoryUser, ADProperties.STREETADDRESS);

            _city = ADHelper.GetProperty(directoryUser, ADProperties.CITY);

            _state = ADHelper.GetProperty(directoryUser, ADProperties.STATE);

            _postalCode = ADHelper.GetProperty(directoryUser, ADProperties.POSTALCODE);

            _country = ADHelper.GetProperty(directoryUser, ADProperties.COUNTRY);

            _company = ADHelper.GetProperty(directoryUser, ADProperties.COMPANY);

            _department = ADHelper.GetProperty(directoryUser, ADProperties.DEPARTMENT);

            _homePhone = ADHelper.GetProperty(directoryUser, ADProperties.HOMEPHONE);

            _extension = ADHelper.GetProperty(directoryUser, ADProperties.EXTENSION);

            _mobile = ADHelper.GetProperty(directoryUser, ADProperties.MOBILE);

            _fax = ADHelper.GetProperty(directoryUser, ADProperties.FAX);

            _emailAddress = ADHelper.GetProperty(directoryUser, ADProperties.EMAILADDRESS);

            _title = ADHelper.GetProperty(directoryUser, ADProperties.TITLE);

            _manager = ADHelper.GetProperty(directoryUser, ADProperties.MANAGER);

            if (!String.IsNullOrEmpty(_manager))
            {

                String[] managerArray = _manager.Split(',');

                _managerName = managerArray[0].Replace("CN=", "");

            }



        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pSource"></param>
        /// <returns></returns>
        public static List<ADUser> FilterByName(String pName, List<ADUser> pSource)
        {
            if (pSource == null) return null;

            return (List<ADUser>)
                pSource.Where<ADUser>(p => (
                    p.LoginName.StartsWith(pName, StringComparison.OrdinalIgnoreCase)
                    || String.IsNullOrEmpty(pName)));

        }
    }

}


