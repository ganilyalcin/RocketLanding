using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketLanding.Service;

namespace RocketLanding.Test
{
    [TestClass]
    public class UnitTest1
    {
        private RocketLandingService service;

        public UnitTest1()
        {
            service = new RocketLandingService(10, 10);
        }
        [TestMethod]
        public void TestMethod1()
        {
            var response = service.GetResponse(5, 5);
            Assert.AreEqual<string>(response, "ok for landing");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var response = service.GetResponse(16, 15);
            Assert.AreEqual<string>(response, "out of platform");
        }

        [TestMethod]
        public void TestMethod3()
        {
            var response = service.GetResponse(5, 5);
            Assert.AreEqual<string>(response, "clash");
        }

        [TestMethod]
        public void TestMethod4()
        {
            var response = service.GetResponse(7, 7);
            Assert.AreEqual<string>(response, "ok for landing");
        }
        [TestMethod]
        public void TestMethod5()
        {
            var response = service.GetResponse(7, 8);
            Assert.AreEqual<string>(response, "clash");
        }
        [TestMethod]
        public void TestMethod6()
        {
            var response = service.GetResponse(6, 7);
            Assert.AreEqual<string>(response, "clash");
        }
        [TestMethod]
        public void TestMethod7()
        {
            var response = service.GetResponse(6, 6);
            Assert.AreEqual<string>(response, "clash");
        }
    }
}
