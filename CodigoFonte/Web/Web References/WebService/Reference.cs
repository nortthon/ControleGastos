﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.239.
// 
#pragma warning disable 1591

namespace Web.WebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class WebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CadastrarUsuarioOperationCompleted;
        
        private System.Threading.SendOrPostCallback EfetuarLoginOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebService() {
            this.Url = global::Web.Properties.Settings.Default.Web_WebService_WebService;
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
        public event CadastrarUsuarioCompletedEventHandler CadastrarUsuarioCompleted;
        
        /// <remarks/>
        public event EfetuarLoginCompletedEventHandler EfetuarLoginCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CadastrarUsuario", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CadastrarUsuario(string nome, string email, string login, string senha) {
            object[] results = this.Invoke("CadastrarUsuario", new object[] {
                        nome,
                        email,
                        login,
                        senha});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void CadastrarUsuarioAsync(string nome, string email, string login, string senha) {
            this.CadastrarUsuarioAsync(nome, email, login, senha, null);
        }
        
        /// <remarks/>
        public void CadastrarUsuarioAsync(string nome, string email, string login, string senha, object userState) {
            if ((this.CadastrarUsuarioOperationCompleted == null)) {
                this.CadastrarUsuarioOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCadastrarUsuarioOperationCompleted);
            }
            this.InvokeAsync("CadastrarUsuario", new object[] {
                        nome,
                        email,
                        login,
                        senha}, this.CadastrarUsuarioOperationCompleted, userState);
        }
        
        private void OnCadastrarUsuarioOperationCompleted(object arg) {
            if ((this.CadastrarUsuarioCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CadastrarUsuarioCompleted(this, new CadastrarUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EfetuarLogin", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Usuario EfetuarLogin(string login, string senha) {
            object[] results = this.Invoke("EfetuarLogin", new object[] {
                        login,
                        senha});
            return ((Usuario)(results[0]));
        }
        
        /// <remarks/>
        public void EfetuarLoginAsync(string login, string senha) {
            this.EfetuarLoginAsync(login, senha, null);
        }
        
        /// <remarks/>
        public void EfetuarLoginAsync(string login, string senha, object userState) {
            if ((this.EfetuarLoginOperationCompleted == null)) {
                this.EfetuarLoginOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEfetuarLoginOperationCompleted);
            }
            this.InvokeAsync("EfetuarLogin", new object[] {
                        login,
                        senha}, this.EfetuarLoginOperationCompleted, userState);
        }
        
        private void OnEfetuarLoginOperationCompleted(object arg) {
            if ((this.EfetuarLoginCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EfetuarLoginCompleted(this, new EfetuarLoginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Usuario {
        
        private int usu_idField;
        
        private string usu_nomeField;
        
        private string usu_emailField;
        
        private string usu_loginField;
        
        private string usu_senhaField;
        
        private int usu_statusField;
        
        /// <remarks/>
        public int Usu_id {
            get {
                return this.usu_idField;
            }
            set {
                this.usu_idField = value;
            }
        }
        
        /// <remarks/>
        public string Usu_nome {
            get {
                return this.usu_nomeField;
            }
            set {
                this.usu_nomeField = value;
            }
        }
        
        /// <remarks/>
        public string Usu_email {
            get {
                return this.usu_emailField;
            }
            set {
                this.usu_emailField = value;
            }
        }
        
        /// <remarks/>
        public string Usu_login {
            get {
                return this.usu_loginField;
            }
            set {
                this.usu_loginField = value;
            }
        }
        
        /// <remarks/>
        public string Usu_senha {
            get {
                return this.usu_senhaField;
            }
            set {
                this.usu_senhaField = value;
            }
        }
        
        /// <remarks/>
        public int Usu_status {
            get {
                return this.usu_statusField;
            }
            set {
                this.usu_statusField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CadastrarUsuarioCompletedEventHandler(object sender, CadastrarUsuarioCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CadastrarUsuarioCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CadastrarUsuarioCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void EfetuarLoginCompletedEventHandler(object sender, EfetuarLoginCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EfetuarLoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EfetuarLoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Usuario Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Usuario)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591