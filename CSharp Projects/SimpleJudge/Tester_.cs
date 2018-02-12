namespace SimpleJudge
{
    using BashSoft2.IO;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Tester_
    {
        private static string mismatchFormat 
            = "Mismatch at line {0} -- expected: \"{1}\", actual: \"{2}\"";

        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteOneLineMessage("Reading files...");
            StringBuilder sb = new StringBuilder();

            try
            {
                string[] userOutput = File.ReadAllLines(userOutputPath);
                string[] expectedOutput = File.ReadAllLines(expectedOutputPath);

                string mismatchPath = PathForMismatchFile(expectedOutputPath);

                int count = 0;

                if (userOutput.Length > expectedOutput.Length)
                {
                    OutputWriter.WriteOneLineMessage(
                        CustomMessages.FileHasMoreText);

                    count = userOutput.Length;
                }

                if (userOutput.Length < expectedOutput.Length)
                {
                    OutputWriter.WriteOneLineMessage(
                        CustomMessages.FileHasLessText);

                    count = expectedOutput.Length;
                }

                for (int i = 0; i < count; i++)
                {
                    string input = "none";
                    string compareWith = "none";

                    if (userOutput.Length > i) { input = userOutput[i]; }
                    if (expectedOutput.Length > i) { compareWith = expectedOutput[i]; }

                    if (!input.Equals(compareWith))
                    {
                        sb.AppendLine(string.Format(
                            mismatchFormat, (i + 1), input, compareWith));
                    }
                }

                if (sb.Length > 0)
                {
                    File.WriteAllText(mismatchPath, sb.ToString());
                }
                else if (sb.Length == 0)
                {
                    OutputWriter.WriteOneLineMessage(
                        CustomMessages.FilesAreIdentical);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                OutputWriter.WriteExeption(ex.Message);
            }
        }

        private static string PathForMismatchFile(string expectedOutputPath)
        {
            int lastIndex = expectedOutputPath.LastIndexOf('\\');
            string path = expectedOutputPath.Substring(0, lastIndex);
            string mismatchPath = path + @"\Mismatches.txt";
            return mismatchPath;
        }
    }
}
