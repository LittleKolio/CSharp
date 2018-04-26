namespace BashSoft_OOP.Interface
{
    public interface IFilesystemManager
    {
        string CurrentDirectory { get; }

        void ChangeDirectory(string path);

        void ChangeDirectoryByRelativePath(string path);

        void CreateDirectory(string directoryName);

        string CreateTextFile(string fileName, string extension);
    }
}