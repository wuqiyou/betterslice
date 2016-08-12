using System.Collections.Generic;
using System.Linq;
using Slice.Data;
using Slice.Web.Common;
using System;

namespace Slice.Web.Models
{
    public class KeywordPageViewModel : PageViewModelBase
    {
        private string Keyword { get; set; }
        public CardViewViewModel CardViewViewModel { get; set; }

        public KeywordPageViewModel(string keyword, IEnumerable<SubjectInfoDto> items, Uri requestedUrl, int pageIndex, int pageSize, LanguageDto language)
            : base(requestedUrl, language)
        {
            Keyword = keyword;
            int totalCount = items.Any() ? items.First<SubjectInfoDto>().TotalCount : 0;

            CardViewViewModel = new CardViewViewModel(items, true, totalCount, pageIndex, pageSize, WebContext.Current.PagerWindowSize);
        }

        protected override void PopulateMetadata()
        {
            base.PopulateMetadata();

            Metadata.Title = Keyword + " Recipes";
        }

        protected override void UpdateAsset()
        {
            base.UpdateAsset();

            AssetModel.AddCSSPath("~/Content/objects/cardView.css");
            AssetModel.AddCSSPath("~/Content/objects/pagination.css");
        }
    }
}