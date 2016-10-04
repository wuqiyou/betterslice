using Slice.Core;
using Slice.Web.Common;

namespace Slice.Web.Models
{
    public class AdUnitViewModel
    {
        public int Position { get; private set; }
        public string UniqueId { get; private set; }
        public string Sizes { get; private set; }
        public string CssClass { get; private set; }

        public AdUnitViewModel(AdType type, int position)
        {
            Position = position;
            string typeStr = type.ToString().ToLower();
            // Set uniqueId as ad-bigbox-1
            UniqueId = string.Format("ad-{0}-{1}", typeStr, position);
            Sizes = WebContext.Current.AdSlotSizes[type];
            // Set css class as ad-bigbox
            if (type != AdType.Leaderboard)
            {
                CssClass = string.Format("ad-{0} ad-labeled", typeStr);
            }
            else
            {
                CssClass = string.Format("ad-{0}", typeStr);
            }
        }
    }
}