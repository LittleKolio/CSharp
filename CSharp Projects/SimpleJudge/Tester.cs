namespace SimpleJudge
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Tester
    {
        private static string mismatchFormat = "Mismatch at line {0} -- expected: \"{1}\", actual: \"{2}\"";
        private static bool mismatchBool = false;
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteOneLineMessage("Reading files...");
            string mismatchPath = GetMismatchPath(expectedOutputPath);

            string[] userOutput = File.ReadAllLines(userOutputPath);
            string[] expectedOutput = File.ReadAllLines(expectedOutputPath);

            StringBuilder sb = new StringBuilder();

            int count = Math.Max(userOutput.Length, expectedOutput.Length);

            for (int i = 0; i < count; i++)
            {
                string input = userOutput[i];
                string compareWith = expectedOutput[i];

                if (!input.Equals(compareWith))
                {
                    sb.AppendLine(string.Format(
                        mismatchFormat, (i + 1), input, compareWith));
                }
            }

            //if (userOutput.Length > expectedOutput.Length)
            //{

            //}

            //if (userOutput.Length < expectedOutput.Length)
            //{

            //}

            if (sb.Length > 0)
            {
                File.WriteAllText(mismatchPath, sb.ToString());
            }
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int lastIndex = expectedOutputPath.LastIndexOf('\\');
            string path = expectedOutputPath.Substring(0, lastIndex);
            string mismatchPath = path + @"\Mismatches.txt";
            return mismatchPath;
        }
    }
}
