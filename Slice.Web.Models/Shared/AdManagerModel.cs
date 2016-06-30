using System.Collections.Generic;
using Slice.Core;

namespace Slice.Web.Models
{
    public class AdManagerModel
    {
        public IList<AdSlot> AdSlots { get; set; }
        public Dictionary<string, string> KeyValuePairs { get; set; }

        public AdManagerModel()
        {
            AdSlots = new List<AdSlot>();
            KeyValuePairs = new Dictionary<string, string>();
        }

        public void AddSlot(AdSlot slot)
        {
            AdSlots.Add(slot);
        }

        public void AddKeyValue(string key, string value)
        {
            if (!KeyValuePairs.ContainsKey(key))
            {
                KeyValuePairs.Add(key, value);
            }
        }
    }
}