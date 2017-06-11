using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpAdvanced.RegularExpression
{
    class Exercises02MatchPhoneNumber
    {
        private const string pattern = "^\\+359(\\s|-)2\\1\\d{3}\\1\\d{4}$";

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
