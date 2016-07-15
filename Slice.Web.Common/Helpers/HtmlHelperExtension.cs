using Slice.Web.Common;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtension
    {
        public static string FullImageUrl(this HtmlHelper htmlHelper, string url)
        {
            if (!string.IsNullOrEmpty(url) && !url.StartsWith("http"))
            {
                url = string.Format("/{0}/{1}", WebContext.Current.ImageServeRoot, url.TrimStart('/'));
            }
            return url;
        }

        public static string AbsoluteFullImageUrl(this HtmlHelper htmlHelper, string url)
        {
            Controller controller = htmlHelper.ViewContext.Controller as Controller;
            string returnUrl = htmlHelper.FullImageUrl(url);
            if (!string.IsNullOrEmpty(returnUrl) && !returnUrl.StartsWith("http"))
            {
                returnUrl = String.Format("{0}://{1}{2}", controller.Request.Url.Scheme, controller.Request.Url.Host, returnUrl);
            }
            return returnUrl;
        }

        public static string AbsoluteFullUrl(this HtmlHelper htmlHelper, string url)
        {
            if (!string.IsNullOrEmpty(url) && !url.StartsWith("http"))
            {
                Controller controller = htmlHelper.ViewContext.Controller as Controller;
                var host = htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.Host;
                url = String.Format("{0}://{1}{2}", controller.Request.Url.Scheme, controller.Request.Url.Host, url);
            }
            return url;
        }
    }
}