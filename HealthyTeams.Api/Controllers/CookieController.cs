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
        private string[] _cookies = new[] { "Chocolate Chip", "Oatmeal Raisin", "Oreo", "Butter", "Snickerdodles", "Gingersnaps", "Shortbread Cookies" };

        [HttpGet]
        public IEnumerable<string> List()
        {
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new string(_cookies[rng.Next(_cookies.Length)])).ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public string Get(int index)
        {
            return _cookies[2];
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (_cookies.Contains(value))
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