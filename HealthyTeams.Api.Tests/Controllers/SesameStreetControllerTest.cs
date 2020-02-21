using HealthyTeams.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HealthyTeam.Api.Tests
{
    [TestClass]
    public class SesameStreetControllerTest
    {
        public SesameStreetController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = new SesameStreetController();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _controller = null;
        }

        [TestMethod]
        public void SesameController_Get_Success()
        {
            //arrange
            int count = 9;

            //act
            IEnumerable<string> result = _controller.List();

            //assert
            Assert.AreEqual(count, result.Count());
        }

        [TestMethod]
        public void ErnieController_Get_CountFail()
        {
            //arrange
            int count = 25;

            //act
            IEnumerable<string> result = _controller.List();

            //assert
            Assert.AreNotEqual(count, result.Count());
        }
    }
}
