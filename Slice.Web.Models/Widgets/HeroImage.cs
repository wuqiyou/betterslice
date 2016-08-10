using Slice.Data;
using SubjectEngine.Core;

namespace Slice.Web.Models.Widgets
{
    public class HeroImage : WidgetViewModel
    {
        public string ImageUrl { get; set; }
        public string ImageText { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public string Description { get; set; }

        public HeroImage()
        {
            ImageUrl = string.Empty;
            ImageText = string.Empty;
            Title = string.Empty;
            Href = string.Empty;
            Description = string.Empty;
        }

        public override void UpdateAsset(AssetModel asset)
        {
            asset.AddCSSPath("~/Content/widgets/heroImage.css");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.HeroImageBlock.Image))
            {
                ImageUrl = referenceInfo.ValuesDic[BlockRegister.HeroImageBlock.Image].ValueUrl;
                ImageText = referenceInfo.ValuesDic[BlockRegister.HeroImageBlock.Image].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.HeroImageBlock.Title))
            {
                Title = referenceInfo.ValuesDic[BlockRegister.HeroImageBlock.Title].ValueText;
                Href = referenceInfo.ValuesDic[BlockRegister.HeroImageBlock.Title].ValueUrl;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.HeroImageBlock.Description))
            {
                Description = referenceInfo.ValuesDic[BlockRegister.HeroImageBlock.Description].ValueHtml;
            }
        }
    }
}