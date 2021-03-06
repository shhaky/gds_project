﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GDS_HUB.ServiceFromAccM {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceFromAccM.IDBHUB")]
    public interface IDBHUB {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/checkUserName", ReplyAction="http://tempuri.org/IDBHUB/checkUserNameResponse")]
        bool checkUserName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/checkUserName", ReplyAction="http://tempuri.org/IDBHUB/checkUserNameResponse")]
        System.Threading.Tasks.Task<bool> checkUserNameAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/registerAsUser", ReplyAction="http://tempuri.org/IDBHUB/registerAsUserResponse")]
        bool registerAsUser(string userName, string firstName, string lastName, string eMail, string passWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/registerAsUser", ReplyAction="http://tempuri.org/IDBHUB/registerAsUserResponse")]
        System.Threading.Tasks.Task<bool> registerAsUserAsync(string userName, string firstName, string lastName, string eMail, string passWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/login", ReplyAction="http://tempuri.org/IDBHUB/loginResponse")]
        bool login(string userName, string passWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/login", ReplyAction="http://tempuri.org/IDBHUB/loginResponse")]
        System.Threading.Tasks.Task<bool> loginAsync(string userName, string passWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/showUserID", ReplyAction="http://tempuri.org/IDBHUB/showUserIDResponse")]
        long showUserID(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/showUserID", ReplyAction="http://tempuri.org/IDBHUB/showUserIDResponse")]
        System.Threading.Tasks.Task<long> showUserIDAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/showUserName", ReplyAction="http://tempuri.org/IDBHUB/showUserNameResponse")]
        string showUserName(long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/showUserName", ReplyAction="http://tempuri.org/IDBHUB/showUserNameResponse")]
        System.Threading.Tasks.Task<string> showUserNameAsync(long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/showEmail", ReplyAction="http://tempuri.org/IDBHUB/showEmailResponse")]
        string showEmail(long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/showEmail", ReplyAction="http://tempuri.org/IDBHUB/showEmailResponse")]
        System.Threading.Tasks.Task<string> showEmailAsync(long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/updateLoginTime", ReplyAction="http://tempuri.org/IDBHUB/updateLoginTimeResponse")]
        void updateLoginTime(long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/updateLoginTime", ReplyAction="http://tempuri.org/IDBHUB/updateLoginTimeResponse")]
        System.Threading.Tasks.Task updateLoginTimeAsync(long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/changePass", ReplyAction="http://tempuri.org/IDBHUB/changePassResponse")]
        bool changePass(long userId, string oldPass, string newPass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/changePass", ReplyAction="http://tempuri.org/IDBHUB/changePassResponse")]
        System.Threading.Tasks.Task<bool> changePassAsync(long userId, string oldPass, string newPass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/showBalance", ReplyAction="http://tempuri.org/IDBHUB/showBalanceResponse")]
        decimal showBalance(long userId, string coinType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBHUB/showBalance", ReplyAction="http://tempuri.org/IDBHUB/showBalanceResponse")]
        System.Threading.Tasks.Task<decimal> showBalanceAsync(long userId, string coinType);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDBHUBChannel : GDS_HUB.ServiceFromAccM.IDBHUB, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DBHUBClient : System.ServiceModel.ClientBase<GDS_HUB.ServiceFromAccM.IDBHUB>, GDS_HUB.ServiceFromAccM.IDBHUB {
        
        public DBHUBClient() {
        }
        
        public DBHUBClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DBHUBClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DBHUBClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DBHUBClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool checkUserName(string userName) {
            return base.Channel.checkUserName(userName);
        }
        
        public System.Threading.Tasks.Task<bool> checkUserNameAsync(string userName) {
            return base.Channel.checkUserNameAsync(userName);
        }
        
        public bool registerAsUser(string userName, string firstName, string lastName, string eMail, string passWord) {
            return base.Channel.registerAsUser(userName, firstName, lastName, eMail, passWord);
        }
        
        public System.Threading.Tasks.Task<bool> registerAsUserAsync(string userName, string firstName, string lastName, string eMail, string passWord) {
            return base.Channel.registerAsUserAsync(userName, firstName, lastName, eMail, passWord);
        }
        
        public bool login(string userName, string passWord) {
            return base.Channel.login(userName, passWord);
        }
        
        public System.Threading.Tasks.Task<bool> loginAsync(string userName, string passWord) {
            return base.Channel.loginAsync(userName, passWord);
        }
        
        public long showUserID(string userName) {
            return base.Channel.showUserID(userName);
        }
        
        public System.Threading.Tasks.Task<long> showUserIDAsync(string userName) {
            return base.Channel.showUserIDAsync(userName);
        }
        
        public string showUserName(long userId) {
            return base.Channel.showUserName(userId);
        }
        
        public System.Threading.Tasks.Task<string> showUserNameAsync(long userId) {
            return base.Channel.showUserNameAsync(userId);
        }
        
        public string showEmail(long userId) {
            return base.Channel.showEmail(userId);
        }
        
        public System.Threading.Tasks.Task<string> showEmailAsync(long userId) {
            return base.Channel.showEmailAsync(userId);
        }
        
        public void updateLoginTime(long userId) {
            base.Channel.updateLoginTime(userId);
        }
        
        public System.Threading.Tasks.Task updateLoginTimeAsync(long userId) {
            return base.Channel.updateLoginTimeAsync(userId);
        }
        
        public bool changePass(long userId, string oldPass, string newPass) {
            return base.Channel.changePass(userId, oldPass, newPass);
        }
        
        public System.Threading.Tasks.Task<bool> changePassAsync(long userId, string oldPass, string newPass) {
            return base.Channel.changePassAsync(userId, oldPass, newPass);
        }
        
        public decimal showBalance(long userId, string coinType) {
            return base.Channel.showBalance(userId, coinType);
        }
        
        public System.Threading.Tasks.Task<decimal> showBalanceAsync(long userId, string coinType) {
            return base.Channel.showBalanceAsync(userId, coinType);
        }
    }
}
