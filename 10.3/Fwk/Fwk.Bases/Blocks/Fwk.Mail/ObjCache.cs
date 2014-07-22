using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Mail.Common;

namespace Fwk.Mail
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ObjCache
    {
        private String mUserMail;
        private String mUserPassword;
        private ConnectionTypeEnum mConnectionType;
        
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
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
