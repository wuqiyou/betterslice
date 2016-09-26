using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Slice.Data;
using Slice.Web.Models.Widgets;

namespace Slice.Web.Models
{
    public class PageViewModel : PageViewModelBase
    {
        public ReferenceInfoDto ReferenceInfo { get; set; }
        public List<ZoneViewModel> Zones { get; set; }
        private int? PageIndex { get; set; }
        // Subsite data
        public bool IsSubsite { get; set; }
        public SubsiteHeaderViewModel SubsiteHeader { get; set; }

        public PageViewModel(ReferenceInfoDto referenceInfo, Uri requestedUrl, int? pageIndex, LanguageDto language)
            : base(requestedUrl, language)
        {
            ReferenceInfo = referenceInfo;
            PageIndex = pageIndex;
            Zones = new List<ZoneViewModel>();
        }

        protected override void PopulatePage()
        {
            base.PopulatePage();

            EnableAds = ReferenceInfo.EnableAds && EnableAds;
            EnableReview = ReferenceInfo.EnableReview && EnableReview;
            EnableTracking = ReferenceInfo.EnableAds && EnableTracking;

            // Create blocks in all zones
            foreach (ZoneInfoDto zoneDto in ReferenceInfo.Template.Zones.OrderBy(o => o.Row))
            {
                ZoneViewModel zone = CreateZoneViewModel(zoneDto);
                Zones.Add(zone);
            }
        }

        protected override void PopulateMetadata()
        {
            base.PopulateMetadata();

            // Populate metadata by current reference
            // Title, Description, Keywords
            Metadata.Title = ReferenceInfo.Title;
            Metadata.Description = ReferenceInfo.Description;
            Metadata.Keywords = ReferenceInfo.Keywords;
            // Set metadata by MetadataProvider widgets
            foreach (ZoneViewModel zone in Zones)
            {
                // Populate metadata from certain widgets
                IMetadataProvider metadataProvider = zone.Widget as IMetadataProvider;
                if (metadataProvider != null)
                {
                    metadataProvider.UpdateMetadata(Metadata);
                }
            }
        }

        protected override void UpdateAsset()
        {
            base.UpdateAsset();
            // Merge in widget level CSS/JS files
            foreach (ZoneViewModel zone in Zones)
            {
                zone.Widget.UpdateAsset(AssetModel);
            }
        }

        public void PopulateSubsite(SubsiteInfoDto subsite)
        {
            IsSubsite = true;
            SubsiteHeader = new SubsiteHeaderViewModel();
            SubsiteHeader.SubsiteTitleColor = subsite.TitleColor;
            SubsiteHeader.Address = subsite.Address;
            SubsiteHeader.Phone = subsite.Phone;
            SubsiteHeader.Fax = subsite.Fax;
            SubsiteHeader.Website = subsite.Website;
            SubsiteHeader.Email = subsite.Email;
            SubsiteHeader.BannerHeightPixel = 120;
            SubsiteHeader.SubsiteBackColor = subsite.BackColor;
            BodyBackgroundColor = subsite.BackColor;
            SubsiteHeader.SubsiteBannerUrl = subsite.BannerUrl;
            if (subsite.SubsiteLanguagesDic.ContainsKey(CurrentLanguage.Id))
            {
                SubsiteHeader.SubsiteTitle = subsite.SubsiteLanguagesDic[CurrentLanguage.Id].Name;
            }
            else
            {
                SubsiteHeader.SubsiteTitle = subsite.Name;
            }
            // Set meta title for subsite
            Metadata.Title = string.Format("{0} | {1}", SubsiteHeader.SubsiteTitle, Metadata.Title);
            // Setup sub site menus
            SubsiteHeader.SubsiteMenus = new List<MenuItem>();
            int menuItems = subsite.Menus.Count();
            float widthPercent = 100 / menuItems;
            foreach (SubsiteMenuDto item in subsite.Menus.OrderBy(o => o.Sort))
            {
                MenuItem newItem = new MenuItem();
                SubsiteHeader.SubsiteMenus.Add(newItem);
                if (item.SubsiteMenuLanguagesDic.ContainsKey(CurrentLanguage.Id))
                {
                    newItem.MenuText = item.SubsiteMenuLanguagesDic[CurrentLanguage.Id].MenuText;
                }
                else
                {
                    newItem.MenuText = item.MenuText;
                }
                newItem.NavigateUrl = item.NavigateUrl.ToLower();
                newItem.WidthPercent = widthPercent;
            }
            // Set current selected menu item
            foreach (MenuItem item in SubsiteHeader.SubsiteMenus.Reverse())
            {
                item.IsCurrent = RequestedUrl.AbsolutePath.StartsWith(item.NavigateUrl);
                if (item.IsCurrent)
                {
                    // As soon as we find one, skip the loop
                    break;
                }
            }
        }

        private ZoneViewModel CreateZoneViewModel(ZoneInfoDto zoneInfo)
        {
            ZoneViewModel zone = new ZoneViewModel();
            zone.ShowLabel = zoneInfo.ShowLabel;
            zone.Label = zoneInfo.Label;
            zone.Row = zoneInfo.Row;
            zone.Col = zoneInfo.Col;
            zone.Style = zoneInfo.Style;

            if (zoneInfo.Block != null)
            {
                if (zoneInfo.Block.IsBuiltIn)
                {
                    Assembly assembly = Assembly.GetCallingAssembly();
                    string fullName = string.Format("{0}.Widgets.{1}", assembly.GetName().Name, zoneInfo.Block.WidgetName);
                    Type type = assembly.GetType(fullName); // full name - i.e. with namespace (perhaps concatenate)
                    if (type != null)
                    {
                        zone.Widget = Activator.CreateInstance(type) as WidgetViewModel;
                    }
                }
                else
                {
                    zone.Widget = new DynamicWidgetViewModel();
                }
                if (zone.Widget != null)
                {
                    zone.Widget.BlockInfo = zoneInfo.Block;
                    zone.Widget.CurrentLanguage = CurrentLanguage;
                    zone.Widget.RequestedUrl = RequestedUrl;
                    zone.Widget.PageIndex = PageIndex;
                    zone.Widget.ZoneStyle = zone.Style;
                    zone.Widget.Populate(ReferenceInfo);
                }
                else
                {
                    // TODO: exception
                }
            }

            return zone;
        }
    }
}