using System.Web.Mvc;

namespace Slice.Controllers.Common
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
