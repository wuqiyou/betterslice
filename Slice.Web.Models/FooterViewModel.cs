using System.Collections.Generic;
using Slice.Data;
using Slice.Web.Models.Shared;

namespace Slice.Web.Models
{
    public class FooterViewModel
    {
        public LanguageDto CurrentLanguage { get; set; }
        public IList<MenuViewModel> FooterMenus { get; set; }
        public SocialLinksViewModel SocialLinks { get; set; }

        public FooterViewModel(LanguageDto language, SocialLinksViewModel socialLinks)
        {
            CurrentLanguage = language;
            FooterMenus = new List<MenuViewModel>();
            SocialLinks = socialLinks;
        }

        public void AddMenus(IList<MainMenuDto> menuItems)
        {
            foreach (MainMenuDto menu in menuItems)
            {
                MenuViewModel menuViewModel = new MenuViewModel(menu.SubMenus, CurrentLanguage, menu.MenuText);
                FooterMenus.Add(menuViewModel);
            }
        }
    }
}