using HealthyTeams.Api.Controllers;
using HealthyTeams.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HealthyTeam.Api.Tests
{
    [TestClass]
    public class WeatherForcastControllerTest
    {
        public WeatherForecastController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = new WeatherForecastController();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _controller = null;
        }

        [TestMethod]
        public void WeatherForcastController_Success()
        {
            //arrange

            //act
            IEnumerable<WeatherForecast> result = _controller.Get();

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 3);
        }
    }
}
