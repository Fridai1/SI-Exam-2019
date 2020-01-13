using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SurveyServiceApp.Managers;
using SurveyServiceApp.Models;

namespace SurveyServiceApp.Controllers
{
    [BindProperties]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static HttpClient Client { get; } = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }

        public IActionResult BookingDone()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Survey
        public string Gender { get; set; }
        public string Age { get; set; }
        public int PostalCode { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }



        public async Task<int> OnPostReview()
        {
            var gender = Gender;
            var age = Age;
            var rating = Rating;
            var postalCode = PostalCode;
            var description = Description;

            ReviewerManager reviewerManager = new ReviewerManager();
            Reviewer reviewer = new Reviewer(gender, age, postalCode);
            reviewerManager.PostReviewer(reviewer);

            SurveyManager surveyManager = new SurveyManager();
            Survey survey = new Survey() { Id = 1, Rating = rating, Description = description };
            surveyManager.PostSurvey(survey);

            LocationManager locationManager = new LocationManager();
            await locationManager.PostLocation(postalCode, 1);

            return rating;
        }

        // GetClosestCars
        public static string Brand { get; set; }
        public static int Doors { get; set; }
        public static string DriversLicense { get; set; }

        // Closest Locations
        public static string[] Address { get; set; }
        public static string[] Distance { get; set; }
        public static string[] Time { get; set; }

        public async Task<IActionResult> SendDetails()
        {
            List<Location> carLocations = new List<Location>();
            var brand = Brand;
            var doors = Doors;
            var driversLicense = DriversLicense;


            PickupDropoffManager pickupDropoffManager = new PickupDropoffManager();
            carLocations = await pickupDropoffManager.GetPickupLocation(doors, brand, driversLicense);

            return View("BookingDone");
        }
    }
}
