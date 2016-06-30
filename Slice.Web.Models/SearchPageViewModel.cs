using System.Collections.Generic;
using Slice.Data;
using Slice.Web.Common;

namespace Slice.Web.Models
{
    public class SearchPageViewModel : PageViewModelBase
    {
        private string Keyword { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<SubjectInfoDto> Items { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }

        public SearchPageViewModel(string keyword, SearchResultDto searchResult, string requestedUrl, LanguageDto language)
            : base(requestedUrl, language)
        {
            Keyword = keyword;
            Items = searchResult.Records;
            TotalCount = searchResult.TotalRecords;


            PaginationViewModel = new PaginationViewModel(TotalCount, CurrentPage, WebContext.Current.MaxPageSize, WebContext.Current.PagerWindowSize);
        }

        protected override void PopulateMetadata()
        {
            base.PopulateMetadata();

            Metadata.Title = "Search by " + Keyword;
        }

        protected override void UpdateAsset()
        {
            base.UpdateAsset();

            AssetModel.AddCSSPath("~/Content/objects/pagination.css");
        }
    }
}