using Slice.Core;
using Slice.Data;
using System;
using System.Collections.Generic;

namespace Slice.Web.Models
{
    public abstract class WidgetViewModel
    {
        public BlockInfoDto BlockInfo { get; set; }
        public LanguageDto CurrentLanguage { get; set; }
        public Uri RequestedUrl { get; set; }
        public int? PageIndex { get; set; }
        public string ZoneStyle { get; set; }
        public IList<AdUnitModel> AdUnits { get; set; }

        public bool HasValue { get; set; }

        public WidgetViewModel()
        {
            AdUnits = new List<AdUnitModel>();
        }

        public abstract void Populate(ReferenceInfoDto referenceInfo);

        public virtual void UpdateAsset(AssetModel asset)
        {
        }

        public virtual void RegisterAds(AdManagerModel adManager)
        {
        }
    }
}