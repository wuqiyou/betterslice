using System.Collections.Generic;
using Slice.Core;

namespace Slice.Web.Models
{
    public class AdManagerModel
    {
        public IList<AdUnitModel> AdUnits { get; set; }
        public Dictionary<string, string> KeyValuePairs { get; set; }

        public AdManagerModel()
        {
            AdUnits = new List<AdUnitModel>();
            KeyValuePairs = new Dictionary<string, string>();
        }

        public AdUnitModel Register(AdType type)
        {
            // Instanciate AdUnit
            AdUnitModel adUnit = new AdUnitModel(type);
            // Add to the list
            AdUnits.Add(adUnit);
            // Set the position
            adUnit.SetPosition(1);
            return adUnit;
        }

        public void AddSlot(AdSlot slot)
        {
            //AdSlots.Add(slot);
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