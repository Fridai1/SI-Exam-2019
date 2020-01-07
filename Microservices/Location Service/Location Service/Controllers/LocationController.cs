using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Location_Service.Models;
using Location_Service.MvcControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Location_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private LocationMvcController locationController = new LocationMvcController();
        // GET: api/Location
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Location
        [HttpPost]
        public void Post([FromBody] ReceivedData value)
        {

            locationController.CreateLocation(value.PostalCode,value.SurveyId);
        }

    }
}
