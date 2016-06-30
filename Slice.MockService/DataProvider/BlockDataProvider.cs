using Slice.Core;
using Slice.Data;
using SubjectEngine.Core;
using System.Collections.Generic;

namespace Slice.MockService.DataProvider
{
    public static class BlockDataProvider
    {
        public static BlockInfoDto MockHeroImage()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "Hero Image";
            block.WidgetName = BlockRegister.HeroImageBlock.WidgetName;
            block.IsBuiltIn = true;

            return block;
        }

        public static BlockInfoDto MockRotator()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "Rotator";
            block.WidgetName = BlockRegister.Rotator.WidgetName;
            block.IsBuiltIn = true;

            return block;
        }

        public static BlockInfoDto MockFeaturedContent()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "FeaturedContent";
            block.WidgetName = BlockRegister.FeaturedContent.WidgetName;
            block.IsBuiltIn = true;

            return block;
        }

        public static BlockInfoDto MockFeaturedContent2nd()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "FeaturedContent2";
            block.WidgetName = BlockRegister.FeaturedContent2nd.WidgetName;
            block.IsBuiltIn = true;

            return block;
        }

        public static BlockInfoDto MockListViewWidget()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "ListViewWidget";
            block.WidgetName = BlockRegister.ListViewWidget.WidgetName;
            block.IsBuiltIn = true;

            return block;
        }

        public static BlockInfoDto MockCardViewWidget()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "CardViewWidget";
            block.WidgetName = BlockRegister.CardViewWidget.WidgetName;
            block.IsBuiltIn = true;

            return block;
        }

        public static BlockInfoDto MockRecipeDetail()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "RecipeDetail";
            block.WidgetName = BlockRegister.RecipeBlock.WidgetName;
            block.IsBuiltIn = true;

            List<SubitemInfoDto> items = new List<SubitemInfoDto>();
            block.Subitems = items;
            GridDto ingredientGrid = new GridDto() { Id = CmsRegister.IngredientGridId };
            GridDto instructionGrid = new GridDto() { Id = CmsRegister.InstructionGridId };
            items.Add(new SubitemInfoDto { SubitemId = BlockRegister.RecipeBlock.IngredientGrid, Grid = ingredientGrid });
            items.Add(new SubitemInfoDto { SubitemId = BlockRegister.RecipeBlock.InstructionGrid, Grid = instructionGrid });

            return block;
        }

        public static BlockInfoDto MockRelatedContent()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "RelatedContent";
            block.WidgetName = BlockRegister.RelatedContent.WidgetName;
            block.IsBuiltIn = true;

            return block;
        }

        public static BlockInfoDto MockPhotoGallery()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "PhotoGallery";
            block.WidgetName = BlockRegister.PhotoGallery.WidgetName;
            block.IsBuiltIn = true;

            List<SubitemInfoDto> items = new List<SubitemInfoDto>();
            block.Subitems = items;
            GridDto photosGrid = new GridDto() { Id = CmsRegister.PhotosGridId };
            items.Add(new SubitemInfoDto { SubitemId = BlockRegister.PhotoGallery.PhotosGrid, Grid = photosGrid });

            return block;
        }

        public static BlockInfoDto MockBlogDetail()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "BlogDetail";
            block.WidgetName = BlockRegister.BlogDetail.WidgetName;
            block.IsBuiltIn = true;

            return block;
        }

        public static BlockInfoDto MockYouTubeVideo()
        {
            BlockInfoDto block = new BlockInfoDto();
            block.Name = "YouTubeVideo";
            block.WidgetName = BlockRegister.YouTubeVideoBlock.WidgetName;
            block.IsBuiltIn = true;

            return block;
        }
    }
}
