namespace BashSoft_OOP.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IStudent
    {
        string Name { get; }

        Dictionary<string, List<int>> Courses { get; }

        List<int> GetTestScoresByCourse(string courseName);

        void AddCourse(ICourse course);

        void AddTestScoresByCourse(string courseName, params int[] scores);
    }
}