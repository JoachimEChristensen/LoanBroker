﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Banks.RuleBase {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Bank", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Bank : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RuleBase.RuleBaseWebServiceSoap")]
    public interface RuleBaseWebServiceSoap {
        
        // CODEGEN: Generating message contract since element name bankResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/bank", ReplyAction="*")]
        Banks.RuleBase.bankResponse bank(Banks.RuleBase.bankRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/bank", ReplyAction="*")]
        System.Threading.Tasks.Task<Banks.RuleBase.bankResponse> bankAsync(Banks.RuleBase.bankRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class bankRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="bank", Namespace="http://tempuri.org/", Order=0)]
        public Banks.RuleBase.bankRequestBody Body;
        
        public bankRequest() {
        }
        
        public bankRequest(Banks.RuleBase.bankRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class bankRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int creditScore;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public double loanAmount;
        
        public bankRequestBody() {
        }
        
        public bankRequestBody(int creditScore, double loanAmount) {
            this.creditScore = creditScore;
            this.loanAmount = loanAmount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class bankResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="bankResponse", Namespace="http://tempuri.org/", Order=0)]
        public Banks.RuleBase.bankResponseBody Body;
        
        public bankResponse() {
        }
        
        public bankResponse(Banks.RuleBase.bankResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class bankResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Banks.RuleBase.Bank[] bankResult;
        
        public bankResponseBody() {
        }
        
        public bankResponseBody(Banks.RuleBase.Bank[] bankResult) {
            this.bankResult = bankResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface RuleBaseWebServiceSoapChannel : Banks.RuleBase.RuleBaseWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RuleBaseWebServiceSoapClient : System.ServiceModel.ClientBase<Banks.RuleBase.RuleBaseWebServiceSoap>, Banks.RuleBase.RuleBaseWebServiceSoap {
        
        public RuleBaseWebServiceSoapClient() {
        }
        
        public RuleBaseWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RuleBaseWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RuleBaseWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RuleBaseWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Banks.RuleBase.bankResponse Banks.RuleBase.RuleBaseWebServiceSoap.bank(Banks.RuleBase.bankRequest request) {
            return base.Channel.bank(request);
        }
        
        public Banks.RuleBase.Bank[] bank(int creditScore, double loanAmount) {
            Banks.RuleBase.bankRequest inValue = new Banks.RuleBase.bankRequest();
            inValue.Body = new Banks.RuleBase.bankRequestBody();
            inValue.Body.creditScore = creditScore;
            inValue.Body.loanAmount = loanAmount;
            Banks.RuleBase.bankResponse retVal = ((Banks.RuleBase.RuleBaseWebServiceSoap)(this)).bank(inValue);
            return retVal.Body.bankResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Banks.RuleBase.bankResponse> Banks.RuleBase.RuleBaseWebServiceSoap.bankAsync(Banks.RuleBase.bankRequest request) {
            return base.Channel.bankAsync(request);
        }
        
        public System.Threading.Tasks.Task<Banks.RuleBase.bankResponse> bankAsync(int creditScore, double loanAmount) {
            Banks.RuleBase.bankRequest inValue = new Banks.RuleBase.bankRequest();
            inValue.Body = new Banks.RuleBase.bankRequestBody();
            inValue.Body.creditScore = creditScore;
            inValue.Body.loanAmount = loanAmount;
            return ((Banks.RuleBase.RuleBaseWebServiceSoap)(this)).bankAsync(inValue);
        }
    }
}
