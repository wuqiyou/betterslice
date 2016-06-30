using System.Collections.Generic;

namespace Slice.Data
{
    public class SearchResultDto
    {
        public int RecordsPerPage { get; set; }
        public int TotalRecords { get; set; }
        public IList<SubjectInfoDto> Records { get; set; }
    }
}
