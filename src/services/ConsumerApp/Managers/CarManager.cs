using System.Collections.Generic;
using System.Threading.Tasks;
using ConsumerApp.Controller;
using ConsumerApp.Models;
using Newtonsoft.Json;

namespace ConsumerApp.Managers
{
    public class CarManager
    {
        public async Task<List<Car>> GetCars()
        {
            List<Car> cars = new List<Car>();

            var responseString = await APIController.Client.GetStringAsync("http://172.18.76.65:8002/api/car");
            cars = JsonConvert.DeserializeObject<List<Car>>(responseString);

            return cars;
        }
    }
}
