using System;
using System.Collections.Generic;
using Slice.Core;
using Slice.Data;
using Slice.Web.Common;

namespace Slice.Web.Models
{
    public class PageViewModelBase
    {
        public Uri RequestedUrl { get; set; }
        public string PageTitle { get; set; }
        public string BodyBackgroundColor { get; set; }
        public bool EnableAds { get; set; }
        public bool EnableReview { get; set; }
        public bool EnableTracking { get; set; }
        public LanguageDto CurrentLanguage { get; set; }
        public AdManagerViewModel AdManagerModel { get; set; }
        public MetadataModel Metadata { get; set; }
        public FooterViewModel Footer { get; set; }
        public AssetViewModel AssetModel { get; set; }
        public IList<AdUnitViewModel> AdUnits { get; set; }

        public PageViewModelBase(Uri requestedUrl, LanguageDto language)
        {
            RequestedUrl = requestedUrl;
            CurrentLanguage = language;
            Metadata = new MetadataModel();
            AdManagerModel = new AdManagerViewModel();
            Footer = new FooterViewModel(language);
            AssetModel = new AssetViewModel();
            AdUnits = new List<AdUnitViewModel>();
        }

        public void Populate()
        {
            PopulatePage();
            PopulateMetadata();
            FinalizeMetadata();
            PopulateAdManager();
            PopulateFooter();
            UpdateAsset();
        }

        protected virtual void PopulatePage()
        {
            EnableAds = WebContext.Current.EnableAds;
            EnableReview = WebContext.Current.EnableReview;
            EnableTracking = WebContext.Current.EnableTracking;
        }

        protected virtual void PopulateMetadata()
        {
            Metadata.OGUrl = RequestedUrl.AbsolutePath;
            // Const metadata
            Metadata.MetaList.AddRange(WebContext.Current.StaticMetadataList);
        }

        protected void FinalizeMetadata()
        {
            // Set PageTitle
            PageTitle = Metadata.Title;
            // Set Description if it's empty
            if (!Metadata.Description.TrimHasValue())
            {
                Metadata.Description = Metadata.Title;
            }
            // og:title
            Metadata.MetaList.Add(new MetadataDto { MetaType = "property", MetaKey = "og:title", MetaContent = Metadata.Title });
            // og:description
            Metadata.MetaList.Add(new MetadataDto { MetaType = "property", MetaKey = "og:description", MetaContent = Metadata.Description });
        }

        protected virtual void PopulateAdManager()
        {
            // register leaderboard
            AdUnits.Add(AdManagerModel.Register(AdType.Leaderboard));

            AdManagerModel.AddSetting("site", "betterswing");
            AdManagerModel.AddSetting("network", "test");
            AdManagerModel.AddSetting("page", "show");
            //AdSettings.KeyValuePairs.Add("section", "show");
            //AdSettings.KeyValuePairs.Add("liveinsite", "show");
        }

        protected virtual void UpdateAsset()
        {
        }

        protected virtual void PopulateFooter()
        {
            // Main menu
            Footer.AddMenu(WebContext.Current.MainMenus, "Main");

            // Inspiration menu
            List<MainMenuDto> items = new List<MainMenuDto>();
            MainMenuDto item1 = new MainMenuDto() { MenuText = "Chicken", NavigateUrl = "/" };
            items.Add(item1);
            MainMenuDto item2 = new MainMenuDto() { MenuText = "Pork", NavigateUrl = "/" };
            items.Add(item2);
            Footer.AddMenu(items, "Inspiration");
            //MenuViewModel inspiration = new MenuViewModel();
            //inspiration.Title = "Inspiration";

        }
    }
}