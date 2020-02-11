using HealthyTeams.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HealthyTeam.Api.Tests
{
    [TestClass]
    public class OscarControllerTest
    {
        public OscarController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = new OscarController();
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
            int count = 6;

            //act
            IEnumerable<string> result = _controller.List();

            //assert
            Assert.AreEqual(count, result.Count());
        }

        [TestMethod]
        public void BertController_Get_CountFail()
        {
            //arrange
            int count = 25;

            //act
            IEnumerable<string> result = _controller.List();

            //assert
            Assert.AreNotEqual(count, result.Count());
        }

        [TestMethod]
        public void BertController_Get_ById_Success()
        {
            //arrange
            int id = 3;

            //act
            string result = _controller.Get(id);

            //assert
            Assert.AreEqual("Farm", result);
        }

        [TestMethod]
        public void BertController_Post_Success()
        {
            //arrange
            string cookie = "Sand";

            //act
            IActionResult result = _controller.Post(cookie);
            ObjectResult response = (ObjectResult)result;
            string responseValue = response.Value.ToString();

            //assert
            Assert.IsInstanceOfType(result, typeof(IActionResult), "'result' type must be of IActionResult");
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
            Assert.AreEqual("value saved successfully", responseValue);
        }

        [TestMethod]
        public void BertController_Fail_Duplicate()
        {
            //arrange
            string cookie = "Trash Can";

            //act
            IActionResult result = _controller.Post(cookie);
            ObjectResult response = (ObjectResult)result;
            string responseValue = response.Value.ToString();

            //assert
            Assert.IsInstanceOfType(result, typeof(IActionResult), "'result' type must be of IActionResult");
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
            Assert.AreEqual(cookie + " not saved, already exists", responseValue);
        }

        [TestMethod]
        public void BertController_Put_Success()
        {
            //arrange
            int id = 5;
            string value = "Rocks";

            //act
            IActionResult result = _controller.Put(id, value);
            OkResult response = (OkResult)result;

            //assert
            Assert.IsInstanceOfType(result, typeof(IActionResult), "'result' type must be of IActionResult");
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
        }

        [TestMethod]
        public void BertController_Put_Fail_IdNotFound()
        {
            //arrange
            int id = 11;
            string value = "Any";

            //act
            IActionResult result = _controller.Put(id, value);
            NotFoundResult response = (NotFoundResult)result;

            //assert
            Assert.IsInstanceOfType(result, typeof(IActionResult), "'result' type must be of IActionResult");
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);
        }

        [TestMethod]
        public void BertController_Delete_Success()
        {
            //arrange
            int id = 31;

            //act
            IActionResult result = _controller.Delete(id);
            StatusCodeResult response = (StatusCodeResult)result;

            //assert
            Assert.IsInstanceOfType(result, typeof(IActionResult), "'result' type must be of IActionResult");
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
        }

        [TestMethod]
        public void BertController_Delete_IdNotFound()
        {
            //arrange
            int id = 3;

            //act
            IActionResult result = _controller.Delete(id);
            StatusCodeResult response = (StatusCodeResult)result;

            //assert
            Assert.IsInstanceOfType(result, typeof(IActionResult), "'result' type must be of IActionResult");
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);
        }
    }
}
