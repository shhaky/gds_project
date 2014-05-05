using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GDS_HUB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class FatToAccService : IFatC_to_AccM 
    {
        // list of all client who are online for being updated when something changes
        private List<Client> _listOnlineClient;
        


        public void logIn(string accountName, string password)
        {
            ICallbackToFatClient callback = OperationContext.Current.GetCallbackChannel<ICallbackToFatClient>();
            
            callback.confirmation();
            
        }

        public bool logOut(string account)
        {
            throw new NotImplementedException();
        }

        public string registration(string name, string residence, string password)
        {
            throw new NotImplementedException();
        }

        public bool sendTransaction(string userAccount, string account, int amount)
        {
            throw new NotImplementedException();
        }
        // ###### here goes all methods which are not in the contract ##############

    }
}
