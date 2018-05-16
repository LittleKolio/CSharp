namespace BashSoft_OOP
{
    using Models.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

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

        public string Name { get; }

        public int NumberOfExams { get; }

        public IReadOnlyList<IStudent> Students => this.students.Values.ToList();

        public void EnrollStudent(IStudent student)
        {
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