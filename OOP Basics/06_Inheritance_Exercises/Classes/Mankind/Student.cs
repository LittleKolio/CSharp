using System;
using System.Linq;

class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber) 
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (value.Length < 5 || 10 < value.Length || 
                !value.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException(
                    "Invalid faculty number!");
            }
            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() +
            $"Faculty number: {this.FacultyNumber}";
    }
}
