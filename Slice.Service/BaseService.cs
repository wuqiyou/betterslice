using Slice.Service.Contract;

namespace Slice.Service
{
    public abstract class BaseService : IBaseService
    {
        public object LanguageId { get; set; }
    }
}
