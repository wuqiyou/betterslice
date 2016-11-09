using System.Collections.Generic;
using Slice.Data;

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
            MenuViewModel menu = new MenuViewModel(menuItems, CurrentLanguage, menuTitle);
            FooterMenus.Add(menu);
        }
    }
}