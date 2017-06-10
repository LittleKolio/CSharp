using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpAdvanced.RegularExpression
{
    class Lab05ExtractTags
    {
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") { break; }

                Regex regex = new Regex("<.+?>");
                MatchCollection matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
