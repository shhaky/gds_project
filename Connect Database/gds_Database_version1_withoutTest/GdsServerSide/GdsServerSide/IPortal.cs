using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GdsServerSide
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IPortal
    {
        //[OperationContract]
        //void test();
        //==================register=======================
        [OperationContract]
        bool checkIfExistedUserName(string userName);

        [OperationContract]
        bool addNewUser(string userName, string passWord, string firstName, string lastName, string email, string joinDate);

        //===============login=============================
        [OperationContract]
        bool checkPassword(string userName, string passWord);

        [OperationContract]
        bool checkIfHasBalance(string userName);

        //================personal page===================
        [OperationContract]
        long getUserId(string userName);

        [OperationContract]
        string getPassWord(string userName);

        [OperationContract]
        string getFirstName(string userName);

        [OperationContract]
        string getLastName(string userName);

        [OperationContract]
        string getEmail(string userName);

        [OperationContract]
        string getJoinDate(string userName);

        [OperationContract]
        bool changePassword(string userName, string password);

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "GdsServerSide.ContractType".
    [Serializable]
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public long UserId
        {
            get;
            set;
        }

        [DataMember]
        public string UserName
        {
            get;
            set;
        }

        [DataMember]
        public string Password
        {
            get;
            set;
        }

        [DataMember]
        public string FirstName
        {
            get;
            set;
        }

        [DataMember]
        public string LastName
        {
            get;
            set;
        }

        [DataMember]
        public string Email
        {
            get;
            set;
        }

        [DataMember]
        public string JoinDate
        {
            get;
            set;
        }
    }
}
