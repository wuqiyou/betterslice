using System.Collections.Generic;
using Slice.Data;

namespace Slice.Web.Models
{
    public class CardViewViewModel
    {
        public IEnumerable<SubjectInfoDto> Items { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }

        public CardViewViewModel(IEnumerable<SubjectInfoDto> items)
        {
            Items = items;
        }

        public CardViewViewModel(IEnumerable<SubjectInfoDto> items, bool showPagination, int totalCount, int currentPage, int pageSize = 10, int pagerWindowSize = 5)
        {
            Items = items;
            if (showPagination && totalCount > 0)
            {
                PaginationViewModel = new PaginationViewModel(totalCount, currentPage, pageSize, pagerWindowSize);
                PaginationViewModel.ShowTotal = false;
            }
        }
    }
}