using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Mail.Common
{  

    public enum LoginResponseEnum
    {
        USER_ALREADY_CONNECT,
        LOGIN_SUCCESS,
        LOGIN_FAIL,
        CONNECTION_FAIL,
        CONNECTION_SUCCESS,
        DISCONNECTION_FAIL,
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
