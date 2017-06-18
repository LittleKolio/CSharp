using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises
{
    class Exercises_04_Sort_Students
    {
        static void Main()
        {
            List<string[]> students = new List<string[]>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                if (input[0].ToLower() == "end") { break; }

                students.Add(new string[]
                {
                    input[0],
                    input[1]
                });
            }

            students
                .OrderBy(stu => stu[1])
                .ThenByDescending(stu => stu[0])
                .ToList()
                .ForEach(stu => Console.WriteLine(string.Join(" ", stu)));
        }
    }
}
