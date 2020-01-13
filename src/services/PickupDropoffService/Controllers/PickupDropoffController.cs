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

        // GET: api/PickupDropoff/Copenhagen&key=INSERT_API_KEY

        [HttpGet("{city1}&{destinations}&key={apiKey}", Name = "Get")]
        // Make into array to return more destinations and calculate the distance.
        public Location Get(string city1, List<string> destinations, string apiKey)
        {
            //// Location API Request
            //string responseFromLocationService = "";
            //List<CarLocation> carLocations = null;

            //WebRequest locationRequest = WebRequest.Create($"http://172.18.76.65:8002/api/location/{destinations}&{car.Brand}");
            //locationRequest.Credentials = CredentialCache.DefaultCredentials;
            //WebResponse webResponse = locationRequest.GetResponse();
            //Stream locationStream = webResponse.GetResponseStream();

            //StreamReader locationReader = new StreamReader(locationStream);
            //responseFromLocationService = locationReader.ReadToEnd();
            //carLocations = JsonConvert.DeserializeObject<List<CarLocation>>(responseFromLocationService);

            //carLocations.GetAllAddresses();

            // Google API Request
            string responseFromGoogleService = "";
            Location googleLocation = null;


            WebRequest googleRequest = WebRequest.Create($"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={city1}&destinations={destinations}&key={apiKey}");
            googleRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse googleResponse = googleRequest.GetResponse();
            Stream googleStream = googleResponse.GetResponseStream();

            if (googleRequest != null)
            {
                StreamReader reader = new StreamReader(googleStream);
                responseFromGoogleService = reader.ReadToEnd();
                googleLocation = JsonConvert.DeserializeObject<Location>(responseFromGoogleService);
            }

            //return $"From {myLocation.Origin_Addresses[0]} to {myLocation.Destination_Addresses[0]}";
            //return responseFromServer;
            // return googleLocation.Rows[0].Elements[0].Distance.Text;
            return googleLocation;
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
