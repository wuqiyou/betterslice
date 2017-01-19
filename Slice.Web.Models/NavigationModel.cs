using Slice.Data;
using System.Collections.Generic;

namespace Slice.Web.Models
{
    public class NavigationModel
    {
        public MenuViewModel MainVav { get; set; }
        public MenuViewModel SubNav { get; set; }

        public NavigationModel(MainMenuDto menuItems, LanguageDto CurrentLanguage)
        { 
        }

        public NavigationModel(IList<MainMenuDto> menuItems, LanguageDto CurrentLanguage)
        {
            MainVav = new MenuViewModel(menuItems, CurrentLanguage);

            //model.MenuItems = new List<MenuItemViewModel>();
            //foreach (MainMenuDto item in menuItems)
            //{
            //    MenuItemViewModel menuItem = new MenuItemViewModel();
            //    model.MenuItems.Add(menuItem);
            //    menuItem.Tooltip = item.Tooltip;
            //    if (item.MainMenuLanguagesDic != null && item.MainMenuLanguagesDic.ContainsKey(CurrentLanguage.Id))
            //    {
            //        menuItem.MenuText = item.MainMenuLanguagesDic[CurrentLanguage.Id].MenuText;
            //    }
            //    else
            //    {
            //        menuItem.MenuText = item.MenuText;
            //    }
            //    menuItem.NavigateUrl = item.NavigateUrl;
            //    menuItem.IsCurrent = !string.IsNullOrEmpty(urlAlias) && urlAlias.StartsWith(item.NavigateUrl);
            //    if (menuItem.IsCurrent && item.SubMenus != null)
            //    {
            //        model.SubMenus = new List<MenuItemViewModel>();
            //        foreach (MainMenuDto subitem in item.SubMenus)
            //        {
            //            MenuItemViewModel subMenu = new MenuItemViewModel();
            //            model.SubMenus.Add(subMenu);
            //            if (item.MainMenuLanguagesDic != null && subitem.MainMenuLanguagesDic.ContainsKey(CurrentLanguage.Id))
            //            {
            //                subMenu.MenuText = subitem.MainMenuLanguagesDic[CurrentLanguage.Id].MenuText;
            //            }
            //            else
            //            {
            //                subMenu.MenuText = subitem.MenuText;
            //            }
            //            subMenu.NavigateUrl = subitem.NavigateUrl;
            //            subMenu.IsCurrent = urlAlias.StartsWith(subitem.NavigateUrl);
            //        }
            //    }
            //}

        }
    }
}