using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using AMEEClient;
//using AMEEClient.Model;
using AMEE;
using AMEE.Model;
using NUnit.Framework;

namespace AMEEInExcel.Core.UnitTests
{
    [TestFixture]
    public class DefraFixture
    {
        [Test]
        public void CanGrabValue()
        {
            Assert.AreEqual("0.54362", new AMEEConnector()
                .GetDataItemValue("transport/defra/fuel", "9DE1D9435784", "massTotalCO2ePerVolume"));
        }

        [Test]
        public void CanCalculate()
        {
            Assert.AreEqual("4.7385", new AMEEConnector()
                .Calculate("transport/defra/fuel", "9DE1D9435784", "totalDirectCO2e", "volume", "10"));
        }
    }
      
}
