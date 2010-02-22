using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// This class will have the properties corresponding to the information of the AD User.  
    /// This is a static class. This class is having all the properties as constant string for ADUser.  
    /// This class is giving readable name to all the properties of user details. 
    /// </summary>
    public static class ADProperties
    {

        public const String OBJECTCLASS = "objectClass";

        public const String CONTAINERNAME = "cn";

        public const String LASTNAME = "sn";

        public const String COUNTRYNOTATION = "c";

        public const String CITY = "l";

        public const String STATE = "st";

        public const String TITLE = "title";

        public const String POSTALCODE = "postalCode";

        public const String PHYSICALDELIVERYOFFICENAME = "physicalDeliveryOfficeName";

        /// <summary>
        /// givenName
        /// </summary>
        public const String FIRSTNAME = "givenName";

        /// <summary>
        /// initials
        /// </summary>
        public const String MIDDLENAME = "initials";

        /// <summary>
        /// DN Es uno de los mas importantes atributos LDAP
        /// CN=Jay Jamieson, OU= Newport,DC=cp,DC=com
        /// CN=GS_CalidadTP_R,OU=Avanzados,OU=Analistas,OU=Seguridad,DC=actionlinecba,DC=org
        /// </summary>
        public const String DISTINGUISHEDNAME = "distinguishedName";

        public const String INSTANCETYPE = "instanceType";

        public const String WHENCREATED = "whenCreated";

        public const String WHENCHANGED = "whenChanged";

        public const String DISPLAYNAME = "displayName";

        /// <summary>
        /// uSNCreated
        /// </summary>
        public const String USNCREATED = "uSNCreated";

        public const String MEMBEROF = "memberOf";

        public const String USNCHANGED = "uSNChanged";

        public const String COUNTRY = "co";

        public const String DEPARTMENT = "department";

        public const String COMPANY = "company";

        public const String PROXYADDRESSES = "proxyAddresses";

        public const String STREETADDRESS = "streetAddress";

        public const String DIRECTREPORTS = "directReports";

        /// <summary>
        /// Reprecenta la propiedad: name 
        /// Nombre completo
        /// </summary>
        public const String NAME = "name";

        /// <summary>
        /// Reprecenta la propiedad: objectGUID
        /// </summary>
        public const String OBJECTGUID = "objectGUID";

        /// <summary>
        /// Reprecenta la propiedad: userAccountControl Se utiliza para dehabilitar una cuenta.-
        /// Valor 514 dehabilita, mientras 512 mantiene la cuenta lista para logon.-
        /// </summary>
        public const String USERACCOUNTCONTROL = "userAccountControl";

        /// <summary>
        /// Reprecenta la propiedad: badPwdCount
        /// </summary>
        public const String BADPWDCOUNT = "badPwdCount";

        /// <summary>
        /// Reprecenta la propiedad: codePage
        /// </summary>
        public const String CODEPAGE = "codePage";
        /// <summary>
        /// Reprecenta la propiedad: countryCode
        /// </summary>
        public const String COUNTRYCODE = "countryCode";
        /// <summary>
        /// Reprecenta la propiedad: badPasswordTime
        /// </summary>
        public const String BADPASSWORDTIME = "badPasswordTime";
        /// <summary>
        /// Reprecenta la propiedad: lastLogoff
        /// </summary>
        public const String LASTLOGOFF = "lastLogoff";

        /// <summary>
        /// Reprecenta la propiedad: lastLogon
        /// </summary>
        public const String LASTLOGON = "lastLogon";

        /// <summary>
        /// Reprecenta la propiedad: pwdLastSet
        /// </summary>
        public const String PWDLASTSET = "pwdLastSet";

        /// <summary>
        /// Reprecenta la propiedad: primaryGroupID
        /// </summary>
        public const String PRIMARYGROUPID = "primaryGroupID";

        /// <summary>
        /// Reprecenta la propiedad: objectSid
        /// </summary>
        public const String OBJECTSID = "objectSid";

        /// <summary>
        /// Reprecenta la propiedad: adminCount
        /// </summary>
        public const String ADMINCOUNT = "adminCount";

        /// <summary>
        /// Reprecenta la propiedad: accountExpires
        /// </summary>
        public const String ACCOUNTEXPIRES = "accountExpires";

        /// <summary>
        /// Reprecenta la propiedad: logonCount
        /// </summary>
        public const String LOGONCOUNT = "logonCount";

        /// <summary>
        /// Reprecenta la propiedad: sAMAccountName
        /// </summary>
        public const String LOGINNAME = "sAMAccountName";

        /// <summary>
        /// Reprecenta la propiedad: sAMAccountType
        /// </summary>
        public const String SAMACCOUNTTYPE = "sAMAccountType";

        public const String SHOWINADDRESSBOOK = "showInAddressBook";

        public const String LEGACYEXCHANGEDN = "legacyExchangeDN";

        /// <summary>
        ///  Reprecenta la propiedad: userPrincipalName
        ///  Nombre usuario como jhendrix@actionline.com
        /// </summary>
        public const String USERPRINCIPALNAME = "userPrincipalName";

        public const String EXTENSION = "ipPhone";

        public const String SERVICEPRINCIPALNAME = "servicePrincipalName";
        
        /// <summary>
        /// Defines the Active Directory Schema category. For example, objectCategory = Person
        /// Ej: CN=Group,CN=Schema,CN=Configuration,DC=actionlinecba,DC=org
        /// </summary>
        public const String OBJECTCATEGORY = "objectCategory";

        public const String DSCOREPROPAGATIONDATA = "dSCorePropagationData";

        public const String LASTLOGONTIMESTAMP = "lastLogonTimestamp";

        public const String EMAILADDRESS = "mail";

        public const String MANAGER = "manager";

        public const String MOBILE = "mobile";

        public const String PAGER = "pager";

        public const String FAX = "facsimileTelephoneNumber";

        public const String HOMEPHONE = "homePhone";

        public const String MSEXCHUSERACCOUNTCONTROL = "msExchUserAccountControl";

        public const String MDBUSEDEFAULTS = "mDBUseDefaults";

        public const String MSEXCHMAILBOXSECURITYDESCRIPTOR = "msExchMailboxSecurityDescriptor";

        public const String HOMEMDB = "homeMDB";

        public const String MSEXCHPOLICIESINCLUDED = "msExchPoliciesIncluded";

        public const String HOMEMTA = "homeMTA";

        public const String MSEXCHRECIPIENTTYPEDETAILS = "msExchRecipientTypeDetails";

        public const String MAILNICKNAME = "mailNickname";

        public const String MSEXCHHOMESERVERNAME = "msExchHomeServerName";

        public const String MSEXCHVERSION = "msExchVersion";

        public const String MSEXCHRECIPIENTDISPLAYTYPE = "msExchRecipientDisplayType";

        public const String MSEXCHMAILBOXGUID = "msExchMailboxGuid";

        public const String NTSECURITYDESCRIPTOR = "nTSecurityDescriptor";

        public const String DESCRIPTION = "description";
        

    }
}
