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
    }
}