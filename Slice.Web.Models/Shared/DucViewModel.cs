using Slice.Data;
using SubjectEngine.Core;

namespace Slice.Web.Models
{
    public class DucViewModel
    {
        public object DucId { get; set; }
        public DucTypes DucType { get; set; }
        public DucValueDto DucValue { get; set; }
        public LanguageDto CurrentLanguage { get; set; }
        public GridViewModel Grid { get; set; }
    }
}