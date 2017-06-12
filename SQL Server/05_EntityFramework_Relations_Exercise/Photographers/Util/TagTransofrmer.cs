namespace Photographers.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TagTransofrmer
    {
        public static string Transofrmer(string value)
        {
            string tag = (string)value;
            if (!tag.StartsWith("#")) { tag = "#" + tag; }
            if (tag.Contains(" ")) { tag = tag.Replace(" ", string.Empty); }
            if (tag.Contains(@"\t")) { tag = tag.Replace(@"\t", string.Empty); }
            if (tag.Length > 20) { tag = tag.Substring(0, 20); }
            return tag;
        }
    }
}
