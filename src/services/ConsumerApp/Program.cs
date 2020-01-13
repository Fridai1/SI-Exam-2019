using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using ConsumerApp.Managers;
using ConsumerApp.Models;
using Newtonsoft.Json;

namespace ConsumerApp
{
    struct LocationData
    {
        public string Address { get; set; }
        public int Distance { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager();
            CarLocationManager carLocationManager = new CarLocationManager();
            List<Car> carCache = new List<Car>();
            Location carLocation = new Location();
            List<LocationData> locData = new List<LocationData>();


            //Console.WriteLine("Welcome to Faraday Car Rental!");
            //Console.WriteLine("______________________________");
            //Console.WriteLine("How many doors does your desired car have?");
            //string chosenNoDoors = Console.ReadLine();
            //Console.WriteLine($"You've chosen {chosenNoDoors}");
            //Console.WriteLine("______________________________");
            //Console.WriteLine("Which brand are you searching for?");
            //Console.WriteLine("We've currently got the following");
            //foreach (var car in carManager.GetCars().Result)
            //{
            //    if (!carCache.Exists(x => x.Brand == car.Brand))
            //    {
            //        carCache.Add(car);
            //        Console.WriteLine($"{car.Brand}");
            //    }
            //}
            //Console.WriteLine("________________________________");
            //string chosenBrand = Console.ReadLine();
            //Console.WriteLine($"You've chosen {chosenBrand} as your brand!");
            //Console.WriteLine("________________________________");
            //Console.WriteLine("Please specify your address in the following format:");
            //Console.WriteLine("Example: Brendetoften 4, Ringsted");
            //Console.WriteLine("____________________________________________________");
            //string givenAddress = Console.ReadLine();
            //Console.WriteLine("____________________________________________________");
            //Console.WriteLine("From the given information we've calculated following:");
            //var responseString = carLocationManager.GetPickupLocation(chosenNoDoors, chosenBrand, givenAddress).Result;

            //for (int i = 0; i < carLocation.DestinationAddresses.Length; i++)
            //{
            //    locData.Add(new LocationData() { Address = carLocation.DestinationAddresses[i], Distance = Int32.Parse(carLocation.Rows[i].Elements[i].Distance.Text)});
            //}

            //var sorted = locData.OrderBy(x => x.Distance);
            

            //Console.WriteLine(locData);
            //Console.ReadLine();

            Console.WriteLine(carLocationManager.GetPickupLocation("4", "Ford", "Lyngby").Result);
            Console.ReadLine();




        }
    }
}
