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
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteOneLineMessage("Reading files...");
            string mismatchPath = GetMismatchPath(expectedOutputPath);

            string[] userOutput = File.ReadAllLines(userOutputPath);
            string[] expectedOutput = File.ReadAllLines(expectedOutputPath);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < userOutput.Length; i++)
            {
                string input = userOutput[i];
                string compareWith = userOutput[i];

                if ()
                {

                }
            }

        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int lastIndex = expectedOutputPath.LastIndexOf('\\');
            string path = expectedOutputPath.Substring(lastIndex);
            string mismatchPath = path + @"\Mismatches.txt";
            return mismatchPath;
        }
    }
}
