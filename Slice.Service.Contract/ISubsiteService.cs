using System.Collections.Generic;
using Slice.Data;

namespace Slice.Service.Contract
{
    public interface ISubsiteService : IBaseService
    {
        IEnumerable<SubsiteBriefDto> GetSubsites(bool isPublished = false);
        SubsiteInfoDto GetSubsiteInfo(object instanceId);
    }
}
