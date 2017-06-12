using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Lab
{
    class Lab_02_Vowel_Count
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
