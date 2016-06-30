using Slice.Data;
using Slice.Web.Models.Entity;
using SubjectEngine.Core;
using System.Collections.Generic;
using System.Linq;

namespace Slice.Web.Models.Widgets
{
    public class PhotoList : WidgetViewModel
    {
        public string Title { get; set; }
        public List<Photo> Items { get; set; }

        public PhotoList()
        {
            Title = string.Empty;
            Items = new List<Photo>();
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.PhotoList.Title))
            {
                Title = referenceInfo.ValuesDic[BlockRegister.PhotoList.Title].ValueText;
            }
            SubitemInfoDto subitem = BlockInfo.Subitems.SingleOrDefault(o => object.Equals(o.SubitemId, BlockRegister.PhotoList.PhotosGrid));
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
                    Items.Add(item);
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
        }
    }
}