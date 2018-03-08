namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Student
    {
        private string name;
        private Dictionary<string, Course> courses;
        private Dictionary<string, double> testScorByCourse;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }
 
        public IDictionary<string, Course> Courses
        {
            get { return this.courses; }
        }

        public IDictionary<string, double> MyProperty
        {
            get { return this.testScorByCourse; }
        }

        public Student(string name)
        {
            this.Name = name;
            this.courses = new Dictionary<string, Course>();
            this.testScorByCourse = new Dictionary<string, double>();
        }

        public void EnrollInCourse(Course course)
        {
            if (this.courses.ContainsKey(course.Name))
            {
                OutputWriter.WriteException(string.Format(
                    ExceptionMessages.data_Student_InCourse, this.name, course.Name));
                return;
            }
            this.courses.Add(course.Name, course);
        }

        public void AddTestScorByCourse(string courseName, params int[] scores)
        {
            if (!courses.ContainsKey(courseName))
            {
                OutputWriter.WriteException(
                    ExceptionMessages.data_Student_NotInCourse);
                return;
            }

            if ()
            {

            }
        }
    }
}
