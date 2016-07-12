using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Slice.Core;
using Slice.Data;
using Slice.Service.Contract;
using Slice.Web.Common;
using Slice.Web.Models;

namespace Slice.Web.Controllers
{
    public class DefaultController : ContentBaseController
    {
        public const string ControllerName = "Default";
        public const string DefaultAction = "Index";

        //[OutputCache(Duration = 300)]
        public ViewResult Index(string urlAlias)
        {
            try
            {
                if (urlAlias.EndsWith("/"))
                {
                    urlAlias = urlAlias.TrimEnd('/');
                }
                ReferenceInfoDto reference = null;
                if (CurrentLanguage.Id == WebContext.Current.DefaultLanguage.Id)
                {
                    reference = Service.GetReference(urlAlias, null);
                }
                else
                {
                    reference = Service.GetReference(urlAlias, CurrentLanguage.Id);
                }
                if (reference == null)
                {
                    throw new HttpException(404, string.Format("Page {0} doesn't exist.", HttpContext.Request.RawUrl));
                }

                int? pageIndex = HttpContext.Request.QueryString[WebContext.Current.PagingQueryString].TryToParse<int>();

                PageViewModel model = new PageViewModel(reference, HttpContext.Request.Url, pageIndex, CurrentLanguage);
                model.Populate();

                // Set info for subsite
                if (reference.SubsiteId != null)
                {
                    ISubsiteService subsiteService = ServiceLocator.Current.GetInstance<ISubsiteService>();
                    SubsiteInfoDto subsite = subsiteService.GetSubsiteInfo(reference.SubsiteId);
                    // Setup sub site parameters
                    model.PopulateSubsite(subsite);
                }

                return View(model);
            }
            catch
            {
                throw;
            }
        }
    }
}
