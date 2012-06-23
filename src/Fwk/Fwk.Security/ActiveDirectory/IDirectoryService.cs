using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.DirectoryServices.ActiveDirectory;

namespace Fwk.Security.ActiveDirectory
{
    public interface IDirectoryService
    {
        /// <summary>
        /// Ej: 
        /// LDAP://domain/DC=xxx,DC=com
        /// LDAP://CORRSF71NT13.pelsoft.org/DC=pelsoft,DC=org
        /// LDAP://Corba362nt01.apelsoft.com.ar/OU=Movistar Sabattini,dc=pelsoft,dc=com,dc=ar
        /// </summary>
        String LDAPPath { get; }
        /// <summary>
        /// LDAPUser property
        /// </summary>
        String LDAPUser { get; }
        /// <summary>
        /// LDAPPassword property
        /// This property is reading the LDAP Password from the config file.
        /// </summary>
        String LDAPPassword { get; }
        /// <summary>
        /// Dominio
        /// </summary>
        String LDAPDomain { get; }
        /// <summary>
        /// Obtiene un usuario por nombre sin tener en cuenta las credenciales del usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        ADUser User_Get_ByName(String pUserName);
        /// <summary>
        /// Verifica si el usuario existe.- 
        /// </summary>
        /// <param name="userName">Nombre de loging de usuario</param>
        /// <returns></returns>
        bool User_Exists(string pUserName);
        /// <summary>
        /// Retorna los grupos a los que pertenece el usuario .-
        /// </summary>
        /// <param name="pUserName">Nombre completo del usuario</param>
        /// <returns></returns>
        List<ADGroup> User_SearchGroupList(String pUserName);
        /// <summary>
        /// Retorna la lista de usuarios pertenecientes a un determinado grupo
        /// </summary>
        /// <param name="groupName">Nombre del grupo</param>
        /// <returns></returns>
        LoginResult User_CheckLogin(string pUserName, string pPassword);
        /// <summary>
        /// Obtiene un ADGroup que reprecenta un grupo 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        ADGroup Group_GetByName(String pName);
        /// <summary>
        /// Obtiene todo los grupos pertenecientes al dominio.-
        /// </summary>
        List<ADGroup> Groups_GetAll();


        void ResetPwd(String pUserName, String pNewPwd, Boolean pForceChangeOnFirstLogon, Boolean pUnlockAccount);

    }
}
