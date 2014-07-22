using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Mail.Common
{  
    /// <summary>
    /// 
    /// </summary>
    public enum LoginResponseEnum
    {
        /// <summary>
        /// 
        /// </summary>
        USER_ALREADY_CONNECT,
        /// <summary>
        /// 
        /// </summary>
        LOGIN_SUCCESS,
        /// <summary>
        /// 
        /// </summary>
        LOGIN_FAIL,
        /// <summary>
        /// 
        /// </summary>
        CONNECTION_FAIL,
        /// <summary>
        /// 
        /// </summary>
        CONNECTION_SUCCESS,
        /// <summary>
        /// 
        /// </summary>
        DISCONNECTION_FAIL,
        /// <summary>
        /// 
        /// </summary>
        DISCONNECTION_SUCCESS
    }

    public enum ConnectionTypeEnum
    {
        IMAP,
        POP3        
    }

    public enum ConnectionStatusEnum
    {
        Disconected = 0, // Current User is disconnected
        Connected = 1 // Current User is connected
    }

    public enum AccountTypeEnum
    {
        POP3 = 0,
        IMAP = 1
    }
}
