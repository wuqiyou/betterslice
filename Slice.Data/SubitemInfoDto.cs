using System;
using SubjectEngine.Core;

namespace Slice.Data
{
    public class SubitemInfoDto
    {
        public object SubitemId { get; set; }
        public string ItemKey { get; set; }
        public string ItemLabel { get; set; }
        public bool IsMetaProvider { get; set; }
        public DucTypes DucType { get; set; }
        public GridDto Grid { get; set; }

        public string Label
        {
            get
            {
                string mark = IsMetaProvider ? "*" : string.Empty;
                return string.Format("Subitem({0}): {1} ({2}){3}", SubitemId, ItemLabel, DucType.ToString(), mark);
            }
        }
    }
}
