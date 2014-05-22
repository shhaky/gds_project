using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace gds_ServerSide
{
     [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CPortal : IPortal
    {
        DataHelper dataHelper;
        //===============================register part===========================================
        public CPortal()
        {
            dataHelper = new DataHelper();
        }

        public bool checkIsExistedUserName(string userName)
        {
            if (dataHelper.checkIsExistedUserName(userName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addNewUser(string userName, string passWord, string firstName, string lastName, string email, string joinDate, string lastLoginTime)
        {
            long userId = dataHelper.getLastestExistedUserId() + 1;
            if (dataHelper.addNewUser(userId, userName, passWord, firstName, lastName, email, joinDate,lastLoginTime))
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
