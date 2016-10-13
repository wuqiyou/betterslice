using Slice.Data;
using System.Collections.Generic;

namespace Slice.Web.Models
{
    public class MenuViewModel
    {
        public LanguageDto CurrentLanguage { get; set; }
        public string Title { get; set; }
        public IList<MenuItemViewModel> MenuItems { get; set; }

        public MenuViewModel(LanguageDto language)
        {
            CurrentLanguage = language;
            MenuItems = new List<MenuItemViewModel>();
        }

        public void AddMenuItem(MainMenuDto item)
        {
            MenuItemViewModel menuItem = new MenuItemViewModel(item, CurrentLanguage);
            MenuItems.Add(menuItem);
        }
    }
}