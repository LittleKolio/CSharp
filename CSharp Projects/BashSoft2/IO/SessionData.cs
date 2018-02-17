namespace BashSoft2.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class SessionData
    {
        public static string currentFolder = Directory.GetCurrentDirectory();

        public static string ParenetOfCurrentFolder(int step)
        {
            string path = currentFolder;
            for (int i = 0; i < step; i++)
            {
                path = Directory
                    .GetParent(path)
                    .ToString();
            }
            return path;

            //int index = path.Length;
            //for (int i = 0; i < step; i++)
            //{
            //    index--;
            //    index = path.LastIndexOf('\\', index);
            //}
            //return path.Substring(0, index);
        }

        public static void ChangeCurrentFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                OutputWriter.WriteOneLineMessage(
                        ExceptionMessages.folder_DoseNotExist);
                return;
            }

            currentFolder = path;
        }

        public static string CreateDirectoryInCurrentFolder(string name)
        {
            string path = currentFolder + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch
            {
                OutputWriter.WriteOneLineMessage(
                    ExceptionMessages.folder_ForbiddenSymbols);
                return null;
            }

            return path;
        }

        public static string CreateTextFileInCurrentFolder(string name, string[] text)
        {
            string path = currentFolder + "\\" + name;
            try
            {
                File.WriteAllLines(path, text);
            }
            catch
            {
                OutputWriter.WriteOneLineMessage(
                    ExceptionMessages.file_ForbiddenSymbols);
                return null;
            }
            return path;
        }
    }
}
