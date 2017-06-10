using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpAdvanced.RegularExpression
{
    class Lab02VowelCount
    {
        static void Main()
        {
            string text = Console.ReadLine();

            Regex regex = new Regex("[aeiouy]", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(text);

            Console.WriteLine($"Vowels: {matches.Count}");
        }
    }
}
