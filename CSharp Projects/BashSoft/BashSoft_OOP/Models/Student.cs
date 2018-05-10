namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// One student is defined by name, courses he enrolled and test scores for the course.
    /// </summary>

    public class Student : IStudent
    {
        private Dictionary<string, ICourse> courses;
        private Dictionary<string, List<int>> testScoresByCourse;

        public Student(string name)
        {
            this.Name = name;
            this.courses = new Dictionary<string, ICourse>();
            this.testScoresByCourse = new Dictionary<string, List<int>>();
        }

        public string Name { get; }
        
        public IReadOnlyDictionary<string, ICourse> Courses => this.courses;

        public void EnrollInCourse(ICourse course)
        {
            //if (this.Courses.ContainsKey(course.Name))
            //{
            //    throw new InvalidOperationException(string.Format(
            //        ExceptionMessages.data_Student_InCourse, this.Name, course.Name));
            //}

            if (!this.Courses.ContainsKey(course.Name))
            {
                this.courses.Add(course.Name, course);
            }
        }

        public void AddTestScoresByCourse(string courseName, params int[] scores)
        {
            if (!this.Courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, this.Name, courseName));
            }

            if (!this.testScoresByCourse.ContainsKey(courseName))
            {
                this.testScoresByCourse.Add(courseName, new List<int>());
            }

            if (this.testScoresByCourse[courseName].Count == Course.numberOfTasksOnExam)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.data_Student_MaxNumberOfScores);
            }

            int numberOfScoreRequired = Course.numberOfTasksOnExam - this.testScoresByCourse[courseName].Count;

            if (scores.Length > numberOfScoreRequired)
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_InvalideNumberOfScores, numberOfScoreRequired, courseName));
            }

            this.testScoresByCourse[courseName].AddRange(scores);
        }

        public List<int> GetTestScoresByCourse(string courseName)
        {
            if (!this.Courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, this.Name, courseName));
            }

            return this.testScoresByCourse
                .FirstOrDefault(s => s.Key == courseName).Value;
        }

        public override string ToString()
        {
            return $" Student: {this.Name}";
        }
    }
}
