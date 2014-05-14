using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GdsHub
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CHub : IHub
    {
        private ServiceReferencePortal.PortalClient proxyOfPortal;
        private ServiceReferenceTransaction.TransactionClient proxyOfTransaction;

        public CHub()
        {
            proxyOfPortal = new ServiceReferencePortal.PortalClient();
            proxyOfTransaction = new ServiceReferenceTransaction.TransactionClient();
        }
        //================================register========================================
        public bool checkIfExistedUserName(string userName)
        {
            if (proxyOfPortal.checkIfExistedUserName(userName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addNewUser(string userName, string passWord, string firstName, string lastName, string email, string joinDate)
        {
            if (proxyOfPortal.addNewUser(userName, passWord, firstName, lastName, email, joinDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //===================================login===========================================
        public bool checkPassword(string userName, string passWord)
        {
            if (proxyOfPortal.checkPassword(userName, passWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //==============================personal page=======================================
        public long getUserId(string userName)
        {
            return proxyOfPortal.getUserId(userName);
        }

        public string getPassWord(string userName)
        {
            return proxyOfPortal.getPassWord(userName);
        }

        public string getFirstName(string userName)
        {
            return proxyOfPortal.getFirstName(userName);
        }

        public string getLastName(string userName)
        {
            return proxyOfPortal.getLastName(userName);
        }

        public string getEmail(string userName)
        {
            return proxyOfPortal.getEmail(userName);
        }

        public string getJoinDate(string userName)
        {
            return proxyOfPortal.getJoinDate(userName);
        }

        public bool changePassword(string userName, string password)
        {
            if (proxyOfPortal.changePassword(userName, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addNewTransaction(long userId, string transTime, string transType, string coinType, decimal amount, string add)
        {
            if (proxyOfTransaction.addNewTransaction(userId, transTime, transType, coinType, amount, add))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> getTransInfo(long userId)
        {
            List<string> temp = new List<string>();
            foreach (string a in proxyOfTransaction.getTransInfo(userId))
            {
                temp.Add(a);
            }
            return temp;
        }
    }
}
