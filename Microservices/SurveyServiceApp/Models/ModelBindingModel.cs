using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SurveyServiceApp.Managers;

namespace SurveyServiceApp.Models
{
    [BindProperties]
    public class ModelBindingModel : PageModel
    {
        public string ReviewGender { get; set; }
        public string ReviewAge { get; set; }
        public int ReviewPostalCode { get; set; }
        public int ReviewRating { get; set; }
        public string ReviewDescription { get; set; }


        public void OnPostReview()
        {


            //LocationManager locationManager = new LocationManager();
            //await locationManager.PostLocation(int.Parse(postalCode), 1);

            ReviewerManager reviewerManager = new ReviewerManager();
            Reviewer reviewer = new Reviewer(ReviewGender, ReviewAge, ReviewPostalCode);
            reviewerManager.PostReviewer(reviewer);

            SurveyManager surveyManager = new SurveyManager();
            Survey survey = new Survey() { Id = 1, Rating = ReviewRating, Description = ReviewDescription };
            surveyManager.PostSurvey(survey);

            RedirectToPage("/#");
        }
    }
}