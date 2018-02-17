namespace BashSoft2.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public static class IOManager
    {
        /// <summary>
        /// Breadth-first traversal using Queue of string. No DirectoryInfo!
        /// </summary>
        /// <remarks>
        /// It is too time-consuming to test every folder to determine
        /// whether wee have permision to open it. Therefore, just enclose
        /// that part of the code in try/catch block.
        /// </remarks>
        /// <param name="path"></param>
        public static void TraversingCurrentDirectory(int down = 3)
        {
            string path = SessionData.currentFolder;

            //I dont no witch is the fastest way to iterate through characters in string!
            //int indentation = Regex.Matches(path, "\\").Count;
            //int indentation = path.Split('\\').Length;
            int initialDepth = path.Count(c => c == '\\');

            Queue<string> fileSystem = new Queue<string>();
            fileSystem.Enqueue(path);
            
            while (fileSystem.Count != 0)
            {
                string currentPath = fileSystem.Dequeue();
                int offsetFromInitialDepth = currentPath.Count(c => c == '\\') - initialDepth;
                if (offsetFromInitialDepth >= down)
                {
                    break;
                }

                string offsetString = new string('\u2500', offsetFromInitialDepth) + '\u2524';
                OutputWriter.WriteOneLineMessage(offsetFromInitialDepth + offsetString + currentPath);

                string[] directories = null;
                try
                {
                    directories = Directory.GetDirectories(currentPath);
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.WriteOneLineMessage(
                        ExceptionMessages.folder_DontHaveAccess);
                    continue;
                }
                // This will happen if current Dir has been deleted by
                // another application or thread after our call to Directory.
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.WriteOneLineMessage(
                        ExceptionMessages.folder_DoseNotExist);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = Directory.GetFiles(currentPath);
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.WriteOneLineMessage(
                        ExceptionMessages.file_DontHaveAccess);
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.WriteOneLineMessage(
                        ExceptionMessages.folder_DoseNotExist);
                    continue;
                }

                foreach (string folder in directories)
                {
                    //offsetString = new string(' ', offsetFromInitialDepth + 1) + "\u2514\u2500\\";
                    //OutputWriter.WriteOneLineMessage(offsetString +
                    //    ExtractNameFromPath(folder));
                    fileSystem.Enqueue(folder);
                }

                foreach (string file in files)
                {
                    //try
                    //{
                    //    FileInfo info = new FileInfo(file);
                    //    offsetString = new string(' ', offsetFromInitialDepth + 1) + "\u2514\u2500";
                    //    OutputWriter.WriteOneLineMessage(offsetString + info.Name);
                    //}
                    //catch (FileNotFoundException)
                    //{
                    //    OutputWriter.WriteOneLineMessage(
                    //        ExceptionMessages.file_DoseNotExist);
                    //    continue;
                    //}

                    offsetString = new string(' ', offsetFromInitialDepth + 1) + "\u251C\u2500";
                    OutputWriter.WriteOneLineMessage(offsetString +
                        ExtractNameFromPath(file));
                }
            }
        }

        private static string ExtractNameFromPath(string path)
        {
            int index = path.LastIndexOf('\\');
            return path.Substring(index + 1);
        }
    }
}
