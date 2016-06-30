using System.Collections.Generic;
using System.Text;
using Slice.Data;
using Slice.Web.Common;
using Slice.Web.Common.Helpers;

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

        public static string LocalizeHref(this HtmlHelper htmlHelper, string href)
        {
            string returnUrl = string.Format("/{0}", href);
            return returnUrl;
        }

        public static string AbsoluteFullUrl(this HtmlHelper htmlHelper, string url)
        {
            Controller controller = htmlHelper.ViewContext.Controller as Controller;
            var host = htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.Host;
            return String.Format("{0}://{1}{2}", controller.Request.Url.Scheme, controller.Request.Url.Host, url);
        }

        public static string LocalizeHrefFromAdmin(this HtmlHelper htmlHelper, string href)
        {
            if (WebContext.Current.IsMultiLanguageSupported)
            {
                return string.Format("/{0}/{1}", WebContext.Current.DefaultLanguage.Culture, href);
            }
            else
            {
                return string.Format("/{0}", href);
            }
        }

        public static string LocalizeAdminHref(this HtmlHelper htmlHelper, string href)
        {
            return string.Format("/{0}", href);
        }

        public static string GetClientId(this HtmlHelper htmlHelper, object id)
        {
            return DucHelper.GetClientId(id);
        }

        public static string ComposeStringCategoryText(this HtmlHelper htmlHelper, IEnumerable<CategoryDto> categorys)
        {
            StringBuilder CategorysText = new StringBuilder();
            categorys.ForAll(o => CategorysText.AppendFormat("{0},", o.CategoryText));
            return CategorysText.ToString();
        }

        public static string ComposeStringCategoryId(this HtmlHelper htmlHelper, IEnumerable<CategoryDto> categorys)
        {
            StringBuilder CategorysText = new StringBuilder();
            categorys.ForAll(o => CategorysText.AppendFormat("{0},", o.Id));
            return CategorysText.ToString();
        }

        public static string ComposeStringKeywordText(this HtmlHelper htmlHelper, IEnumerable<ReferenceKeywordInfoDto> keywords)
        {
            StringBuilder text = new StringBuilder();
            keywords.ForAll(o => text.AppendFormat("{0},", o.KeywordName));
            return text.ToString();
        }
    }
}