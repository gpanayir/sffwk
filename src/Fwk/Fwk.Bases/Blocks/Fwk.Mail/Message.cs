﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Mail
{
    public class Message
    {

        private String mSubject;
        private Int32 mId;
        private Boolean mUnSeen;
        private String mBody;
        private String mURL;


        public String URL
        {
            get
            {
                return mURL;
            }
            set
            {
                mURL = value;
            }
        }       

        public String Body
        {
            get
            {
                return mBody;
            }
            set
            {
                mBody = value;
            }
        }

        public Boolean UnSeen
        {
            get
            {
                return mUnSeen;
            }
            set
            {
                mUnSeen = value;
            }
        }

        public Int32 Id
        {
            get
            {
                return mId;
            }
            set
            {
                mId = value;
            }
        }

        public String Subject
        {
            get
            {
                return mSubject;
            }
            set
            {
                mSubject = value;
            }
        }

    }
}