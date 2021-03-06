﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GdsClientSide.ServiceReferenceHUB {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceHUB.IHub", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IHub {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/checkIfExistedUserName", ReplyAction="http://tempuri.org/IHub/checkIfExistedUserNameResponse")]
        bool checkIfExistedUserName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/checkIfExistedUserName", ReplyAction="http://tempuri.org/IHub/checkIfExistedUserNameResponse")]
        System.Threading.Tasks.Task<bool> checkIfExistedUserNameAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/addNewUser", ReplyAction="http://tempuri.org/IHub/addNewUserResponse")]
        bool addNewUser(string userName, string passWord, string firstName, string lastName, string email, string joinDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/addNewUser", ReplyAction="http://tempuri.org/IHub/addNewUserResponse")]
        System.Threading.Tasks.Task<bool> addNewUserAsync(string userName, string passWord, string firstName, string lastName, string email, string joinDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/checkPassword", ReplyAction="http://tempuri.org/IHub/checkPasswordResponse")]
        bool checkPassword(string userName, string passWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/checkPassword", ReplyAction="http://tempuri.org/IHub/checkPasswordResponse")]
        System.Threading.Tasks.Task<bool> checkPasswordAsync(string userName, string passWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getUserId", ReplyAction="http://tempuri.org/IHub/getUserIdResponse")]
        long getUserId(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getUserId", ReplyAction="http://tempuri.org/IHub/getUserIdResponse")]
        System.Threading.Tasks.Task<long> getUserIdAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getPassWord", ReplyAction="http://tempuri.org/IHub/getPassWordResponse")]
        string getPassWord(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getPassWord", ReplyAction="http://tempuri.org/IHub/getPassWordResponse")]
        System.Threading.Tasks.Task<string> getPassWordAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getFirstName", ReplyAction="http://tempuri.org/IHub/getFirstNameResponse")]
        string getFirstName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getFirstName", ReplyAction="http://tempuri.org/IHub/getFirstNameResponse")]
        System.Threading.Tasks.Task<string> getFirstNameAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getLastName", ReplyAction="http://tempuri.org/IHub/getLastNameResponse")]
        string getLastName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getLastName", ReplyAction="http://tempuri.org/IHub/getLastNameResponse")]
        System.Threading.Tasks.Task<string> getLastNameAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getEmail", ReplyAction="http://tempuri.org/IHub/getEmailResponse")]
        string getEmail(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getEmail", ReplyAction="http://tempuri.org/IHub/getEmailResponse")]
        System.Threading.Tasks.Task<string> getEmailAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getJoinDate", ReplyAction="http://tempuri.org/IHub/getJoinDateResponse")]
        string getJoinDate(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getJoinDate", ReplyAction="http://tempuri.org/IHub/getJoinDateResponse")]
        System.Threading.Tasks.Task<string> getJoinDateAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/changePassword", ReplyAction="http://tempuri.org/IHub/changePasswordResponse")]
        bool changePassword(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/changePassword", ReplyAction="http://tempuri.org/IHub/changePasswordResponse")]
        System.Threading.Tasks.Task<bool> changePasswordAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/addNewTransaction", ReplyAction="http://tempuri.org/IHub/addNewTransactionResponse")]
        bool addNewTransaction(long userId, string transTime, string transType, string coinType, decimal amount, string add);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/addNewTransaction", ReplyAction="http://tempuri.org/IHub/addNewTransactionResponse")]
        System.Threading.Tasks.Task<bool> addNewTransactionAsync(long userId, string transTime, string transType, string coinType, decimal amount, string add);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getTransInfo", ReplyAction="http://tempuri.org/IHub/getTransInfoResponse")]
        string[] getTransInfo(long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHub/getTransInfo", ReplyAction="http://tempuri.org/IHub/getTransInfoResponse")]
        System.Threading.Tasks.Task<string[]> getTransInfoAsync(long userId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHubChannel : GdsClientSide.ServiceReferenceHUB.IHub, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HubClient : System.ServiceModel.ClientBase<GdsClientSide.ServiceReferenceHUB.IHub>, GdsClientSide.ServiceReferenceHUB.IHub {
        
        public HubClient() {
        }
        
        public HubClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HubClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HubClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HubClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool checkIfExistedUserName(string userName) {
            return base.Channel.checkIfExistedUserName(userName);
        }
        
        public System.Threading.Tasks.Task<bool> checkIfExistedUserNameAsync(string userName) {
            return base.Channel.checkIfExistedUserNameAsync(userName);
        }
        
        public bool addNewUser(string userName, string passWord, string firstName, string lastName, string email, string joinDate) {
            return base.Channel.addNewUser(userName, passWord, firstName, lastName, email, joinDate);
        }
        
        public System.Threading.Tasks.Task<bool> addNewUserAsync(string userName, string passWord, string firstName, string lastName, string email, string joinDate) {
            return base.Channel.addNewUserAsync(userName, passWord, firstName, lastName, email, joinDate);
        }
        
        public bool checkPassword(string userName, string passWord) {
            return base.Channel.checkPassword(userName, passWord);
        }
        
        public System.Threading.Tasks.Task<bool> checkPasswordAsync(string userName, string passWord) {
            return base.Channel.checkPasswordAsync(userName, passWord);
        }
        
        public long getUserId(string userName) {
            return base.Channel.getUserId(userName);
        }
        
        public System.Threading.Tasks.Task<long> getUserIdAsync(string userName) {
            return base.Channel.getUserIdAsync(userName);
        }
        
        public string getPassWord(string userName) {
            return base.Channel.getPassWord(userName);
        }
        
        public System.Threading.Tasks.Task<string> getPassWordAsync(string userName) {
            return base.Channel.getPassWordAsync(userName);
        }
        
        public string getFirstName(string userName) {
            return base.Channel.getFirstName(userName);
        }
        
        public System.Threading.Tasks.Task<string> getFirstNameAsync(string userName) {
            return base.Channel.getFirstNameAsync(userName);
        }
        
        public string getLastName(string userName) {
            return base.Channel.getLastName(userName);
        }
        
        public System.Threading.Tasks.Task<string> getLastNameAsync(string userName) {
            return base.Channel.getLastNameAsync(userName);
        }
        
        public string getEmail(string userName) {
            return base.Channel.getEmail(userName);
        }
        
        public System.Threading.Tasks.Task<string> getEmailAsync(string userName) {
            return base.Channel.getEmailAsync(userName);
        }
        
        public string getJoinDate(string userName) {
            return base.Channel.getJoinDate(userName);
        }
        
        public System.Threading.Tasks.Task<string> getJoinDateAsync(string userName) {
            return base.Channel.getJoinDateAsync(userName);
        }
        
        public bool changePassword(string userName, string password) {
            return base.Channel.changePassword(userName, password);
        }
        
        public System.Threading.Tasks.Task<bool> changePasswordAsync(string userName, string password) {
            return base.Channel.changePasswordAsync(userName, password);
        }
        
        public bool addNewTransaction(long userId, string transTime, string transType, string coinType, decimal amount, string add) {
            return base.Channel.addNewTransaction(userId, transTime, transType, coinType, amount, add);
        }
        
        public System.Threading.Tasks.Task<bool> addNewTransactionAsync(long userId, string transTime, string transType, string coinType, decimal amount, string add) {
            return base.Channel.addNewTransactionAsync(userId, transTime, transType, coinType, amount, add);
        }
        
        public string[] getTransInfo(long userId) {
            return base.Channel.getTransInfo(userId);
        }
        
        public System.Threading.Tasks.Task<string[]> getTransInfoAsync(long userId) {
            return base.Channel.getTransInfoAsync(userId);
        }
    }
}
