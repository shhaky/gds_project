using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DatabaseHUB
{
    public class CDBHUB : IDBHUB
    {
        ServiceReferenceMDB.MDBClient proxyOfMDB;
        ServiceReferenceSDB.SDBClient proxyOfSDB;
        ServiceReferenceCDB.CDBClient proxyOfCDB;

        public CDBHUB()
        {
            proxyOfMDB = new ServiceReferenceMDB.MDBClient();
            proxyOfSDB = new ServiceReferenceSDB.SDBClient();
            proxyOfCDB = new ServiceReferenceCDB.CDBClient();
        }
        //---useful method---
        public long getLastestExistedUserId()
        {
            long maxIdOfMDB = proxyOfMDB.getLastestExistedUserId();
            long maxIdOfSDB = proxyOfSDB.getLastestExistedUserId();
            long maxIdOfCDB = proxyOfCDB.getLastestExistedUserId();
            long[] temp = { maxIdOfMDB, maxIdOfSDB, maxIdOfCDB };
            long max = maxIdOfMDB;
            foreach (long a in temp)
            {
                if (a > max)
                {
                    max = a;
                }
            }
            return max+1;
        }

        public bool checkUserName(string userName)
        {
            if (proxyOfMDB.checkUserName(userName) || proxyOfSDB.checkUserName(userName))
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
            long tempId = proxyOfSDB.showUserId(userName);
            string pass = proxyOfCDB.showPassWord(tempId);
            if (pass == passWord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //---register part---
        public bool registerAsUser(string userName, string firstName, string lastName, string eMail, string passWord)
        {
            if (!checkUserName(userName))
            {
                try
                {
                    long userId = getLastestExistedUserId();
                    string joinDate = Convert.ToString(System.DateTime.Now);
                    string lastLoginTime = joinDate;
                    proxyOfMDB.registerAsUser(userId, userName, firstName, lastName, joinDate, passWord, eMail, lastLoginTime);
                    proxyOfSDB.registerAsUser(userId, userName, firstName, lastName, joinDate);
                    proxyOfCDB.registerAsUser(userId, passWord, eMail, lastLoginTime);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //---login part---
        public bool login(string userName, string passWord)
        {
            if (checkUserName(userName))
            {
                if (proxyOfMDB.login(userName, passWord))
                {
                    return true;
                }
                else if (checkPassword(userName, passWord))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //---account management---
        public long showUserID(string userName)
        {
            if (proxyOfMDB.checkUserName(userName))
            {
                return proxyOfMDB.showUserId(userName);
            }
            else if (proxyOfSDB.checkUserName(userName))
            {
                return proxyOfSDB.showUserId(userName);
            }
            else
            {
                return 0;
            }
        }
        //==================????================================
        public string showUserName(long userId)
        {
            return proxyOfMDB.showUserName(userId);
        }

        public string showEmail(long userId)
        {
            return proxyOfMDB.showEmail(userId);
        }

        public void updateLoginTime(long userId)
        {
            string loginTime = Convert.ToString(System.DateTime.Now);
            proxyOfCDB.updateLoginTime(userId, loginTime);
            proxyOfMDB.updateLoginTime(userId, loginTime);          
        }

        public bool changePass(long userId,string oldPass, string newPass)
        {
            if (proxyOfCDB.showPassWord(userId) == oldPass)
            {
                if (proxyOfCDB.changePass(userId, newPass))
                {
                    if (proxyOfMDB.changePass(userId, newPass))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public decimal showBalance(long userId, string coinType)
        {
          return proxyOfMDB.showBalance(userId, coinType);
        }
        //---transaction part---

        //---trade part---
        
    }
}
