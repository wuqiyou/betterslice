using Slice.Data;
using SubjectEngine.Core;
using System;
using System.Web;

namespace Slice.Web.Models.Widgets
{
    public class YouTubeVideo : WidgetViewModel, IMetadataProvider
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public int AutoPlay { get; set; }

        public YouTubeVideo()
        {
            VideoId = string.Empty;
            Title = string.Empty;
            AutoPlay = 0;
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.YouTubeVideoBlock.VideoId))
            {
                VideoId = referenceInfo.ValuesDic[BlockRegister.YouTubeVideoBlock.VideoId].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.YouTubeVideoBlock.Title))
            {
                Title = referenceInfo.ValuesDic[BlockRegister.YouTubeVideoBlock.Title].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.YouTubeVideoBlock.Description))
            {
                Description = referenceInfo.ValuesDic[BlockRegister.YouTubeVideoBlock.Description].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.YouTubeVideoBlock.ThumbnailUrl))
            {
                ThumbnailUrl = referenceInfo.ValuesDic[BlockRegister.YouTubeVideoBlock.ThumbnailUrl].ValueUrl;
            }
            if (HttpContext.Current.Request.RawUrl.Contains("/video"))
            {
                AutoPlay = 1;
            }
        }

        public void UpdateMetadata(MetadataModel metadata)
        {
            if (!metadata.Title.TrimHasValue())
            {
                metadata.Title = Title;
            }
            if (!metadata.OGImage.TrimHasValue())
            {
                metadata.OGImage = ThumbnailUrl;
            }
        }
    }
}