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
        ERROR_PASSWORD_EXPIRED = 1330,

        /// <summary>
        /// Este mensaje de error puede deberse a cualquiera de las siguientes situaciones:
        ///     La configuración de red del cliente es incorrecta. Esto incluye la ausencia de direcciones incorrecta para los servidores DNS localizar y resolver los controladores de dominio o.
        ///     La configuración del cliente Winsock Proxy es incorrecta, impedir la resolución correcta de controladores de dominio disponibles y sus direcciones.
        ///     Conectividad de red entre el cliente y los controladores de dominio descubiertos consultando DNS no está disponible.
        ///     Comunicación a través de la red para el controlador de dominio funciona correctamente, pero devolvió una respuesta no válida al cliente.
        ///     El controlador de dominio utilizado como origen de datos mientras está abierto el complemento ha convertido en no disponible.
        /// </summary>
        ERROR_SERVER_IS_NOT_OPERATIONAL
    }

    public enum LOGON32
    {
        /// <summary>
        /// This parameter causes LogonUser to create a primary token.
        /// Use the standard logon provider for the system. 
        /// This is the recommended value for the dwLogonProvider parameter. 
        /// It provides maximum compatibility with current and future releases of Windows NT.
        /// </summary>
        LOGON32_PROVIDER_DEFAULT = 0,
        /// <summary>
        /// 
        /// </summary>
        LOGON32_LOGON_INTERACTIVE = 2
    }
}
