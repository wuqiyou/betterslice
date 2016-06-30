using System.ComponentModel.DataAnnotations;
using Slice.Data;

namespace Slice.Web.Models.Widgets
{
    public class ContactUs : WidgetViewModel
    {
        [Required(ErrorMessage = "*Please input email address")]
        public string Email { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "*Please input your comments")]
        public string Content { get; set; }

        public string SuccessfulMessage { get; set; }

        public ContactUs()
        {
        }

        public override void UpdateAsset(AssetModel asset)
        {
            base.UpdateAsset(asset);

            asset.AddTailJSPath("~/Scripts/pages/contactus.js");
        }

        public override void Populate(ReferenceInfoDto referenceInfo)
        {
            SuccessfulMessage = "Thank you. Your message was successfully sent.";
        }
    }
}