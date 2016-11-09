using System.Collections.Generic;

namespace Slice.Web.Models
{
    public class NavigationModel
    {
        public IList<MenuItemViewModel> MenuItems { get; set; }
        public IList<MenuItemViewModel> SubMenus { get; set; }
    }
}