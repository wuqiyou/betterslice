using System.Collections.Generic;
using System.Web.Mvc;
using Framework.Component;
using Microsoft.Practices.ServiceLocation;
using Slice.Data;
using Slice.Service.Contract;
using Slice.Web.Models;
using SubjectEngine.Data;

namespace Slice.RecipeWeb.Controllers
{
    public class ReviewController : BaseController
    {
        public const string ControllerName = "Review";
        public const string SaveReviewAction = "SaveReview";
        public const string ReviewListAction = "ReviewList";

        private IReviewService Service { get; set; }

        public ReviewController()
        {
            Service = ServiceLocator.Current.GetInstance<IReviewService>();
        }

        public ViewResult SaveReview(int refId, ReviewViewModel review)
        {
            if (!string.IsNullOrEmpty(review.Content))
            {
                ReviewDto data = new ReviewDto();
                data.IssuedBy = review.Name;
                data.Content = review.Content;

                IFacadeUpdateResult<ReviewData> result = Service.SaveReview(data, refId);
                if (!result.IsSuccessful)
                {
                }
            }
            IEnumerable<ReviewDto> reviews = Service.GetReviews(refId);
            return View(ReviewListAction, reviews);
        }

        public PartialViewResult ReviewList(int refId)
        {
            IEnumerable<ReviewDto> reviews = Service.GetReviews(refId);
            return PartialView(reviews);
        }
    }
}
