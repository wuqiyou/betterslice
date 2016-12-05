using Slice.Core;
using Slice.Data;
using Slice.Web.Models.Entity;
using Slice.Web.Models.Shared;
using SubjectEngine.Core;
using System;
using System.Linq;

namespace Slice.Web.Models.Widgets
{
    public class RecipeDetail : WidgetViewModel, IMetadataProvider
    {
        public Recipe Recipe { get; set; }
        public ReferenceKeywordsViewModel TagsViewModel { get; set; }
        public SocialShareBarViewModel SocialShareBarViewModel { get; set; } 

        public RecipeDetail()
        {
            Recipe = new Recipe();
        }

        public override void UpdateAsset(AssetViewModel asset)
        {
            asset.AddCSSPath("~/Content/widgets/recipeDetail.css");
            asset.AddCSSPath("~/Content/widgets/subjectDetail.css");
            asset.AddCSSPath("~/Content/objects/socialShare.css");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.RecipeBlock.Name))
            {
                Recipe.Name = referenceInfo.ValuesDic[BlockRegister.RecipeBlock.Name].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.RecipeBlock.Subtitle))
            {
                Recipe.Subtitle = referenceInfo.ValuesDic[BlockRegister.RecipeBlock.Subtitle].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.RecipeBlock.Image))
            {
                Recipe.ImageUrl = referenceInfo.ValuesDic[BlockRegister.RecipeBlock.Image].ValueUrl;
                Recipe.ImageText = referenceInfo.ValuesDic[BlockRegister.RecipeBlock.Image].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.RecipeBlock.Abstract))
            {
                Recipe.Abstract = referenceInfo.ValuesDic[BlockRegister.RecipeBlock.Abstract].ValueText;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.RecipeBlock.Tips))
            {
                Recipe.Tips = referenceInfo.ValuesDic[BlockRegister.RecipeBlock.Tips].ValueHtml;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.RecipeBlock.PrepareTime))
            {
                Recipe.PrepareTimeMinutes = referenceInfo.ValuesDic[BlockRegister.RecipeBlock.PrepareTime].ValueInt;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.RecipeBlock.CookTime))
            {
                Recipe.CookTimeMinutes = referenceInfo.ValuesDic[BlockRegister.RecipeBlock.CookTime].ValueInt;
            }
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.RecipeBlock.Servings))
            {
                Recipe.Servings = referenceInfo.ValuesDic[BlockRegister.RecipeBlock.Servings].ValueInt;
            }
            SubitemInfoDto ingredientSubitem = BlockInfo.Subitems.SingleOrDefault(o => object.Equals(o.SubitemId, BlockRegister.RecipeBlock.IngredientGrid));
            object ingredientGridId = null;
            if (ingredientSubitem != null && ingredientSubitem.Grid != null)
            {
                ingredientGridId = ingredientSubitem.Grid.Id;
            }
            SubitemInfoDto instructionSubitem = BlockInfo.Subitems.SingleOrDefault(o => object.Equals(o.SubitemId, BlockRegister.RecipeBlock.InstructionGrid));
            object instructionGridId = null;
            if (instructionSubitem != null && instructionSubitem.Grid != null)
            {
                instructionGridId = instructionSubitem.Grid.Id;
            }

            if (referenceInfo.GridRows != null)
            {
                foreach (GridRowDto row in referenceInfo.GridRows.Where(o => object.Equals(o.GridId, ingredientGridId)))
                {
                    RecipeIngredient item = new RecipeIngredient();
                    Recipe.RecipeIngredients.Add(item);
                    DucValueDto valueOrder = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.RecipeIngredientGrid.Col_Sortorder));
                    if (valueOrder != null)
                    {
                        item.Sortorder = valueOrder.ValueInt.HasValue ? valueOrder.ValueInt.Value : 0;
                    }
                    DucValueDto valueIngredientName = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.RecipeIngredientGrid.Col_IngredientName));
                    if (valueIngredientName != null)
                    {
                        item.IngredientName = valueIngredientName.ValueText;
                    }
                    DucValueDto valueQuantity = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.RecipeIngredientGrid.Col_Quantity));
                    if (valueQuantity != null)
                    {
                        item.Quantity = valueQuantity.ValueText;
                    }
                    DucValueDto valueUnitOfMeasure = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.RecipeIngredientGrid.Col_UnitOfMeasure));
                    if (valueUnitOfMeasure != null)
                    {
                        item.UnitOfMeasure = valueUnitOfMeasure.ValueText;
                    }
                }
                foreach (GridRowDto row in referenceInfo.GridRows.Where(o => object.Equals(o.GridId, instructionGridId)))
                {
                    RecipeInstruction item = new RecipeInstruction();
                    Recipe.RecipeInstructions.Add(item);
                    DucValueDto valueOrder = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.RecipeInstructionGrid.Col_Sortorder));
                    if (valueOrder != null)
                    {
                        item.Sortorder = valueOrder.ValueInt.HasValue ? valueOrder.ValueInt.Value : 0;
                    }
                    DucValueDto valueDescription = row.Cells.SingleOrDefault(o => object.Equals(o.DucId, BlockRegister.RecipeInstructionGrid.Col_Description));
                    if (valueDescription != null)
                    {
                        item.Description = valueDescription.ValueText;
                    }
                }
            }
            // Keyword view model
            TagsViewModel = new ReferenceKeywordsViewModel(referenceInfo);
            SocialShareBarViewModel = new SocialShareBarViewModel(RequestedUrl.AbsoluteUri, Recipe.Name, Recipe.ImageUrl);
        }

        public void UpdateMetadata(MetadataModel metadata)
        {
            if (!metadata.Title.TrimHasValue())
            {
                metadata.Title = Recipe.Name;
            }
            if (!metadata.Description.TrimHasValue())
            {
                metadata.Description = Recipe.Abstract;
            }
            if (!metadata.OGImage.TrimHasValue())
            {
                metadata.OGImage = Recipe.ImageUrl;
            }
        }
    }
}