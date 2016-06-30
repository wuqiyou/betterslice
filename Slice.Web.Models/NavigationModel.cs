using System.Collections.Generic;

namespace Slice.Web.Models
{
    public class NavigationModel
    {
        public IList<MenuItem> MenuItems { get; set; }
        public IList<MenuItem> SubMenus { get; set; }
    }
}