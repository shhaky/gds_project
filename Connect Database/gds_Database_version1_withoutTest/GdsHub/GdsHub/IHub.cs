using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GdsHub
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IHub
    {
        //======================register========================
        [OperationContract]
        bool checkIfExistedUserName(string userName);

        [OperationContract]
        bool addNewUser(string userName, string passWord, string firstName, string lastName, string email, string joinDate);
       
        //=====================login===========================
        [OperationContract]
        bool checkPassword(string userName, string passWord); 

        //=============personal page=========================
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
        bool changePassword(string userName,string password);

        [OperationContract]
        bool addNewTransaction(long userId, string transTime, string transType, string coinType, decimal amount, string add);

        [OperationContract]
        List<string> getTransInfo(long userId);

        [OperationContract]
        decimal getBalance(long userId, string coinType);
    }

    
}
