using System.ComponentModel.DataAnnotations;

namespace Slice.Web.Models
{
    public class ReviewViewModel
    {
        public int RefId { get; set; }

        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        public string Content { get; set; }
    }
}