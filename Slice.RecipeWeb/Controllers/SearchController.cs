using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Slice.Core;
using Slice.Data;
using Slice.Web.Common;
using Slice.Web.Models;

namespace Slice.RecipeWeb.Controllers
{
    public class SearchController : ContentBaseController
    {
        public const string ControllerName = "Search";
        public const string IndexAction = "Index";
        public const string SubmitFormAction = "SubmitForm";

        public ActionResult Index(string q)
        {
            int pageIndex = 1;
            int pageSize = WebContext.Current.MaxPageSize;
            string did = "";

            IEnumerable<SubjectInfoDto> result = Service.GetSubjectsBySearch(q, did, pageIndex, pageSize, CurrentLanguage.Id);
            SearchPageViewModel model = new SearchPageViewModel(q, new SearchResultDto(), HttpContext.Request.RawUrl, CurrentLanguage);
            model.Populate();

            return View(model);
        }

        [HttpPost]
        public ActionResult SubmitForm(FormCollection formData)
        {
            string key = formData["q"].Trim();
            return RedirectToAction(IndexAction, new { q = key });
        }
    }
}
