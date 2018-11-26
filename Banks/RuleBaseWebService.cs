﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="RuleBaseWebServiceSoap", Namespace="http://tempuri.org/")]
public partial class RuleBaseWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback makeLoanOperationCompleted;
    
    /// <remarks/>
    public RuleBaseWebService() {
        this.Url = "http://localhost:3239/RuleBaseWebService.asmx";
    }
    
    /// <remarks/>
    public event makeLoanCompletedEventHandler makeLoanCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/makeLoan", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public Bank[] makeLoan(int creditScore, double loanAmount) {
        object[] results = this.Invoke("makeLoan", new object[] {
                    creditScore,
                    loanAmount});
        return ((Bank[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginmakeLoan(int creditScore, double loanAmount, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("makeLoan", new object[] {
                    creditScore,
                    loanAmount}, callback, asyncState);
    }
    
    /// <remarks/>
    public Bank[] EndmakeLoan(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((Bank[])(results[0]));
    }
    
    /// <remarks/>
    public void makeLoanAsync(int creditScore, double loanAmount) {
        this.makeLoanAsync(creditScore, loanAmount, null);
    }
    
    /// <remarks/>
    public void makeLoanAsync(int creditScore, double loanAmount, object userState) {
        if ((this.makeLoanOperationCompleted == null)) {
            this.makeLoanOperationCompleted = new System.Threading.SendOrPostCallback(this.OnmakeLoanOperationCompleted);
        }
        this.InvokeAsync("makeLoan", new object[] {
                    creditScore,
                    loanAmount}, this.makeLoanOperationCompleted, userState);
    }
    
    private void OnmakeLoanOperationCompleted(object arg) {
        if ((this.makeLoanCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.makeLoanCompleted(this, new makeLoanCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
public partial class Bank {
    
    private string nameField;
    
    private string bankIdField;
    
    /// <remarks/>
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public string bankId {
        get {
            return this.bankIdField;
        }
        set {
            this.bankIdField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
public delegate void makeLoanCompletedEventHandler(object sender, makeLoanCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class makeLoanCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal makeLoanCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public Bank[] Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((Bank[])(this.results[0]));
        }
    }
}