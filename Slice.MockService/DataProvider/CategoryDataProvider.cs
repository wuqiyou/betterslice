using System.Collections.Generic;
using Slice.Data;

namespace Slice.MockService.DataProvider
{
    public static class CategoryDataProvider
    {
        public static List<CategoryDto> MockCategories()
        {
            List<CategoryDto> categories = new List<CategoryDto>();
            for (int j = 1; j <= 7; j++)
            {
                CategoryDto item = new CategoryDto { Id = j, CategoryText = string.Format("Category{0}", j), Slug = string.Format("category{0}", j) };
                categories.Add(item);
            }

            return categories;
        }
    }
}
