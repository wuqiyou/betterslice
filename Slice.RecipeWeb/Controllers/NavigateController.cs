using System.Collections.Generic;
using System.Web.Mvc;
using Slice.Data;
using Slice.Web.Common;
using Slice.Web.Models;

namespace Slice.RecipeWeb.Controllers
{
    public class NavigateController : BaseController
    {
        public const string ControllerName = "Navigate";
        public const string MainMenuAction = "MainMenu";

        public NavigateController()
        {
            CurrentLanguage = CurrentUserContext.CurrentLanguage;
        }

        public PartialViewResult MainMenu()
        {
            string urlAlias = Request.RawUrl.TrimStart('/');
            NavigationModel model = new NavigationModel(WebContext.Current.HeaderMenus, CurrentLanguage);
            return PartialView(model);
        }
    }
}
