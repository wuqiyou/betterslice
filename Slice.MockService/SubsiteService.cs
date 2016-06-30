using System;
using System.Collections.Generic;
using Slice.Data;
using Slice.Service.Contract;

namespace Slice.MockService
{
    public class SubsiteService : BaseService, ISubsiteService
    {
        public IEnumerable<SubsiteBriefDto> GetSubsites(bool isPublished = false)
        {
            List<SubsiteBriefDto> list = new List<SubsiteBriefDto>();
            SubsiteBriefDto fake = new SubsiteBriefDto();
            list.Add(fake);
            fake.Slug = "test-master1";
            fake.Name = "test master1";
            fake.BackColor = "#d0d";

            SubsiteBriefDto fake2 = new SubsiteBriefDto();
            list.Add(fake2);
            fake2.Slug = "test-master2";
            fake2.Name = "test master2";
            fake2.BackColor = "#C6C9C0";

            return list;
        }

        public SubsiteInfoDto GetSubsiteInfo(object instanceId)
        {
            throw new NotImplementedException();
        }
    }
}
