using Slice.Service.Contract;

namespace Slice.MockService
{
    public abstract class BaseService : IBaseService
    {
        public object LanguageId { get; set; }
    }
}
