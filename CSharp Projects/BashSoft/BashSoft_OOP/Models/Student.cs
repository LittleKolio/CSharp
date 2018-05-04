namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
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

        public void AddTestScorsByCourse(string courseName, params int[] scores)
        {
            if (!this.Courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, this.Name, courseName));
            }

            if (!this.testScorsByCourse.ContainsKey(courseName))
            {
                this.testScorsByCourse.Add(courseName, new List<int>());
            }

            if (this.testScorsByCourse[courseName].Count == Course.numberOfTasksOnExam)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.data_Student_MaxNumberOfScores);
            }

            int numberOfScoreRequired = Course.numberOfTasksOnExam - this.testScorsByCourse[courseName].Count;

            if (scores.Length > numberOfScoreRequired)
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_InvalideNumberOfScores, numberOfScoreRequired, courseName));
            }

            this.testScorsByCourse[courseName].AddRange(scores);
        }

        public List<int> GetTestScorsByCourse(string courseName)
        {
            if (!this.Courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, this.Name, courseName));
            }

            return this.testScorsByCourse
                .FirstOrDefault(s => s.Key == courseName).Value;
        }

        public string CoursesToString(string courseName)
        {
            List<int> testScores = this.GetTestScorsByCourse(courseName);
            string testScoresToString = string.Join(" ", testScores);
            double average = testScores.Average();

            return $"Average: {average} ({testScoresToString})";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Student: {this.name}");

            foreach (ICourse course in this.courses.Values)
            {
                sb.Append($"    Course: {course.Name} / ")
                    .AppendLine(this.CoursesToString(course.Name));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
