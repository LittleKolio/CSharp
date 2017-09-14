namespace SimpleJudge
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteOneLineMessage("Reading files...");
            string mismatchPath = GetMismatchPath(expectedOutputPath);

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
