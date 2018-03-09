namespace BashSoft.IO
{
    using System;
    using System.IO;

    public static class CustomPath
    {
        public static string CurrentPath = Directory.GetCurrentDirectory();

        public static void ParenetOfCurrentPath(int step)
        {
            for (int i = 0; i < step; i++)
            {
                CurrentPath = Directory
                    .GetParent(CurrentPath)
                    .ToString();
            }
        }

        public static void ChangePath(string newPath)
        {
            CurrentPath = newPath;
        }

        public static string PathForMismatches(string fileTwoPath)
        {
            int lastIndex = fileTwoPath.LastIndexOf('\\');
            string path = fileTwoPath.Substring(0, lastIndex);
            string mismatchPath = path + @"\Mismatches.txt";
            return mismatchPath;
        }
    }
}
