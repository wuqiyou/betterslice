using System.Collections.Generic;

namespace Slice.Web.Models.Entity
{
    public class Rotator
    {
        public string Title { get; set; }
        public IList<RotatorItem> Items { get; set; }

        public Rotator()
        {
            Items = new List<RotatorItem>();
        }
    }
}
