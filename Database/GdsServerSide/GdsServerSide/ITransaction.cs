using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GdsServerSide
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    //[ServiceContract(SessionMode = SessionMode.Required)]
    [ServiceContract]
    public interface ITransaction
    {
        [OperationContract]
        bool addNewTransaction(long userId, string transTime, string transType, string coinType, decimal amount, long add);

        [OperationContract]
        List<string> getTransInfo(long userId);
    }
}
