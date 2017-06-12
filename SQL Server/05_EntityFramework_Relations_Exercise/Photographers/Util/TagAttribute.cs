namespace Photographers.Util
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string tag = (string)value;
            bool isValid = Regex.IsMatch(tag, @"^#(\w{1,19})(?=[^\s\t]*)$");
            if (!isValid) { return false; }
            return true;
        }
    }
}
