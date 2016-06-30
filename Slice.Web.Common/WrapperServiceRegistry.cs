using Framework.Unity;
using Microsoft.Practices.Unity;
using Mock = Slice.MockService;
using Slice.Service.Contract;
using Slice.Service;

namespace Slice.Web.Common
{
    public class WrapperServiceRegistry : IUnityRegistry
    {
        public void Initialize(IUnityContainer container)
        {
            if (WebContext.Current.RunOnMockData)
            {
                container
                    .RegisterType<IReviewService, Mock.ReviewService>()
                    .RegisterType<IGeneralService, Mock.GeneralService>()
                    .RegisterType<ISubsiteService, Mock.SubsiteService>()
                    .RegisterType<IReferenceService, Mock.ReferenceService>()
                    .RegisterType<ITemplateService, Mock.TemplateService>();
            }
            else
            {
                container
                    .RegisterType<IReviewService, ReviewService>()
                    .RegisterType<IGeneralService, GeneralService>()
                    .RegisterType<ISubsiteService, SubsiteService>()
                    .RegisterType<IReferenceService, ReferenceService>()
                    .RegisterType<ITemplateService, TemplateService>();
            }
        }
    }
}
