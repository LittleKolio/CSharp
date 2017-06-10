using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpAdvanced.RegularExpression
{
    class Lab07ValidTime
    {
        static void Main()
        {
            string pattern = "(0[0-9]|1[012]):([0-5][0-9]):([0-5][0-9]) [AP]M";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") { break; }

                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);

                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }
    }
}
