using Slice.Web.Common;
using Slice.Web.Controllers;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtension
    {
        public static string LocalizeHref(this HtmlHelper htmlHelper, string href)
        {
            string returnUrl = string.Empty;
            if (WebContext.Current.IsMultiLanguageSupported)
            {
                BaseController controller = htmlHelper.ViewContext.Controller as BaseController;
                returnUrl = string.Format("/{0}/{1}", controller.CurrentLanguage.Culture, href.TrimStart('/'));
            }
            else
            {
                returnUrl = string.Format("/{0}", href.TrimStart('/'));
            }
            return returnUrl;
        }
    }
}