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

        public static void CreateDirectory(string folderName)
        {
            string path = CurrentPath + "\\" + folderName;

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                OutputWriter.WriteExeption(
                    CustomMessages.NotAllowedCharacters);
            }
        }

        public static void ChangePath(string newPath)
        {
            CurrentPath = newPath;
        }
    }
}
