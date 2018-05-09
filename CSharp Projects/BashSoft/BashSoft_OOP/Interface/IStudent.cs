namespace BashSoft_OOP.Interface
{
    using System.Collections.Generic;

    public interface IStudent
    {
        string Name { get; }

        IReadOnlyDictionary<string, ICourse> Courses { get; }

        List<int> GetTestScoresByCourse(string courseName);

        void EnrollInCourse(ICourse course);

        void AddTestScoresByCourse(string courseName, params int[] scores);
    }
}