using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises
{
    public class Speciality
    {
        public string Name { get; set; }
        public int FacultyNumber { get; set; }
    }
    public class Student
    {
        public string Name { get; set; }
        public int FacultyNumber { get; set; }
    }
    class Exercises_11_Students_Joined_To_Specialties
    {
        static void Main()
        {
            List<Speciality> specialities = new List<Speciality>();
            List<Student> students = new List<Student>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                if (input[0].ToLower() == "students:") { break; }

                specialities.Add(new Speciality
                {
                    Name = string.Join(" ", input.Take(2)),
                    FacultyNumber = int.Parse(input[2])
                });
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                if (input[0].ToLower() == "end") { break; }

                students.Add(new Student
                {
                    Name = string.Join(" ", input.Skip(1)),
                    FacultyNumber = int.Parse(input[0])
                });
            }

            students
                .OrderBy(stu => stu.Name)
                .Join(
                    specialities, 
                    stu => stu.FacultyNumber, 
                    spe => spe.FacultyNumber,
                    (stu, spe) => new
                        {
                            Name = stu.Name,
                            FacNum = stu.FacultyNumber,
                            Spec = spe.Name
                        })
                .ToList()
                .ForEach(stu => 
                    Console.WriteLine(
                        $"{stu.Name} {stu.FacNum} {stu.Spec}"));
        }
    }
}
