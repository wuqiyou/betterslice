using System.Collections.Generic;
using Slice.Data;

namespace Slice.MockService.DataProvider
{
    public static class KeywordDataProvider
    {
        public static List<KeywordDto> MockKeywords()
        {
            List<KeywordDto> keywords = new List<KeywordDto>();
            for (int i = 1; i <= 6; i++)
            {
                KeywordDto keyword = new KeywordDto { Id = i, Name = string.Format("Keyword{0}", i), Slug = string.Format("Keyword{0}", i) };
                keywords.Add(keyword);
            }

            return keywords;
        }
    }
}
