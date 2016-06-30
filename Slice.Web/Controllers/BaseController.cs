using System.Web.Mvc;
using Slice.Data;
using Slice.Web.Common;
using SubjectEngine.Data;

namespace Slice.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public const string KeyLanguageCookie = "SliceLanguageCookie";

        private const string UserContextStateKey = "UserContextStateKey";

        public LanguageDto CurrentLanguage { get; set; }

        private UserContext _currentUserContext;
        public UserContext CurrentUserContext
        {
            get
            {
                if (_currentUserContext == null)
                {
                    if (System.Web.HttpContext.Current.Session[UserContextStateKey] != null)
                    {
                        _currentUserContext = (UserContext)System.Web.HttpContext.Current.Session[UserContextStateKey];
                    }
                    else
                    {
                        _currentUserContext = new UserContext(new UserIdentity());
                        System.Web.HttpContext.Current.Session[UserContextStateKey] = _currentUserContext;
                    }
                }

                return _currentUserContext;
            }
        }
    }
}
