using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace Location_Service.Models
{
    public class DbUtilities
    {
        private string hostName = "mysql90.unoeuro.com";
        private string username = "fridai_dk";
        private string pwd = "2pmkf5x4";
        private string database = "fridai_dk_db";
        private string connString;
        private MySqlConnection connection;

        public DbUtilities()
        {
            Initiliaze();
            
        }
        private void Initiliaze()
        {
            connString = "Server=mysql90.unoeuro.com;uid=fridai_dk;pwd=2pmkf5x4;database=fridai_dk_db";
        }

        //open connection to database
        

        public int PostLocation(Location location)
        {
            string query = $"INSERT INTO `Location` (`idLocation`, `SurveyId`, `Postalcode`, `City`, `District`, `Region`, `LatitudeCoords`, `LongtitudeCoords`)" +
                           $" VALUES ('{null}','{location.SurveyId}','{location.PostalCode}','{location.City}','{location.District}','{location.Region}','{location.LatitudeCoords}','{location.LongtitudeCoords}'); ";

            using (var connection = new MySqlConnection(connString))
            {
                connection.Execute(query);
                var newLocation = connection.Query<Location>("Select * FROM Location ORDER BY idLocation DESC LIMIT 1").ToList();
                return newLocation.Last().idLocation;
            }
        }

        public List<CarLocation> GetLocationsByCar(Car car)
        {
            string query = $"SELECT * FROM `Cars` WHERE brand = '{car.brand}' AND Doors = {car.Door}";
            List<Car> result = new List<Car>();
            List<CarLocation> locationList = new List<CarLocation>();
            
            // Gets all cars with the predetermined filter
            using (var connection = new MySqlConnection(connString))
            {
                 result = connection.Query<Car>(query).ToList();
            }

            // Gets all the locations where the previous cars where located.
            using (var connection = new MySqlConnection(connString))
            {
                
                foreach (var c in result)
                {
                    // checks to see if we have already found that specific location.
                    if (!locationList.Exists(x => x.idCarLocation == c.IdCarLocation))
                    {
                        query = $"SELECT * CarLocation WHERE idCarLocation = {c.IdCarLocation}";
                        List<CarLocation> l = connection.Query<CarLocation>(query).ToList();
                        locationList.Append(l[0]);
                    }
                    
                }
            }

            return locationList;


        }
    }
}