namespace BashSoft_OOP.Repository
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using Models.Interfaces;
    using StaticData;
    using System.Linq;
    using System.Text;

    public class CoursesRepository : IRepository
    {
        private Dictionary<string, ICourse> courses;

        public CoursesRepository()
        {
            this.courses = new Dictionary<string, ICourse>();
        }

        public IReadOnlyList<ICourse> Courses =>  this.courses.Values.ToList();

        public int Count => this.courses.Count;

        public void AddCourse(ICourse course)
        {
            string courseName = course.Name;

            if (!this.courses.ContainsKey(courseName))
            {
                this.courses.Add(courseName, course);
            }
        }

        public void RemoveCourse(string courseName)
        {
            if (!this.courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Cours_NotExist, courseName));
            }

            this.courses.Remove(courseName);
        }

        public ICourse GetCourse(string courseName)
        {
            if (!this.courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Cours_NotExist, courseName));
            }

            return this.courses[courseName];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ICourse course in this.courses.Values)
            {
                sb.AppendLine(course.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
