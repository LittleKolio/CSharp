namespace StudentSystem.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data;
    using Models;
    using Util;
    using System.Drawing;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "StudentSystem.Data.StudentSystemContext";
        }

        protected override void Seed(StudentSystemContext context)
        {
            #region Courses
            var courses = new List<Course>();
            courses.Add(new Course()
            {
                //Id = 1,
                Name = "Data",
                Description = "Database",
                StartDate = new DateTime(2010, 1, 1),
                EndDate = new DateTime(2010, 6, 1),
                Price = 123.34m,
            });
            courses.Add(new Course()
            {
                //Id = courses.Count + 1,
                Name = "Bank",
                Description = "Bank System",
                StartDate = new DateTime(2020, 1, 1),
                EndDate = new DateTime(2020, 6, 1),
                Price = 456.09m,
            });
            courses.Add(new Course()
            {
                //Id = courses.Count + 1,
                Name = "Work",
                Description = "Bank System",
                StartDate = new DateTime(2020, 1, 1),
                EndDate = new DateTime(2020, 6, 1),
                Price = 456.09m,
            });
            foreach (var c in courses)
            {
                context.Courses.AddOrUpdate(a => a.Name, c);
            }
            context.SaveChanges();
            #endregion

            #region Students
            var students = new List<Student>();
            students.Add(new Student()
            {
                //Id = 1,
                Name = "A",
                PhoneNumber = "(544) 681248616",
                RegistratiOn = new DateTime(2000, 1, 1),
                //BirthDay = new DateTime(1900, 1, 1),
            });
            students.Add(new Student()
            {
                //Id = students.Count + 1,
                Name = "B",
                //PhoneNumber = "(4) 86702",
                RegistratiOn = new DateTime(2001, 1, 1),
                BirthDay = new DateTime(1901, 1, 1),
            });
            foreach (var s in students)
            {
                context.Students.AddOrUpdate(a => a.Name, s);
            }
            context.SaveChanges();
            #endregion

            #region Add Courses
            var coursesForStudent_1 = new List<Course>()
            {
                context.Courses.Where(c => c.Name == "Data").FirstOrDefault()
            };
            foreach (var cs in coursesForStudent_1)
            {
                try { context.Students.Find(1).Courses.Add(cs); }
                catch { continue; }
            }

            var coursesForStudent_2 = context.Courses.ToList();
            foreach (var cs in coursesForStudent_2)
            {
                try { context.Students.Find(2).Courses.Add(cs); }
                catch { continue; }
            }

            context.SaveChanges();
            #endregion

            #region Homeworks
            var homeworks = new List<Homework>();
            homeworks.Add(
                new Homework()
                {
                    //Id = 1,
                    Content = Util.insertFile("../../Files/celsius h720.pdf"),
                    ContentName = "celsius h720",
                    ContentType = ContentType.pdf,
                    SubmissionDate = new DateTime(2020, 5, 1),
                    CourseId = context.Courses.Where(c => c.Name == "Data").FirstOrDefault().Id,
                    StudentId = context.Students.Where(s => s.Name == "A").FirstOrDefault().Id
                }
            );
            homeworks.Add(
                new Homework()
                {
                    //Id = homeworks.Count + 1,
                    Content = Util.insertFile("../../Files/thinkpad w520.pdf"),
                    ContentName = "thinkpad w520",
                    ContentType = ContentType.pdf,
                    SubmissionDate = new DateTime(2010, 5, 1),
                    CourseId = context.Courses.Where(c => c.Name == "Bank").FirstOrDefault().Id,
                    StudentId = context.Students.Where(s => s.Name == "B").FirstOrDefault().Id
                }
            );
            foreach (var h in homeworks)
            {
                context.Homeworks.AddOrUpdate(a => a.ContentName, h);
            }
            context.SaveChanges();
            #endregion
        }
    }
}
