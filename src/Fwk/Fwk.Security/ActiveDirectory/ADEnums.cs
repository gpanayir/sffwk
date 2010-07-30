using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security.ActiveDirectory
{

    /// <summary>
    /// 
    /// </summary>
    public enum ADAccountOptions
    {
        /// <summary>
        /// 
        /// </summary>
        UF_TEMP_DUPLICATE_ACCOUNT = 0x0100,
        /// <summary>
        /// 
        /// </summary>
        UF_NORMAL_ACCOUNT = 0x0200,
        /// <summary>
        /// Dec = 512 
        /// </summary>
        UF_INTERDOMAIN_TRUST_ACCOUNT = 0x0800,
        /// <summary>
        /// Dec =2048
        /// </summary>
        UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,
        /// <summary>
        /// 
        /// </summary>
        UF_SERVER_TRUST_ACCOUNT = 0x2000,
        /// <summary>
        /// Cuenta de usuario no expiro &h10000 = (dec = 65536)
        /// 
        /// </summary>
        UF_DONT_EXPIRE_PASSWD = 0x10000,
        /// <summary>
        /// 
        /// </summary>
        UF_SCRIPT = 0x0001,
        /// <summary>
        /// ACCOUNTDISABLE: la cuenta de usuario está desactivada. (dec = 2)
        /// </summary>
        UF_ACCOUNTDISABLE = 0x0002,
        /// <summary>
        /// HOMEDIR_REQUIRED: se requiere la carpeta principal. 
        /// </summary>
        UF_HOMEDIR_REQUIRED = 0x0008,
        /// <summary>
        /// 16
        /// </summary>
        UF_LOCKOUT = 0x0010,
        /// <summary>
        /// 
        /// </summary>
        UF_PASSWD_NOTREQD = 0x0020,
        /// <summary>
        /// 
        /// </summary>
        UF_PASSWD_CANT_CHANGE = 0x0040,
        /// <summary>
        /// 16
        /// </summary>
        UF_ACCOUNT_LOCKOUT = 0X0010,
        /// <summary>
        /// 
        /// </summary>
        UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0X0080,



    }

    /// <summary>
    /// Determina el resultado de loging de usuario
    /// </summary>
    public enum LoginResult
    {
        /// <summary>
        /// Logoing exitoso
        /// </summary>
        LOGIN_OK = 0,

        /// <summary>
        /// Uario no existe
        /// </summary>
        LOGIN_USER_DOESNT_EXIST,

        /// <summary>
        /// Cuenta inactiva
        /// </summary>
        LOGIN_USER_ACCOUNT_INACTIVE,

        /// <summary>
        /// Clave incorrecta
        /// </summary>
        LOGIN_USER_OR_PASSWORD_INCORRECT,

        /// <summary>
        /// Cuenta de usuario bloqueada
        /// </summary>
        LOGIN_USER_ACCOUNT_LOCKOUT,

        ERROR_PASSWORD_MUST_CHANGE = 1907,
        ERROR_PASSWORD_EXPIRED = 1330

    }

}
