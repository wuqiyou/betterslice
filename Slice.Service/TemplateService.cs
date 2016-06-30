using Framework.UoW;
using Slice.Data;
using Slice.DataConverter;
using Slice.Registry;
using Slice.Service.Contract;
using SubjectEngine.Component;

namespace Slice.Service
{
    public class TemplateService : BaseService, ITemplateService
    {
        public TemplateInfoDto GetTemplate(object templateId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                uow.BeginTransaction();
                TemplateFacade facade = new TemplateFacade(uow);
                TemplateInfoDto result = facade.GetTemplateInfo(templateId, new TemplateInfoConverter());
                return result;
            }
        }
    }
}
