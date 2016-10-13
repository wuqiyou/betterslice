using System.Collections.Generic;

namespace Slice.Web.Models
{
    public class SubsiteHeaderViewModel
    {
        public string SubsiteTitle { get; set; }
        public int BannerHeightPixel { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string SubsiteBackColor { get; set; }
        public string SubsiteTitleColor { get; set; }
        public string SubsiteBannerUrl { get; set; }
        public IList<MenuItemViewModel> SubsiteMenus { get; set; }
    }
}