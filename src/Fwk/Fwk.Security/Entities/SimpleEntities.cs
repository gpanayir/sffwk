using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Principal;

using System.Windows.Forms;
using System.Web.Security;
using System.Xml.Serialization;


namespace Fwk.Security.Common
{

    [XmlInclude(typeof(User)), Serializable]
    public class User
    {
        private String m_AppName;
        private String m_UserName;
        private DateTime m_LastActivityDate;
        private String m_Email;
        private Boolean m_IsApproved;
        private Boolean m_IsLockedOut;
        private String m_Comment;
        private String m_Password;
        private String m_QuestionPassword;
        private String m_AnswerPassword;
        
        /// <summary>
        /// Answer security password
        /// </summary>
        public String AnswerPassword
        {
            get
            {
                return m_AnswerPassword;
            }
            set
            {
                m_AnswerPassword = value;
            }
        }
        /// <summary>
        /// Question security password
        /// </summary>
        public String QuestionPassword
        {
            get
            {
                return m_QuestionPassword;
            }
            set
            {
                m_QuestionPassword = value;
            }
        }
        /// <summary>
        /// User Password
        /// </summary>
        public String Password
        {
            get
            {
                return m_Password;
            }
            set
            {
                m_Password = value;
            }
        }
        /// <summary>
        /// User comment or description
        /// </summary>
        public String Comment
        {
            get
            {
                return m_Comment;
            }
            set
            {
                m_Comment = value;
            }
        }                
        /// <summary>
        /// Application name
        /// </summary>
        public String AppName
        {
            get { return m_AppName; }
            set { m_AppName = value; }
        }
        /// <summary>
        /// User name
        /// </summary>
        public String UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        /// <summary>
        /// Last user activity
        /// </summary>
        public DateTime LastActivityDate
        {
            get{return m_LastActivityDate;}
            set{m_LastActivityDate = value;}
        }
        /// <summary>
        /// Get User Lock
        /// </summary>
        public Boolean IsLockedOut
        {
            get{return m_IsLockedOut;}            
        }
        /// <summary>
        /// User Approved 
        /// </summary>
        public Boolean IsApproved
        {
            get{return m_IsApproved;}
            set{m_IsApproved = value;}
        }
        /// <summary>
        /// User Email
        /// </summary>
        public String Email
        {
            get{return m_Email;}
            set{m_Email = value;}
        }


        public User(MembershipUser pMembershipUser)
        {
            m_UserName = pMembershipUser.UserName;
            m_LastActivityDate = pMembershipUser.LastActivityDate;
            m_IsLockedOut = pMembershipUser.IsLockedOut;
            m_IsApproved = pMembershipUser.IsApproved;
            m_Email = pMembershipUser.Email;
            m_Comment = pMembershipUser.Comment;
            m_QuestionPassword = pMembershipUser.PasswordQuestion;            

        }

        public User(string pUserName)
        {
            m_UserName = pUserName;

        }

    }
    [XmlRoot("UserList"), SerializableAttribute]
    public class UserList : List<User>
    {
        public String[] GetArraNames()
        {
            StringBuilder list = new StringBuilder(); ;
            foreach (User r in this)
            {
                list.Append(r.UserName);
                list.Append(",");
            }
            list.Remove(list.Length - 1, list.Length);
            return list.ToString().Split(',');
        }
    }
    [XmlInclude(typeof(Rol)), Serializable]
    public class Rol
    {

        public Rol(){}
        public Rol(string pname)
        {
            _RolName = pname;
        }
        public Rol(string name,string description)
        {
            _RolName = name;
            _Description = description;
        }
        String _RolName;

        public String RolName
        {
            get { return _RolName; }
            set { _RolName = value; }
        }
        String _Description;
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public override string ToString()
        {
            return _RolName;
        }

    }
    [XmlRoot("RolList"), SerializableAttribute]
    public class RolList : List<Rol>
    {
        public String[] GetArrayNames()
        {
            StringBuilder list = new StringBuilder(); ;
            foreach (Rol r in this)
            {
                list.Append(r.RolName);
                list.Append(",");
            }
            list.Remove(list.Length - 1, 1);
            return list.ToString().Split(',');
        }
    }

}
