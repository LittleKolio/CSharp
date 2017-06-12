using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Exercises
{
    class Exercises_07_Valid_Usernames
    {
        private const string pattern = "^[a-zA-Z]\\w{2,24}$";
        static void Main()
        {
            Regex regex = new Regex(pattern);

            string[] names = Console.ReadLine()
                .Split(new[] { ' ', '/', '\\', '(', ')' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Where(n => regex.Match(n).Success)
                .ToArray();

            string firstName = names[0];
            string secondName = names[1];
            int maxSum = firstName.Length + secondName.Length;

            for (int n = 1; n < names.Length - 1; n++)
            {
                int length = names[n].Length + names[n + 1].Length;
                if (maxSum < length)
                {
                    firstName = names[n];
                    secondName = names[n + 1];
                    maxSum = length;
                }
            }

            Console.WriteLine(firstName);
            Console.WriteLine(secondName);
        }
    }
}
