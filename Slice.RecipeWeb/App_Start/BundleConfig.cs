using System.Web.Optimization;
using Slice.Web.Models;

namespace Slice.RecipeWeb
{
    public class BundleConfig
    {
        public static readonly string CSSBundles = "~/Content/css";
        public static readonly string HeadJSBundles = "~/bundles/headjs";
        public static readonly string TailJSBundles = "~/bundles/tailjs";

        public static void RegisterBundles(AssetViewModel asset)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.

            Bundle cssBundle = new StyleBundle(BundleConfig.CSSBundles);
            cssBundle.Include(
                "~/Content/site.css",
                "~/Content/objects/ad.css",
                "~/Content/objects/header.css",
                "~/Content/objects/footer.css",
                "~/Content/objects/genericBlock.css",
                "~/Content/objects/navigation.css",
                "~/Content/objects/comment.css",
                //"~/Content/objects/review.css",
                "~/Content/objects/socialLinks.css",
                "~/Content/objects/subsiteNav.css"
                );
            foreach (string path in asset.IncludeCSSPaths)
            {
                cssBundle.Include(path);
            }
            BundleTable.Bundles.Add(cssBundle);

            Bundle headJSBundle = new ScriptBundle(BundleConfig.HeadJSBundles);
            headJSBundle.Include(
                        "~/Scripts/vendor/modernizr-2.6.2.min.js",
                        "~/Scripts/vendor/responsive-nav.min.js");
            foreach (string path in asset.IncludeHeadJSPaths)
            {
                headJSBundle.Include(path);
            }
            BundleTable.Bundles.Add(headJSBundle);

            Bundle tailJSBundle = new ScriptBundle(BundleConfig.TailJSBundles);
            tailJSBundle.Include(
                        "~/Scripts/vendor/media.match.min.js",
                        "~/Scripts/vendor/enquire.js",
                        "~/Scripts/objects/header.js");
            foreach (string path in asset.IncludeTailJSPaths)
            {
                tailJSBundle.Include(path);
            }
            BundleTable.Bundles.Add(tailJSBundle);
            // Enable minification js to be bundled even in Debug mode
            BundleTable.EnableOptimizations = true;
        }
    }
}