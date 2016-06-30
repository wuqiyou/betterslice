using Framework.Component;
using Framework.UoW;
using Slice.Data;
using Slice.DataConverter;
using Slice.Registry;
using Slice.Service.Contract;
using SubjectEngine.Component;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Slice.Service
{
    public class SubsiteService : BaseService, ISubsiteService
    {
        public IEnumerable<SubsiteBriefDto> GetSubsites(bool isPublished = false)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                SubsiteFacade facade = new SubsiteFacade(uow);
                List<SubsiteBriefDto> result = facade.GetSubsites(new SubsiteBriefConverter(), isPublished);
                return result;
            }
        }

        public SubsiteInfoDto GetSubsiteInfo(object instanceId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                SubsiteFacade facade = new SubsiteFacade(uow);
                SubsiteInfoDto result = facade.GetSubsiteInfo(instanceId, new SubsiteInfoConverter());
                return result;
            }
        }
    }
}
