using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// This class will have the properties corresponding to the information of the AD User. 
    /// 1.       This class has read only properties for fetching First Name, Last Name, City, Login Name etc.
    /// 2.       Constructor of the class is taking one parameter of type DirectoryEntry class.
    /// 3.       In Constructor all the information about ADUser is getting fetched using static class ADProperties.
    /// 4.       There are two static functions inside this class. GetUser and GetProperty
    /// 5.       Get Property is returning a string which holds property of AD User.
    /// 6.       GetUser static function is returning an ADUser. 
    /// </summary>
    public class ADUserDetail
    {

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



        public ADUserDetail Manager
        {

            get
            {

                if (!String.IsNullOrEmpty(_managerName))
                {

                    ADHelper ad = new ADHelper();

                    return ad.GetUserByFullName(_managerName);

                }

                return null;

            }

        }



        public String ManagerName
        {

            get { return _managerName; }

        }
        private ADUserDetail(DirectoryEntry directoryUser)
        {



            String domainAddress;

            String domainName;

            _firstName = GetProperty(directoryUser, ADProperties.FIRSTNAME);

            _middleName = GetProperty(directoryUser, ADProperties.MIDDLENAME);

            _lastName = GetProperty(directoryUser, ADProperties.LASTNAME);

            _loginName = GetProperty(directoryUser, ADProperties.LOGINNAME);

            String userPrincipalName = GetProperty(directoryUser, ADProperties.USERPRINCIPALNAME);

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

            _streetAddress = GetProperty(directoryUser, ADProperties.STREETADDRESS);

            _city = GetProperty(directoryUser, ADProperties.CITY);

            _state = GetProperty(directoryUser, ADProperties.STATE);

            _postalCode = GetProperty(directoryUser, ADProperties.POSTALCODE);

            _country = GetProperty(directoryUser, ADProperties.COUNTRY);

            _company = GetProperty(directoryUser, ADProperties.COMPANY);

            _department = GetProperty(directoryUser, ADProperties.DEPARTMENT);

            _homePhone = GetProperty(directoryUser, ADProperties.HOMEPHONE);

            _extension = GetProperty(directoryUser, ADProperties.EXTENSION);

            _mobile = GetProperty(directoryUser, ADProperties.MOBILE);

            _fax = GetProperty(directoryUser, ADProperties.FAX);

            _emailAddress = GetProperty(directoryUser, ADProperties.EMAILADDRESS);

            _title = GetProperty(directoryUser, ADProperties.TITLE);

            _manager = GetProperty(directoryUser, ADProperties.MANAGER);

            if (!String.IsNullOrEmpty(_manager))
            {

                String[] managerArray = _manager.Split(',');

                _managerName = managerArray[0].Replace("CN=", "");

            }

        }





        private static String GetProperty(DirectoryEntry userDetail, String propertyName)
        {

            if (userDetail.Properties.Contains(propertyName))
            {

                return userDetail.Properties[propertyName][0].ToString();

            }

            else
            {

                return string.Empty;

            }

        }



        public static ADUserDetail GetUser(DirectoryEntry directoryUser)
        {

            return new ADUserDetail(directoryUser);

        }

    }

}


