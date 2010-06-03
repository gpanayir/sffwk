﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fwk.Security.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fwk.Security.Properties.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are some problems while trying to get domains urls from database. Check the following connectionstring key &quot;{0}&quot;  in the appconfig file.-.
        /// </summary>
        public static string AD_GetingDomainsURL_Error {
            get {
                return ResourceManager.GetString("AD_GetingDomainsURL_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Impersonalization error.- The security Active directory throw  the following error : {0}.
        /// </summary>
        public static string AD_Impersonation_Error {
            get {
                return ResourceManager.GetString("AD_Impersonation_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Domain {0} not exist .
        /// </summary>
        public static string AD_NotExistDomainsURL {
            get {
                return ResourceManager.GetString("AD_NotExistDomainsURL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Authenticate user.
        /// </summary>
        public static string AuthenticateTitleMessage {
            get {
                return ResourceManager.GetString("AuthenticateTitleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Authorization rule {0} not found in configuration..
        /// </summary>
        public static string AuthorizationRuleNotFoundMsg {
            get {
                return ResourceManager.GetString("AuthorizationRuleNotFoundMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Checking roles for &quot;{0}&quot;.
        /// </summary>
        public static string CheckingRolesMessage {
            get {
                return ResourceManager.GetString("CheckingRolesMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The identity was added to the cache and can be retrieved using the token {0}.
        /// </summary>
        public static string CreateTokenMessage {
            get {
                return ResourceManager.GetString("CreateTokenMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot create a token for non-authenticated user. This scenario requires running the &quot;Authenticate user using credentials&quot; scenario first.
        /// </summary>
        public static string CreateTokenRequiresIdentityMessage {
            get {
                return ResourceManager.GetString("CreateTokenRequiresIdentityMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to retrieve the identity. The supplied token is expired..
        /// </summary>
        public static string ExpiredTokenErrorMessage {
            get {
                return ResourceManager.GetString("ExpiredTokenErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot expire token because it couldn&apos;t be created..
        /// </summary>
        public static string ExpireTokenErrorMessage {
            get {
                return ResourceManager.GetString("ExpireTokenErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Token was expired..
        /// </summary>
        public static string ExpireTokenMessage {
            get {
                return ResourceManager.GetString("ExpireTokenMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Identity: {0}.
        /// </summary>
        public static string IdentityMessage {
            get {
                return ResourceManager.GetString("IdentityMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are some problems while trying to use the Fwk Security Block t, please check the following error messages: 
        ///
        ///{0}
        ///
        ///This block requires a database configured with the ASP.NET services schema. Please make sure the database has been initialized using the aspnet_regsql.exe script, and the system&apos;s app.config file contains the correct database connection string..
        /// </summary>
        public static string MembershipSecurityGenericError {
            get {
                return ResourceManager.GetString("MembershipSecurityGenericError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find a profile for current user. You can create a profile by using the &quot;Write profile information about a user&quot; button..
        /// </summary>
        public static string ProfileNotFoundMessage {
            get {
                return ResourceManager.GetString("ProfileNotFoundMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to First Name: {0}
        ///  Last Name: {1}
        ///  Preferred Theme: {2}.
        /// </summary>
        public static string ProfileStringMessage {
            get {
                return ResourceManager.GetString("ProfileStringMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The profile has been saved for &quot;{0}&quot;
        ///.
        /// </summary>
        public static string ProfileUpdatedMessage {
            get {
                return ResourceManager.GetString("ProfileUpdatedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The security provider {0} not found.
        /// </summary>
        public static string ProviderNameNotFound {
            get {
                return ResourceManager.GetString("ProviderNameNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot retrieve identity because the token doesn&apos;t exist..
        /// </summary>
        public static string RetrieveIdentityErrorMessage {
            get {
                return ResourceManager.GetString("RetrieveIdentityErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The identity with the following information was retrieved using the token
        ///	Name: {0}
        ///	Authorization Type: {1}.
        /// </summary>
        public static string RetrieveIdentityMessage {
            get {
                return ResourceManager.GetString("RetrieveIdentityMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Role {0} created..
        /// </summary>
        public static string RolCreatedMessage {
            get {
                return ResourceManager.GetString("RolCreatedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} not contain rules.-.
        /// </summary>
        public static string Role_WithoutRules {
            get {
                return ResourceManager.GetString("Role_WithoutRules", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Role {0} already exists..
        /// </summary>
        public static string RoleExist {
            get {
                return ResourceManager.GetString("RoleExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Role {0} is not empty, have users associates..
        /// </summary>
        public static string RoleNotEmpty {
            get {
                return ResourceManager.GetString("RoleNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are some problems while trying to create rule.
        /// </summary>
        public static string Rule_Crate_Error {
            get {
                return ResourceManager.GetString("Rule_Crate_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are some problems while trying to get all rule information, please check the application name  &quot;{0}&quot; ..
        /// </summary>
        public static string Rule_ProblemGetingAlls_Error {
            get {
                return ResourceManager.GetString("Rule_ProblemGetingAlls_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are some problems while trying to get rule information, please check the following rule name: {0}.
        /// </summary>
        public static string Rule_ProblemGetingData_Error {
            get {
                return ResourceManager.GetString("Rule_ProblemGetingData_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The rule {0} created.-.
        /// </summary>
        public static string RuleCreatedMessage {
            get {
                return ResourceManager.GetString("RuleCreatedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The rule provider fot provider named {0} not exist in config file.-  Check the following rule provider named  &quot;{0}&quot;  in the appconfig file.-.
        /// </summary>
        public static string RuleProvider_NotExist {
            get {
                return ResourceManager.GetString("RuleProvider_NotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rule: {0}
        ///Result: user is not authorized.
        /// </summary>
        public static string RuleResultFalseMessage {
            get {
                return ResourceManager.GetString("RuleResultFalseMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rule: {0}
        ///Result: user is authorized.
        /// </summary>
        public static string RuleResultTrueMessage {
            get {
                return ResourceManager.GetString("RuleResultTrueMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select a user name and select or enter a role..
        /// </summary>
        public static string User_AddRoleErrorMessage {
            get {
                return ResourceManager.GetString("User_AddRoleErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Role {1} added for user {0}..
        /// </summary>
        public static string User_AddRoleMessage {
            get {
                return ResourceManager.GetString("User_AddRoleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are some problems while trying to create user {0}.  Status: {1}.
        /// </summary>
        public static string User_Created_Error_Message {
            get {
                return ResourceManager.GetString("User_Created_Error_Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User {0} created..
        /// </summary>
        public static string User_CreatedMessage {
            get {
                return ResourceManager.GetString("User_CreatedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new user.
        /// </summary>
        public static string User_CreateTitleMessage {
            get {
                return ResourceManager.GetString("User_CreateTitleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select a user name..
        /// </summary>
        public static string User_DeleteErrorMessage {
            get {
                return ResourceManager.GetString("User_DeleteErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User {0} deleted..
        /// </summary>
        public static string User_DeleteMessage {
            get {
                return ResourceManager.GetString("User_DeleteMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select a user name and a role..
        /// </summary>
        public static string User_DeleteRoleErrorMessage {
            get {
                return ResourceManager.GetString("User_DeleteRoleErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Role {1} deleted for user {0}..
        /// </summary>
        public static string User_DeleteRoleMessage {
            get {
                return ResourceManager.GetString("User_DeleteRoleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User {0} already exists..
        /// </summary>
        public static string User_Existe {
            get {
                return ResourceManager.GetString("User_Existe", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter a user name and select a role and a rule..
        /// </summary>
        public static string User_IdentityRoleErrorMessage {
            get {
                return ResourceManager.GetString("User_IdentityRoleErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username: {0}
        ///Role: {1}.
        /// </summary>
        public static string User_IdentityRoleMessage {
            get {
                return ResourceManager.GetString("User_IdentityRoleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to authenticate user {0}. Either the username does not exist in database or the provided password is not correct. Or user is not aproved.-.
        /// </summary>
        public static string User_InvalidCredentialsMessage {
            get {
                return ResourceManager.GetString("User_InvalidCredentialsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User {0} already exists..
        /// </summary>
        public static string User_NoApproved {
            get {
                return ResourceManager.GetString("User_NoApproved", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user {0} not exist.
        /// </summary>
        public static string User_NotExist {
            get {
                return ResourceManager.GetString("User_NotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You should authenticate a user first..
        /// </summary>
        public static string User_NullIdentityMessage {
            get {
                return ResourceManager.GetString("User_NullIdentityMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The following profile has been read for &quot;{0}&quot;
        ///  {1}
        ///.
        /// </summary>
        public static string User_ProfileMessage {
            get {
                return ResourceManager.GetString("User_ProfileMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  Member of role {0}: {1}.
        /// </summary>
        public static string User_RoleMessage {
            get {
                return ResourceManager.GetString("User_RoleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully authenticated user {0}.
        /// </summary>
        public static string ValidCredentialsMessage {
            get {
                return ResourceManager.GetString("ValidCredentialsMessage", resourceCulture);
            }
        }
    }
}
