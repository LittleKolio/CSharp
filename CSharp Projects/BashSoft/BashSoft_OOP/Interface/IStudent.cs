namespace BashSoft_OOP.Interface
{
    using System.Collections.Generic;

    public interface IStudent
    {
        string Name { get; }

        IReadOnlyDictionary<string, ICourse> Courses { get; }

        IReadOnlyDictionary<string, List<int>> TestScorByCourse { get; }

        void EnrollInCourse(ICourse course);

        void AddTestScorByCourse(string courseName, params int[] scores);
    }
}