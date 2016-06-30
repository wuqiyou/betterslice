using System.Collections.Generic;
using Framework.UoW;
using Slice.Data;
using Slice.DataConverter;
using Slice.Registry;
using Slice.Service.Contract;
using SubjectEngine.Component;

namespace Slice.Service
{
    public class ReferenceService : BaseService, IReferenceService
    {
        public ReferenceInfoDto GetReference(string alias, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                ReferenceInfoDto detail = facade.GetReferenceInfo(alias, null, languageId, new ReferenceInfoConverter(languageId));
                return detail;
            }
        }

        public IEnumerable<SubjectInfoDto> GetAttachedSubjects(object refId, int subitemId, int pageIndex, int pageSize, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                List<SubjectInfoDto> dtoList = facade.GetAttachedSubjects(refId, subitemId, pageIndex, pageSize, null, languageId, new SubjectInfoConverter());
                return dtoList;
            }
        }

        public IEnumerable<SubjectInfoDto> GetSubjectsByCategory(object categoryId, int templateId, int pageIndex, int pageSize, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                List<SubjectInfoDto> dtoList = facade.GetSubjectsByCategory(categoryId, templateId, pageIndex, pageSize, languageId, new SubjectInfoConverter());
                return dtoList;
            }
        }

        public IEnumerable<SubjectInfoDto> GetSubjectsByKeyword(object keywordId, int templateId, int pageIndex, int pageSize, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                List<SubjectInfoDto> dtoList = facade.GetSubjectsByKeyword(keywordId, templateId, pageIndex, pageSize, languageId, new SubjectInfoConverter());
                return dtoList;
            }
        }

        public IEnumerable<SubjectInfoDto> GetSubjectsBySearch(string key, string subjectType, int pageIndex, int pageSize, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                List<SubjectInfoDto> dtoList = new List<SubjectInfoDto>();
                return dtoList;
            }
        }
    }
}
