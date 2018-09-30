using Slice.Data;

namespace Slice.Web.Common.Helpers
{
    public static class MenuItemHelper
    {
        public static bool IsCurrent(string navigateUrl, string requestPath, LanguageDto currentLanguage)
        {
            if (WebContext.Current.IsMultiLanguageSupported)
            {
                string fullNavigateUrl = string.Format("/{0}{1}", currentLanguage.Culture, navigateUrl);
                return requestPath.StartsWith(fullNavigateUrl);
            }
            else
            {
                return requestPath.StartsWith(navigateUrl);
            }
        }
    }
}
