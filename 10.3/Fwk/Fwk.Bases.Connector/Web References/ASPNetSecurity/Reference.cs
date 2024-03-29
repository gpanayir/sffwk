﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18052.
// 
#pragma warning disable 1591

namespace Fwk.Bases.Connector.ASPNetSecurity {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ASPNetSoap", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BaseEntity))]
    public partial class ASPNet : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ExecuteServiceOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetServiceConfigurationOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetServicesListOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetProviderInfoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ASPNet() {
            this.Url = global::Fwk.Bases.Connector.Properties.Settings.Default.Fwk_Bases_Connector_ASPNetSecurity_ASPNet;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ExecuteServiceCompletedEventHandler ExecuteServiceCompleted;
        
        /// <remarks/>
        public event GetServiceConfigurationCompletedEventHandler GetServiceConfigurationCompleted;
        
        /// <remarks/>
        public event GetServicesListCompletedEventHandler GetServicesListCompleted;
        
        /// <remarks/>
        public event GetProviderInfoCompletedEventHandler GetProviderInfoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ExecuteService", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ExecuteService(string providerName, string pServiceName, string pData) {
            object[] results = this.Invoke("ExecuteService", new object[] {
                        providerName,
                        pServiceName,
                        pData});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ExecuteServiceAsync(string providerName, string pServiceName, string pData) {
            this.ExecuteServiceAsync(providerName, pServiceName, pData, null);
        }
        
        /// <remarks/>
        public void ExecuteServiceAsync(string providerName, string pServiceName, string pData, object userState) {
            if ((this.ExecuteServiceOperationCompleted == null)) {
                this.ExecuteServiceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteServiceOperationCompleted);
            }
            this.InvokeAsync("ExecuteService", new object[] {
                        providerName,
                        pServiceName,
                        pData}, this.ExecuteServiceOperationCompleted, userState);
        }
        
        private void OnExecuteServiceOperationCompleted(object arg) {
            if ((this.ExecuteServiceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteServiceCompleted(this, new ExecuteServiceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetServiceConfiguration", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetServiceConfiguration(string providerName, string serviceName) {
            object[] results = this.Invoke("GetServiceConfiguration", new object[] {
                        providerName,
                        serviceName});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetServiceConfigurationAsync(string providerName, string serviceName) {
            this.GetServiceConfigurationAsync(providerName, serviceName, null);
        }
        
        /// <remarks/>
        public void GetServiceConfigurationAsync(string providerName, string serviceName, object userState) {
            if ((this.GetServiceConfigurationOperationCompleted == null)) {
                this.GetServiceConfigurationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetServiceConfigurationOperationCompleted);
            }
            this.InvokeAsync("GetServiceConfiguration", new object[] {
                        providerName,
                        serviceName}, this.GetServiceConfigurationOperationCompleted, userState);
        }
        
        private void OnGetServiceConfigurationOperationCompleted(object arg) {
            if ((this.GetServiceConfigurationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetServiceConfigurationCompleted(this, new GetServiceConfigurationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetServicesList", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetServicesList(string providerName, bool ViewAsXml) {
            object[] results = this.Invoke("GetServicesList", new object[] {
                        providerName,
                        ViewAsXml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetServicesListAsync(string providerName, bool ViewAsXml) {
            this.GetServicesListAsync(providerName, ViewAsXml, null);
        }
        
        /// <remarks/>
        public void GetServicesListAsync(string providerName, bool ViewAsXml, object userState) {
            if ((this.GetServicesListOperationCompleted == null)) {
                this.GetServicesListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetServicesListOperationCompleted);
            }
            this.InvokeAsync("GetServicesList", new object[] {
                        providerName,
                        ViewAsXml}, this.GetServicesListOperationCompleted, userState);
        }
        
        private void OnGetServicesListOperationCompleted(object arg) {
            if ((this.GetServicesListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetServicesListCompleted(this, new GetServicesListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetProviderInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MetadataProvider GetProviderInfo(string providerName) {
            object[] results = this.Invoke("GetProviderInfo", new object[] {
                        providerName});
            return ((MetadataProvider)(results[0]));
        }
        
        /// <remarks/>
        public void GetProviderInfoAsync(string providerName) {
            this.GetProviderInfoAsync(providerName, null);
        }
        
        /// <remarks/>
        public void GetProviderInfoAsync(string providerName, object userState) {
            if ((this.GetProviderInfoOperationCompleted == null)) {
                this.GetProviderInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetProviderInfoOperationCompleted);
            }
            this.InvokeAsync("GetProviderInfo", new object[] {
                        providerName}, this.GetProviderInfoOperationCompleted, userState);
        }
        
        private void OnGetProviderInfoOperationCompleted(object arg) {
            if ((this.GetProviderInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetProviderInfoCompleted(this, new GetProviderInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18060")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MetadataProvider : BaseEntity {
        
        private string applicationIdField;
        
        private string nameField;
        
        private string configProviderTypeField;
        
        private string securityProviderNameField;
        
        private string sourceInfoField;
        
        /// <remarks/>
        public string ApplicationId {
            get {
                return this.applicationIdField;
            }
            set {
                this.applicationIdField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string ConfigProviderType {
            get {
                return this.configProviderTypeField;
            }
            set {
                this.configProviderTypeField = value;
            }
        }
        
        /// <remarks/>
        public string SecurityProviderName {
            get {
                return this.securityProviderNameField;
            }
            set {
                this.securityProviderNameField = value;
            }
        }
        
        /// <remarks/>
        public string SourceInfo {
            get {
                return this.sourceInfoField;
            }
            set {
                this.sourceInfoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MetadataProvider))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18060")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class BaseEntity {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ExecuteServiceCompletedEventHandler(object sender, ExecuteServiceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteServiceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExecuteServiceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetServiceConfigurationCompletedEventHandler(object sender, GetServiceConfigurationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetServiceConfigurationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetServiceConfigurationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetServicesListCompletedEventHandler(object sender, GetServicesListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetServicesListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetServicesListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetProviderInfoCompletedEventHandler(object sender, GetProviderInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetProviderInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetProviderInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public MetadataProvider Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MetadataProvider)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591