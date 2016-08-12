using Slice.Data;
using SubjectEngine.Core;

namespace Slice.Web.Models.Widgets
{
    public class FeaturedContent : WidgetViewModel
    {
        public string Title { get; set; }
        public CardViewViewModel CardViewViewModel { get; set; }

        public FeaturedContent()
        {
            Title = string.Empty;
        }

        public override void UpdateAsset(AssetModel asset)
        {
            asset.AddCSSPath("~/Content/objects/cardView.css");
            asset.AddCSSPath("~/Content/widgets/featuredContent.css");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.FeaturedContent.Title))
            {
                DucValueDto value = referenceInfo.ValuesDic[BlockRegister.FeaturedContent.Title];
                Title = value.ValueText;
            }

            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.FeaturedContent.FeatureItemCollection))
            {
                DucValueDto value = referenceInfo.ValuesDic[BlockRegister.FeaturedContent.FeatureItemCollection];
                if (value.AttachedSubjects != null && value.AttachedSubjects.Count > 0)
                {
                    HasValue = true;
                    CardViewViewModel = new CardViewViewModel(value.AttachedSubjects);
                }
            }
        }
    }
}