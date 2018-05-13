namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using Newtonsoft.Json;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Course : ICourse
    {
        public const int maxScoreOnExam = 100;

        private Dictionary<string, IStudent> students;

        public Course(string name, int numberOfExams)
        {
            this.Name = name;
            this.NumberOfExams = numberOfExams;
            this.students = new Dictionary<string, IStudent>();
        }

        [JsonProperty("course")]
        public string Name { get; }

        [JsonProperty("exams")]
        public int NumberOfExams { get; }

        public IReadOnlyDictionary<string, IStudent> Students => this.students;

        public void EnrollStudent(IStudent student)
        {
            //if (students.ContainsKey(student.Name))
            //{
            //    throw new InvalidOperationException(string.Format(
            //        ExceptionMessages.data_Student_InCourse, student.Name, this.Name));
            //}

            if (!students.ContainsKey(student.Name))
            {
                this.students.Add(student.Name, student);
            }
        }

        public override string ToString()
        {
            return $" Course: {this.Name}";
        }
    }
}