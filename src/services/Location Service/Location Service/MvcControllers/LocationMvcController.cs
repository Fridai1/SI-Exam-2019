using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Location_Service.Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Agreement.Srp;

namespace Location_Service.MvcControllers
{
    public class LocationMvcController
    {
        DbUtilities dbu = new DbUtilities();
        public LocationMvcController()
        {
            Initialize();
        }
        private string _url = "https://dawa.aws.dk/postnumre/";
        public HttpClient Client { get; set; }

        public string URL
        {
            get => _url;
            set => _url = value;
        }


        public void Initialize()
        {
            HttpClient httpClient = new HttpClient();
            Client = httpClient;
            httpClient.BaseAddress = new Uri(URL);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async void CreateLocation(int postalCode, int SurveyId)
        {

            var request =(HttpWebRequest) WebRequest.Create(URL + postalCode);

            request.Method = "GET";

            string content = "";

            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                        RawLocation a = JsonConvert.DeserializeObject<RawLocation>(content);
                        Location location = new Location()
                        {
                            City = a.navn,
                            District = a.kommuner[0].navn,
                            PostalCode = postalCode,
                            LatitudeCoords = a.visueltcenter[0],
                            LongtitudeCoords = a.visueltcenter[1],
                            SurveyId = SurveyId
                                
                        };
                        dbu.PostLocation(location);
                    }
                }
            }

        }
    }
}