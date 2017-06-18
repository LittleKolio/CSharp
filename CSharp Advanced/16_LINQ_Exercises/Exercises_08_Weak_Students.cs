using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LINQ_Exercises
{
    class Exercises_08_Weak_Students
    {
        static void Main()
        {
            /*
            List<string[]> students = new List<string[]>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end") { break; }

                string[] temp = Regex.Split(input, @"(?<!\d)\s");
                if (Regex.Matches(temp[2], "[23]").Count >= 2)
                {
                    students.Add(new string[]
                        {
                            temp[0],
                            temp[1]
                        });
                }
            }

            students.ForEach(stu => Console.WriteLine(string.Join(" ", stu)));
            */

            List<string[]> students = new List<string[]>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end") { break; }

                students.Add(input.Split(' '));
            }

            students
                .Where(str => 
                    str.Skip(2).Count(num => 
                        int.Parse(num) <= 3)
                    >= 2)
                .ToList()
                .ForEach(stu => 
                    Console.WriteLine(string.Join(" ", stu.Take(2))));
        }
    }
}
