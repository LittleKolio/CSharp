namespace BashSoft_OOP.Repository.Interfaces
{
    public interface IProcessJsonFormat
    {
        void ReadCoursesFromFile(string coursesPath);

        void ReadStudentsFromFile(string studentsPath);
    }
}
