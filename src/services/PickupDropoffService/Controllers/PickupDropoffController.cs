using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PickupDropoffService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickupDropoffController : ControllerBase
    {
        private string apiKey = "AIzaSyCL5mdgxOBB8UFM6prTzYCnqjw_qW8qca8";


        // GET: api/PickupDropoff
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PickupDropoff/5
        [HttpGet("{city1}&{city2}", Name = "Get")]
        public string Get(string city1, string city2)
        {
            string responseFromServer = "";
            WebRequest webRequest = WebRequest.Create($"https://maps.googleapis.com/maps/api/directions/json?origin={city1}&destination={city2}&key={apiKey}");
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            WebResponse webResponse = webRequest.GetResponse();
            Stream dataStream = webResponse.GetResponseStream();

            if (dataStream != null)
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }

            webResponse.Close();
            return responseFromServer;
        }

        // POST: api/PickupDropoff
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/PickupDropoff/5
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
