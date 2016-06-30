using System;
using System.Collections.Generic;
using Framework.Component;
using Slice.Data;
using Slice.Service.Contract;
using SubjectEngine.Data;

namespace Slice.MockService
{
    public class ReviewService : BaseService, IReviewService
    {
        public IEnumerable<ReviewDto> GetReviews(int refId, bool isPublished = false)
        {
            throw new NotImplementedException();
        }

        public IFacadeUpdateResult<ReviewData> SaveReview(ReviewDto instance, int refId)
        {
            throw new NotImplementedException();
        }
    }
}
