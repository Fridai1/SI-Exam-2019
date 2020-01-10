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

        [HttpGet("{city1}&key={apiKey}", Name = "Get")]
        // Make into array to return more destinations and calculate the distance.
        public string Get(string city1, [FromBody]string[] city2, string apiKey)
        {
            // Google API Request
            string responseFromServer = "";
            Location googleLocation = null;

            WebRequest googleRequest = WebRequest.Create($"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={city1}&destinations={city2}&key={apiKey}");
            googleRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse googleResponse = googleRequest.GetResponse();
            Stream googleStream = googleResponse.GetResponseStream();

            //// Location API Request
            //WebRequest locationRequest = WebRequest.Create($"https://inserturl.com");
            //locationRequest.Credentials = CredentialCache.DefaultCredentials;
            //WebResponse webResponse = locationRequest.GetResponse();
            //Stream locationStream = webResponse.GetResponseStream();

            if (googleRequest != null)
            {
                StreamReader reader = new StreamReader(googleStream);
                responseFromServer = reader.ReadToEnd();
                googleLocation = JsonConvert.DeserializeObject<Location>(responseFromServer);
            }

            //return $"From {myLocation.Origin_Addresses[0]} to {myLocation.Destination_Addresses[0]}";
            //return responseFromServer;
            // return googleLocation.Rows[0].Elements[0].Distance.Text;
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
