using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Exercises
{
    class Exercises_09_Query_Mess
    {
        private static Dictionary<string, string> queryMess;
        private const string patternSpace = @"(%20|\+)+";

        static void Main()
        {

            while (true)
            {
                queryMess = new Dictionary<string, string>();

                string[] input = Console.ReadLine().Split('?');
                if (input[0].ToLower() == "end") { break; }

                if (input.Length > 1)
                {
                    CustomSplit(input[1]);
                }
                else
                {
                    CustomSplit(input[0]);
                }

                foreach (var item in queryMess)
                {
                    Console.Write($"{item.Key}=[{item.Value}]");
                }
                Console.WriteLine();
            }
        }

        private static void CustomSplit(string input)
        {
            Regex.Replace(input, patternSpace, " ")
                .Split('&')
                .Select(e => new string[]
                {
                    e.Split('=')[0].Trim(),
                    e.Split('=')[1].Trim()
                })
                .ToList()
                .ForEach(e =>
                {
                    if (!queryMess.ContainsKey(e[0]))
                    {
                        queryMess.Add(e[0], e[1]);
                    }
                    else
                    {
                        queryMess[e[0]] += ", " + e[1];
                    }
                });
        }
    }
}
