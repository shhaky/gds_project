using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace gds_hub
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CHub : IHub
    {
        private ServiceReferenceCPortal.PortalClient proxyOfProtal;

        public CHub()
        {
            proxyOfProtal = new ServiceReferenceCPortal.PortalClient();
        }
        //================================register========================================
        public bool checkIsExistedUserName(string userName)
        {
            if (proxyOfProtal.checkIsExistedUserName(userName))
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
            if (proxyOfProtal.addNewUser(userName, passWord, firstName, lastName, email, joinDate, lastLoginTime))
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
