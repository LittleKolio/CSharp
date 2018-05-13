namespace BashSoft_OOP
{
    using Interface;
    using System;
    using System.Collections.Generic;

    public class StudentsRepository : IRepository
    {
        private Dictionary<string, ICourse> courses;

        public StudentsRepository()
        {
            this.courses = new Dictionary<string, ICourse>();
        }

        public IReadOnlyDictionary<string, ICourse> Courses =>  this.courses;

        public int Count => this.courses.Count;

        public void AddCourse(ICourse course)
        {
            string courseName = course.Name;

            if (this.courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Cours_Exist, courseName));
            }

            this.courses.Add(courseName, course);
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
    }
}
