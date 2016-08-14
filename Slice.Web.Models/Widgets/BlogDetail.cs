using Slice.Data;
using Slice.Web.Models.Entity;
using SubjectEngine.Core;
using System;
using System.Text;

namespace Slice.Web.Models.Widgets
{
    public class BlogDetail : WidgetViewModel, IMetadataProvider
    {
        public Article Article { get; set; }

        public BlogDetail()
        {
            Article = new Article();
        }

        public override void UpdateAsset(AssetModel asset)
        {
            asset.AddCSSPath("~/Content/widgets/blogDetail.css");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.BlogDetail.Title))
            {
                Article.Title = referenceInfo.ValuesDic[BlockRegister.BlogDetail.Title].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.BlogDetail.Content))
            {
                Article.Content = referenceInfo.ValuesDic[BlockRegister.BlogDetail.Content].ValueHtml;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.BlogDetail.Abstract))
            {
                Article.Abstract = referenceInfo.ValuesDic[BlockRegister.BlogDetail.Abstract].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.BlogDetail.Image))
            {
                Article.ImageUrl = referenceInfo.ValuesDic[BlockRegister.BlogDetail.Image].ValueUrl;
            }
            StringBuilder subtitle = new StringBuilder();
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.BlogDetail.Author))
            {
                subtitle.Append(referenceInfo.ValuesDic[BlockRegister.BlogDetail.Author].ValueText);
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.BlogDetail.IssuedTime))
            {
                DateTime? value = referenceInfo.ValuesDic[BlockRegister.BlogDetail.IssuedTime].ValueDate;
                if (value.HasValue)
                {
                    subtitle.AppendFormat(" | {0}", value.Value.ToShortDateString());
                }
            }
            Article.Subtitle = subtitle.ToString();
        }

        public void UpdateMetadata(MetadataModel metadata)
        {
            if (!metadata.Title.TrimHasValue())
            {
                metadata.Title = Article.Title;
            }
            if (!metadata.Description.TrimHasValue())
            {
                if (Article.Abstract.TrimHasValue())
                {
                    metadata.Description = Article.Abstract;
                }
                else if (Article.Content.TrimHasValue())
                {
                    metadata.Description = Article.Content.Substring(0, 300).RemoveHTML();
                }
                else
                {
                    metadata.Description = Article.Title;
                }
            }
            if (!metadata.OGImage.TrimHasValue())
            {
                metadata.OGImage = Article.ImageUrl;
            }
        }
    }
}