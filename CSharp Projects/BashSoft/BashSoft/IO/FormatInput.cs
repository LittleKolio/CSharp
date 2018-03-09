using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.IO
{
    public static class FormatInput
    {
        public static string[] SplitText(string input, string delimiter)
        {
            string[] result = input.Split(
                delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            return result;
        }
    }
}
