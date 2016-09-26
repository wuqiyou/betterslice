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
        public AdManagerModel AdManagerModel { get; set; }
        public MetadataModel Metadata { get; set; }
        public FooterModel Footer { get; set; }
        public AssetModel AssetModel { get; set; }

        public PageViewModelBase(Uri requestedUrl, LanguageDto language)
        {
            RequestedUrl = requestedUrl;
            CurrentLanguage = language;
            Metadata = new MetadataModel();
            AdManagerModel = new AdManagerModel();
            Footer = new FooterModel();
            AssetModel = new AssetModel();
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
            if (EnableAds)
            {
                AdManagerModel.AddKeyValue("site", "betterswing");
                AdManagerModel.AddKeyValue("network", "test");
                AdManagerModel.AddKeyValue("page", "show");
                //AdSettings.KeyValuePairs.Add("section", "show");
                //AdSettings.KeyValuePairs.Add("liveinsite", "show");
            }
        }

        protected virtual void UpdateAsset()
        {
        }

        protected virtual void PopulateFooter()
        {
            // Footer menu
            Footer.FooterMenus = new List<MenuItem>();
            foreach (MainMenuDto item in WebContext.Current.MainMenus)
            {
                MenuItem newItem = new MenuItem();
                Footer.FooterMenus.Add(newItem);
                if (item.MainMenuLanguagesDic != null && item.MainMenuLanguagesDic.ContainsKey(CurrentLanguage.Id))
                {
                    newItem.MenuText = item.MainMenuLanguagesDic[CurrentLanguage.Id].MenuText;
                }
                else
                {
                    newItem.MenuText = item.MenuText;
                }
                newItem.NavigateUrl = item.NavigateUrl;
                newItem.Tooltip = item.Tooltip;
            }
        }
    }
}