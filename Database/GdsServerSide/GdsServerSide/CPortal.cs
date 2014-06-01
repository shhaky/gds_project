using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GdsServerSide
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CPortal : IPortal
    {
        DataHelper dataHelper;
        UserInfo user;
        public CPortal()
        {
            dataHelper = new DataHelper();
            user = new UserInfo();
        }

        public bool checkIfExistedUserName(string userName)
        {
            if (dataHelper.checkIfExistedUserName(userName))
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
            long userId = dataHelper.getLastestExistedUserId() + 1;
            if (dataHelper.addNewUser(userId, userName, passWord, firstName, lastName, email, joinDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //===========================================login=====================================================
        public bool checkPassword(string userName, string passWord)
        {
            if (dataHelper.checkPassword(userName, passWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void updateLoginTime(string userName,string time)
        {
            dataHelper.updateLoginTime(userName, time);
        }

        public string getLastLoginTime(string userName)
        {
            return dataHelper.getLastLoginTime(userName);
        }
        //=============================personal page============================================================

        public long getUserId(string userName)
        {
            return dataHelper.getUserId(userName);
        }

        public string getPassWord(string userName)
        {
            return dataHelper.getPassWord(userName);
        }

        public string getFirstName(string userName)
        {
            return dataHelper.getFirstName(userName);
        }

        public string getLastName(string userName)
        {
            return dataHelper.getLastName(userName);
        }

        public string getEmail(string userName)
        {
            return dataHelper.getEmail(userName);
        }

        public string getJoinDate(string userName)
        {
            return dataHelper.getJoinDate(userName);
        }

        public bool changePassword(string userName, string password)
        {
            if (dataHelper.changePassword(userName, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal getBalance(long userId, string coinType)
        {
            return dataHelper.getBalance(userId, coinType);
        }
    }
}
