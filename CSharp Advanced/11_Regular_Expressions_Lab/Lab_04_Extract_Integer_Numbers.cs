using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Lab
{
    class Lab_04_Extract_Integer_Numbers
    {
        static void Main()
        {
            string text = Console.ReadLine();

            Regex regex = new Regex("\\d+");
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
