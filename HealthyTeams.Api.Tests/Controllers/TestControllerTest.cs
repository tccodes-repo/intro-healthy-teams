using HealthyTeams.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HealthyTeam.Api.Tests
{
    [TestClass]
    public class TestControllerTest
    {
        public TestController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = new TestController();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _controller = null;
        }

        [TestMethod]
        public void BertController_Get_Success()
        {
            //arrange
            string value = "Hello World";

            //act
            string result = _controller.Get();

            //assert
            Assert.AreEqual(value, result);
        }      
    }
}
