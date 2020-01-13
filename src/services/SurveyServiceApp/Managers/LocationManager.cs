using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SurveyServiceApp.Models;

namespace SurveyServiceApp.Managers
{
    public class LocationManager
    {
        public async Task PostLocation(int postalCode, int surveyId)
        {
            var location = new SurveyLocation {PostalCode = postalCode, SurveyId = surveyId};

            var json = JsonConvert.SerializeObject(location);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://172.18.76.65:8000/api/location";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            
        }
    }
}