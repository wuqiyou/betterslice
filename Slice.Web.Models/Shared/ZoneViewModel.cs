
namespace Slice.Web.Models
{
    public class ZoneViewModel
    {
        public string Label { get; set; }
        public bool ShowLabel { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public string Style { get; set; }
        public WidgetViewModel Widget { get; set; }
    }
}