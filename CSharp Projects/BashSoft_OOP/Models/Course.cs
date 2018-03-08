namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int numberOfTasksOnExam = 5;
        private const int maxScoreOnExam = 5;

        private string name;
        private Dictionary<string, Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new Dictionary<string, Student>();
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

        public void EnrollStudent(Student student)
        {
            if (students.ContainsKey(student.Name))
            {
                OutputWriter.WriteException(string.Format(
                    ExceptionMessages.data_Student_InCourse, student.Name, this.Name));
                return;
            }
            this.students.Add(student.Name, student);
        }
    }
}
