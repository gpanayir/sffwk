using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Principal;

using System.Windows.Forms;
using System.Web.Security;
using System.Xml.Serialization;
using Fwk.Bases;


namespace Fwk.Security.Common
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(User)), Serializable]
    public class User
    {
        private Int32? _UserId = 0;
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
        private string _DNI;

        bool? _MustChangePassword;
        Int32? _ModifiedByUserId;
        DateTime? _ModifiedDate;
        AuthenticationModeEnum _AuthenticationMode = AuthenticationModeEnum.WindowsIntegrated;

        public string DNI
        {
            get { return _DNI; }
            set { _DNI = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32? ModifiedByUserId
        {
            get { return _ModifiedByUserId; }
            set { _ModifiedByUserId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool? MustChangePassword
        {
            get { return _MustChangePassword; }
            set { _MustChangePassword = value; }
        }
        string _FirstName;

        /// <summary>
        /// 
        /// </summary>
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        string _LastName;

        /// <summary>
        /// 
        /// </summary>
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        string[] _Roles;

        /// <summary>
        /// 
        /// </summary>
        public string[] Roles
        {
            get { return _Roles; }
            set { _Roles = value; }
        }
        /// <summary>
        /// Identificador de usuario int 32. No es la clave GUID. 
        /// Este valor es para comp'atibilidad con sistenmas existentes
        /// 
        /// </summary>
        public Int32? UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
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
    
        /// <summary>
        /// 
        /// </summary>
        public AuthenticationModeEnum AuthenticationMode
        {
            get { return _AuthenticationMode; }
            set { _AuthenticationMode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMembershipUser"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUserName"></param>
        public User(string pUserName)
        {
            m_UserName = pUserName;

        }

        /// <summary>
        /// 
        /// </summary>
        public User()
        {}
        /// <summary>
        /// Crea el array de roles.- Eleimina los qe exuisten 
        /// </summary>
        /// <param name="RolList"><see cref="RolList"/></param>
        public void AddRoles(RolList rolList)        
        {
            _Roles = new String[rolList.Count];
            int i = 0;
            foreach (Rol r in rolList)
            {
                _Roles[i] = r.RolName;
                i++;
            }
        }

        /// <summary>
        /// Obtiene la lista de roles de usuarios en formato de RolList
        /// </summary>
        /// <returns></returns>
        public RolList GetRolList()
        {
            RolList lst = new RolList();
            foreach (string r in _Roles)
            {
                lst.Add(new Rol (r));
            }
            return lst;
        }
    }

    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public String RolName
        {
            get { return _RolName; }
            set { _RolName = value; }
        }
        String _Description;
        /// <summary>
        /// 
        /// </summary>
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
    
            StringBuilder list = new StringBuilder();
            if (this == null || this.Count == 0)
            {
                return new String[] { };
            }
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
