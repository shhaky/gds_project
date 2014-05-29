using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GdsServerSide
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    [ServiceBehavior]
    public class CTransaction : ITransaction
    {
        DataHelper dataHelper;
        long transId = 0;
        public CTransaction()
        {
            dataHelper = new DataHelper();
        }

        //public long getLastestTransId(string userId)
        //{
        //    return dataHelper.getLastestExistedTransId();
        //}

        public bool addNewTransaction(long userId, string transTime, string transType, string coinType, decimal amount, long add)
        {
            transId = dataHelper.getLastestExistedTransId() + 1;
            if (dataHelper.addNewTransaction(transId, userId, transTime, transTime, coinType, amount, add))
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
            List<string> temp = dataHelper.getTransInfo(userId);
            return temp;
        }

    }
}