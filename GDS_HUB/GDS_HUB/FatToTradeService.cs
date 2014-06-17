using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;


namespace GDS_HUB
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AddressFilterMode= AddressFilterMode.Any)]
    class FatToTradeService : ItradingService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        public void buy(string accountName, string password)
        {
            throw new NotImplementedException();
        }

        public bool sell(string account)
        {
            throw new NotImplementedException();
        }
    }
}
