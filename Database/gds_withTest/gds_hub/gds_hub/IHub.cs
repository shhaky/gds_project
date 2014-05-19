using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace gds_hub
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IHub
    {
        //======================register========================
        [OperationContract]
        bool checkIsExistedUserName(string userName);

        [OperationContract]
        bool addNewUser(string userName, string passWord, string firstName, string lastName, string email, string joinDate,string lastLoginTime);
    }

}

