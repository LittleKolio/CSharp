namespace BashSoft_OOP.Interface
{
    using System.Collections.Generic;

    public interface IStudent
    {
        string Name { get; }

        IReadOnlyDictionary<string, ICourse> Courses { get; }

        List<int> GetTestScorsByCourse(string courseName);

        void EnrollInCourse(ICourse course);

        void AddTestScorsByCourse(string courseName, params int[] scores);

        string CoursesToString(string courseName);
    }
}