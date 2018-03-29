namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Student
    {
        private string name;
        private Dictionary<string, Course> courses;
        private Dictionary<string, double> testScorByCourse;

        public Student(string name)
        {
            this.Name = name;
            this.courses = new Dictionary<string, Course>();
            this.testScorByCourse = new Dictionary<string, double>();
        }

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
 
        public IDictionary<string, Course> Courses => this.courses;

        public IDictionary<string, double> TestScorByCourse => this.testScorByCourse;

        public void EnrollInCourse(Course course)
        {
            if (this.Courses.ContainsKey(course.Name))
            {
                OutputWriter.WriteException(string.Format(
                    ExceptionMessages.data_Student_InCourse, this.Name, course.Name));
                return;
            }
            this.Courses.Add(course.Name, course);
        }

        public void AddTestScorByCourse(string courseName, params int[] scores)
        {
            if (!this.Courses.ContainsKey(courseName))
            {
                OutputWriter.WriteException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, this.Name, courseName));
                return;
            }

            if (scores.Length > Course.numberOfTasksOnExam)
            {
                OutputWriter.WriteException(string.Format(
                    ExceptionMessages.params_InvalidNumber, Course.numberOfTasksOnExam));
                return;
            }

            this.TestScorByCourse.Add(courseName, CalculateTestScore(scores));
        }

        private double CalculateTestScore(int[] scores)
        {
            double precentage = scores.Sum() / 
                (double)(Course.numberOfTasksOnExam * Course.maxScoreOnExam);
            double testScore = precentage * 4 + 2;
            return testScore;
        }
    }
}
