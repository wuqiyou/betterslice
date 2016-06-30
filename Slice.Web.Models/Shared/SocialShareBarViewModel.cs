using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slice.Web.Models.Shared
{
    public enum SocialShareButtonType
    {
        Facebook,
        Twitter,
        GooglePlus,
        Pinterest,
    }

    public class SocialShareButton
    {
        public static readonly Dictionary<SocialShareButtonType, string> URL_FORMAT_DEFAULTS = new Dictionary<SocialShareButtonType, string>() {
            // TODO: add share link formats
            { SocialShareButtonType.Twitter, "https://twitter.com/intent/tweet?url={0}&text={1}" },
            { SocialShareButtonType.Facebook, "http://facebook.com/sharer.php?u={0}" },
            { SocialShareButtonType.Pinterest, "https://www.pinterest.com/pin/create/bookmarklet/?url={0}&media={2}&description={1}" }
        };

        public string Key { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class SocialShareBarViewModel
    {
        public List<SocialShareButton> ShareButtons { get; set; }

        public SocialShareBarViewModel(string pageUrl, string shareTitle = "", string shareImageUrl = "")
            : this(new SocialShareButtonType[] { SocialShareButtonType.Facebook, SocialShareButtonType.Twitter, SocialShareButtonType.GooglePlus }, pageUrl, shareTitle, shareImageUrl)
        {

        }

        public SocialShareBarViewModel(IEnumerable<SocialShareButtonType> icons, string pageUrl, string shareTitle = "", string shareImageUrl = "")
        {
            ShareButtons = new List<SocialShareButton>();

            foreach (SocialShareButtonType icon in icons)
            {
                SocialShareButton button = new SocialShareButton() { Key = icon.ToString().ToLower(), Name = icon.ToString() };
                string urlStringFormat = SocialShareButton.URL_FORMAT_DEFAULTS[icon];
                button.Url = string.Format(urlStringFormat, pageUrl, shareTitle, shareImageUrl);
            }
        }
    }
}
