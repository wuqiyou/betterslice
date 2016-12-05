using Slice.Core;
using Slice.Data;
using Slice.Web.Common;
using Slice.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Slice.RecipeWeb.Controllers
{
    public class RecipeController : ContentBaseController
    {
        public const string ControllerName = "Recipe";
        public const string CategoryAction = "Category";
        public const string TagAction = "Tag";

        public ViewResult Tag(string tag)
        {
            int pageIndex = PageIndex.HasValue ? PageIndex.Value : 1;
            int pageSize = 12;
            if (WebContext.Current.RecipeKeywords.ContainsKey(tag))
            {
                KeywordDto keywordDto = WebContext.Current.RecipeKeywords[tag];
                IEnumerable<SubjectInfoDto> result = Service.GetSubjectsByKeyword(keywordDto.Id, CmsRegister.RECIPE_TEMPLATE_ID, pageIndex, pageSize, CurrentLanguage.Id);
                TagPageViewModel model = new TagPageViewModel(keywordDto.Name, result, HttpContext.Request.Url, pageIndex, pageSize, CurrentLanguage);
                model.Populate();

                return View(model);
            }
            else
            {
                return null;
            }
        }

        public ViewResult Category(string category)
        {
            int pageIndex = PageIndex.HasValue ? PageIndex.Value : 1;
            int pageSize = 24;

            if (WebContext.Current.RecipeCategories.ContainsKey(category))
            {
                CategoryDto categoryDto = WebContext.Current.RecipeCategories[category];
                IEnumerable<SubjectInfoDto> result = Service.GetSubjectsByCategory(categoryDto.Id, CmsRegister.RECIPE_TEMPLATE_ID, pageIndex, pageSize, CurrentLanguage.Id);
                CategoryPageViewModel model = new CategoryPageViewModel(categoryDto.CategoryText, result, HttpContext.Request.Url, pageIndex, pageSize, CurrentLanguage);
                model.Populate();

                return View(model);
            }
            else
            {
                return null;
            }
        }

        public PartialViewResult LoadMore(int categoryId, int? pageIndex)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            IEnumerable<SubjectInfoDto> result = Service.GetSubjectsByCategory(categoryId, CmsRegister.RECIPE_TEMPLATE_ID, pageIndex.Value, 24, CurrentLanguage.Id);
            return PartialView("_SubjectsCardView", result);
        }
    }
}
