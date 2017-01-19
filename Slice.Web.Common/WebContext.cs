using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Slice.Core;
using Slice.Data;
using Slice.Service.Contract;
using SubjectEngine.Core;

namespace Slice.Web.Common
{
    public class WebContext
    {
        // Static Interface
        private static volatile WebContext _instance = new WebContext();
        public static WebContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("The WebContext is not initialized");
                }

                return _instance;
            }
        }

        // Site settings from web.config
        public bool RunOnMockData { get; set; }
        public string AdServiceUnit { get; set; }
        public string SiteName { get; set; }
        public string ImageServeRoot { get; set; }
        public int DefaultLanguageId { get; set; }
        public bool EnableAds { get; set; }
        public bool IsMultiLanguageSupported { get; set; }
        public bool IsTestMode { get; set; }
        public bool EnableReview { get; set; }
        public bool EnableTracking { get; set; }
        public string PagingQueryString { get; set; }
        public int PagerWindowSize { get; set; }
        public int MaxPageSize { get; set; }

        public IEnumerable<MetadataDto> StaticMetadataList { get; set; }
        public IList<MainMenuDto> HeaderMenus { get; set; }
        public IList<MainMenuDto> FooterMenus { get; set; }
        public Dictionary<string, string> SubsiteRedirectDic { get; set; }
        public Dictionary<object, LanguageDto> LanguageDic { get; set; }
        public Dictionary<string, LanguageDto> LanguageDicByCulture { get; set; }
        public LanguageDto DefaultLanguage { get; set; }

        public Dictionary<AdType, string> AdSlotSizes { get; set; }

        public Dictionary<string, KeywordDto> RecipeKeywords { get; set; }
        public Dictionary<string, CategoryDto> RecipeCategories { get; set; }

        // Instance Interface
        private WebContext()
        {
            AdSlotSizes = new Dictionary<AdType, string>();
            StaticMetadataList = new List<MetadataDto>();
            LanguageDic = new Dictionary<object, LanguageDto>();
            LanguageDicByCulture = new Dictionary<string, LanguageDto>();
            SubsiteRedirectDic = new Dictionary<string, string>();
            RecipeKeywords = new Dictionary<string, KeywordDto>();
            RecipeCategories = new Dictionary<string, CategoryDto>();

            // Site settings from web.config
            SetSiteSettings();
        }

        public void Initilize()
        {
            IGeneralService service = ServiceLocator.Current.GetInstance<IGeneralService>();
            StaticMetadataList = service.GetMetadata();
            HeaderMenus = service.GetHeaderMenus().ToList();
            FooterMenus = service.GetFooterMenus().ToList();
            IEnumerable<LanguageDto> availableLanguages = service.GetLanguages().ToList();

            foreach (LanguageDto language in availableLanguages)
            {
                LanguageDic.Add(language.Id, language);
                LanguageDicByCulture.Add(language.Culture, language);
            }

            DefaultLanguage = LanguageDic[DefaultLanguageId];

            ISubsiteService subsiteService = ServiceLocator.Current.GetInstance<ISubsiteService>();
            IEnumerable<SubsiteBriefDto> subsites = subsiteService.GetSubsites(true);
            foreach (SubsiteBriefDto item in subsites)
            {
                // Set Subsite redirection dictionary
                string key = string.Format("/{0}", item.Slug.ToLower());
                string value;
                if (WebContext.Current.IsMultiLanguageSupported)
                {
                    value = string.Format("/{0}/{1}", item.Culture, item.Slug);
                }
                else
                {
                    value = string.Format("/{0}", item.Slug);
                }
                SubsiteRedirectDic.Add(key, value);
            }

            InitAdSlotSize();

            InitRecipeKeywordsAndCategories();
        }

        private void SetSiteSettings()
        {
            RunOnMockData = Convert.ToBoolean(ConfigurationManager.AppSettings["RunOnMockData"]);
            AdServiceUnit = ConfigurationManager.AppSettings["AdServiceUnit"];
            SiteName = ConfigurationManager.AppSettings["SiteName"];
            ImageServeRoot = ConfigurationManager.AppSettings["ImageServeRoot"];
            DefaultLanguageId = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultLanguageId"]);
            IsMultiLanguageSupported = Convert.ToBoolean(ConfigurationManager.AppSettings["IsMultiLanguageSupported"]);
            EnableAds = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableAds"]);
            EnableReview = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableReview"]);
            EnableTracking = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableTracking"]);
            IsTestMode = Convert.ToBoolean(ConfigurationManager.AppSettings["IsTestMode"]);
            PagingQueryString = ConfigurationManager.AppSettings["PagingQueryString"];
            PagerWindowSize = Convert.ToInt32(ConfigurationManager.AppSettings["PagerWindowSize"]);
            MaxPageSize = Convert.ToInt32(ConfigurationManager.AppSettings["MaxPageSize"]);
        }

        private void InitAdSlotSize()
        {
            AdSlotSizes.Add(AdType.Leaderboard, "[[728, 90], [320, 50], [970, 90]]");
            AdSlotSizes.Add(AdType.BigBox, "[300, 250]");
            AdSlotSizes.Add(AdType.DoubleBigBox, "[300, 600]");
            AdSlotSizes.Add(AdType.Wallpaper, "[1, 1]");
            AdSlotSizes.Add(AdType.Billboard, "[970, 250]");
        }

        private void InitRecipeKeywordsAndCategories()
        {
            ITemplateService service = ServiceLocator.Current.GetInstance<ITemplateService>();
            TemplateInfoDto template = service.GetTemplate(CmsRegister.RECIPE_TEMPLATE_ID);
            foreach (KeywordDto item in template.Keywords)
            {
                RecipeKeywords.Add(item.Slug, item);
            }
            foreach (CategoryDto item in template.Categorys)
            {
                RecipeCategories.Add(item.Slug, item);
            }
        }
    }
}