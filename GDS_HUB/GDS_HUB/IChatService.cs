using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace GDS_HUB
{
     [ServiceContract(Namespace = "GDS_HUB", CallbackContract = typeof(ICallbackToFatChat))]
    interface IChatService
    {
         [OperationContract]
         bool sendMessage(string accNameSender, string msg);
    }
     public interface ICallbackToFatChat
     {
         [OperationContract(IsOneWay = true)]
         void receivedMessage(string msg);

     }
}
