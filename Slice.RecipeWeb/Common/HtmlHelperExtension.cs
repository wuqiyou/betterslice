﻿
namespace System.Web.Mvc
{
    public static class HtmlHelperExtension
    {
        public static string LocalizeHref(this HtmlHelper htmlHelper, string href)
        {
            string returnUrl = string.Empty;
            if (!string.IsNullOrEmpty(href))
            {
                returnUrl = string.Format("/{0}", href.TrimStart('/'));
            }
            return returnUrl;
        }
    }
}