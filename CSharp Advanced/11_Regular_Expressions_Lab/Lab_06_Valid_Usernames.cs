using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Lab
{
    class Lab_06_Valid_Usernames
    {
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") { break; }

                Regex regex = new Regex("^[\\w-]{3,16}$");
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
