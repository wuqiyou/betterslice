using System.Collections.Generic;
using Slice.Data;
using Slice.Service.Contract;
using SubjectEngine.Core;
using SubjectEngine.Data;

namespace Slice.MockService
{
    public class GeneralService : BaseService, IGeneralService
    {
        public IEnumerable<LanguageDto> GetLanguages()
        {
            List<LanguageDto> result = new List<LanguageDto>();
            result.Add(new LanguageDto { Id = 1, Culture = "en", Label = "English", Name = "English" });
            result.Add(new LanguageDto { Id = 2, Culture = "zh", Label = "Chinese", Name = "Chinese" });
            return result;
        }

        public IEnumerable<MetadataDto> GetMetadata()
        {
            List<MetadataDto> list = new List<MetadataDto>();
            list.Add(new MetadataDto { MetaType = "name", MetaKey = "googlebot", MetaContent = "noodp" });
            list.Add(new MetadataDto { MetaType = "property", MetaKey = "og:locale", MetaContent = "en-CA" });
            return list;
        }

        public IEnumerable<MainMenuDto> GetHeaderMenus()
        {
            List<MainMenuDto> items = new List<MainMenuDto>();

            MainMenuDto item1 = new MainMenuDto { NavigateUrl = "recipe", MenuText = "Recipes" };
            items.Add(item1);
            SetSubMenu(item1);

            MainMenuDto item2 = new MainMenuDto { NavigateUrl = "article", MenuText = "Articles" };
            items.Add(item2);

            MainMenuDto item3 = new MainMenuDto { NavigateUrl = "gallery", MenuText = "Photos" };
            items.Add(item3);

            MainMenuDto item4 = new MainMenuDto { NavigateUrl = "video", MenuText = "Videos" };
            items.Add(item4);

            return items;
        }

        public IEnumerable<MainMenuDto> GetFooterMenus()
        {
            List<MainMenuDto> items = new List<MainMenuDto>();

            MainMenuDto item1 = new MainMenuDto { NavigateUrl = "recipe", MenuText = "Recipes" };
            items.Add(item1);
            SetSubMenu(item1);

            MainMenuDto item2 = new MainMenuDto { NavigateUrl = "article", MenuText = "Articles" };
            items.Add(item2);

            MainMenuDto item3 = new MainMenuDto { NavigateUrl = "gallery", MenuText = "Photos" };
            items.Add(item3);

            MainMenuDto item4 = new MainMenuDto { NavigateUrl = "video", MenuText = "Videos" };
            items.Add(item4);

            return items;
        }

        private void SetSubMenu(MainMenuDto item)
        {
            List<MainMenuDto> subItems = new List<MainMenuDto>();
            item.SubMenus = subItems;
            for (int j = 1; j <= 7; j++)
            {
                MainMenuDto subItem = new MainMenuDto { NavigateUrl = string.Format("{0}/category/category{1}", item.NavigateUrl, j), MenuText = string.Format("Category{0}", j) };
                subItems.Add(subItem);
            }
        }

        public UserIdentity Authenticate(string email, string encryptedPassword)
        {
            UserIdentity user = new UserIdentity();
            user.DomainId = (int)UserDomains.Anonymous;
            user.Email = "saa@aa.com";
            return user;
        }
    }
}
