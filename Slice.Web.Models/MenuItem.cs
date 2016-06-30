
namespace Slice.Web.Models
{
    public class MenuItem
    {
        public string MenuText { get; set; }
        public string NavigateUrl { get; set; }
        public string Tooltip { get; set; }
        public bool IsCurrent { get; set; }
        public float WidthPercent { get; set; }
    }
}