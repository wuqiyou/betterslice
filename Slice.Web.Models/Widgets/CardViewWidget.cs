using Microsoft.Practices.ServiceLocation;
using Slice.Data;
using Slice.Service.Contract;
using Slice.Web.Common;
using SubjectEngine.Core;
using System.Collections.Generic;
using System.Linq;

namespace Slice.Web.Models.Widgets
{
    public class CardViewWidget : WidgetViewModel
    {
        public CardViewViewModel CardViewViewModel { get; set; }

        public CardViewWidget()
        {
        }

        public override void UpdateAsset(AssetModel asset)
        {
            if (CardViewViewModel.PaginationViewModel != null && !CardViewViewModel.PaginationViewModel.IsSuppressed)
            {
                asset.AddCSSPath("~/Content/objects/pagination.css");
            }
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            int pageSize = 0;
            bool showPagination = false;
            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.CardViewWidget.PageSize))
            {
                DucValueDto value = referenceInfo.ValuesDic[BlockRegister.CardViewWidget.PageSize];
                if (value.ValueInt.HasValue)
                {
                    pageSize = value.ValueInt.Value;
                }
                showPagination = pageSize > 0;
            }
            if (pageSize == 0)
            {
                pageSize = WebContext.Current.MaxPageSize;
            }

            int currentPage = PageIndex.HasValue ? PageIndex.Value : 1;

            object languageId = CurrentLanguage != null ? CurrentLanguage.Id : null;
            IReferenceService service = ServiceLocator.Current.GetInstance<IReferenceService>();
            IEnumerable<SubjectInfoDto>  items = service.GetAttachedSubjects(referenceInfo.ReferenceId,
                        BlockRegister.CardViewWidget.ReferenceList,
                        currentPage, pageSize, languageId);
            int totalCount = items.Any() ? items.First<SubjectInfoDto>().TotalCount : 0;

            CardViewViewModel = new CardViewViewModel(items, showPagination, totalCount, currentPage, pageSize, WebContext.Current.PagerWindowSize);
        }
    }
}