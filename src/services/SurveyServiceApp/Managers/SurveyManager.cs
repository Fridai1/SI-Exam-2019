using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using SurveyServiceApp.Models;

namespace SurveyServiceApp.Managers
{
    public class SurveyManager
    {
        private string hostName = "mysql90.unoeuro.com";
        private string username = "fridai_dk";
        private string pwd = "2pmkf5x4";
        private string database = "fridai_dk_db";
        private string connString = "Server=mysql90.unoeuro.com;uid=fridai_dk;pwd=2pmkf5x4;database=fridai_dk_db";

        public int PostSurvey(Survey survey)
        {
            string query = $"INSERT INTO `Survey` (`Id`, `Rating`, `Description`) " +
                           $"VALUES ('{null}','{survey.Rating}','{survey.Description}');";

            using (var connection = new MySqlConnection(connString))
            {
                connection.Execute(query);
                var newSurvey = connection.Query<Reviewer>("Select * FROM Survey ORDER BY Id DESC LIMIT 1").ToList();
                return newSurvey.Last().Id;
            }
        }
    }
}