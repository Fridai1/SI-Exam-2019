using System.Net.Http;

namespace ConsumerApp.Controller
{
    public class APIController
    {
        public static HttpClient Client { get; } = new HttpClient();

        public APIController()
        {

        }
    }
}
