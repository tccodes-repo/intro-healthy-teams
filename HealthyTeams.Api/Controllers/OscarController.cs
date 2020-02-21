using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTeams.Api.Controllers
{
    [Route("api/oscar")]
    [ApiController]
    public class OscarController : ControllerBase
    {
        private string[] _favoriteThings = new string[] { "Trash Can", "Trash", "Farm", "Swimming Pool", "Bowling Ally", "Piano" };

        [HttpGet]
        public IEnumerable<string> List()
        {
            return _favoriteThings;
        }

        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            return _favoriteThings[id - 1];
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (_favoriteThings.Contains(value))
            {
                return new OkObjectResult(value + " not saved, already exists");
            }

            return new OkObjectResult("value saved successfully");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id > 10)
            {
                return new NotFoundResult();
            }

            return new OkResult();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 3)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return new StatusCodeResult(StatusCodes.Status200OK);
        }
    }
}
