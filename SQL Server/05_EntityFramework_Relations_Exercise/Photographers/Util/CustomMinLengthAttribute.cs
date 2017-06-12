namespace Photographers.Util
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomMinLengthAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }

        public override bool IsValid(object value)
        {
            string tag = (string)value;
            if (tag.Length > this.MinLength) { return false; }
            return true;
            //return base.IsValid(value);
        }
    }
}
