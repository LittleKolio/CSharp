namespace BashSoft_OOP
{
    using Models.Interfaces;
    using StaticData;
    //
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// One student is defined by name, courses he enrolled and test scores for the course.
    /// </summary>

    public class Student : IStudent
    {
        private class CourseInfo
        {
            public CourseInfo(ICourse course)
            {
                this.Course = course;
                this.TestScores = new List<int>();
            }

            public ICourse Course { get; set; }
            public List<int> TestScores { get; set; }
        }

        private Dictionary<string, CourseInfo> courses;

        public Student(string name)
        {
            this.Name = name;
            this.courses = new Dictionary<string, CourseInfo>();
        }

        public string Name { get; }

        public Dictionary<string, List<int>> Courses =>
            this.courses.Values
            .ToDictionary(s => s.Course.Name, s => s.TestScores);

        public void AddCourse(ICourse course)
        {
            if (!this.courses.ContainsKey(course.Name))
            {
                CourseInfo courseInfo = new CourseInfo(course);

                this.courses.Add(course.Name, courseInfo);
            }
        }

        public void AddTestScoresByCourse(string courseName, params int[] scores)
        {
            if (!this.courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, 
                    this.Name, courseName));
            }

            if (scores.Length > this.courses[courseName].Course.NumberOfExams)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.data_Student_NumberOfScores, 
                    this.courses[courseName].Course.NumberOfExams));
            }

            this.courses[courseName].TestScores = new List<int>(scores);
        }

        public List<int> GetTestScoresByCourse(string courseName)
        {
            if (!this.courses.ContainsKey(courseName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, this.Name, courseName));
            }

            return this.courses[courseName].TestScores;
        }

        public override string ToString()
        {
            return $" Student: {this.Name}";
        }
    }
}
