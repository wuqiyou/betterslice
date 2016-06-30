using Framework.Component;
using Slice.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Slice.Service.Contract
{
    public interface IReviewService : IBaseService
    {
        IEnumerable<ReviewDto> GetReviews(int refId, bool isPublished = false);
        IFacadeUpdateResult<ReviewData> SaveReview(ReviewDto instance, int refId);
    }
}
