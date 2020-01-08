using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Service.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        DatabaseUtilities dbu = new DatabaseUtilities();
        // GET: api/Car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return dbu.GetAllCars();
        }

        // GET: api/Car/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Car
        
    }
}
