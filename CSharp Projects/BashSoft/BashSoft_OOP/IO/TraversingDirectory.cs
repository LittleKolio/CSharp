namespace BashSoft_OOP.IO
{
    using Interfaces;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class TraversingDirectory : ITraverse
    {
        private IWriter writer;

        public TraversingDirectory(IWriter writer)
        {
            this.writer = writer;
        }

        /// <summary>
        /// Breadth-first traversal using Queue, no DirectoryInfo!
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

                int offsetFromInitialDepth = currentPath.Count(c => c == '\\') - initialDepth;

                if (offsetFromInitialDepth >= down)
                {
                    break;
                }

                string offsetString = new string('\u2500', offsetFromInitialDepth) + '\u2524';

                this.writer.WriteEmptyLine();
                this.writer.WriteMessage(offsetFromInitialDepth + offsetString + currentPath);

                string[] directories = this.GetDirectories(currentPath);

                //get files
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(currentPath);
                }
                catch (UnauthorizedAccessException)
                {
                    this.writer.WriteException(ExceptionMessages.file_DontHaveAccess);
                }
                catch (DirectoryNotFoundException)
                {
                    this.writer.WriteException(ExceptionMessages.dir_DoseNotExist);
                }

                //enqueue directories
                foreach (string folder in directories)
                {
                    fileSystem.Enqueue(folder);
                }

                //write files
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

                    this.writer.WriteMessage(offsetString + fileName);
                }
            }
        }

        private string[] GetDirectories(string currentPath)
        {
            string[] directories = null;
            try
            {
                directories = Directory.GetDirectories(currentPath);
            }
            catch (UnauthorizedAccessException)
            {
                this.writer.WriteException(ExceptionMessages.dir_DontHaveAccess);
            }

            // This will happen if current Dir has been deleted by
            // another application or thread after our call to Directory.
            catch (DirectoryNotFoundException)
            {
                this.writer.WriteException(ExceptionMessages.dir_DoseNotExist);
            }

            return directories;
        }
    }
}
