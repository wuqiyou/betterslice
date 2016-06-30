using System.Web.Mvc;
using System.Web.Routing;
using Slice.Web.Common;
using Slice.Web.Controllers;

namespace Slice.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*allImgs}", new { allImgs = @".*\.(png|gif|jpg|jpeg)(/.*)?" });

            routes.MapRoute(
                name: "Review",
                url: "Riview/{action}",
                defaults: new { controller = ReviewController.ControllerName },
                namespaces: new[] { "Slice.Web.Controllers" }
            );
            routes.MapRoute(
                name: "ContactUs",
                url: "Contact/{action}",
                defaults: new { controller = ContactController.ControllerName },
                namespaces: new[] { "Slice.Web.Controllers" }
            );
            if (WebContext.Current.IsMultiLanguageSupported)
            {
                routes.MapRoute(
                    name: "ekPages",
                    url: "{culture}/{*urlAlias}",
                    defaults: new { culture = UrlParameter.Optional, controller = "Default", action = "Index", urlAlias = "home" },
                    namespaces: new[] { "Slice.Web.Controllers" }
                );
            }
            else
            {
                routes.MapRoute(
                    name: "Search",
                    url: "Search/{action}",
                    defaults: new { controller = "Search", action = "Index" },
                    namespaces: new[] { "Slice.Web.Controllers" }
                );
                routes.MapRoute(
                    name: "RecipeByCategory",
                    url: "recipe/category/{category}",
                    defaults: new { controller = "Recipe", action = "Category" },
                    namespaces: new[] { "Slice.Web.Controllers" }
                );
                routes.MapRoute(
                    name: "RecipeByKeyword",
                    url: "recipe/keyword/{keyword}",
                    defaults: new { controller = "Recipe", action = "Keyword" },
                    namespaces: new[] { "Slice.Web.Controllers" }
                );
                routes.MapRoute(
                    name: "TemplatePages",
                    url: "{*urlAlias}",
                    defaults: new { controller = "Default", action = "Index", urlAlias = "home" },
                    namespaces: new[] { "Slice.Web.Controllers" }
                );
            }

            // Leave this route for some child actions
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Slice.Web.Controllers" }
            );
        }
    }
}