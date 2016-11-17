using Slice.Core;
using Slice.Data;
using SubjectEngine.Core;
using System;

namespace Slice.Web.Models.Widgets
{
    public class AdWidget : WidgetViewModel
    {
        public AdType AdType { get; set; }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            string adType = GetValueText(referenceInfo, BlockRegister.AdWidget.AdType);
            Enum.TryParse(
            // TODO: hard code as a BigBox, init AdType based on reference data later. 
            AdType = Core.AdType.BigBox;
        }

        public override void RegisterAds(AdManagerViewModel adManager)
        {
            AdUnits.Add(adManager.Register(AdType));
        }
    }
}