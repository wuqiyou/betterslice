using Slice.Data;
using System;
using System.Collections.Generic;

namespace Slice.Web.Models
{
    public class NavigationModel
    {
        public MenuViewModel MainVav { get; set; }
        public MenuViewModel SubNav { get; set; }

        public NavigationModel(IList<MainMenuDto> menuItems, Uri requestedUrl, LanguageDto currentLanguage)
        {
            // Build main navigation view model 
            MainVav = new MenuViewModel();
            foreach (MainMenuDto item in menuItems)
            {
                MenuItemViewModel menuItem = new MenuItemViewModel(item, currentLanguage);
                MainVav.MenuItems.Add(menuItem);
                // Find out current item
                if (requestedUrl.AbsolutePath.StartsWith(item.NavigateUrl))
                {
                    // current item found
                    menuItem.IsCurrent = true;
                    // Build sub menu view model
                    SubNav = new MenuViewModel();
                    foreach (MainMenuDto subItem in item.SubMenus)
                    {
                        MenuItemViewModel subMenuItem = new MenuItemViewModel(subItem, currentLanguage);
                        SubNav.MenuItems.Add(subMenuItem);
                        // Find out current item
                        if (requestedUrl.AbsolutePath.StartsWith(subMenuItem.NavigateUrl))
                        {
                            // current item found
                            subMenuItem.IsCurrent = true;
                        }
                    }
                }
            }
        }
    }
}