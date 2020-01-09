using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DropoffPickupService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropoffPickupController : ControllerBase
    {
        // GET: api/DropoffPickup
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DropoffPickup/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DropoffPickup
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/DropoffPickup/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
