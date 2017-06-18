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
            List<string[]> students = new List<string[]>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end") { break; }

                string[] temp = Regex.Split(input, @"(?<!\d)\s");
                if (Regex.IsMatch(temp[2], "6"))
                {
                    students.Add(new string[]
                        {
                            temp[0],
                            temp[1]
                        });
                }
            }

            students.ForEach(stu => Console.WriteLine(string.Join(" ", stu)));
        }
    }
}
