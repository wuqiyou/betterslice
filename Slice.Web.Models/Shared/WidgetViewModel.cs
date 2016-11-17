using Slice.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Slice.Web.Models
{
    public abstract class WidgetViewModel
    {
        public BlockInfoDto BlockInfo { get; set; }
        public LanguageDto CurrentLanguage { get; set; }
        public Uri RequestedUrl { get; set; }
        public int? PageIndex { get; set; }
        public string ZoneStyle { get; set; }
        public IList<AdUnitViewModel> AdUnits { get; set; }

        public bool HasValue { get; set; }

        public WidgetViewModel()
        {
            AdUnits = new List<AdUnitViewModel>();
        }

        public abstract void Populate(ReferenceInfoDto referenceInfo);

        public virtual void UpdateAsset(AssetViewModel asset)
        {
        }

        public virtual void RegisterAds(AdManagerViewModel adManager)
        {
        }

        protected SubitemInfoDto GetSubitemInfo(int subitemId)
        {
            return BlockInfo.Subitems.SingleOrDefault(o => object.Equals(o.SubitemId, subitemId));
        }

        protected string GetValueText(ReferenceInfoDto referenceInfo, int subitemId)
        {
            if (referenceInfo.ValuesDic.ContainsKey(subitemId))
            {
                return referenceInfo.ValuesDic[subitemId].ValueText;
            }

            SubitemInfoDto subitem = GetSubitemInfo(subitemId);
            return subitem != null ? subitem.DefaultValue : null;
        }
    }
}