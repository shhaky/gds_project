using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace GDS_HUB
{
    [ServiceContract(Namespace = "GDS_HUB", CallbackContract = typeof(ICallbackToFatTrade))]
    public interface ItradingService
    {
        [OperationContract(IsOneWay = true)]
        void buy(string accountName, string password);

        [OperationContract]
        bool sell(string account);

    }

    public interface ICallbackToFatTrade
    {
        [OperationContract(IsOneWay = true)]
        void confirmation();

    }
}
