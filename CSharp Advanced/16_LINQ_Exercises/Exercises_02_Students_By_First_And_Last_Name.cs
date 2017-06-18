using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises
{
    class Exercises_02_Students_By_First_And_Last_Name
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
                .Where(stu => stu[1].CompareTo(stu[0]) == 1)
                .ToList()
                .ForEach(stu =>
                    Console.WriteLine(string.Join(" ", stu)));
        }
    }
}
