namespace BashSoft_OOP.Models.Interfaces
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        int NumberOfExams { get; }

        IReadOnlyList<IStudent> Students { get; }

        void EnrollStudent(IStudent student);
    }
}