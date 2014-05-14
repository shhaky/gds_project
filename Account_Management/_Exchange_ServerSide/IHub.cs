using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _Exchange_ServerSide
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IHub
    {
        [OperationContract]
        long getLastestId();

        [OperationContract]
        bool checkIfExistedUserName(string userName);

        [OperationContract]
        bool addNewUser(long userId, string userName, string passWord, string firstName, string lastName, string email, string joinDate);

        [OperationContract]
        bool checkPassword(string userName, string passWord);
    
    }

    //================================================================================================
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
