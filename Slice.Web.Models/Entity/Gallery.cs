using System.Collections.Generic;
using Slice.Data;

namespace Slice.Web.Models.Entity
{
    public class Gallery
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Abstract { get; set; }
        public string ThumbnailUrl { get; set; }
        public List<Photo> Items { get; set; }
        public List<SubjectInfoDto> RelatedGalleries { get; set; }

        public Gallery()
        {
            Items = new List<Photo>();
            RelatedGalleries = new List<SubjectInfoDto>();
        }
    }
}
