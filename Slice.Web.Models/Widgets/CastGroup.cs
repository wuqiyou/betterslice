using Slice.Data;
using Slice.Web.Models.Entity;
using SubjectEngine.Core;
using System.Collections.Generic;
using System.Linq;

namespace Slice.Web.Models.Widgets
{
    public class CastGroup : WidgetViewModel
    {
        public string Title { get; set; }
        public List<Cast> Casts { get; set; }

        public CastGroup()
        {
            Casts = new List<Cast>();
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.CastGroup.Title))
            {
                DucValueDto value = referenceInfo.ValuesDic[BlockRegister.CastGroup.Title];
                Title = value.ValueText;
            }
            if (referenceInfo.GridRows != null)
            {
                foreach (GridRowDto row in referenceInfo.GridRows)
                {
                    Cast item = new Cast();
                    Casts.Add(item);
                    DucValueDto valueTitle = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.CastGrid.Col_MemberId));
                    if (valueTitle != null)
                    {
                        item.MemberId = valueTitle.ValueText;
                    }
                }
            }
        }
    }
}