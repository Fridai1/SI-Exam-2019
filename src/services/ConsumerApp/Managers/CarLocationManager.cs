using System.Collections.Generic;
using System.Threading.Tasks;
using ConsumerApp.Controller;
using ConsumerApp.ExtensionMethods;
using ConsumerApp.Models;
using Newtonsoft.Json;

namespace ConsumerApp.Managers
{
    public class CarLocationManager
    {
        public async Task<Location> GetPickupLocation(string doors, string brand, string driversLicense)
        {
            var pickup = new Location();

            // JAVA API
            //var customerResponse = await HomeController.Client.GetStringAsync("http://172.18.76.65:8002/api/customer/{driversLicense}");
            //string customerLocation = JsonConvert.DeserializeObject<string>(customerResponse);

            // LOCATION API
            var locationResponse = await APIController.Client.GetStringAsync($"http://172.18.76.65:8002/api/location/{doors}&{brand}");
            List<CarLocation> carLocations = JsonConvert.DeserializeObject<List<CarLocation>>(locationResponse);

            //PICKUP DROPOFF API
            var responseString = await APIController.Client.GetStringAsync($"http://172.18.76.65:8002/api/pickupdropoff/{driversLicense}&{carLocations.GetAllAddresses()}&key=AIzaSyCL5mdgxOBB8UFM6prTzYCnqjw_qW8qca8");
            pickup = JsonConvert.DeserializeObject<Location>(responseString);

            return pickup;
        }
    }
}