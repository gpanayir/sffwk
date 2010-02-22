﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Security.Common;
using Microsoft.Practices.EnterpriseLibrary.Security;

namespace Fwk.Security
{
    /// <summary>
    /// 
    /// </summary>
    public  static class FwkMembershipScripts
    {
        static string _RuleInCategory_i;
        static string _Category_d = "DELETE FROM aspnet_RulesCategory WHERE  aspnet_RulesCategory.CategoryId = [CategoryId]";
        static string _RulesCategory_d = "DELETE FROM aspnet_RulesInCategory WHERE  aspnet_RulesInCategory.CategoryId = [CategoryId]";

        public static string RuleInCategory_i
        {
            get
            {
                SetRuleInCategory_i();
                return FwkMembershipScripts._RuleInCategory_i;
            }

        }
        static string _Rule_i;

        public static string Rule_i
        {
            get
            {
                SetRule_i(); 
                return FwkMembershipScripts._Rule_i;
            }

        }
        static string _Rule_u;

        public static string Rule_u
        {
            get
            {
                SetRule_u();
                return FwkMembershipScripts._Rule_u;
            }

        }
     
        public static string RulesCategory_d
        {
            get
            {
                return FwkMembershipScripts._RulesCategory_d;
            }

        }
        public static string Category_d
        {
            get
            {
                return FwkMembershipScripts._Category_d;
            }

        }


        static string _ApplicationId_s;

        public static string ApplicationId_s
        {
            get
            {
                SetApplicationId();
                return FwkMembershipScripts._ApplicationId_s;
            }

        }
        static string _Category_i;

        public static string Category_i
        {
            get
            {
                SetCategory_i();
                return _Category_i;
            }

        }
        static void SetRuleInCategory_i()
        {

            if (string.IsNullOrEmpty(_RuleInCategory_i))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);

                sb.Append(@"	INSERT INTO aspnet_RulesInCategory");
                sb.Append(@"		(CategoryId");
                sb.Append(@"		,RuleName");
                sb.Append(@"		,ApplicationId)");

                sb.Append(@"	VALUES (");
                sb.Append(@"		[CategoryId],");
                sb.Append(@"		'[RuleName]',");
                sb.Append(@"		CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]')) ");


                _RuleInCategory_i = sb.ToString();
            }


        }
        static void SetCategory_i()
        {

            if (string.IsNullOrEmpty(_Category_i))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);

                sb.Append(@"	INSERT INTO aspnet_RulesCategory");
                sb.Append(@"		(ParentCategoryId");
                sb.Append(@"		,[Name]");
                sb.Append(@"		,ApplicationId)");

                sb.Append(@"	VALUES (");
                sb.Append(@"		[ParentCategoryId],");
                sb.Append(@"		'[CategoryName]',");
                sb.Append(@"		CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]')) select @@IDENTITY");


                _Category_i = sb.ToString();
            }


        }

        static void SetApplicationId()
        {
            if (string.IsNullOrEmpty(_ApplicationId_s))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
                sb.Append(@"DECLARE @ApplicationId uniqueidentifier ");
                sb.Append(@"    SELECT  @ApplicationId = NULL ");
                sb.Append(@"    SELECT  @ApplicationId = ApplicationId  ");
                sb.Append(@"    FROM aspnet_Applications WHERE LOWER('[ApplicationName]') = LoweredApplicationName ");
                //sb.Append(@"    IF (@ApplicationId IS NULL) ");
                //sb.Append(@"        RETURN(0) ");
                _ApplicationId_s = sb.ToString();
            }

        }


        static void SetRule_i()
        {

            if (string.IsNullOrEmpty(_Rule_i))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);


                sb.Append(@"	INSERT INTO dbo.aspnet_Rules");
                sb.Append(@"		(expression ");
                sb.Append(@"		,[name]");
                sb.Append(@"		,ApplicationId)");

                sb.Append(@"	VALUES (");
                sb.Append(@"		'[expression]',");
                sb.Append(@"		'[rulename]',");
                sb.Append(@"		CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]')) ");


                _Rule_i = sb.ToString();
            }

        }
        static void SetRule_u()
        {

            if (string.IsNullOrEmpty(_Rule_u))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);


                sb.Append(@"	UPDATE dbo.aspnet_Rules");
                sb.Append(@"	SET	expression = '[expression]'");
                sb.Append(@"		,[name]= '[rulename]'");
                sb.Append(@"	WHERE [name]= '[rulename]' and ApplicationId = CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]')");
   

                _Rule_u = sb.ToString();
            }

        }

        /// <summary>
        /// Construye la lista de usuarios y de roles desde la expresion de la regla.-
        /// </summary>
        /// <param name="assignedRoleList"></param>
        /// <param name="excludeUserList"></param>
        /// <returns></returns>
        public static string BuildRuleExpression(List<Rol> assignedRoleList, List<User> excludeUserList)
        {
            StringBuilder wexpression = new StringBuilder();

            #region included roles
            if (assignedRoleList.Count != 0)
            {
                wexpression.Append("(");
                foreach (Rol rol in assignedRoleList)
                {
                    wexpression.Append("R:");
                    wexpression.Append(rol.RolName);
                    wexpression.AppendLine(" OR ");
                }
                wexpression.Remove(wexpression.Length - 5, 5);
                wexpression.Append(")");
            }
            #endregion

            #region Excluded users
            if (excludeUserList.Count != 0)
            {
                if (assignedRoleList.Count != 0)
                    wexpression.Append(" AND ");

                wexpression.Append("NOT (");
                foreach (User user in excludeUserList)
                {
                    wexpression.Append("I:");
                    wexpression.Append(user.UserName);
                    wexpression.AppendLine(" OR ");
                }
                wexpression.Remove(wexpression.Length - 5, 5);
                wexpression.Append(")");
            }
            #endregion

            return wexpression.ToString();
        }

     
        /// <summary>
        /// Retorba las lista de usuarios y roles desde la expresion de la regla
        /// </summary>
        /// <param name="wexpression"></param>
        /// <param name="assignedRoleList"></param>
        /// <param name="excludeUserList"></param>
        public static void BuildRolesAndUsers_FromRuleExpression(string wexpression, out RolList assignedRoleList, out UserList excludeUserList)
        {
            Rol wRol;
            User wUser;
            assignedRoleList = new RolList();
            excludeUserList = new UserList();

            StringBuilder exp = new StringBuilder(wexpression);

            exp.Replace("R:", string.Empty);
            exp.Replace("I:", string.Empty);
            exp.Replace("(", string.Empty);
            exp.Replace(")", string.Empty);
            exp.Replace("AND", string.Empty);
            String[] wArray = exp.ToString().Split(new string[] { "NOT" }, StringSplitOptions.RemoveEmptyEntries);

            if (wArray.Length > 0)
            {
                foreach (string str in wArray[0].Split(new string[] { "OR" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    wRol = new Rol(str.Trim());
                    assignedRoleList.Add(wRol);
                }
            }

            if (wArray.Length > 1)
            {
                foreach (string str in wArray[1].Split(new string[] { "OR" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    wUser = new User(str.Trim());
                    excludeUserList.Add(wUser);
                }
            }

        }

       


    }
}

