namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Student
    {
        private string name;
        private Dictionary<string, Course> courses;
        private Dictionary<string, double> scorByCourse;

        public string Name
        {
            get { return this.name; }
            set
            {
                //if (string.IsNullOrEmpty(value))
                //{
                //    throw new ArgumentNullException();
                //}
                this.name = value;
            }
        }
        //public ReadOnlyCollection<Course> Courses
        //{
        //    get { return new ReadOnlyCollection<Course>(this.courses); }
        //}
        public IDictionary<string, Course> Courses
        {
            get { return this.courses; }
        }
        public IDictionary<string, double> MyProperty
        {
            get { return this.scorByCourse; }
        }

        public Student(string name)
        {
            this.Name = name;
            this.courses = new Dictionary<string, Course>();
            this.scorByCourse = new Dictionary<string, double>();
        }

        public void EnrollInCourse(Course course)
        {
            if (this.courses.ContainsKey(course.Name))
            {
                OutputWriter.WriteException(string.Format(
                    ExceptionMessages.data_AlreadyInCourse, this.name, course.Name));
                return;
            }
            this.courses.Add(course.Name, course);
        }

        public void AddScorByCourse(string courseName)
        {
            if (!courses.ContainsKey(courseName))
            {
                OutputWriter.WriteException(
                    ExceptionMessages.data_NotEnrolledInCourse);
                return;
            }

            if ()
            {

            }
        }
    }
}
