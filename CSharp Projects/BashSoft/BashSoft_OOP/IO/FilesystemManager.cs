namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FilesystemManager : IFilesystemManager
    {
        private string currentDirectory;

        public FilesystemManager()
        {
            this.currentDirectory = Directory.GetCurrentDirectory();
        }

        public string CurrentDirectory => this.currentDirectory;

        //public static string ParenetOfCurrentFolder(int step)
        //{
        //    string path = currentDirectory;
        //    for (int i = 0; i < step; i++)
        //    {
        //        path = Directory.GetParent(path).ToString();
        //    }
        //    return path;
        //}

        public void ChangeDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new ArgumentException(
                        ExceptionMessages.dir_DoseNotExist);
            }
            this.currentDirectory = path;
        }

        public void ChangeDirectoryByRelativePath(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new ArgumentException(
                        ExceptionMessages.dir_DoseNotExist);
            }
            this.currentDirectory = Path.GetFullPath(
                Path.Combine(currentDirectory, path));
        }

        public void CreateDirectory(string directoryName)
        {
            string path = Path.Combine(currentDirectory, directoryName);
            try
            {
                Directory.CreateDirectory(path);
            }
            catch
            {
                throw new ArgumentException(
                    ExceptionMessages.dir_ForbiddenSymbols);
            }

            this.currentDirectory = path;
        }

        //public string CreateTextFile(string name, string[] text)
        //{
        //    string path = Path.Combine(currentDirectory, name);
        //    try
        //    {
        //        File.WriteAllLines(path, text);
        //    }
        //    catch
        //    {
        //        throw new ArgumentException(
        //            ExceptionMessages.file_ForbiddenSymbols);
        //    }
        //    return path;
        //}

        public string CreateTextFile(string fileName, string extension)
        {
            string path = Path.Combine(currentDirectory, fileName, extension);
            try
            {
                File.CreateText(path);
            }
            catch
            {
                throw new ArgumentException(
                    ExceptionMessages.file_ForbiddenSymbols);
            }
            return path;
        }
    }
}
