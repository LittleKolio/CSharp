using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Exercises
{
    class Exercises_04_Replace_Tag
    {
        private const string pattern = "<a\\s*href=('|\")(.+)\\1>(\\w+)<\\/a>";

        //private const string pattern = "<a\\s*href=('|\")(?<href>.+)\\1>(?<text>\\w+)<\\/a>";
        //private const string format = "[URL href=\"{0}\"]{1}[/URL]";

        static void Main()
        {
            Regex regex = new Regex(pattern);

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end") { break; }

                //string tag = Regex.Replace(
                //    input, 
                //    pattern, 
                //    m => string.Format(
                //        format, 
                //        m.Groups["href"].Value, 
                //        m.Groups["text"].Value));

                string tag = Regex.Replace(input, pattern, 
                    "[URL href=\"$2\"]$3[/URL]");

                Console.WriteLine(tag);
            }
        }
    }
}
