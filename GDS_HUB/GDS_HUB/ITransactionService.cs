using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace GDS_HUB
{
    [ServiceContract(Namespace = "GDS_HUB", CallbackContract = typeof(ICallbackToFatTrans))]
    interface ITransactionService
    {
        [OperationContract(IsOneWay = true)]
        void transfer(string accNameSender,string accNameReceiver, double amount );

    }
    public interface ICallbackToFatTrans
    {
        [OperationContract(IsOneWay = true)]
        void confirmation();

    }
}
