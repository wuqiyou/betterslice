using Slice.Data;
using Slice.Web.Models.Entity;
using SubjectEngine.Core;

namespace Slice.Web.Models.Widgets
{
    public class RotatorWidget : WidgetViewModel
    {
        public Rotator RotatorEntity { get; set; }
        public string RotatorUniqueId { get; private set; }

        public RotatorWidget()
        {
            RotatorEntity = new Rotator();
            RotatorEntity.Title = string.Empty;
        }

        public override void UpdateAsset(AssetViewModel asset)
        {
            asset.AddCSSPath("~/Content/objects/flexslider.css");
            asset.AddCSSPath("~/Content/widgets/rotator.css");
            asset.AddTailJSPath("~/Scripts/vendor/jquery.flexslider.js");
            asset.AddTailJSPath("~/Scripts/objects/rotator.js");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.Rotator.RotatorItemCollection))
            {
                DucValueDto value = referenceInfo.ValuesDic[BlockRegister.Rotator.RotatorItemCollection];
                RotatorUniqueId = string.Format("rotator{0}", value.Id);
                foreach (SubjectInfoDto dto in value.AttachedSubjects)
                {
                    RotatorItem item = new RotatorItem();
                    RotatorEntity.Items.Add(item);
                    item.Title = dto.Title;
                    item.Abstract = dto.Description;
                    item.TargetUrl = dto.UrlAlias;
                    item.ImageUrl = dto.ImageUrl;
                }
            }

            //SubitemInfoDto subitem = Block.Subitems.SingleOrDefault(o => object.Equals(o.SubitemId, BlockRegister.Rotator.RotatorItemCollection));
            //object gridId = null;
            //if (subitem != null && subitem.Grid != null)
            //{
            //    gridId = subitem.Grid.Id;
            //}
            //if (Reference.GridRows != null)
            //{
            //    foreach (GridRowDto row in Reference.GridRows.Where(o => object.Equals(o.GridId, gridId)))
            //    {
            //        RotatorItem item = new RotatorItem();
            //        RotatorEntity.Items.Add(item);
            //        DucValueDto valueLink = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, GridRegister.RotatorItemGrid.Col_Hyperlink));
            //        if (valueLink != null)
            //        {
            //            item.Title = valueLink.ValueText;
            //            item.TargetUrl = valueLink.ValueUrl;
            //        }
            //        DucValueDto valueAbstract = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, GridRegister.RotatorItemGrid.Col_Abstract));
            //        if (valueAbstract != null)
            //        {
            //            item.Abstract = valueAbstract.ValueText;
            //        }
            //        DucValueDto valueImage = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, GridRegister.RotatorItemGrid.Col_Image));
            //        if (valueImage != null)
            //        {
            //            item.ImageUrl = valueImage.ValueUrl;
            //        }
            //    }
            //}
            HasValue = RotatorEntity.Items != null && RotatorEntity.Items.Count > 0;
        }
    }
}