namespace BashSoft_OOP.Models.Interfaces
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        int NumberOfExams { get; }

        IReadOnlyList<IStudent> Students { get; }

        void AddStudent(IStudent student);

        void RemoveStudent(string studentName);

        IStudent GetStudent(string studentName);
    }
}