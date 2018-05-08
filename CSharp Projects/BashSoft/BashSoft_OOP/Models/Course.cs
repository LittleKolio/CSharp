namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Course : ICourse
    {
        public const int numberOfTasksOnExam = 5;
        //public const int maxScoreOnExam = 100;

        private string name;
        private Dictionary<string, IStudent> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new Dictionary<string, IStudent>();
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