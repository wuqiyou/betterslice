using Slice.Data;
using System.Collections.Generic;

namespace Slice.Web.Models
{
    public class MenuViewModel
    {
        public string Title { get; set; }
        public IList<MenuItemViewModel> MenuItems { get; set; }

        public MenuViewModel()
        {
            MenuItems = new List<MenuItemViewModel>();
        }

        public MenuViewModel(IEnumerable<MainMenuDto> items, LanguageDto language)
            : this(items, language, string.Empty)
        {
        }

        public MenuViewModel(IEnumerable<MainMenuDto> items, LanguageDto language, string title)
        {
            Title = title;
            MenuItems = new List<MenuItemViewModel>();
            foreach (MainMenuDto item in items)
            {
                MenuItemViewModel menuItem = new MenuItemViewModel(item, language);
                MenuItems.Add(menuItem);
            }
        }
    }
}