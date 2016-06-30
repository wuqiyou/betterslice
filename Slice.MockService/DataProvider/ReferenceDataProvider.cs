using System.Collections.Generic;
using Slice.Data;
using System.Linq;

namespace Slice.MockService.DataProvider
{
    public static class ReferenceDataProvider
    {
        public static ReferenceInfoDto MockByAlias(string alias)
        {
            switch (alias)
            {
                case "recipe":
                    return MockListPage(11, "Recipe");
                case "article":
                    return MockListPage(12, "Article");
                case "gallery":
                    return MockListPage(13, "Gallery");
                case "video":
                    return MockListPage(14, "Video");
                default:
                    if (alias.Contains("recipe/"))
                    {
                        return MockRecipeDetailPage();
                    }
                    else if (alias.Contains("article/"))
                    {
                        return MockBlogDetailPage();
                    }
                    else if (alias.Contains("gallery/"))
                    {
                        return MockPhotoGalleryPage();
                    }
                    else if (alias.Contains("video/"))
                    {
                        return MockYouTubeVideoPage(alias);
                    }
                    else
                    {
                        return MockHome();
                    }
            }
        }

        public static ReferenceInfoDto MockHome()
        {
            ReferenceInfoDto item = new ReferenceInfoDto();
            item.Slug = "home";
            item.Description = "Food resipes";
            item.Title = "Food resipes home";
            item.HideTitle = true;
            item.Template = TemplateDataProvider.MockHomeTemplate();
            item.ValuesDic = new Dictionary<object, DucValueDto>();
            // Rotator values
            foreach (DucValueDto value in DucDataProvider.MockRotatorValues())
            {
                item.ValuesDic.Add(value.DucId, value);
            }

            // FeaturedContent values
            foreach (DucValueDto value in DucDataProvider.MockFeaturedContentValues())
            {
                item.ValuesDic.Add(value.DucId, value);
            }

            // FeaturedContent2nd values
            foreach (DucValueDto value in DucDataProvider.MockFeaturedContent2ndValues())
            {
                item.ValuesDic.Add(value.DucId, value);
            }

            return item;
        }

        public static ReferenceInfoDto MockListPage(int referenceId, string contentType)
        {
            ReferenceInfoDto item = new ReferenceInfoDto();
            item.ReferenceId = referenceId;
            item.Slug = contentType.ToLower();
            item.Description = "Food " + contentType;
            item.Title = contentType + " List";
            item.HideTitle = false;
            item.Template = TemplateDataProvider.MockSubjectsListViewTemplate();

            item.ValuesDic = new Dictionary<object, DucValueDto>();
            // ListView values
            foreach (DucValueDto value in DucDataProvider.MockListViewValues(contentType))
            {
                item.ValuesDic.Add(value.DucId, value);
            }

            return item;
        }

        public static ReferenceInfoDto MockRecipeDetailPage()
        {
            ReferenceInfoDto item = new ReferenceInfoDto();
            item.Title = "Recipe detail";
            item.Description = "Recipe detail description";
            item.HideTitle = true;
            item.EnableAds = true;
            item.EnableReview = true;
            item.EnableCategory = true;
            item.Template = TemplateDataProvider.MockRecipeDetailTemplate();
            item.RelatedSubjects = DucDataProvider.MockAttachedSubjects(6, "Recipe");

            // keywords
            List<ReferenceKeywordInfoDto> keywords = new List<ReferenceKeywordInfoDto>();
            item.ReferenceKeywords = keywords;
            foreach (KeywordDto keyword in KeywordDataProvider.MockKeywords())
            {
                keywords.Add(new ReferenceKeywordInfoDto { KeywordName = keyword.Name, KeywordSlug = keyword.Slug });
            }

            item.ValuesDic = new Dictionary<object, DucValueDto>();
            foreach (DucValueDto value in DucDataProvider.MockRecipeDetailValues())
            {
                item.ValuesDic.Add(value.DucId, value);
            }

            // Grid data
            List<GridRowDto> rows = DucDataProvider.MockRecipeDetailIngredientGridRows(12);
            rows.AddRange(DucDataProvider.MockRecipeDetailInstructionGridRows(6));
            item.GridRows = rows;
            
            return item;
        }

        public static ReferenceInfoDto MockPhotoGalleryPage()
        {
            ReferenceInfoDto item = new ReferenceInfoDto();
            item.Title = "Photo gallery";
            item.Description = "Photo gallery description";
            item.HideTitle = true;
            item.EnableAds = true;
            item.EnableReview = true;
            item.EnableCategory = true;
            item.Template = TemplateDataProvider.MockPhotoGalleryTemplate();

            item.ValuesDic = new Dictionary<object, DucValueDto>();
            foreach (DucValueDto value in DucDataProvider.MockPhotoGalleryValues())
            {
                item.ValuesDic.Add(value.DucId, value);
            }

            item.GridRows = DucDataProvider.MockPhotoGalleryPhotosGridRows(7);

            return item;
        }

        public static ReferenceInfoDto MockBlogDetailPage()
        {
            ReferenceInfoDto item = new ReferenceInfoDto();
            item.Title = "Blog detail";
            item.Description = "Blog detail description";
            item.HideTitle = true;
            item.EnableAds = true;
            item.EnableReview = true;
            item.EnableCategory = true;
            item.Template = TemplateDataProvider.MockBlogDetailTemplate();
            item.RelatedSubjects = DucDataProvider.MockAttachedSubjects(4, "Article");

            item.ValuesDic = new Dictionary<object, DucValueDto>();
            foreach (DucValueDto value in DucDataProvider.MockBlogDetailValues())
            {
                item.ValuesDic.Add(value.DucId, value);
            }

            return item;
        }

        public static ReferenceInfoDto MockYouTubeVideoPage(string pageAlias)
        {
            ReferenceInfoDto item = new ReferenceInfoDto();
            item.Title = "Youtube video";
            item.Description = "Youtube video description";
            item.HideTitle = true;
            item.EnableAds = true;
            item.EnableReview = true;
            item.EnableCategory = true;
            item.Template = TemplateDataProvider.MockYouTubeVideoTemplate();
            item.RelatedSubjects = DucDataProvider.MockAttachedSubjectsOfVideo().Take(3);

            item.ValuesDic = new Dictionary<object, DucValueDto>();
            foreach (DucValueDto value in DucDataProvider.VideoInstances[pageAlias])
            {
                item.ValuesDic.Add(value.DucId, value);
            }

            return item;
        }
    }
}
