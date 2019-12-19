
namespace SurveyServiceApp.Models
{
    public enum ReviewerGender { Male, Female, Other }
    public enum ReviewerAge { TwentyToTwentyNine, ThirtyToThirtyNine, FortyToFortyNine, FiftyToFiftyNine, SixtyToSixtyNine, SeventyToSeventyNine }

    public class Reviewer
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public int PostalCode { get; set; }

        public Reviewer(string gender, string age, int postalCode)
        {
            Gender = gender;
            Age = age;
            PostalCode = postalCode;
        }

        public Reviewer()
        {

        }
    }
}