namespace Location_Service.Models
{
    public class Location
    {
        public Location()
        {
            
        }
        public int idLocation { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
        public double LatitudeCoords { get; set; }
        public double LongtitudeCoords { get; set; }
        public int SurveyId { get; set; }
    }
}