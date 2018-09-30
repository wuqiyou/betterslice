using System;
using System.Collections.Generic;
using Slice.Data;
using Slice.Web.Common.Helpers;

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
                menuItem.IsCurrent = MenuItemHelper.IsCurrent(item.NavigateUrl, requestedUrl.AbsolutePath, currentLanguage);

                if (menuItem.IsCurrent)
                {
                    // current item found
                    // Build sub menu view model
                    SubNav = new MenuViewModel();
                    foreach (MainMenuDto subItem in item.SubMenus)
                    {
                        MenuItemViewModel subMenuItem = new MenuItemViewModel(subItem, currentLanguage);
                        SubNav.MenuItems.Add(subMenuItem);
                        // Find out current item
                        subMenuItem.IsCurrent = MenuItemHelper.IsCurrent(subMenuItem.NavigateUrl, requestedUrl.AbsolutePath, currentLanguage);
                    }
                }
            }
        }
    }
}