namespace BashSoft_OOP.Repository.Interfaces
{
    using Models.Interfaces;
    using System.Collections.Generic;

    public interface IRepository
    {
        IReadOnlyDictionary<string, ICourse> Courses { get; }

        int Count { get; }

        void AddCourse(ICourse course);

        ICourse GetCourse(string courseName);
    }
}