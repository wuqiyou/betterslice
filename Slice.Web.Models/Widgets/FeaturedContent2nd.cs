using Slice.Data;
using SubjectEngine.Core;

namespace Slice.Web.Models.Widgets
{
    public class FeaturedContent2nd : WidgetViewModel
    {
        public string Title { get; set; }
        public CardViewViewModel CardViewViewModel { get; set; }

        public FeaturedContent2nd()
        {
            Title = string.Empty;
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.FeaturedContent2nd.Title))
            {
                DucValueDto value = referenceInfo.ValuesDic[BlockRegister.FeaturedContent2nd.Title];
                Title = value.ValueText;
            }

            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.FeaturedContent2nd.FeatureItemCollection))
            {
                DucValueDto value = referenceInfo.ValuesDic[BlockRegister.FeaturedContent2nd.FeatureItemCollection];
                if (value.AttachedSubjects != null && value.AttachedSubjects.Count > 0)
                {
                    HasValue = true;
                    CardViewViewModel = new CardViewViewModel(value.AttachedSubjects);
                }
            }
        }
    }
}