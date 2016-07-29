using Slice.Data;
using SubjectEngine.Core;
using System;

namespace Slice.Web.Models.Widgets
{
    public class SubjectDetail : WidgetViewModel, IMetadataProvider
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string ImageText { get; set; }
        public string Description { get; set; }
        public string VideoId { get; set; }

        public SubjectDetail()
        {
            Title = string.Empty;
            ImageUrl = string.Empty;
            ImageText = string.Empty;
            Description = string.Empty;
            VideoId = string.Empty;
        }

        public override void UpdateAsset(AssetModel asset)
        {
            asset.AddCSSPath("~/Content/objects/subjectDetail.css");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.SubjectDetailBlock.Title))
            {
                Title = referenceInfo.ValuesDic[BlockRegister.SubjectDetailBlock.Title].ValueText;
            } 
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.SubjectDetailBlock.Image))
            {
                ImageUrl = referenceInfo.ValuesDic[BlockRegister.SubjectDetailBlock.Image].ValueUrl;
                ImageText = referenceInfo.ValuesDic[BlockRegister.SubjectDetailBlock.Image].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.SubjectDetailBlock.Description))
            {
                Description = referenceInfo.ValuesDic[BlockRegister.SubjectDetailBlock.Description].ValueHtml;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.SubjectDetailBlock.VideoId))
            {
                VideoId = referenceInfo.ValuesDic[BlockRegister.SubjectDetailBlock.VideoId].ValueText;
            }
        }

        public void UpdateMetadata(MetadataModel metadata)
        {
            if (!metadata.Title.TrimHasValue())
            {
                metadata.Title = Title;
            }
            if (!metadata.Description.TrimHasValue())
            {
                metadata.Description = Description;
            }
            if (!metadata.OGImage.TrimHasValue())
            {
                metadata.OGImage = ImageUrl;
            }
        }
    }
}