namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tester
    {
        public void CompareContent(
            string userOutputPath, string expectedOutputPath)
        {
            if (!ValidatePath(userOutputPath))
            {
                return;
            }
            if (!ValidatePath(expectedOutputPath))
            {
                return;
            }

            Console.WriteLine("Reading files...");

            string[] userOutputLines = File.ReadAllLines(userOutputPath);
            string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

            string mismatchPath = GetMismatchPath(expectedOutputPath);
            bool isMismatch;
            string[] mismatches = GetMismates(
                userOutputLines, expectedOutputLines, out isMismatch);

            PrintMismatches(mismatches, isMismatch, mismatchPath);

            Console.WriteLine("Files readed");
        }

        private bool ValidatePath(string filePath)
        {
            bool exists = File.Exists(filePath);
            if (!exists)
            {
                Console.WriteLine(
                    string.Format(ExceptionMessages.file_DoseNotExist, filePath));
            }
            return exists;
        }

        private void PrintMismatches(
            string[] mismatches, bool isMismatch, string mismatchPath)
        {
            if (isMismatch)
            {
                foreach (string line in mismatches)
                {
                    Console.WriteLine(line);
                }

                try
                {
                    File.WriteAllLines(mismatchPath, mismatches);
                }
                catch
                {
                    Console.WriteLine(
                        ExceptionMessages.file_ForbiddenSymbols);
                }
            }
            else
            {
                Console.WriteLine(
                    "Files are identical. There are no mismatches.");
            }
        }

        private string[] GetMismates(
            string[] userOutputLines, 
            string[] expectedOutputLines, 
            out bool isMismatch
            )
        {
            isMismatch = false;
            string[] mismatches = new string[userOutputLines.Length];
            Console.WriteLine("Comparing files...");

            for (int index = 0; index < userOutputLines.Length; index++)
            {
                string output = string.Empty;
                string userLine = userOutputLines[index];
                string expectedLine = expectedOutputLines[index];
                if (!userLine.Equals(expectedLine))
                {
                    isMismatch = true;
                    output = string.Format(ExceptionMessages.file_WriteMismatche,
                        index, expectedLine, userLine);
                }
                else
                {
                    output = string.Format("Line {0} -- {1}",
                        index, userLine);
                }
                //output += Environment.NewLine;
                mismatches[index] = output;
            }
            return mismatches;
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            return Path.Combine(
                Path.GetDirectoryName(expectedOutputPath), "Mismatches.txt");
        }
    }
}
