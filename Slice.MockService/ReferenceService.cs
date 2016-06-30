using System.Collections.Generic;
using Slice.Data;
using Slice.MockService.DataProvider;
using Slice.Service.Contract;

namespace Slice.MockService
{
    public class ReferenceService : BaseService, IReferenceService
    {
        public ReferenceInfoDto GetReference(string alias, object languageId)
        {
            return ReferenceDataProvider.MockByAlias(alias);
        }

        public IEnumerable<SubjectInfoDto> GetAttachedSubjects(object refId, int subitemId, int pageIndex, int pageSize, object languageId)
        {
            return DucDataProvider.MockAttachedSubjectsWithPagination(refId, pageIndex, pageSize);
        }

        public IEnumerable<SubjectInfoDto> GetSubjectsByCategory(object categoryId, int templateId, int pageIndex, int pageSize, object languageId)
        {
            return DucDataProvider.MockAttachedSubjectsWithPagination(categoryId, pageIndex, pageSize);
        }

        public IEnumerable<SubjectInfoDto> GetSubjectsByKeyword(object keywordId, int templateId, int pageIndex, int pageSize, object languageId)
        {
            return DucDataProvider.MockAttachedSubjectsWithPagination(keywordId, pageIndex, pageSize);
        }

        public IEnumerable<SubjectInfoDto> GetSubjectsBySearch(string term, string subjectType, int pageIndex, int pageSize, object languageId)
        {
            throw new System.NotImplementedException();
        }
    }
}
