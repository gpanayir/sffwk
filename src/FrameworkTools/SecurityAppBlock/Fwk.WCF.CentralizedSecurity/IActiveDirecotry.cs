using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Fwk.WCF.CentralizedSecurity.Contracts;

namespace Fwk.WCF.CentralizedSecurity
{
    
    [ServiceContract]
    public interface IActiveDirecotry
    {
        LoogonUserResult Autenticate(string userName, string password, string domain);

        [OperationContract(Name="Verifica si existe un usuario en un dominio")]
        bool User_Exist(string userName, string domain);

        [OperationContract(Name = "Verifica si existe un usuario en un dominio")]
        ActiveDirectoryUser Retrive_User_ByName(string userName, string domain);

        [OperationContract(Name = "Retorna todos los grupos de un determinado usuario")]
        ActiveDirectoryGroup[] Retrive_User_Groups(string userName, string domain);

        [OperationContract(Name = "Retorna todos los usuarios de un determinado grupo")]
        ActiveDirectoryUser[] Retrive_Group_Users(string groupName, string domain);

        [OperationContract(Name = "Retorna todos los usuarios de un determinado grupo")]
        ActiveDirectoryGroup[] Retrive_Groups(string domain);

        [OperationContract(Name = "Lista de dominios y su informacion LDAP")]
        Fwk.WCF.CentralizedSecurity.Contracts.DomainsUrl[] Retrive_DomainsUrl();

        bool User_Reset_Password(string userName, string newPassword, string domain);

        bool User_SetActivation(string userName, bool disabled, string domain);

        bool User_Unlock(string userName, string domain);

        bool User_Lock(string userName, string domain);

        string Test();
    }
}
