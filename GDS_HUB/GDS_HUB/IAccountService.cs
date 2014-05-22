using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GDS_HUB
{
    [ServiceContract(Namespace = "GDS_HUB", CallbackContract = typeof(ICallbackToFatClient))]
    public interface IFatC_to_AccM
    {
        [OperationContract]
        int logIn(string accountName, string password);

        [OperationContract]
        bool logOut();

        [OperationContract]
        bool register(string userName, string passWord,string firstName,
                           string lastName, string email, string joinDate);
      
        [OperationContract]
        bool sendTransaction(string userAccount, string account, int amount);
    }

  // Client class which represent the GDS client 
    [DataContract]
    public class Client
    {
        private string _name;
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private string _password;
        private double _balance;
        private ICallbackToFatClient callBack;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public ICallbackToFatClient Callback
        {
            get { return callBack; }
            set {callBack = value; }
        }

    }

   // callback to fat client from the Account service
    public interface ICallbackToFatClient
    {
        [OperationContract(IsOneWay = true)]
        void confirmation();

        [OperationContract(IsOneWay = true)]
        void serverInfo(string info);

    }
}
