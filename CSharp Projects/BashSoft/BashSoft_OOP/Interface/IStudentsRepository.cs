namespace BashSoft_OOP.Interface
{
    using System.Collections.Generic;

    public interface IStudentsRepository
    {
        IReadOnlyDictionary<string, ICourse> Courses { get; }

        void ReadDataFromConsole();

        void ReadDataFromFile(string path);
    }
}