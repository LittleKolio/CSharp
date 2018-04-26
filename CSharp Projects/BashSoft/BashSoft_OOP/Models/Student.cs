namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Student : IStudent
    {
        private string name;
        private Dictionary<string, ICourse> courses;
        private Dictionary<string, List<int>> testScorByCourse;

        public Student(string name)
        {
            this.Name = name;
            this.courses = new Dictionary<string, ICourse>();
            this.testScorByCourse = new Dictionary<string, List<int>>();
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

        public IReadOnlyDictionary<string, List<int>> TestScorByCourse => this.testScorByCourse;

        public void EnrollInCourse(ICourse course)
        {
            if (this.Courses.ContainsKey(course.Name))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_InCourse, this.Name, course.Name));
            }
            this.courses.Add(course.Name, course);
        }

        public void AddTestScorByCourse(string courseName, params int[] scores)
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

            this.testScorByCourse.Add(courseName, new List<int>(scores));
        }

        //private double CalculateTestScore(int[] scores)
        //{
        //    double precentage = scores.Sum() / 
        //        (double)(Course.numberOfTasksOnExam * Course.maxScoreOnExam);
        //    double testScore = precentage * 4 + 2;
        //    return testScore;
        //}
    }
}
