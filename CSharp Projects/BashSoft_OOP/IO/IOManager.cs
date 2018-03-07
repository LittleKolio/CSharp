namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class IOManager
    {
        /// <summary>
        /// Breadth-first traversal using Queue<string>, no DirectoryInfo!
        /// </summary>
        /// <remarks>
        /// It is too time-consuming to test every folder to determine
        /// whether wee have permision to open it. Therefore, just enclose
        /// that part of the code in try/catch block.
        /// </remarks>
        /// <param name="path"></param>
        
        public void TraversingCurrentDirectory(int down = 3)
        {
            string path = FilesystemOperations.currentDirectory;

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

                string offsetString = new string(
                    '\u2500', offsetFromInitialDepth) + '\u2524';
                OutputWriter.WriteOneLineMessage(
                    offsetFromInitialDepth + offsetString + currentPath);

                string[] directories = null;
                try
                {
                    directories = Directory.GetDirectories(currentPath);
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.WriteException(
                        ExceptionMessages.dir_DontHaveAccess);
                    continue;
                }
                // This will happen if current Dir has been deleted by
                // another application or thread after our call to Directory.
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.WriteException(
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
                    OutputWriter.WriteException(
                        ExceptionMessages.file_DontHaveAccess);
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.WriteException(
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
                    OutputWriter.WriteOneLineMessage(offsetString + fileName);
                }
            }
        }

        public void OpenFileWithDefaultProgram(string name)
        {
            string path = FilesystemOperations.currentDirectory;

            string filePath = Path.Combine(path, name);
            if (!File.Exists(filePath))
            {
                OutputWriter.WriteException(
                    string.Format(ExceptionMessages.file_DoseNotExist, name));
                return;
            }
            Process.Start(filePath);
        }

        public void CompareTwoFiles(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteOneLineMessage("Reading files...");

            bool fileExist = true;
            if (!File.Exists(userOutputPath))
            {
                OutputWriter.WriteException(
                        string.Format(ExceptionMessages.file_DoseNotExist, userOutputPath));
                fileExist = false;
            }

            if (!File.Exists(expectedOutputPath))
            {
                OutputWriter.WriteException(
                        string.Format(ExceptionMessages.file_DoseNotExist, expectedOutputPath));
                fileExist = false;
            }

            if (!fileExist)
            {
                return;
            }

            string[] userOutputLines = File.ReadAllLines(userOutputPath);
            string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

            string mismatchPath = GetMismatchPath(expectedOutputPath);
            bool isMismatch;
            string[] mismatches = GetMismates(userOutputLines, expectedOutputLines, out isMismatch);

            PrintMismatches(mismatches, isMismatch, mismatchPath);
            OutputWriter.WriteOneLineMessage("Files readed");
        }

        private void PrintMismatches(string[] mismatches, bool isMismatch, string mismatchPath)
        {
            if (isMismatch)
            {
                foreach (string line in mismatches)
                {
                    OutputWriter.WriteOneLineMessage(line);
                }

                try
                {
                    File.WriteAllLines(mismatchPath, mismatches);
                }
                catch
                {
                    OutputWriter.WriteException(
                        ExceptionMessages.file_ForbiddenSymbols);
                }
            }
            else
            {
                OutputWriter.WriteOneLineMessage(
                    "Files are identical. There are no mismatches.");
            }
        }

        private string[] GetMismates(string[] userOutputLines, string[] expectedOutputLines, out bool isMismatch)
        {
            string formatForMismatch = "Mismatch at line {0} -- expected: \"{1}\", actual: \"{2}\"";
            isMismatch = false;
            string[] mismatches = new string[userOutputLines.Length];
            OutputWriter.WriteOneLineMessage("Comparing files...");

            for (int index = 0; index < userOutputLines.Length; index++)
            {
                string output = string.Empty;
                string userLine = userOutputLines[index];
                string expectedLine = expectedOutputLines[index];
                if (!userLine.Equals(expectedLine))
                {
                    isMismatch = true;
                    output = string.Format(formatForMismatch, index, expectedLine, userLine);
                }
                else
                {
                    output = userLine;
                }
                //output += Environment.NewLine;
                mismatches[index] = output;
            }
            return mismatches;
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            //Path Combine does not work with relative paths
            //string path = Path.Combine(directory,@"\Mismatches.txt");

            return Path.GetDirectoryName(expectedOutputPath) + @"\Mismatches.txt";
        }
    }
}
