﻿using Framework.Core;
namespace Slice.Data
{
    public class CategoryDto : BaseDto
    {
        public string CategoryText { get; set; }
        public string Slug { get; set; }
        public object TemplateId { get; set; }
    }
}
