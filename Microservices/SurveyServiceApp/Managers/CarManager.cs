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
            var responseString = await HomeController.Client.GetStringAsync("http://167.172.102.122:8001/api/car");
            var cars = new List<Car>();
            cars = JsonConvert.DeserializeObject<List<Car>>(responseString);

            return cars;
        }

    }
}