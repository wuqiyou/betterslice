using System.Collections.Generic;
using System.Web.Mvc;
using Slice.Data;
using Slice.Web.Common;
using Slice.Web.Models;

namespace Slice.Web.Controllers
{
    public class NavigateController : BaseController
    {
        public const string ControllerName = "Navigate";
        public const string MainMenuAction = "MainMenu";

        public NavigateController()
        {
            CurrentLanguage = CurrentUserContext.CurrentLanguage;
        }

        public PartialViewResult MainMenu()
        {
            string urlAlias = Request.RawUrl.TrimStart('/');
            NavigationModel model = new NavigationModel();
            model.MenuItems = new List<MenuItem>();
            foreach (MainMenuDto item in WebContext.Current.MainMenus)
            {
                MenuItem menuItem = new MenuItem();
                model.MenuItems.Add(menuItem);
                menuItem.Tooltip = item.Tooltip;
                if (item.MainMenuLanguagesDic.ContainsKey(CurrentLanguage.Id))
                {
                    menuItem.MenuText = item.MainMenuLanguagesDic[CurrentLanguage.Id].MenuText;
                }
                else
                {
                    menuItem.MenuText = item.MenuText;
                }
                menuItem.NavigateUrl = item.NavigateUrl;
                menuItem.IsCurrent = !string.IsNullOrEmpty(urlAlias) && urlAlias.StartsWith(item.NavigateUrl);
                if (menuItem.IsCurrent && item.SubMenus != null)
                {
                    model.SubMenus = new List<MenuItem>();
                    foreach (MainMenuDto subitem in item.SubMenus)
                    {
                        MenuItem subMenu = new MenuItem();
                        model.SubMenus.Add(subMenu);
                        if (subitem.MainMenuLanguagesDic.ContainsKey(CurrentLanguage.Id))
                        {
                            subMenu.MenuText = subitem.MainMenuLanguagesDic[CurrentLanguage.Id].MenuText;
                        }
                        else
                        {
                            subMenu.MenuText = subitem.MenuText;
                        }
                        subMenu.NavigateUrl = subitem.NavigateUrl;
                        subMenu.IsCurrent = urlAlias.StartsWith(subitem.NavigateUrl);
                    }
                }
            }
            return PartialView(model);
        }
    }
}
