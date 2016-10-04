using Slice.Core;
using Slice.Data;
using SubjectEngine.Core;

namespace Slice.Web.Models.Widgets
{
    public class AdWidget : WidgetViewModel
    {
        public AdType AdType { get; set; }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            // TODO: hard code as a BigBox, init AdType based on reference data later. 
            AdType = Core.AdType.BigBox;
        }

        public override void RegisterAds(AdManagerViewModel adManager)
        {
            AdUnits.Add(adManager.Register(AdType));
        }
    }
}