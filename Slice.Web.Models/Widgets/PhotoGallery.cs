using Slice.Data;
using Slice.Web.Models.Entity;
using SubjectEngine.Core;
using System;
using System.Linq;

namespace Slice.Web.Models.Widgets
{
    public class PhotoGallery : WidgetViewModel, IMetadataProvider
    {
        public Gallery Gallery { get; set; }

        public PhotoGallery()
        {
            Gallery = new Gallery();
        }

        public override void UpdateAsset(AssetModel asset)
        {
            asset.AddCSSPath("~/Content/objects/flexslider.css");
            asset.AddCSSPath("~/Content/objects/photoGallery.css");
            asset.AddTailJSPath("~/Scripts/vendor/jquery.flexslider.js");
            asset.AddTailJSPath("~/Scripts/objects/photoGallery.js");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.PhotoGallery.Title))
            {
                Gallery.Title = referenceInfo.ValuesDic[BlockRegister.PhotoGallery.Title].ValueText;
            } 
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.PhotoGallery.Subtitle))
            {
                Gallery.Subtitle = referenceInfo.ValuesDic[BlockRegister.PhotoGallery.Subtitle].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.PhotoGallery.Abstract))
            {
                Gallery.Abstract = referenceInfo.ValuesDic[BlockRegister.PhotoGallery.Abstract].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.PhotoGallery.ThumbnailUrl))
            {
                Gallery.ThumbnailUrl = referenceInfo.ValuesDic[BlockRegister.PhotoGallery.ThumbnailUrl].ValueUrl;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.PhotoGallery.RelatedGalleryList))
            {
                DucValueDto value = referenceInfo.ValuesDic[BlockRegister.PhotoGallery.RelatedGalleryList];
                // Exclude current reference
                Gallery.RelatedGalleries = value.AttachedSubjects.Where(o => !object.Equals(o.ReferenceId, referenceInfo.ReferenceId)).ToList();
            }

            SubitemInfoDto subitem = BlockInfo.Subitems.SingleOrDefault(o => object.Equals(o.SubitemId, BlockRegister.PhotoGallery.PhotosGrid));
            object photoGridId = null;
            if (subitem != null && subitem.Grid != null)
            {
                photoGridId = subitem.Grid.Id;
            }
            if (referenceInfo.GridRows != null)
            {
                int index = 0;
                foreach (GridRowDto row in referenceInfo.GridRows.Where(o => object.Equals(o.GridId, photoGridId)))
                {
                    Photo item = new Photo();
                    Gallery.Items.Add(item);
                    item.Index = index++;
                    item.Credit = string.Empty;
                    DucValueDto valueTitle = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.PhotoGrid.Col_Title));
                    if (valueTitle != null)
                    {
                        item.Title = valueTitle.ValueText;
                    }
                    DucValueDto valueSubTitle = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.PhotoGrid.Col_Subtitle));
                    if (valueSubTitle != null)
                    {
                        item.Subtitle = valueSubTitle.ValueText;
                    }
                    DucValueDto valueAbstract = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.PhotoGrid.Col_Abstract));
                    if (valueAbstract != null)
                    {
                        item.Abstract = valueAbstract.ValueText;
                    }
                    DucValueDto valueImage = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.PhotoGrid.Col_Image));
                    if (valueImage != null)
                    {
                        item.ImageUrl = valueImage.ValueUrl;
                    }                    
                }
            }

            HasValue = Gallery.Title.TrimHasValue()
                || Gallery.Abstract.TrimHasValue()
                || Gallery.ThumbnailUrl.TrimHasValue()
                || Gallery.Items.Count > 0;
        }

        public void UpdateMetadata(MetadataModel metadata)
        {
            if (!metadata.Title.TrimHasValue())
            {
                metadata.Title = Gallery.Title;
            }
            if (!metadata.Description.TrimHasValue())
            {
                if (Gallery.Abstract.TrimHasValue())
                {
                    metadata.Description = Gallery.Abstract;
                }
                else
                {
                    metadata.Description = Gallery.Title;
                }
            }
            if (!metadata.OGImage.TrimHasValue())
            {
                if (Gallery.ThumbnailUrl.TrimHasValue())
                {
                    metadata.OGImage = Gallery.ThumbnailUrl;
                }
                else if (Gallery.Items.Count > 0)
                {
                    metadata.OGImage = Gallery.Items[0].ImageUrl;
                }
            }
        }
    }
}