using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LINQ_Exercises
{
    class Exercises_07_Excellent_Students
    {
        static void Main()
        {
            List<string[]> emails = new List<string[]>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                if (input[0].ToLower() == "end") { break; }

                if (Regex.IsMatch(input[2], "6"))
                {
                    emails.Add(new string[]
                        {
                            input[0],
                            input[1]
                        });
                }
            }

            emails.ForEach(email => Console.WriteLine(string.Join(" ", email)));
        }
    }
}
