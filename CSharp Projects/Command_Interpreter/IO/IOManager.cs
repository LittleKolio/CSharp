namespace Command_Interpreter.IO
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
        /// Breadth-first traversal using Queue of string.
        /// No DirectoryInfo!
        /// No dept limit!
        /// </summary>
        /// <remarks>
        /// It is too time-consuming to test every folder to determine
        /// whether wee have permision to open it. Therefore, just enclose
        /// that part of the code in try/catch block.
        /// </remarks>
        /// <param name="path"></param>
        public static void TraversingFileSystem(string path)
        {
            //I dont no witch is the fastest way to iterate through characters in string!
            //int indentation = Regex.Matches(path, "\\").Count;
            //int indentation = path.Split('\\').Length;
            int initialDepth = path.Count(c => c == '\\');

            Queue<string> fileSystem = new Queue<string>();

            if (!Directory.Exists(path))
            {
                throw new ArgumentException();
            }
            fileSystem.Enqueue(path);
            
            while (fileSystem.Count != 0)
            {
                string currentPath = fileSystem.Dequeue();
                int offset = currentPath.Count(c => c == '\\') - initialDepth;
                string offsetString = '\u251C' + new string('\u2500', offset);

                OutputWriter.WriteOneLineMessage(offsetString + currentPath);

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
                catch (UnauthorizedAccessException ex)
                {
                    OutputWriter.WriteOneLineMessage(
                        ExceptionMessages.file_DontHaveAccess);
                    continue;
                }
                catch (DirectoryNotFoundException ex)
                {
                    OutputWriter.WriteOneLineMessage(
                        ExceptionMessages.folder_DoseNotExist);
                    continue;
                }

                foreach (string folder in directories)
                {
                    fileSystem.Enqueue(folder);
                }

                foreach (string file in files)
                {
                    try
                    {
                        FileInfo info = new FileInfo(file);
                        offsetString = new string(' ', offset + 1) + "\u2514\u2500";
                        OutputWriter.WriteOneLineMessage(offsetString + info.Name);
                    }
                    catch (FileNotFoundException ex)
                    {
                        OutputWriter.WriteOneLineMessage(
                            ExceptionMessages.file_DoseNotExist);
                        continue;
                    }
                }

            }
        }
    }
}
