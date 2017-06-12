using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Exercises
{
    class Exercises_03_Series_Of_Letters
    {
        private const string pattern = "(\\w)\\1+";

        static void Main()
        {
            string input = Console.ReadLine();

            //string result = Regex.Replace(input, pattern, 
            //    m => m.Groups[1].Value);
            string result = Regex.Replace(input, pattern, "$1");

            Console.WriteLine(result);
        }
    }
}
