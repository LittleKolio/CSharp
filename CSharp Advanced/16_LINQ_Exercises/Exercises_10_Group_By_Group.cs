using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises
{
    public class Person
    {
        public string Name { get; set; }
        public int Group { get; set; }
    }
    class Exercises_10_Group_By_Group
    {
        static void Main()
        {
            List<Person> students = new List<Person>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                if (input[0].ToLower() == "end") { break; }

                students.Add(new Person
                {
                    Name = string.Join(" ", input.Take(2)),
                    Group = int.Parse(input[2])
                });
            }

            students
                .GroupBy(stu => stu.Group)
                .OrderBy(group => group.Key)
                .Select(group => new
                {
                    Group = group.Key,
                    Students = group
                        .Select(stu => stu.Name)
                        .ToList()
                })
                .ToList()
                .ForEach(obj => 
                    Console.WriteLine(
                        "{0} - {1}", 
                        obj.Group, 
                        string.Join(", ", obj.Students)));

        }
    }
}
