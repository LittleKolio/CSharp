using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises
{
    class Exercises_09_Students_Enrolled_In_2014_Or_2015
    {
        static void Main()
        {
            List<string[]> students = new List<string[]>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end") { break; }

                students.Add(input.Split(' '));
            }

            //foreach (var stu in students)
            //{
            //    Console.WriteLine(stu[0].EndsWith("14"));
            //}

            students
                .Where(str =>
                    str[0].EndsWith("14") ||
                    str[0].EndsWith("15"))
                .ToList()
                .ForEach(stu =>
                    Console.WriteLine(string.Join(" ", stu.Skip(1))));
        }
    }
}
