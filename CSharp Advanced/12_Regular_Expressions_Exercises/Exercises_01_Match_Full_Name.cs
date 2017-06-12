using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Exercises
{
    class Exercises_01_Match_Full_Name
    {
        private const string pattern = "^\\b([A-Z][a-z]+)\\s([A-Z][a-z]+)\\b$";

        static void Main()
        {
            Regex regex = new Regex(pattern);

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end") { break; }

                Match match = regex.Match(input);

                if (match.Success)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
