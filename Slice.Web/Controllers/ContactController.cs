using System.Web.Mvc;
using Framework.Component;
using Microsoft.Practices.ServiceLocation;
using Slice.Data;
using Slice.Service.Contract;
using Slice.Web.Models.Widgets;
using SubjectEngine.Data;

namespace Slice.Web.Controllers
{
    public class ContactController : BaseController
    {
        public const string ControllerName = "Contact";
        public const string SaveFormAction = "SaveForm";
        public const string ThankYouAction = "ThankYou";

        private IReviewService Service { get; set; }

        public ContactController()
        {
            Service = ServiceLocator.Current.GetInstance<IReviewService>();
        }

        public ActionResult SaveForm(ContactUs formData)
        {
            if (ModelState.IsValid)
            {
                // Save data
                ReviewDto data = new ReviewDto();
                data.IssuedByEmail = formData.Email;
                data.IssuedBy = formData.Name;
                data.Content = formData.Content;

                IFacadeUpdateResult<ReviewData> result = Service.SaveReview(data, 0);
                string message = "Thank you. Your message was successfully sent.";
                if (!result.IsSuccessful)
                {
                    message = "Your message wasn't sent successfully. Can you try it later?";
                }
                return Json(new { isSuccessful = result.IsSuccessful, responseText = message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { statusCode = false, responseText = "Invalid input" }, JsonRequestBehavior.AllowGet);
        }
    }
}
