using System.Collections.Generic;
using Slice.Data;

namespace Slice.Web.Models.Entity
{
    public class Article
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string Abstract { get; set; }
        public string ImageUrl { get; set; }

        public Article()
        {
            Title = string.Empty;
            Subtitle = string.Empty;
            Content = string.Empty;
            Abstract = string.Empty;
            ImageUrl = string.Empty;
        }
    }
}
