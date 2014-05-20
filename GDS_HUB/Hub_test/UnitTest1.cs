using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDS_HUB;
namespace Hub_test
{
    
    [TestClass]
    public class UnitTest1
    {
        FatToAccService obj = new FatToAccService();
        
        [TestMethod]
        public void TestMethod1()
        {
            int result = obj.checkIfExistedUserNameHUB("username", "password");
        }
    }
}
