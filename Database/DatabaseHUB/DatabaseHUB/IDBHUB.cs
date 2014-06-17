using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DatabaseHUB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDBHUB
    {
        //---register part---
        [OperationContract]
        bool checkUserName(string userName);
        [OperationContract]
        bool registerAsUser(string userName, string firstName, string lastName, string eMail, string passWord);

        //---login part---
        [OperationContract]
        bool login(string userName, string passWord);

        //---account management---
        [OperationContract]
        long showUserID(string userName);

        [OperationContract]
        string showUserName(long userId);

        [OperationContract]
        string showEmail(long userId);

        [OperationContract]
        void updateLoginTime(long userId);

        [OperationContract]
        bool changePass(long userId, string oldPass, string newPass);

        [OperationContract]
        decimal showBalance(long userId, string coinType);

        //---transaction part---

        //---trade part---
        
    }

}
