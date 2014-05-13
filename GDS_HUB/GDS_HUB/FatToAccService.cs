using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GDS_HUB
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FatToAccService : IFatC_to_AccM 
    {
        public ServiceFromAccM.HubClient H_A_proxy = new ServiceFromAccM.HubClient();

        // list of all client who are online for being updated when something changes
        private List<Client> _listOnlineClient = new List<Client>();
        DataProvider db = new DataProvider();

       

        // this method is for registration
        public bool addNewUserHUB(long userId, string userName, string passWord,string firstName, string lastName, string email, string joinDate)
        {
            bool check = false;
            try
            {
                check = H_A_proxy.addNewUser(userId,userName,passWord,firstName,lastName,email,joinDate);

            }
            catch (NullReferenceException)
            {
                check = false;
            }
            return check;
        }

        // checking if that username is available
        public bool checkIfExistedUserNameHUB(string userName)
        {
            bool check = false;
            try
            {
                check = H_A_proxy.checkIfExistedUserName(userName);

            }
            catch (NullReferenceException)
            {
                check = false;
            }
            return check;
        }

        // checking for the password
        public bool checkPasswordHUB(string userName, string passWord)
        {
            bool check = false;
            try
            {
              check = H_A_proxy.checkPassword(userName, passWord);

            }catch(NullReferenceException)
            {
                check = false;
            }
            return check;
        }


        public void logIn(string accountName, string password)
        {
            string _logInfo;
            ICallbackToFatClient callback = OperationContext.Current.GetCallbackChannel<ICallbackToFatClient>();

            try
            {
                if (db.logIn(accountName, password))
                {

                    callback.confirmation();
                }
                else
                {
                    _logInfo = "Wrong Username or password!";
                    callback.serverInfo(_logInfo);
                }

            }
            catch (Exception )
            {
                _logInfo = "Server could not respond, Please try again later!";
                callback.serverInfo(_logInfo);
            } 
        }

        public bool logOut(string account)
        {
            throw new NotImplementedException();
        }

        public void registration(string name, string residence, string password)
        {
            string _logInfo;
            ICallbackToFatClient callback = OperationContext.Current.GetCallbackChannel<ICallbackToFatClient>();
            try
            {
                if (db.registration(name, residence, password))
                {
                    callback.confirmation();
                }
                else
                {
                    _logInfo = "Try again with different data";
                    callback.serverInfo(_logInfo);
                }

            }
            catch(Exception)
            {
                _logInfo = "server could not respond";
                callback.serverInfo(_logInfo);
            }
        }

        public bool sendTransaction(string userAccount, string account, int amount)
        {
            throw new NotImplementedException();
        }
        // ###### here goes all methods which are not in the contract ##############

    }
}
