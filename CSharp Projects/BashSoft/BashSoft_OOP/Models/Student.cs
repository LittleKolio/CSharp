namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// One student is defined by name, courses he enrolled and test scores for the course.
    /// </summary>

    public class Student : IStudent, IComparable<KeyValuePair<string, List<int>>>
    {
        private string name;
        private Dictionary<string, ICourse> courses;
        private Dictionary<string, List<int>> testScorsByCourse;

        public Student(string name)
        {
            this.Name = name;
            this.courses = new Dictionary<string, ICourse>();
            this.testScorsByCourse = new Dictionary<string, List<int>>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }
 
        public IReadOnlyDictionary<string, ICourse> Courses => this.courses;

        public void EnrollInCourse(ICourse course)
        {
            if (this.Courses.ContainsKey(course.Name))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_InCourse, this.Name, course.Name));
            }
            this.courses.Add(course.Name, course);
        }

        public void AddTestScorsByCourse(string courseName, params int[] scores)
        {
            if (!this.Courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, this.Name, courseName));
            }

            if (scores.Length > Course.numberOfTasksOnExam)
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.params_InvalidNumber, Course.numberOfTasksOnExam));
            }

            if (!this.testScorsByCourse.ContainsKey(courseName))
            {
                this.testScorsByCourse.Add(courseName, null);
            }

            this.testScorsByCourse[courseName] = new List<int>(scores);
        }

        public KeyValuePair<string, List<int>> TestScorsByCourse(string courseName)
        {
            if (!this.Courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, this.Name, courseName));
            }

            return this.testScorsByCourse.FirstOrDefault(s => s.Key == courseName);
        }

        public int CompareTo(KeyValuePair<string, List<int>> other)
        {
            double thisAverage = this.testScorsByCourse[other.Key].Average();
            double otherAverage = other.Value.Average();

            return thisAverage.CompareTo(otherAverage);
        }
    }
}
