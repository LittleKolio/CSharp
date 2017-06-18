using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises
{
    class Exercises_03_Students_By_Age
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

                if (18 <= int.Parse(input[2]) && int.Parse(input[2]) <= 24)
                {
                    students.Add(new string[]
                    {
                        input[0],
                        input[1],
                        input[2]
                    });
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine(string.Join(" ", student));
            }
        }
    }
}
