namespace PickupDropoffService.Models
{
    public class City2
    {
        public string[] Cities { get; set; }

        public override string ToString()
        {
            string cities = Cities[0];

            foreach (var city in Cities)
            {
                if(cities != city)
                {
                    cities += $"|{city}";
                }
            }
            return cities;
        }
    }
}