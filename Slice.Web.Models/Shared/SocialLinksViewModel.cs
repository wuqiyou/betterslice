using System.Collections.Generic;

namespace Slice.Web.Models.Shared
{
    public class SocialLinksViewModel
    {
        public List<SocialShareButton> ShareButtons { get; set; }

        public SocialLinksViewModel()
        {
            ShareButtons = new List<SocialShareButton>();

            AddButton(SocialShareButtonType.Facebook, "/");
            AddButton(SocialShareButtonType.Twitter, "/");
            AddButton(SocialShareButtonType.Pinterest, "/");
        }

        public void AddButton(SocialShareButtonType icon, string linkUrl)
        {
            SocialShareButton button = new SocialShareButton() { Key = icon.ToString().ToLower(), Name = icon.ToString() };
            ShareButtons.Add(button);
            button.Url = linkUrl;
        }
    }
}
