using Slice.Data;
using SubjectEngine.Core;
using System.Collections.Generic;

namespace Slice.Web.Models.Widgets
{
    public class FeaturedContent : WidgetViewModel
    {
        public string Title { get; set; }
        public IEnumerable<SubjectInfoDto> Items { get; set; }

        public FeaturedContent()
        {
            Title = string.Empty;
        }

        public override void UpdateAsset(AssetViewModel asset)
        {
            asset.AddCSSPath("~/Content/widgets/featuredContent.css");
            asset.AddCSSPath("~/Content/objects/cardView.css");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            Title = GetValueText(referenceInfo, BlockRegister.FeaturedContent.Title);

            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.FeaturedContent.FeatureItemCollection))
            {
                DucValueDto value = referenceInfo.ValuesDic[BlockRegister.FeaturedContent.FeatureItemCollection];
                if (value.AttachedSubjects != null && value.AttachedSubjects.Count > 0)
                {
                    HasValue = true;
                    Items = value.AttachedSubjects;
                }
            }
        }
    }
}