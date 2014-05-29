using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDS_HUB;
using Moq;
namespace Hub_test
     
{
    
    [TestClass]
    public class FatToAccServiceTest
    {
        Mock<FatToAccService> obj = new Mock<FatToAccService>();
         
        
        [TestMethod]
        public void longInTest()
        {
           int i = 4;
         Assert.AreEqual( 4, i );

        }
    }
}
