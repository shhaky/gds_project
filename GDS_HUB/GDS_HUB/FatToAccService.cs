using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
namespace GDS_HUB
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FatToAccService : IFatC_to_AccM
    {
        public ServiceFromAccM.PortalClient H_A_proxy = new ServiceFromAccM.PortalClient();

        // list of all client who are online for being updated when something changes
        private List<Client> _listOnlineClient = new List<Client>();
        DataProvider db = new DataProvider();


        // this method is communicate with Account management for the login of the client
        public int logIn(string accountName, string password)
        {
            int _logInfo = 3; // 3 stands for server problem, by defalt we set _logInfo to 3.
            ICallbackToFatClient callback = OperationContext.Current.GetCallbackChannel<ICallbackToFatClient>();

            try
            {
                _logInfo = checkIfExistedUserNameHUB(accountName);
                if (_logInfo == 4) // checks if username exist first before we checks for password
                {
                    _logInfo = checkPasswordHUB(accountName, password);
                    if (_logInfo == 4)
                    {
                        Client client = new Client();
                        client.EmailAddress = accountName;
                        client.Callback = callback;
                        _listOnlineClient.Add(client);
                    }
                }
            }
            catch (Exception)
            {
                return 3; // sever connection problem
            }
            return _logInfo;
        }

        public bool logOut()
        {
            bool loggedOut = false;
            ICallbackToFatClient callback = OperationContext.Current.GetCallbackChannel
                                            <ICallbackToFatClient>();
            foreach (Client c in _listOnlineClient)
            {
                if (c.Callback == callback)
                {
                    _listOnlineClient.Remove(c);
                    loggedOut = true;
                    break;
                }
            }
            return loggedOut;
        }


        // this method is for registration
        public bool register( string userName, string passWord, string firstName, string lastName, string email, string joinDate)
        {
            int isTaken;
            bool check = false;

            isTaken = checkIfExistedUserNameHUB(userName);
            if (isTaken == 4)
            {
                try
                {
                    check = H_A_proxy.addNewUser(userName, passWord, firstName, lastName, email, joinDate);

                }
                catch (Exception)
                {
                    check = false;
                }
            }
            return check;
        }

        // this method is for transfert money to one client to another
        public bool sendTransaction(string userAccount, string account, int amount)
        {
            throw new NotImplementedException();
        }


        // ########################################################################
        // ###### HERE GOES ALL METHODS WHICH ARE NOT IN THE CONTRACT ##############

        // checking if that username is available
        public int checkIfExistedUserNameHUB(string userName)
        {
            int check;
            try
            {
                if (H_A_proxy.checkIfExistedUserName(userName))
                {
                    check = 4; // username exist
                }
                else
                {
                    check = 1; // username doesnt exist
                }

            }
            catch (Exception)
            {
                check = 3; // server connection error
            }
            return check;
        }

        // checking for the password
        public int checkPasswordHUB(string userName, string passWord)
        {
            int check;
            try
            {
                if (!H_A_proxy.checkPassword(userName, passWord))
                    check = 4; // password exist
                else
                    check = 2; // password doesnt exist

            }
            catch (Exception)
            {
                check = 3; // server connection error
            }
            return check;
        }


        
    }
}
