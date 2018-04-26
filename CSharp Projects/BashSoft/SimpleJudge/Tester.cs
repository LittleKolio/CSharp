namespace SimpleJudge
{
    using System;
    using System.IO;

    public static class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            Console.WriteLine("Reading files...");
            if (!File.Exists(userOutputPath) || !File.Exists(expectedOutputPath))
            {
                throw new ArgumentException();
            }
            
            string[] userOutputLines = File.ReadAllLines(userOutputPath);
            string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

            string mismatchPath = GetMismatchPath(expectedOutputPath);
            bool isMismatch;
            string[] mismatches = GetMismates(userOutputLines, expectedOutputLines, out isMismatch);

            PrintMismatches(mismatches, isMismatch, mismatchPath);
            Console.WriteLine("Files readed");
        }

        private static void PrintMismatches(string[] mismatches, bool isMismatch, string mismatchPath)
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
                    Console.WriteLine("Forbidden Symbols!");
                }
            }
            else
            {
                Console.WriteLine(
                    "Files are identical. There are no mismatches.");
            }
        }

        private static string[] GetMismates(string[] userOutputLines, string[] expectedOutputLines, out bool isMismatch)
        {
            string formatForMismatch = "Mismatch at line {0} -- expected: \"{1}\", actual: \"{2}\"";
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

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int index = expectedOutputPath.LastIndexOf('\\');

            //Path Combine does not work with relative paths
            //string path = Path.Combine(directory,@"\Mismatches.txt");

            return expectedOutputPath.Substring(0, index) + @"\Mismatches.txt";
        }
    }
}
