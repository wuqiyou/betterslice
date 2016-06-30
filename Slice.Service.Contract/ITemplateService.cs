using Slice.Data;

namespace Slice.Service.Contract
{
    public interface ITemplateService : IBaseService
    {
        TemplateInfoDto GetTemplate(object templateId);
    }
}
