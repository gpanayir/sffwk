using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Mail.Common;

namespace Fwk.Mail
{
    [Serializable]
    public class ObjCache
    {
        private String mUserMail;
        private String mUserPassword;
        private ConnectionTypeEnum mConnectionType;
        

        public ConnectionTypeEnum ConnectionType
        {
            get
            {
                return mConnectionType;
            }
            set
            {
                mConnectionType = value;
            }
        }
        public String UserPassword
        {
            get
            {
                return mUserPassword;
            }
            set
            {
                mUserPassword = value;
            }
        }
        public String UserMail
        {
            get
            {
                return mUserMail;
            }
            set
            {
                mUserMail = value;
            }
        }
      
    }
}
