using Slice.Core;
using Slice.Web.Common;

namespace Slice.Web.Models
{
    public class AdUnitModel
    {
        public int Position { get; private set; }
        public string UniqureId { get; private set; }
        public string Sizes { get; private set; }
        public string CssClass { get; set; }

        public AdUnitModel(AdType type, int position, string cssClass = "")
        {
            Position = position;
            CssClass = cssClass;
            //UniqureId = string.Format("ad-{0}-{1}", type.ToString().ToLower(), position);
            UniqureId = string.Format("ad-{0}", type.ToString().ToLower());
            Sizes = WebContext.Current.AdSlotSizes[type];
        }
    }
}