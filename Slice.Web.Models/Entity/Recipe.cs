using System.Collections.Generic;

namespace Slice.Web.Models.Entity
{
    public class Recipe
    {
        public object Id { get; set; }
        public string Name { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
        public string ImageText { get; set; }
        public string Abstract { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
        public List<RecipeInstruction> RecipeInstructions { get; set; }
        public string Tips { get; set; }
        public RecipeRating Rating { get; set; }
        public int? PrepareTimeMinutes { get; set; }
        public int? CookTimeMinutes { get; set; }
        public int? Servings { get; set; }
        
        private int? _firstHalfCount;

        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredient>();
            RecipeInstructions = new List<RecipeInstruction>();
        }

        public int? TotalTimeMinutes
        {
            get
            {
                return PrepareTimeMinutes + CookTimeMinutes;
            }
        }

        private int FirstHalfCount
        {
            get
            {
                if (!_firstHalfCount.HasValue)
                {
                    _firstHalfCount = RecipeIngredients.Count / 2 + RecipeIngredients.Count % 2;
                }

                return _firstHalfCount.Value;
            }
        }

        public List<RecipeIngredient> FirstHalfIngredients
        {
            get
            {
                return RecipeIngredients.GetRange(0, FirstHalfCount);
            }
        }

        public List<RecipeIngredient> SecondHalfIngredients
        {
            get
            {
                int half = RecipeIngredients.Count / 2;

                return RecipeIngredients.GetRange(FirstHalfCount, half);
            }
        }
    }
}
