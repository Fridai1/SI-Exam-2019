using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PickupDropoffService.Models;

namespace PickupDropoffService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickupDropoffController : ControllerBase
    {


        // GET: api/PickupDropoff
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PickupDropoff/5

        [HttpGet("{city1}&{city2}&key={apiKey}", Name = "Get")]
        // Make into array to return more destinations and calculate the distance.
        public string Get(string city1, string city2, string apiKey)
        {
            string responseFromServer = "";
            Location myLocation = null;
            WebRequest webRequest = WebRequest.Create($"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={city1}&destinations={city2}&key={apiKey}");
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            WebResponse webResponse = webRequest.GetResponse();
            Stream dataStream = webResponse.GetResponseStream();

            if (dataStream != null)
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                myLocation = JsonConvert.DeserializeObject<Location>(responseFromServer);
            }

            //return $"From {myLocation.Origin_Addresses[0]} to {myLocation.Destination_Addresses[0]}";
            //return responseFromServer;

            return myLocation.Rows[0].Elements[0].Distance.Text;
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
