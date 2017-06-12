namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Util;
    using System.Data.Entity.Migrations;

    public class StudentSystemInitializer : DropCreateDatabaseAlways<StudentSystemContext>
    {
        protected override void Seed(StudentSystemContext context)
        {
            #region Courses
            var courses = new List<Course>();
            courses.Add(new Course
            {
                Name = "Data",
                Description = "Database",
                StartDate = new DateTime(2010, 1, 1),
                EndDate = new DateTime(2010, 6, 1),
                Price = 123.34m,
            });
            courses.Add(new Course
            {
                Name = "Bank",
                Description = "Bank System",
                StartDate = new DateTime(2020, 1, 1),
                EndDate = new DateTime(2020, 6, 1),
                Price = 456.09m,
            });
            courses.Add(new Course
            {
                Name = "Shop",
                Description = "Sell Scrap Machine",
                StartDate = new DateTime(2030, 1, 1),
                EndDate = new DateTime(2030, 6, 1),
                Price = 456.09m,
            });

            context.Courses.AddRange(courses);
            context.SaveChanges();
            #endregion

            #region Students
            var students = new List<Student>();
            students.Add(new Student()
            {
                Name = "A",
                PhoneNumber = "(544) 681248616",
                RegistratiOn = new DateTime(2000, 1, 1)
                //BirthDay = new DateTime(1900, 1, 1),
            });
            students.Add(new Student()
            {
                Name = "B",
                //PhoneNumber = "(4) 86702",
                RegistratiOn = new DateTime(2001, 1, 1),
                BirthDay = new DateTime(1901, 1, 1)
            });
            students.Add(new Student()
            {
                Name = "C",
                //PhoneNumber = "(4) 86702",
                RegistratiOn = new DateTime(1991, 1, 1),
                BirthDay = new DateTime(1891, 1, 1)
            });
            students.Add(new Student()
            {
                Name = "D",
                PhoneNumber = "(454352) 45675634",
                RegistratiOn = new DateTime(2011, 1, 1),
                BirthDay = new DateTime(1991, 1, 1)
            });
            context.Students.AddRange(students);
            context.SaveChanges();
            #endregion

            #region Homeworks
            var homeworks = new List<Homework>();
            homeworks.Add(
                new Homework()
                {
                    Content = Util.insertFile("../../Files/celsius h720.pdf"),
                    ContentType = ContentType.pdf,
                    SubmissionDate = new DateTime(2020, 5, 1),
                    CourseId = context.Courses.Where(c => c.Name == "Data").FirstOrDefault().Id,
                    StudentId = context.Students.Where(s => s.Name == "A").FirstOrDefault().Id
                }
            );
            homeworks.Add(
                new Homework()
                {
                    Content = Util.insertFile("../../Files/thinkpad w520.pdf"),
                    ContentType = ContentType.pdf,
                    SubmissionDate = new DateTime(2010, 5, 1),
                    CourseId = context.Courses.Where(c => c.Name == "Bank").FirstOrDefault().Id,
                    StudentId = context.Students.Where(s => s.Name == "B").FirstOrDefault().Id
                }
            );
            context.Homeworks.AddRange(homeworks);
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }
    }
}
