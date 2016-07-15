using Slice.Data;
using System;

namespace Slice.Web.Models
{
    public class WidgetViewModel
    {
        public BlockInfoDto BlockInfo { get; set; }
        public LanguageDto CurrentLanguage { get; set; }
        public Uri RequestedUrl { get; set; }
        public int? PageIndex { get; set; }
        public string ZoneStyle { get; set; }

        public bool HasValue { get; set; }

        public WidgetViewModel()
        {
        }

        public virtual void Populate(ReferenceInfoDto referenceInfo)
        {
        }

        public virtual void UpdateAsset(AssetModel asset)
        {
        }
    }
}