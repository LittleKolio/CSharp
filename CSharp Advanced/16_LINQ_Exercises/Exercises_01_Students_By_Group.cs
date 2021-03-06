﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises
{
    class Exercises_01_Students_By_Group
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

                if (input[2] == "2")
                {
                    students.Add(new string[]
                        {
                            input[0],
                            input[1]
                        });
                }
            }

            students
                .OrderBy(stu => stu[0])
                .ToList()
                .ForEach(stu => 
                    Console.WriteLine(string.Join(" ", stu)));
        }
    }
}
