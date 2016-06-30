using Framework.UoW;
using Slice.Data;
using Slice.DataConverter;
using Slice.Registry;
using Slice.Service.Contract;
using SubjectEngine.Component;
using SubjectEngine.Data;
using System.Collections.Generic;
using System.Linq;

namespace Slice.Service
{
    public class GeneralService : BaseService, IGeneralService
    {
        public IEnumerable<LanguageDto> GetLanguages()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                LanguageFacade languageFacade = new LanguageFacade(uow);
                IEnumerable<LanguageDto> result = languageFacade.RetrieveAllLanguage(new LanguageConverter());
                return result;
            }
        }

        public IEnumerable<MetadataDto> GetMetadata()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                MetadataFacade facade = new MetadataFacade(uow);
                IEnumerable<MetadataDto> result = facade.RetrieveAll(new MetadataConverter());
                return result.Where(x => !string.IsNullOrEmpty(x.MetaContent));
            }
        }

        private IEnumerable<MainMenuDto> BuildMenuTrees(IEnumerable<MainMenuDto> items)
        {
            IEnumerable<MainMenuDto> topItems = items.Where(o => o.ParentId == null).OrderBy(o => o.Sort);
            IEnumerable<MainMenuDto> Subitems = items.Where(o => o.ParentId != null);
            // Loop to get sub menus
            foreach (MainMenuDto item in topItems)
            {
                item.SubMenus = Subitems.Where(o => object.Equals(o.ParentId, item.Id)).OrderBy(o => o.Sort);
            }

            return topItems;
        }

        public IEnumerable<MainMenuDto> GetPublishedMenus()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                MainMenuFacade facade = new MainMenuFacade(uow);
                List<MainMenuDto> items = facade.GetPublishedMenus(new MainMenuConverter());

                return BuildMenuTrees(items);
            }
        }

        public UserIdentity Authenticate(string email, string encryptedPassword)
        {
            UserIdentity authenticatedUser = null;
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                AuthenticateFacade facade = new AuthenticateFacade(uow);
                authenticatedUser = facade.Authenticate(email, encryptedPassword);
            }

            return authenticatedUser;
        }
    }
}
