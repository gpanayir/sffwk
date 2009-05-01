using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Principal;

using System.Windows.Forms;
using System.Web.Security;


namespace Fwk.Security.Common
{

    public class User
    {
        String _UserName;

        public String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        String _AppName;

        public String AppName
        {
            get { return _AppName; }
            set { _AppName = value; }
        }
        public User(MembershipUser pMembershipUser)
        {
            _UserName = pMembershipUser.UserName;

        }
        public User(string pUserName)
        {
            _UserName = pUserName;

        }
    }

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


    public class Rol
    {

        public Rol(string pname)
        {
            _RolName = pname;
        }
        String _RolName;

        public String RolName
        {
            get { return _RolName; }
            set { _RolName = value; }
        }

        public override string ToString()
        {
            return _RolName;
        }
    }

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
