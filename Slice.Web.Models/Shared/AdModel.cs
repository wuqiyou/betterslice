using System;
using Slice.Core;

namespace Slice.Web.Models
{
    public class AdModel
    {
        public AdManagerModel AdManagerModel { get; set; }
        public AdSlot Slot { get; set; }
        public string CssClass { get; set; }

        public int Position { get; set; }
    }
}