using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpAdvanced.RegularExpression
{
    class Lab03NonDigitCount
    {
        static void Main()
        {
            string text = Console.ReadLine();

            Regex regex = new Regex("\\D");
            MatchCollection matches = regex.Matches(text);

            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}
