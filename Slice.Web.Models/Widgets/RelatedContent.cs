using Slice.Data;
using System.Collections.Generic;
using System.Linq;

namespace Slice.Web.Models.Widgets
{
    public class RelatedContent : WidgetViewModel
    {
        public string Title { get; set; }
        public CardViewViewModel CardViewViewModel { get; set; }

        public RelatedContent()
        {
            Title = "Related content";
        }

        public override void UpdateAsset(AssetModel asset)
        {
            asset.AddCSSPath("~/Content/widgets/relatedContent.css");
            asset.AddCSSPath("~/Content/objects/cardView.css");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.RelatedSubjects != null)
            {
                IList<SubjectInfoDto> items = referenceInfo.RelatedSubjects.Where(o => !object.Equals(o.ReferenceId, referenceInfo.ReferenceId)).ToList();
                // Set flag
                HasValue = items.Count > 0;
                CardViewViewModel = new CardViewViewModel(items);
            }
        }
    }
}