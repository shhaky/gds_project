﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SubTDataBase
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISDB
    {
        //---useful method---
        [OperationContract]
        long getLastestExistedUserId();

        [OperationContract]
        bool checkUserName(string userName);
        //---register part---
        [OperationContract]
        void registerAsUser(long usrId, string userName, string firstName, string lastName, string joinDate);
        //---login part---
        [OperationContract]
        long showUserId(string userName);

        //---account management---

        [OperationContract]
        string showUserName(long userId);


        //---transaction part---

        //---trade part---
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "SubTDataBase.ContractType".
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
