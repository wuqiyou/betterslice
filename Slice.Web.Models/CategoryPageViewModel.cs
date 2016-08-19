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
        public CardViewViewModel CardViewViewModel { get; set; }

        public CategoryPageViewModel(string category, IEnumerable<SubjectInfoDto> items, Uri requestedUrl, LanguageDto language)
            : base(requestedUrl, language)
        {
            Category = category;
            int totalCount = items.Any() ? items.First<SubjectInfoDto>().TotalCount : 0;

            CardViewViewModel = new CardViewViewModel(items);
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
            AssetModel.AddCSSPath("~/Content/objects/pagination.css");
        }
    }
}