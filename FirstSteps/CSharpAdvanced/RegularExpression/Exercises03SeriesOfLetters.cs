using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpAdvanced.RegularExpression
{
    class Exercises03SeriesOfLetters
    {
        private const string pattern = "(\\w)\\1+";

        static void Main()
        {
            string input = Console.ReadLine();

            string result = Regex.Replace(input, pattern, m => m.Groups[1].Value);

            Console.WriteLine(result);
        }
    }
}
