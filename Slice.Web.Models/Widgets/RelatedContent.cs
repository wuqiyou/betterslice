﻿using Slice.Data;
using SubjectEngine.Core;
using System.Collections.Generic;
using System.Linq;

namespace Slice.Web.Models.Widgets
{
    public class RelatedContent : WidgetViewModel
    {
        public string Title { get; set; }
        public IEnumerable<SubjectInfoDto> Items { get; set; }

        public RelatedContent()
        {
            Title = "Related content";
        }

        public override void UpdateAsset(AssetViewModel asset)
        {
            asset.AddCSSPath("~/Content/widgets/relatedContent.css");
            asset.AddCSSPath("~/Content/objects/cardView.css");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            Title = GetValueText(referenceInfo, BlockRegister.RelatedContent.Title);

            if (referenceInfo.RelatedSubjects != null)
            {
                IList<SubjectInfoDto> items = referenceInfo.RelatedSubjects.Where(o => !object.Equals(o.ReferenceId, referenceInfo.ReferenceId)).ToList();
                // Set flag
                HasValue = items.Count > 0;
                Items = items;
            }
        }
    }
}