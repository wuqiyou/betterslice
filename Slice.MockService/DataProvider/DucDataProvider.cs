using Slice.Core;
using Slice.Data;
using SubjectEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Slice.MockService.DataProvider
{
    public static class DucDataProvider
    {
        public static Dictionary<string, List<DucValueDto>> VideoInstances { get; set; }

        static DucDataProvider()
        {
            VideoInstances = new Dictionary<string, List<DucValueDto>>();

            string[] videoIds = new string[] { "RnaGFvB353A", "JLU0FcE-7cw", "GJcN4EGDZgc", "Ala6gAUK3fc", "xz3eV5MRIOM", "WN42Ey4YfKI" };
            foreach (string videoId in videoIds)
            {
                string pageAlias = string.Format("video/{0}", videoId).ToLower();
                VideoInstances.Add(pageAlias, MockYouTubeVideoValues(videoId));
            }
        }

        public static List<DucValueDto> MockRotatorValues()
        {
            List<DucValueDto> items = new List<DucValueDto>();

            DucValueDto ducValue1 = new DucValueDto();
            items.Add(ducValue1);
            ducValue1.DucId = BlockRegister.Rotator.RotatorItemCollection;
            ducValue1.AttachedSubjects = MockAttachedSubjects(4, "Recipe");

            return items;
        }

        public static List<DucValueDto> MockListViewValues(string contentType)
        {
            List<DucValueDto> items = new List<DucValueDto>();

            DucValueDto ducValue1 = new DucValueDto();
            items.Add(ducValue1);
            ducValue1.DucId = BlockRegister.ListViewWidget.PageSize;
            ducValue1.ValueInt = 10;

            DucValueDto ducValue2 = new DucValueDto();
            items.Add(ducValue2);
            ducValue2.DucId = BlockRegister.ListViewWidget.ReferenceList;
            //ducValue2.ValueInt = 0;
            //ducValue2.AttachedSubjects = MockAttachedSubjects(16, contentType);

            return items;
        }

        public static List<DucValueDto> MockFeaturedContentValues()
        {
            List<DucValueDto> items = new List<DucValueDto>();

            DucValueDto ducValue1 = new DucValueDto();
            items.Add(ducValue1);
            ducValue1.DucId = BlockRegister.FeaturedContent.Title;
            ducValue1.ValueText = "Editor's pick";

            DucValueDto ducValue2 = new DucValueDto();
            items.Add(ducValue2);
            ducValue2.DucId = BlockRegister.FeaturedContent.FeatureItemCollection;
            ducValue2.AttachedSubjects = MockAttachedSubjects(6, "Recipe");

            return items;
        }

        public static List<DucValueDto> MockFeaturedContent2ndValues()
        {
            List<DucValueDto> items = new List<DucValueDto>();

            DucValueDto ducValue1 = new DucValueDto();
            items.Add(ducValue1);
            ducValue1.DucId = BlockRegister.FeaturedContent2nd.Title;
            ducValue1.ValueText = "Latest Recipes";

            DucValueDto ducValue2 = new DucValueDto();
            items.Add(ducValue2);
            ducValue2.DucId = BlockRegister.FeaturedContent2nd.FeatureItemCollection;
            ducValue2.AttachedSubjects = MockAttachedSubjects(6, "Recipe");

            return items;
        }

        public static List<DucValueDto> MockRecipeDetailValues()
        {
            List<DucValueDto> items = new List<DucValueDto>();

            DucValueDto ducValue1 = new DucValueDto();
            items.Add(ducValue1);
            ducValue1.DucId = BlockRegister.RecipeBlock.Name;
            ducValue1.ValueText = "Recipe name";

            DucValueDto ducValue2 = new DucValueDto();
            items.Add(ducValue2);
            ducValue2.DucId = BlockRegister.RecipeBlock.Abstract;
            ducValue2.ValueText = "Recipe abstract Recipe abstract Recipe abstract Recipe abstract Recipe abstract Recipe abstract";

            DucValueDto ducValue3 = new DucValueDto();
            items.Add(ducValue3);
            ducValue3.DucId = BlockRegister.RecipeBlock.Image;
            ducValue3.ValueText = "Recipe image";
            ducValue3.ValueUrl = "http://placehold.it/460x230";

            DucValueDto ducValue4 = new DucValueDto();
            items.Add(ducValue4);
            ducValue4.DucId = BlockRegister.RecipeBlock.PrepareTime;
            ducValue4.ValueInt = 10;

            DucValueDto ducValue5 = new DucValueDto();
            items.Add(ducValue5);
            ducValue5.DucId = BlockRegister.RecipeBlock.CookTime;
            ducValue5.ValueInt = 30;

            DucValueDto ducValue6 = new DucValueDto();
            items.Add(ducValue6);
            ducValue6.DucId = BlockRegister.RecipeBlock.Servings;
            ducValue6.ValueInt = 3;

            //DucValueDto ducValue7 = new DucValueDto();
            //items.Add(ducValue7);
            //ducValue7.DucId = CmsRegister.RecipeBlock.Tips;
            //ducValue7.ValueHtml = "Recipe tips 123";

            return items;
        }

        public static List<GridRowDto> MockRecipeDetailIngredientGridRows(int rowCount)
        {
            List<GridRowDto> rows = new List<GridRowDto>();

            for (int index = 1; index <= rowCount; index++)
            {
                GridRowDto row = new GridRowDto();
                rows.Add(row);
                row.GridId = CmsRegister.IngredientGridId;
                List<DucValueDto> cells = new List<DucValueDto>();
                row.Cells = cells;

                DucValueDto valueOrder = new DucValueDto { DucId = BlockRegister.RecipeIngredientGrid.Col_Sortorder, ValueInt = index };
                cells.Add(valueOrder);

                DucValueDto valueIngredientName = new DucValueDto { DucId = BlockRegister.RecipeIngredientGrid.Col_IngredientName, ValueText = string.Format("ingredient {0}, just samples", index) };
                cells.Add(valueIngredientName);

                DucValueDto valueQuantity = new DucValueDto { DucId = BlockRegister.RecipeIngredientGrid.Col_Quantity, ValueText = index.ToString() };
                cells.Add(valueQuantity);

                DucValueDto valueUnitOfMeasure = new DucValueDto { DucId = BlockRegister.RecipeIngredientGrid.Col_UnitOfMeasure, ValueText = "spoons" };
                cells.Add(valueUnitOfMeasure);
            }

            return rows;
        }

        public static List<GridRowDto> MockRecipeDetailInstructionGridRows(int rowCount)
        {
            List<GridRowDto> rows = new List<GridRowDto>();

            for (int index = 1; index <= rowCount; index++)
            {
                GridRowDto row = new GridRowDto();
                rows.Add(row);
                row.GridId = CmsRegister.InstructionGridId;
                List<DucValueDto> cells = new List<DucValueDto>();
                row.Cells = cells;

                DucValueDto valueOrder = new DucValueDto { DucId = BlockRegister.RecipeInstructionGrid.Col_Sortorder, ValueInt = index };
                cells.Add(valueOrder);

                DucValueDto valueDescription = new DucValueDto { DucId = BlockRegister.RecipeInstructionGrid.Col_Description };
                valueDescription.ValueText = string.Format("recipe instruction {0}, exact instructions on how to make this recipe exact instructions on how to make this recipe. exact instructions on how to make this recipe", index);
                cells.Add(valueDescription);
            }

            return rows;
        }

        public static List<DucValueDto> MockPhotoGalleryValues()
        {
            List<DucValueDto> items = new List<DucValueDto>();

            DucValueDto ducValue1 = new DucValueDto();
            items.Add(ducValue1);
            ducValue1.DucId = BlockRegister.PhotoGallery.Title;
            ducValue1.ValueText = "Gallery Title";

            DucValueDto ducValue2 = new DucValueDto();
            items.Add(ducValue2);
            ducValue2.DucId = BlockRegister.PhotoGallery.Abstract;
            ducValue2.ValueText = "Gallery brief description";

            DucValueDto ducValue3 = new DucValueDto { DucId = BlockRegister.PhotoGallery.RelatedGalleryList };
            items.Add(ducValue3);
            ducValue3.ValueInt = 1;
            ducValue3.AttachedSubjects = DucDataProvider.MockAttachedSubjects(4, "Gallery");


            return items;
        }

        public static List<GridRowDto> MockPhotoGalleryPhotosGridRows(int rowCount)
        {
            List<GridRowDto> rows = new List<GridRowDto>();

            for (int index = 1; index <= rowCount; index++)
            {
                GridRowDto row = new GridRowDto();
                rows.Add(row);
                row.GridId = CmsRegister.PhotosGridId;
                List<DucValueDto> cells = new List<DucValueDto>();
                row.Cells = cells;

                DucValueDto valueTitle = new DucValueDto { DucId = BlockRegister.PhotoGrid.Col_Title };
                cells.Add(valueTitle);
                valueTitle.ValueText = string.Format("Photo No.{0} Title", index);

                DucValueDto valueAbstract = new DucValueDto { DucId = BlockRegister.PhotoGrid.Col_Abstract };
                cells.Add(valueAbstract);
                valueAbstract.ValueText = string.Format("Photo No.{0} abstract", index);

                DucValueDto valueImage = new DucValueDto { DucId = BlockRegister.PhotoGrid.Col_Image };
                cells.Add(valueImage);
                valueImage.ValueUrl = "http://placehold.it/460x230";
            }

            return rows;
        }

        public static List<DucValueDto> MockBlogDetailValues()
        {
            List<DucValueDto> items = new List<DucValueDto>();

            DucValueDto ducValue1 = new DucValueDto();
            items.Add(ducValue1);
            ducValue1.DucId = BlockRegister.BlogDetail.Title;
            ducValue1.ValueText = "Test Blog Title";

            DucValueDto ducValue2 = new DucValueDto();
            items.Add(ducValue2);
            ducValue2.DucId = BlockRegister.BlogDetail.Author;
            ducValue2.ValueText = "Dave Test";

            DucValueDto ducValue3 = new DucValueDto();
            items.Add(ducValue3);
            ducValue3.DucId = BlockRegister.BlogDetail.IssuedTime;
            ducValue3.ValueDate = DateTime.Today;

            DucValueDto ducValue4 = new DucValueDto { DucId = BlockRegister.BlogDetail.Image };
            items.Add(ducValue4);
            ducValue4.ValueUrl = "http://placehold.it/460x230";

            DucValueDto ducValue5 = new DucValueDto { DucId = BlockRegister.BlogDetail.Content };
            items.Add(ducValue5);
            ducValue5.ValueHtml = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pulvinar metus et urna tempus interdum. Vestibulum purus neque, blandit non sollicitudin vitae, molestie in nisi. Cras in blandit erat. Pellentesque et dolor ut libero ultrices vulputate. Donec at velit ligula. Nunc nec tincidunt est, sit amet tincidunt sapien. Donec condimentum leo tristique sapien suscipit venenatis. Aenean dapibus condimentum porttitor. Mauris vulputate leo sit amet enim posuere, eu egestas ante pulvinar. Pellentesque sit amet arcu quis justo placerat vestibulum eu non odio. In vulputate ipsum sem, eu molestie ligula ultrices sit amet. Praesent pellentesque diam at ex hendrerit, non sagittis ligula consectetur. Suspendisse id turpis velit. Nunc hendrerit dolor neque, ac facilisis urna auctor a. Nunc sodales semper tellus vel lobortis. Nunc eget enim at nunc accumsan suscipit vel a nunc. Sed iaculis placerat ante, in lacinia dui lacinia nec. Duis malesuada luctus pellentesque. Vestibulum eros nisl, posuere vel molestie eu, consectetur quis nibh. Nunc at eleifend quam. Vestibulum urna neque, sodales non posuere vel, tristique eget risus. Integer blandit, orci ac ultricies efficitur, enim libero ultricies arcu, ut viverra metus massa ut massa. Sed ut mauris ac orci faucibus dignissim. Morbi laoreet id felis non gravida. Vivamus bibendum, nulla vitae luctus pellentesque, justo ligula maximus erat, non tempor mauris arcu quis ex. Cras viverra et quam sit amet efficitur. Ut pulvinar volutpat enim ac mattis. Vivamus at dolor lacus. Sed tincidunt arcu at nibh ornare sollicitudin. Morbi blandit vulputate lectus quis vestibulum. Vivamus vel velit dapibus, efficitur libero eget, commodo leo. Nulla facilisi. Nulla mollis et elit sit amet sodales. Nam fermentum maximus odio nec consequat. Nulla ut feugiat ex. Mauris vitae sollicitudin neque. Proin sagittis sapien eu mattis pretium. Pellentesque maximus enim a diam semper vulputate. Nam cursus suscipit purus, at egestas enim pellentesque pulvinar. Cras non dolor ex. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Integer blandit massa non fringilla auctor.";

            return items;
        }

        public static List<DucValueDto> MockYouTubeVideoValues(string videoId)
        {
            List<DucValueDto> items = new List<DucValueDto>();

            DucValueDto ducValue1 = new DucValueDto();
            items.Add(ducValue1);
            ducValue1.DucId = BlockRegister.YouTubeVideoBlock.Title;
            ducValue1.ValueText = string.Format("Video {0} Title", videoId);

            DucValueDto ducValue2 = new DucValueDto();
            items.Add(ducValue2);
            ducValue2.DucId = BlockRegister.YouTubeVideoBlock.Description;
            ducValue2.ValueText = string.Format("Video {0} brief description", videoId);

            DucValueDto ducValue3 = new DucValueDto { DucId = BlockRegister.YouTubeVideoBlock.VideoId };
            items.Add(ducValue3);
            ducValue3.ValueText = videoId;

            DucValueDto ducValue4 = new DucValueDto { DucId = BlockRegister.YouTubeVideoBlock.ThumbnailUrl };
            items.Add(ducValue4);
            ducValue4.ValueText = string.Format("http://img.youtube.com/vi/{0}/0.jpg", videoId);

            return items;
        }

        public static List<SubjectInfoDto> MockAttachedSubjectsWithPagination(object id, int pageIndex, int pageSize)
        {
            string contentType = "Recipe";
            switch ((int)id)
            {
                case 11:
                    contentType = "Recipe";
                    break;
                case 12:
                    contentType = "Article";
                    break;
                case 13:
                    contentType = "Gallery";
                    break;
                case 14:
                    return MockAttachedSubjectsOfVideo();
            }

            return MockAttachedSubjects(pageSize, contentType);
        }

        public static List<SubjectInfoDto> MockAttachedSubjects(int count, string contentType)
        {
            List<SubjectInfoDto> subjects = new List<SubjectInfoDto>();
            for (int i = 1; i <= count; i++)
            {
                SubjectInfoDto subject = new SubjectInfoDto();
                subjects.Add(subject);
                subject.ReferenceId = i;
                subject.TotalCount = 100;
                subject.Title = string.Format("{0}{1} Title", contentType, i);
                subject.Description = string.Format("{0}{1} description, this is very interesting.", contentType, i);
                subject.UrlAlias = string.Format("{0}/{0}-{1}-alias/{2}", contentType, i, i).ToLower();
                subject.ImageUrl = "http://placehold.it/460x230";
            }

            return subjects;
        }

        public static List<SubjectInfoDto> MockAttachedSubjectsOfVideo()
        {
            List<SubjectInfoDto> subjects = new List<SubjectInfoDto>();
            foreach (string videoId in VideoInstances.Keys)
            {
                SubjectInfoDto subject = new SubjectInfoDto();
                subjects.Add(subject);
                subject.Title = string.Format("{0} Title", videoId);
                subject.Description = string.Format("{0} description, this is very interesting.", videoId);
                subject.UrlAlias = string.Format("{0}", videoId).ToLower();
                // get imageUrl
                List<DucValueDto> values = VideoInstances[videoId];
                DucValueDto value = values.FirstOrDefault(o => object.Equals(o.DucId, BlockRegister.YouTubeVideoBlock.ThumbnailUrl));
                if (value != null)
                {
                    subject.ImageUrl = value.ValueText;
                }
                else
                {
                    subject.ImageUrl = "http://placehold.it/460x230";
                }
            }

            return subjects;
        }

        private static string GetVideoId()
        {
            string[] videoIds = new string[] { "RnaGFvB353A", "JLU0FcE-7cw", "GJcN4EGDZgc", "Ala6gAUK3fc", "xz3eV5MRIOM", "WN42Ey4YfKI" };
            Random indexGenerator = new Random(DateTime.Now.Second);
            int index = indexGenerator.Next(6);

            return videoIds[index];
        }
    }
}
