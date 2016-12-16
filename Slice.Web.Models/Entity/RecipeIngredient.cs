using Slice.Core;
using System.Text;

namespace Slice.Web.Models.Entity
{
    public class RecipeIngredient
    {
        public int Sortorder { get; set; }
        public string IngredientName { get; set; }
        public string Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        // Not used for now
        public string IngredientLabel { get; set; }
        public string IsMainIngredient { get; set; }
        public string UnitOfMeasureId { get; set; }
        public string UnitOfMeasureLabel { get; set; }

        public virtual string Display
        {
            get
            {
                StringBuilder result = new StringBuilder();

                string quantityDisplay = StringHelper.ConvertToFraction(Quantity);
                if (quantityDisplay != string.Empty)
                {
                    result.Append(quantityDisplay);
                    result.Append(" ");
                    result.Append(UnitOfMeasure);
                    result.Append(" ");
                }

                result.Append(IngredientName);

                return result.ToString();
            }
        }
    }
}
