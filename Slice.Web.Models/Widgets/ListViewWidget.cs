using Microsoft.Practices.ServiceLocation;
using Slice.Data;
using Slice.Service.Contract;
using Slice.Web.Common;
using SubjectEngine.Core;
using System.Collections.Generic;
using System.Linq;

namespace Slice.Web.Models.Widgets
{
    public class ListViewWidget : WidgetViewModel
    {
        public IEnumerable<SubjectInfoDto> Items { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }

        public ListViewWidget()
        {
        }

        public override void UpdateAsset(AssetModel asset)
        {
            asset.AddCSSPath("~/Content/objects/cardView.css");
            asset.AddCSSPath("~/Content/objects/pagination.css");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            int pageSize = 0;
            bool showPagination = false;

            if (referenceInfo.ValuesDic.ContainsKey(BlockRegister.ListViewWidget.PageSize))
            {
                DucValueDto value = referenceInfo.ValuesDic[BlockRegister.ListViewWidget.PageSize];
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

            int currentPage = PageIndex.HasValue && showPagination ? PageIndex.Value : 1;

            object languageId = CurrentLanguage != null ? CurrentLanguage.Id : null;
            IReferenceService service = ServiceLocator.Current.GetInstance<IReferenceService>();
            Items = service.GetAttachedSubjects(referenceInfo.ReferenceId,
                        BlockRegister.ListViewWidget.ReferenceList,
                        currentPage, pageSize, languageId);
            int totalCount = Items.Any() ? Items.First<SubjectInfoDto>().TotalCount : 0;

            PaginationViewModel = new PaginationViewModel(totalCount, currentPage, pageSize, WebContext.Current.PagerWindowSize);
            PaginationViewModel.ShowTotal = false;
        }
    }
}