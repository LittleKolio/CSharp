using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Lab
{
    class Lab_08_Extract_Quotations
    {
        static void Main()
        {
            string pattern = "('|\")(.+?)\\1";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }
        }
    }
}
