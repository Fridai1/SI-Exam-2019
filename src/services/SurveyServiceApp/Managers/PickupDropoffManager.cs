using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SurveyServiceApp.Controllers;
using SurveyServiceApp.ExtensionMethods;
using SurveyServiceApp.Models;

namespace SurveyServiceApp.Managers
{
    public class PickupDropoffManager
    {
        public async Task<List<Location>> GetPickupLocation(int doors, string brand, string driversLicense)
        {
            var pickup = new List<Location>();

            // JAVA API
            //var customerResponse = await HomeController.Client.GetStringAsync("http://172.18.76.65:8002/api/customer/{driversLicense}");
            //string customerLocation = JsonConvert.DeserializeObject<string>(customerResponse);

            // LOCATION API
            var locationResponse = await HomeController.Client.GetStringAsync("http://172.18.76.65:8002/api/location/{doors.ToString()}&{brand}");
            List<CarLocation> carLocations = JsonConvert.DeserializeObject<List<CarLocation>>(locationResponse);

            //PICKUP DROPOFF API
            var responseString = await HomeController.Client.GetStringAsync($"http://172.18.76.65:8002/api/pickupdropoff/{driversLicense}&{carLocations.GetAllAddresses()}&key=AIzaSyCL5mdgxOBB8UFM6prTzYCnqjw_qW8qca8");
            pickup = JsonConvert.DeserializeObject<List<Location>>(responseString);

            return pickup;
        }
    }
}