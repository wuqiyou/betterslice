using System.Collections.Generic;
using Slice.Core;

namespace Slice.Web.Models
{
    public class AdManagerModel
    {
        public IList<AdUnitModel> AdUnits { get; set; }
        public Dictionary<string, string> KeyValuePairs { get; set; }
        public Dictionary<AdType, int> UnitsCounterByType { get; set; }

        public AdManagerModel()
        {
            AdUnits = new List<AdUnitModel>();
            KeyValuePairs = new Dictionary<string, string>();
            UnitsCounterByType = new Dictionary<AdType, int>();
        }

        public AdUnitModel Register(AdType type, string cssClass = "")
        {
            // Get position of current requested Ad
            int position = 1;
            if (UnitsCounterByType.ContainsKey(type))
            {
                position = ++UnitsCounterByType[type];
            }
            else
            {
                UnitsCounterByType.Add(type, position);
            }

            // Instanciate AdUnit
            AdUnitModel adUnit = new AdUnitModel(type, position, cssClass);
            // Add to the list
            AdUnits.Add(adUnit);
            return adUnit;
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