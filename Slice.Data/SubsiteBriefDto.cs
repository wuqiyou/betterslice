﻿using Framework.Core;

namespace Slice.Data
{
    public class SubsiteBriefDto : BaseDto
    {
        public int SubsiteId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Slug { get; set; }
        public string Culture { get; set; }
        public string BackColor { get; set; }
        public string TitleColor { get; set; }
        public string BannerUrl { get; set; }
        public int? DefaultLanguageId { get; set; }
        public int? DefaultLocationId { get; set; }
        public int? SubsiteFolderId { get; set; }
        public bool IsPublished { get; set; }
    }
}
