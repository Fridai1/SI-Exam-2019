using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using SurveyServiceApp.Controllers;
using SurveyServiceApp.Models;

namespace SurveyServiceApp.Managers
{
    public class LocationManager
    {
        public async Task PostLocation(int postalCode, int surveyId)
        {
            
            var location = new Location();
            location.PostalCode = postalCode;
            location.SurveyId = surveyId;

            var json = JsonConvert.SerializeObject(location);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://167.172.102.122:8000/api/location";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            
        }
    }
}