using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using SurveyServiceApp.Controllers;
using SurveyServiceApp.Models;

namespace SurveyServiceApp.Managers
{
    public class CarManager
    {
        public async Task<List<Car>> GetCars()
        {
            var cars = new List<Car>
            {
                new Car(1, "XY39201", "Ford", 5),
                new Car(2, "QZ30281", "Ford", 5),
                new Car(3, "PQ10578", "Ford", 7),
                new Car(4, "XY39201", "Audi", 3),
                new Car(5, "XY39201", "Tesla", 5)
            };
            //var responseString = await HomeController.Client.GetStringAsync("http://172.18.76.65:8002/api/car");
            //cars = JsonConvert.DeserializeObject<List<Car>>(responseString);

            return cars;
        }
    }
}