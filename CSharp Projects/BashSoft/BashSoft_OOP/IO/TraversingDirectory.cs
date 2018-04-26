namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class TraversingDirectory
    {
        private IWriter writer;

        public TraversingDirectory(IWriter writer)
        {
            this.writer = writer;
        }

        /// <summary>
        /// Breadth-first traversal using Queue<string>, no DirectoryInfo!
        /// </summary>
        /// <remarks>
        /// It is too time-consuming to test every folder to determine whether wee have permision to open it. Therefore, just enclose that part of the code in try/catch block.
        /// </remarks>
        public void Traversing(string path, int down = 3)
        {
            //I dont no witch is the fastest way to iterate through characters in string!
            //int indentation = Regex.Matches(path, "\\").Count;
            //int indentation = path.Split('\\').Length;

            int initialDepth = path.Count(c => c == '\\');
            
            Queue<string> fileSystem = new Queue<string>();
            fileSystem.Enqueue(path);

            while (fileSystem.Count != 0)
            {
                string currentPath = fileSystem.Dequeue();

                int offsetFromInitialDepth = currentPath
                    .Count(c => c == '\\') - initialDepth;

                if (offsetFromInitialDepth >= down)
                {
                    break;
                }

                string offsetString = new string(
                    '\u2500', offsetFromInitialDepth) + '\u2524';

                this.writer.WriteOneLineMessage(
                    offsetFromInitialDepth + offsetString + currentPath);

                string[] directories = null;
                try
                {
                    directories = Directory.GetDirectories(currentPath);
                }
                catch (UnauthorizedAccessException)
                {
                    this.writer.WriteException(
                        ExceptionMessages.dir_DontHaveAccess);
                    continue;
                }
                // This will happen if current Dir has been deleted by
                // another application or thread after our call to Directory.
                catch (DirectoryNotFoundException)
                {
                    this.writer.WriteException(
                        ExceptionMessages.dir_DoseNotExist);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = Directory.GetFiles(currentPath);
                }
                catch (UnauthorizedAccessException)
                {
                    this.writer.WriteException(
                        ExceptionMessages.file_DontHaveAccess);
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    this.writer.WriteException(
                        ExceptionMessages.dir_DoseNotExist);
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

                    string fileName = Path.GetFileName(file);

                    this.writer.WriteOneLineMessage(offsetString + fileName);
                }
            }
        }

        //public void OpenFileWithDefaultProgram(string name)
        //{
        //    string path = this.filesystemOperations.currentDirectory;

        //    string filePath = Path.Combine(path, name);

        //    if (!File.Exists(filePath))
        //    {
        //        this.writer.WriteException(
        //            string.Format(ExceptionMessages.file_DoseNotExist, name));
        //        return;
        //    }

        //    Process.Start(filePath);
        //}
    }
}
