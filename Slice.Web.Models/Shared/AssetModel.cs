using System.Collections.Generic;

namespace Slice.Web.Models
{
    public class AssetModel
    {
        public List<string> IncludeCSSPaths { get; set; }
        public List<string> IncludeHeadJSPaths { get; set; }
        public List<string> IncludeTailJSPaths { get; set; }

        public AssetModel()
        {
            IncludeCSSPaths = new List<string>();
            IncludeHeadJSPaths = new List<string>();
            IncludeTailJSPaths = new List<string>();
        }

        public void AddCSSPath(string cssPath)
        {
            IncludeCSSPaths.Add(cssPath);
        }

        public void AddHeadJSPath(string jsPath)
        {
            IncludeHeadJSPaths.Add(jsPath);
        }

        public void AddTailJSPath(string jsPath)
        {
            IncludeTailJSPaths.Add(jsPath);
        }
    }
}