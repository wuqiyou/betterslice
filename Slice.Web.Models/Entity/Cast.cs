using System;

namespace Slice.Web.Models.Entity
{
    public class Cast
    {
        public string MemberId { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime DateEnrolled { get; set; }
        public string Notes { get; set; }
    }
}
