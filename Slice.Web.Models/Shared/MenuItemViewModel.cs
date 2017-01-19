using Slice.Data;

namespace Slice.Web.Models
{
    public class MenuItemViewModel
    {
        public string MenuText { get; set; }
        public string NavigateUrl { get; set; }
        public string Tooltip { get; set; }
        public bool IsCurrent { get; set; }
        public float WidthPercent { get; set; }

        public MenuItemViewModel()
        {
        }

        public MenuItemViewModel(MainMenuDto item, LanguageDto currentLanguage)
        {
            if (item.MainMenuLanguagesDic != null && item.MainMenuLanguagesDic.ContainsKey(currentLanguage.Id))
            {
                MenuText = item.MainMenuLanguagesDic[currentLanguage.Id].MenuText;
            }
            else
            {
                MenuText = item.MenuText;
            }
            NavigateUrl = item.NavigateUrl;
            Tooltip = item.Tooltip;
        }
    }
}