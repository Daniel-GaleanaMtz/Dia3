﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceReferenceLogin {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceLogin.IServiceLogin")]
    public interface IServiceLogin {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceLogin/isCorrect", ReplyAction="http://tempuri.org/IServiceLogin/isCorrectResponse")]
        bool isCorrect(string user, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceLogin/isCorrect", ReplyAction="http://tempuri.org/IServiceLogin/isCorrectResponse")]
        System.Threading.Tasks.Task<bool> isCorrectAsync(string user, string pass);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceLoginChannel : PL.ServiceReferenceLogin.IServiceLogin, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceLoginClient : System.ServiceModel.ClientBase<PL.ServiceReferenceLogin.IServiceLogin>, PL.ServiceReferenceLogin.IServiceLogin {
        
        public ServiceLoginClient() {
        }
        
        public ServiceLoginClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceLoginClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceLoginClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceLoginClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool isCorrect(string user, string pass) {
            return base.Channel.isCorrect(user, pass);
        }
        
        public System.Threading.Tasks.Task<bool> isCorrectAsync(string user, string pass) {
            return base.Channel.isCorrectAsync(user, pass);
        }
    }
}