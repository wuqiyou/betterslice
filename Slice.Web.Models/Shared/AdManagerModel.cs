using System.Collections.Generic;
using Slice.Core;

namespace Slice.Web.Models
{
    public class AdManagerModel
    {
        public IList<AdUnitModel> AdUnits { get; set; }
        public Dictionary<string, string> TargetingSettings { get; set; }
        public Dictionary<AdType, int> AdsCounterByType { get; set; }

        public AdManagerModel()
        {
            AdUnits = new List<AdUnitModel>();
            TargetingSettings = new Dictionary<string, string>();
            AdsCounterByType = new Dictionary<AdType, int>();
        }

        public AdUnitModel Register(AdType type)
        {
            // Get position of current requested Ad
            int position = 1;
            if (AdsCounterByType.ContainsKey(type))
            {
                position = ++AdsCounterByType[type];
            }
            else
            {
                AdsCounterByType.Add(type, position);
            }

            // Instanciate AdUnit
            AdUnitModel adUnit = new AdUnitModel(type, position);
            // Add to the list
            AdUnits.Add(adUnit);
            return adUnit;
        }

        public void AddSetting(string key, string value)
        {
            if (!TargetingSettings.ContainsKey(key))
            {
                TargetingSettings.Add(key, value);
            }
        }
    }
}