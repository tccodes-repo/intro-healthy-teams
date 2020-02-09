using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTeams.Api.Controllers
{
    [Route("api/ernie")]
    [ApiController]
    public class ErnieController : ControllerBase
    {
        private string[] _favoriteThings = new string[] { "Bert", "Rubber Ducky", "Singing", "Bath time" };

    // GET: api/ernie
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _favoriteThings;
        }

        // GET: api/ernie/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return _favoriteThings[id - 1];
        }

        // POST: api/ernie
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (_favoriteThings.Contains(value))
            {
                return new OkObjectResult(value + " not saved, already exists");
            }

            return new OkObjectResult("value saved successfully");
        }

        // PUT: api/ernie/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id > 10)
            {
                return new NotFoundResult();
            }

            return new OkResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
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
