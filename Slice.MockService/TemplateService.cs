using Slice.Data;
using Slice.MockService.DataProvider;
using Slice.Service.Contract;

namespace Slice.MockService
{
    public class TemplateService : BaseService, ITemplateService
    {
        public TemplateInfoDto GetTemplate(object templateId)
        {
            TemplateInfoDto template = new TemplateInfoDto();
            template.Categorys = CategoryDataProvider.MockCategories();

            template.Keywords = KeywordDataProvider.MockKeywords();

            return template;
        }
    }
}
