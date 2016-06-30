using System.Collections.Generic;
using System.Linq;
using Slice.Data;

namespace Slice.Web.Models
{
    public class ReferenceKeywordsViewModel
    {
        public IList<ReferenceKeywordInfoDto> KeywordList { get; set; }

        public ReferenceKeywordsViewModel(ReferenceInfoDto reference)
        {
            if (reference.ReferenceKeywords.Any())
            {
                KeywordList = reference.ReferenceKeywords.OrderBy(o => o.KeywordName).ToList();
            }
            else
            {
                KeywordList = new List<ReferenceKeywordInfoDto>();
            }
        }
    }
}