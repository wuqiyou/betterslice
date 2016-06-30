using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Framework.Unity;
using Framework.UoW;
using Microsoft.Practices.ServiceLocation;
using NLog;
using Slice.Registry;
using Slice.Web.Common;
using Slice.Web.Controllers;
using SubjectEngine.Configuration;

namespace Slice.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            InitUnity();
            InitFramework();
            InitWebContext();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void InitUnity()
        {
            IList<IUnityRegistry> registries = new List<IUnityRegistry>();
            registries.Add(new CoreRegistry());
            registries.Add(new SubjectEngineRepositoryRegistry());
            registries.Add(new SubjectEngineServiceRegistry());
            registries.Add(new WrapperServiceRegistry());
            UnityLibrary library = new UnityLibrary(registries);
            library.InitializeServiceLocator();
        }

        private void InitFramework()
        {
            IDataStoreManager storeManager = ServiceLocator.Current.GetInstance<IDataStoreManager>();
            EntityResolver entityResolver = ServiceLocator.Current.GetInstance<EntityResolver>();
            IBusinessObjectFactory factory = ServiceLocator.Current.GetInstance<IBusinessObjectFactory>();
            UnitOfWorkFactory.Instance.Initialize(storeManager, entityResolver, entityResolver, factory);
        }

        private void InitWebContext()
        {
            WebContext.Current.Initilize();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            LogExceptionMessage(ex);

            var controller = new ErrorController();
            var routeData = new RouteData();
            var action = "Index";

            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;

                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;

                    // others if any

                    default:
                        action = "Index";
                        break;
                }
            }

            var httpContext = ((MvcApplication)sender).Context;

            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var currentController = " ";
            var currentAction = " ";

            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            httpContext.ClearError();
            //httpContext.Response.Clear();
            //httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
            //httpContext.Response.TrySkipIisCustomErrors = true;
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;

            controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Request.Path.ToLower();
            // redirect home
            if (path == "/")
            {
                HttpCookie languageCookie = HttpContext.Current.Request.Cookies.Get(BaseController.KeyLanguageCookie);
                string language = languageCookie != null ? languageCookie.Value : WebContext.Current.DefaultLanguage.Culture;
                string newUrl = string.Empty;
                if (WebContext.Current.IsMultiLanguageSupported)
                {
                    newUrl = string.Format("/{0}", language);
                }
                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.Response.Redirect(newUrl, true);
                }
            }
            // redirect subsites to its default language & location
            if (WebContext.Current.IsMultiLanguageSupported)
            {
                if (path.EndsWith("/"))
                {
                    path = path.TrimEnd('/');
                }
                if (WebContext.Current.SubsiteRedirectDic.ContainsKey(path))
                {
                    string targetUrl = WebContext.Current.SubsiteRedirectDic[path];
                    if (!string.IsNullOrEmpty(targetUrl))
                    {
                        HttpContext.Current.Response.StatusCode = 301;
                        HttpContext.Current.Response.RedirectPermanent(targetUrl, true);
                    }
                }
            }
        }

        private void LogExceptionMessage(Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.ToString());
        }
    }
}