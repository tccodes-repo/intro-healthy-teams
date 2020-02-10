using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTeams.Api.Controllers
{
    [Route("api/sesamestreet")]
    [ApiController]
    public class SesameStreetController : ControllerBase
    {
        private string[] _characters = { "Ernie", "Big Bird", "Bert", "Oscar", "Grover", "Count", "Kermit", "Rosita" };

        [HttpGet]        
        public IEnumerable<string> List()
        {
            return _characters;
        }
    }
}