using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyTeams.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthyTeams.Api.Controllers
{
    [ApiController]
    [Route("api/weatherforcast")]
    public class WeatherForecastController : ControllerBase
    {
        private string[] _outcomes = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> List()
        {
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = _outcomes[rng.Next(_outcomes.Length)]
            }).ToArray();
        }
    }
}
