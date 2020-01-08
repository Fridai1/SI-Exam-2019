using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using SurveyServiceApp.Models;

namespace SurveyServiceApp.Managers
{
    public class ReviewerManager
    {
        private string hostName = "mysql90.unoeuro.com";
        private string username = "fridai_dk";
        private string pwd = "2pmkf5x4";
        private string database = "fridai_dk_db";
        private string connString = "Server=mysql90.unoeuro.com;uid=fridai_dk;pwd=2pmkf5x4;database=fridai_dk_db";

        public int PostReviewer(Reviewer reviewer)
        {
            string query = $"INSERT INTO `Reviewer` (`Id`, `Gender`, `Age`, `PostalCode`) " +
                           $"VALUES ('{null}','{reviewer.Gender}','{reviewer.Age}','{reviewer.PostalCode}');";
            
            using (var connection = new MySqlConnection(connString))
            {
                connection.Execute(query);
                var newReviewer = connection.Query<Reviewer>("Select * FROM Reviewer ORDER BY Id DESC LIMIT 1").ToList();
                return newReviewer.Last().Id;
            }
        }
    }
}