using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Lab
{
    class Lab_01_Match_Count
    {
        static void Main()
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            Console.WriteLine($"{matches.Count}");
        }
    }
}
