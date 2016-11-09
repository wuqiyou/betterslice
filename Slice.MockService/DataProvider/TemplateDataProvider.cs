using System.Collections.Generic;
using Slice.Core;
using Slice.Data;

namespace Slice.MockService.DataProvider
{
    public static class TemplateDataProvider
    {
        public static TemplateInfoDto MockHomeTemplate()
        {
            TemplateInfoDto template = new TemplateInfoDto();
            template.HideTitle = true;
            template.Name = "Complex Home";

            List<ZoneInfoDto> zones = new List<ZoneInfoDto>();
            template.Zones = zones;

            //ZoneInfoDto zone1 = new ZoneInfoDto();
            //zones.Add(zone1);
            //zone1.Block = BlockDataProvider.MockRotator();
            //zone1.Style = CmsRegister.FULL_WIDTH_STYLE;

            //ZoneInfoDto zone2 = new ZoneInfoDto();
            //zones.Add(zone2);
            //zone2.Block = BlockDataProvider.MockFeaturedContent();

            //ZoneInfoDto zone3 = new ZoneInfoDto();
            //zones.Add(zone3);
            //zone3.Block = BlockDataProvider.MockFeaturedContent2nd();

            //ZoneInfoDto zone4 = new ZoneInfoDto();
            //zones.Add(zone4);
            //zone4.Style = CmsRegister.RIGHT_RAIL_STYLE;
            //zone4.Block = BlockDataProvider.MockAdWidget();

            return template;
        }

        public static TemplateInfoDto MockSubjectsListViewTemplate()
        {
            TemplateInfoDto template = new TemplateInfoDto();
            template.HideTitle = true;
            template.Name = "Subjects List View";

            List<ZoneInfoDto> zones = new List<ZoneInfoDto>();
            template.Zones = zones;

            ZoneInfoDto zone1 = new ZoneInfoDto();
            zones.Add(zone1);
            zone1.Block = BlockDataProvider.MockListViewWidget();

            return template;
        }

        public static TemplateInfoDto MockRecipeDetailTemplate()
        {
            TemplateInfoDto template = new TemplateInfoDto();
            template.HideTitle = false;

            List<ZoneInfoDto> zones = new List<ZoneInfoDto>();
            template.Zones = zones;

            // Recipe zone/block
            ZoneInfoDto zone1 = new ZoneInfoDto();
            zones.Add(zone1);
            zone1.Block = BlockDataProvider.MockRecipeDetail();

            ZoneInfoDto zone3 = new ZoneInfoDto();
            zones.Add(zone3);
            zone3.Style = CmsRegister.RIGHT_RAIL_STYLE;
            zone3.Block = BlockDataProvider.MockAdWidget();

            ZoneInfoDto zone2 = new ZoneInfoDto();
            zones.Add(zone2);
            zone2.Style = CmsRegister.RIGHT_RAIL_STYLE;
            zone2.Block = BlockDataProvider.MockRelatedContent();

            return template;
        }

        public static TemplateInfoDto MockBlogDetailTemplate()
        {
            TemplateInfoDto template = new TemplateInfoDto();
            template.HideTitle = false;

            List<ZoneInfoDto> zones = new List<ZoneInfoDto>();
            template.Zones = zones;

            ZoneInfoDto zone1 = new ZoneInfoDto();
            zones.Add(zone1);
            zone1.Block = BlockDataProvider.MockBlogDetail();

            ZoneInfoDto zone2 = new ZoneInfoDto();
            zones.Add(zone2);
            zone2.Style = CmsRegister.RIGHT_RAIL_STYLE;
            zone2.Block = BlockDataProvider.MockRelatedContent();

            return template;
        }

        public static TemplateInfoDto MockPhotoGalleryTemplate()
        {
            TemplateInfoDto template = new TemplateInfoDto();
            template.HideTitle = false;

            List<ZoneInfoDto> zones = new List<ZoneInfoDto>();
            template.Zones = zones;

            ZoneInfoDto zone1 = new ZoneInfoDto();
            zones.Add(zone1);
            zone1.Block = BlockDataProvider.MockPhotoGallery();

            return template;
        }

        public static TemplateInfoDto MockYouTubeVideoTemplate()
        {
            TemplateInfoDto template = new TemplateInfoDto();
            template.HideTitle = false;

            List<ZoneInfoDto> zones = new List<ZoneInfoDto>();
            template.Zones = zones;

            ZoneInfoDto zone1 = new ZoneInfoDto();
            zones.Add(zone1);
            zone1.Block = BlockDataProvider.MockYouTubeVideo();

            ZoneInfoDto zone2 = new ZoneInfoDto();
            zones.Add(zone2);
            zone2.Style = CmsRegister.RIGHT_RAIL_STYLE;
            zone2.Block = BlockDataProvider.MockRelatedContent();

            return template;
        }
    }
}
