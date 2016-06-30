using Slice.Data;
using System.Collections.Generic;

namespace Slice.Web.Models
{
    public class MetadataModel
    {
        public MetadataModel()
        {
            MetaList = new List<MetadataDto>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string OGImage { get; set; }
        public string OGUrl { get; set; }
        public List<MetadataDto> MetaList { get; set; }
    }
}