using Microsoft.Practices.ServiceLocation;
using Slice.Service.Contract;
using Slice.Web.Common;
using Slice.Web.Common.Helpers;
using System;
using System.Web.Mvc;

namespace Slice.RecipeWeb.Controllers
{
    public class ContentBaseController : BaseController
    {
        protected IReferenceService Service { get; set; }

        protected int? PageIndex
        {
            get
            {
                return Request.QueryString[WebContext.Current.PagingQueryString].TryToParse<int>();
            }
        }

        public ContentBaseController()
        {
            Service = ServiceLocator.Current.GetInstance<IReferenceService>();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var routeData = filterContext.Controller.ControllerContext.RouteData.Values;
            // Setup current Language
            if (WebContext.Current.IsMultiLanguageSupported)
            {
                object queryCulture;
                if (routeData.TryGetValue("culture", out queryCulture))
                {
                    string cultureName = queryCulture.ToString();
                    SetCurrentLanguage(cultureName, true);
                }
                else
                {
                    string language = CookieHelper.ReadCookie(KeyLanguageCookie);
                    if (language != null)
                    {
                        SetCurrentLanguage(language, false);
                    }
                }
            }
            else
            {
                CurrentLanguage = WebContext.Current.DefaultLanguage;
            }
        }

        protected void SetCurrentLanguage(string language, bool updateCookie = true)
        {
            if (WebContext.Current.LanguageDicByCulture.ContainsKey(language))
            {
                CurrentLanguage = WebContext.Current.LanguageDicByCulture[language];
            }
            else
            {
                CurrentLanguage = WebContext.Current.DefaultLanguage;
            }
            if (updateCookie)
            {
                CookieHelper.WriteCookie(KeyLanguageCookie, CurrentLanguage.Culture);
            }
            CurrentUserContext.CurrentLanguage = CurrentLanguage;
        }
    }
}
