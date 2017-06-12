using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Exercises
{
    class Exercises_08_Extract_Hyperlinks
    {
        private const string pattern =
            @"<a[^>]*href\s*=\s*" + 
            @"((?<href>[^<>'""\s]+)|" + 
            @"""(?<href>[^<>""]+)""|" + 
            @"'(?<href>[^<>']+)')";

        static void Main()
        {
            Regex regex = new Regex(pattern, RegexOptions.Multiline);

            StringBuilder text = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end") { break; }
                text.Append(input);
            }

            MatchCollection matches = regex.Matches(text.ToString());

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups["href"].Value);
            }
        }
    }
}
