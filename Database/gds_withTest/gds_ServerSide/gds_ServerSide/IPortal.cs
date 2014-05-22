using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace gds_ServerSide
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IPortal
    {
        //==================register=======================
        [OperationContract]
        bool checkIsExistedUserName(string userName);

        [OperationContract]
        bool addNewUser(string userName, string passWord, string firstName, string lastName, string email, string joinDate,string lastLoginTime);
    }
}

