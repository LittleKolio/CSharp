namespace BashSoft_OOP
{
    using StaticData;
    using Models.Interfaces;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course : ICourse
    {
        private Dictionary<string, IStudent> students;

        public Course(string name, int numberOfExams = Constants.Course_NumberOfExams)
        {
            this.Name = name;
            this.NumberOfExams = numberOfExams;
            this.students = new Dictionary<string, IStudent>();
        }

        public string Name { get; }

        public int NumberOfExams { get; }

        public IReadOnlyList<IStudent> Students => this.students.Values.ToList();

        public void AddStudent(IStudent student)
        {
            if (!students.ContainsKey(student.Name))
            {
                this.students.Add(student.Name, student);
            }
        }

        public void RemoveStudent(string studentName)
        {
            if (!this.students.ContainsKey(studentName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, studentName));
            }

            this.students.Remove(studentName);
        }

        public IStudent GetStudent(string studentName)
        {
            if (!this.students.ContainsKey(studentName))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NotInCourse, studentName));
            }

            return this.students[studentName];
        }

        public override string ToString()
        {
            return $" Course: {this.Name}";
        }
    }
}