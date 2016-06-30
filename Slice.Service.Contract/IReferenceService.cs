using System.Collections.Generic;
using Slice.Data;

namespace Slice.Service.Contract
{
    public interface IReferenceService : IBaseService
    {
        ReferenceInfoDto GetReference(string alias, object languageId);
        IEnumerable<SubjectInfoDto> GetAttachedSubjects(object refId, int subitemId, int pageIndex, int pageSize, object languageId);
        IEnumerable<SubjectInfoDto> GetSubjectsByCategory(object categoryId, int templateId, int pageIndex, int pageSize, object languageId);
        IEnumerable<SubjectInfoDto> GetSubjectsByKeyword(object keywordId, int templateId, int pageIndex, int pageSize, object languageId);
        IEnumerable<SubjectInfoDto> GetSubjectsBySearch(string term, string subjectType, int pageIndex, int pageSize, object languageId);
    }
}
