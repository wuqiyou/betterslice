using System.Collections.Generic;
using System.Linq;
using Slice.Data;
using SubjectEngine.Core;

namespace Slice.Web.Models
{
    public class DynamicWidgetViewModel : WidgetViewModel
    {
        public IList<DucViewModel> Ducs { get; set; }

        public DynamicWidgetViewModel()
        {
            Ducs = new List<DucViewModel>();
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            foreach (SubitemInfoDto subitem in BlockInfo.Subitems)
            {
                DucViewModel duc = new DucViewModel { DucId = subitem.SubitemId, DucType = subitem.DucType };
                Ducs.Add(duc);
                if (subitem.DucType != DucTypes.Grid)
                {
                    DucValueDto value = null;
                    if (referenceInfo.ValuesDic.ContainsKey(subitem.SubitemId))
                    {
                        value = referenceInfo.ValuesDic[subitem.SubitemId];
                    }
                    duc.DucValue = value;
                }
                else
                {
                    if (subitem.Grid != null)
                    {
                        GridViewModel grid = new GridViewModel();
                        grid.ReferenceId = referenceInfo.ReferenceId;
                        grid.Grid = subitem.Grid;
                        grid.GridRows = referenceInfo.GridRows.Where(o => object.Equals(o.GridId, subitem.Grid.Id)).OrderByDescending(o => o.Id);
                        duc.Grid = grid;
                    }
                }
            }
        }
    }
}