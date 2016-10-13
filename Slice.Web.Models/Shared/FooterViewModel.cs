using Slice.Data;
using System.Collections.Generic;

namespace Slice.Web.Models
{
    public class FooterViewModel
    {
        public LanguageDto CurrentLanguage { get; set; }
        public IList<MenuViewModel> FooterMenus { get; set; }

        public FooterViewModel(LanguageDto language)
        {
            CurrentLanguage = language;
            FooterMenus = new List<MenuViewModel>();
        }

        public void AddMenu(IList<MainMenuDto> menuItems, string menuTitle)
        {
            MenuViewModel menu = new MenuViewModel(CurrentLanguage);
            FooterMenus.Add(menu);
            menu.Title = menuTitle;
            foreach (MainMenuDto menuItem in menuItems)
            {
                menu.AddMenuItem(menuItem);
            }
        }
    }
}