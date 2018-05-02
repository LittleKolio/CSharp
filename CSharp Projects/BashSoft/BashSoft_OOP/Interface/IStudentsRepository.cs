namespace BashSoft_OOP.Interface
{
    using System.Collections.Generic;

    public interface IStudentsRepository
    {
        IReadOnlyDictionary<string, ICourse> Courses { get; }

        ICourse GetCourse(string courseName);

        void ReadDataFromConsole();

        void ReadDataFromFile(string path);
    }
}