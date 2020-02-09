using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTeams.Api.Controllers
{
    [Route("api/cookie")]
    [ApiController]
    public class CookieController : ControllerBase
    {
        private string[] _cookies = new[] { "Chocolate Chip", "Oatmeal Raisin", "Oreo", "Butter", "Snickerdoodles", "Gingersnaps", "Shortbread Cookies" };

        // GET: api/cookie
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new string(_cookies[rng.Next(_cookies.Length)])).ToArray();           
        }

        // GET: api/ernie/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return _cookies[2];
        }

        // POST: api/ernie
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (_cookies.Contains(value))
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