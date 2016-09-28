using Slice.Core;
using Slice.Data;
using Slice.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Slice.Web.Models
{
    public class CategoryPageViewModel : PageViewModelBase
    {
        private string Category { get; set; }
        public IEnumerable<SubjectInfoDto> Items { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }

        public CategoryPageViewModel(string category, IEnumerable<SubjectInfoDto> items, Uri requestedUrl, int pageIndex, int pageSize, LanguageDto language)
            : base(requestedUrl, language)
        {
            Category = category;
            Items = items;
            int totalCount = items.Any() ? items.First<SubjectInfoDto>().TotalCount : 0;
            if (totalCount > 0)
            {
                PaginationViewModel = new PaginationViewModel(totalCount, pageIndex, pageSize, WebContext.Current.PagerWindowSize);
                PaginationViewModel.ShowTotal = false;
            }
        }

        protected override void PopulateMetadata()
        {
            base.PopulateMetadata();

            Metadata.Title = Category + " Recipes";
        }

        protected override void UpdateAsset()
        {
            base.UpdateAsset();

            AssetModel.AddCSSPath("~/Content/objects/cardView.css");
            if (PaginationViewModel != null && !PaginationViewModel.IsSuppressed)
            {
                AssetModel.AddCSSPath("~/Content/objects/pagination.css");
            }
        }

        protected override void PopulateAdManager()
        {
            base.PopulateAdManager();

            // Register 2 BigBox ads
            AdUnits.Add(AdManagerModel.Register(AdType.BigBox));
            AdUnits.Add(AdManagerModel.Register(AdType.BigBox));
        }
    }
}