using System.Collections.Generic;
using Slice.Core;

namespace Slice.Web.Models
{
    public class AdManagerViewModel
    {
        public IList<AdUnitViewModel> AdUnits { get; set; }
        public Dictionary<string, string> TargetingSettings { get; set; }
        public Dictionary<AdType, int> AdsCounterByType { get; set; }

        public AdManagerViewModel()
        {
            AdUnits = new List<AdUnitViewModel>();
            TargetingSettings = new Dictionary<string, string>();
            AdsCounterByType = new Dictionary<AdType, int>();
        }

        public AdUnitViewModel Register(AdType type)
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
            AdUnitViewModel adUnit = new AdUnitViewModel(type, position);
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