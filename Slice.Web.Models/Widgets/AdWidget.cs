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
        }
    }
}