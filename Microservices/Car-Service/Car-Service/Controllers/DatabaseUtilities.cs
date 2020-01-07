using System.Collections.Generic;
using System.Data;
using System.Linq;
using Car_Service.Model;
using Dapper;
using Microsoft.CodeAnalysis;
using MySql.Data.MySqlClient;

namespace Car_Service.Controllers
{
    public class DatabaseUtilities
    {
        private string hostName = "mysql90.unoeuro.com";
        private string username = "fridai_dk";
        private string pwd = "2pmkf5x4";
        private string database = "fridai_dk_db";
        private string connString;
        private MySqlConnection connection;

        public DatabaseUtilities()
        {
            Initiliaze();

        }
        private void Initiliaze()
        {
            connString = "Server=mysql90.unoeuro.com;uid=fridai_dk;pwd=2pmkf5x4;database=fridai_dk_db";
        }

        //open connection to database


        public List<Car> GetAllCars()
        {
            string query = "SELECT c.brand, c.licensePlate FROM `Cars` c";

            using (IDbConnection connection = new MySqlConnection(connString))
            {
                return connection.Query<Car>(query).ToList();
            }
        }
    }
}