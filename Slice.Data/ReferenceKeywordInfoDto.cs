﻿using Framework.Core;

namespace Slice.Data
{
    public class ReferenceKeywordInfoDto : BaseDto
    {
        public object KeywordId { get; set; }
        public string KeywordName { get; set; }
        public string KeywordSlug { get; set; }
        public int Sort { get; set; }
    }
}
