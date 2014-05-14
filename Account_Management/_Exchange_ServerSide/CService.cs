using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _Exchange_ServerSide
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CService : IHub
    {
        private DataHelper dataHelper;

        public CService()
        {
            dataHelper = new DataHelper();
        }

        public long getLastestId()
        {
            return dataHelper.getLastestExistedUserId();
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

        public bool addNewUser(long userId, string userName, string passWord, string firstName, string lastName, string email, string joinDate)
        {
            if (dataHelper.addNewUser(userId, userName, passWord, firstName, lastName, email, joinDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
    }
}
