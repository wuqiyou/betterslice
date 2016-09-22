using Slice.Core;

namespace Slice.Web.Models
{
    public class AdUnitModel
    {
        public AdType AdType { get; private set; }
        public int Position { get; private set; }

        public string UniqureId
        {
            get
            {
                return string.Format("ad-{0}-{1}", AdType.ToString().ToLower(), Position);
            }
        }

        public AdUnitModel(AdType type)
        {
            AdType = type;
            Position = 1;
        }

        public void SetPosition(int position)
        {
            Position = position;
        }
    }
}